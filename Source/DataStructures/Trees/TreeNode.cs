/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of CSFundamentalAlgorithms project.
 *
 * CSFundamentalAlgorithms is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * CSFundamentalAlgorithms is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with CSFundamentals.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;

// TODO: I feel this can be simplified, no need to pass 3 parameters! the definition is recursive!

namespace CSFundamentals.DataStructures.Trees
{
    public abstract class TreeNode<T, T1, T2> : IEquatable<T>, ITreeNode<T, T1, T2> where T : ITreeNode<T, T1, T2> where T1 : IComparable<T1>, IEquatable<T1>
    {
        public T1 Key { get; set; }
        public T2 Value { get; set; }

        public TreeNode(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }

        public abstract T LeftChild { get; set; }
        public abstract T RightChild { get; set; }
        public abstract T Parent { get; set; }

        public bool IsLeaf()
        {
            if (LeftChild == null && RightChild == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if the node is the left child of its parent.
        /// </summary>
        /// <returns>True in case the node is the left child of its parent, and false otherwise.</returns>
        public bool IsLeftChild()
        {
            if (Parent == null) return false;
            if (Parent.LeftChild == null) return false;
            if (Parent.LeftChild.Key.CompareTo(Key) == 0) return true;
            return false;
        }

        /// <summary>
        /// Checks to see if the node is the right child of its parent. 
        /// </summary>
        /// <returns>True in case the node is the right child of its parent, and false if it is not.</returns>
        public bool IsRightChild()
        {
            if (Parent == null) return false;
            if (Parent.RightChild == null) return false;
            if (Parent.RightChild.Key.CompareTo(this.Key) == 0) return true;
            return false;
        }

        public bool IsRoot()
        {
            if (Parent == null) return true;
            return false;
        }

        public T GetUncle()
        {
            if (Parent == null) return default(T);
            if (Parent.Parent == null) return default(T);
            if (Parent.Parent.LeftChild != null && Parent.Parent.LeftChild.Key.CompareTo(Parent.Key) == 0)
            {
                return Parent.Parent.RightChild;
            }
            else if (Parent.Parent.RightChild != null && Parent.Parent.RightChild.Key.CompareTo(Parent.Key) == 0)
            {
                return Parent.Parent.LeftChild;
            }
            return default(T);
        }

        public T GetSibling()
        {
            if (Parent == null) return default(T);
            if (Parent.LeftChild != null && Parent.LeftChild.Equals(this))
                return Parent.RightChild;
            return Parent.LeftChild;
        }

        public T GetGrandParent()
        {
            if (Parent == null) return default(T);
            if (Parent.Parent == null) return default(T);
            return Parent.Parent;
        }

        public bool Equals(T other)
        {
            if (other == null) return false;
            if (Key.Equals(other.Key)) return true;
            return false;
        }

        /// <summary>
        /// Checks whether the node forms a line with its parent and grandparent. 
        /// Notice a line needs exactly 3 nodes. 
        /// </summary>
        public bool FormsLine()
        {
            if (Parent == null) return false;
            if (IsLeftChild() && Parent.IsLeftChild()) return true;
            if (IsRightChild() && Parent.IsRightChild()) return true;
            return false;
        }

        /// <summary>
        /// Checks whether the node forms a triangle with its parent and grandparent.
        /// Notice a triangle needs exactly 3 nodes.
        /// </summary>
        public bool FormsTriangle()
        {
            if (Parent == null) return false;
            if (IsLeftChild() && Parent.IsRightChild()) return true;
            if (IsRightChild() && Parent.IsLeftChild()) return true;
            return false;
        }

        //TODO if these methods are defined static, they are probably not in a good location, 
        public static List<List<T>> GetAllPathToNullLeaves(T startNode)
        {
            if (startNode == null)
            {
                return new List<List<T>>();
            }

            List<List<T>> paths = new List<List<T>>();
            List<List<T>> leftPaths = GetAllPathToNullLeaves(startNode.LeftChild);
            List<List<T>> rightPaths = GetAllPathToNullLeaves(startNode.RightChild);

            for (int i = 0; i < leftPaths.Count; i++)
            {
                var newPath = new List<T>();
                newPath.Add(startNode);
                newPath.AddRange(leftPaths[i]);
                paths.Add(newPath);
            }
            for (int i = 0; i < rightPaths.Count; i++)
            {
                var newPath = new List<T>();
                newPath.Add(startNode);
                newPath.AddRange(rightPaths[i]);
                paths.Add(newPath);
            }

            if (paths.Count == 0)
            {
                paths.Add(new List<T> { startNode });
            }

            return paths;
        }

        public static void InOrderTraversal(T root, List<T> inOrder)
        {
            if (root != null)
            {
                InOrderTraversal(root.LeftChild, inOrder);
                inOrder.Add(root);
                InOrderTraversal(root.RightChild, inOrder);
            }
        }
    }
}
