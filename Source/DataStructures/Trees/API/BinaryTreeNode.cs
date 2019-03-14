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

namespace CSFundamentals.DataStructures.Trees.API
{
    public abstract class BinaryTreeNode<T, T1, T2> : IComparable<T>, ITreeNode<T, T1, T2> where T : ITreeNode<T, T1, T2> where T1 : IComparable<T1>
    {
        public T1 Key { get; set; }
        public T2 Value { get; set; }

        public BinaryTreeNode(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }

        public abstract T LeftChild { get; set; }
        public abstract T RightChild { get; set; }
        public abstract T Parent { get; set; }

        /// <summary>
        /// Checks whether the current node is a leaf node. A node is leaf if it has no children. 
        /// </summary>
        /// <returns>True if the current node is leaf, and false otherwise. </returns>
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
        /// <returns>True in case the node is the right child of its parent, and false otherwise.</returns>
        public bool IsRightChild()
        {
            if (Parent == null) return false;
            if (Parent.RightChild == null) return false;
            if (Parent.RightChild.Key.CompareTo(Key) == 0) return true;
            return false;
        }

        /// <summary>
        /// Checks whether the current node is the root of the tree. A node is root if it has no parent. 
        /// </summary>
        /// <returns>True in case the current node is the root, and false otherwise.</returns>
        public bool IsRoot()
        {
            if (Parent == null) return true;
            return false;
        }

        /// <summary>
        /// Gets the uncle of the current node. Uncle is the sibling of the parent.
        /// </summary>
        /// <returns>Uncle node.</returns>
        public T GetUncle()
        {
            if (Parent == null) return default(T);
            if (Parent.Parent == null) return default(T);
            if (Parent.Parent.LeftChild != null && Parent.Parent.LeftChild.CompareTo(Parent) == 0)
            {
                return Parent.Parent.RightChild;
            }
            else if (Parent.Parent.RightChild != null && Parent.Parent.RightChild.CompareTo(Parent) == 0)
            {
                return Parent.Parent.LeftChild;
            }
            return default(T);
        }

        /// <summary>
        /// Gets the sibling of the current node.
        /// </summary>
        /// <returns>Sibling node.</returns>
        public T GetSibling()
        {
            if (Parent == null) return default(T);
            if (Parent.LeftChild != null && Parent.LeftChild.Key.CompareTo(Key) == 0)
                return Parent.RightChild;
            return Parent.LeftChild;
        }

        /// <summary>
        /// Gets the grandparent of the current node. GrandParent is the parent of the parent. 
        /// </summary>
        /// <returns></returns>
        public T GetGrandParent()
        {
            if (Parent == null) return default(T);
            if (Parent.Parent == null) return default(T);
            return Parent.Parent;
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

        public int CompareTo(T other)
        {
            return Key.CompareTo(other.Key);
        }

        // TODO: Test
        public bool IsComplete()
        {
            if (RightChild != null && LeftChild != null)
            {
                return true;
            }
            return false;
        }

        // TODO: Test
        public List<T> GetChidlren()
        {
            List<T> children = new List<T>();
            if (RightChild != null)
            {
                children.Add(RightChild);
            }
            if (LeftChild != null)
            {
                children.Add(LeftChild);
            }
            return children;
        }

        // TODO: Test
        public List<T> GetGrandChildren()
        {
            List<T> grandChildren = new List<T>();
            if(RightChild != null)
                grandChildren.AddRange(RightChild.GetChidlren());
            if (LeftChild != null)
                grandChildren.AddRange(LeftChild.GetChidlren());
            return grandChildren;
        }

        public bool Equals(T other)
        {
            if (other == null) return false;
            if (Key.CompareTo(other.Key) == 0) return true;
            return false;
        }
    }
}
