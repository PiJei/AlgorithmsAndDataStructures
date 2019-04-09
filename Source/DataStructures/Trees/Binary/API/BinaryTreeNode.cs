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

namespace CSFundamentals.DataStructures.Trees.Binary.API
{
    public abstract class BinaryTreeNode<TNode, TKey, TValue> : IComparable<TNode>, IBinaryTreeNode<TNode, TKey, TValue> where TNode : IBinaryTreeNode<TNode, TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public BinaryTreeNode(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public abstract TNode LeftChild { get; set; }
        public abstract TNode RightChild { get; set; }
        public abstract TNode Parent { get; set; }

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
        public TNode GetUncle()
        {
            if (Parent == null) return default(TNode);
            if (Parent.Parent == null) return default(TNode);
            if (Parent.Parent.LeftChild != null && Parent.Parent.LeftChild.CompareTo(Parent) == 0)
            {
                return Parent.Parent.RightChild;
            }
            else if (Parent.Parent.RightChild != null && Parent.Parent.RightChild.CompareTo(Parent) == 0)
            {
                return Parent.Parent.LeftChild;
            }
            return default(TNode);
        }

        /// <summary>
        /// Gets the sibling of the current node.
        /// </summary>
        /// <returns>Sibling node.</returns>
        public TNode GetSibling()
        {
            if (Parent == null) return default(TNode);
            if (Parent.LeftChild != null && Parent.LeftChild.Key.CompareTo(Key) == 0)
                return Parent.RightChild;
            return Parent.LeftChild;
        }

        /// <summary>
        /// Gets the grandparent of the current node. GrandParent is the parent of the parent. 
        /// </summary>
        /// <returns></returns>
        public TNode GetGrandParent()
        {
            if (Parent == null) return default(TNode);
            if (Parent.Parent == null) return default(TNode);
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

        public int CompareTo(TNode other)
        {
            return Key.CompareTo(other.Key);
        }

        /// <summary>
        /// Checks whether the current node is complete. A binary tree node is complete if it has both left and right children.
        /// </summary>
        /// <returns>True in case the current node is complete, and false otherwise.</returns>
        public bool IsComplete()
        {
            if (RightChild != null && LeftChild != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the immediate not-null children of the current node, the collection contains left and right children thus. 
        /// </summary>
        /// <returns>List of the immediate direct children of the current node.</returns>
        public List<TNode> GetChildren()
        {
            List<TNode> children = new List<TNode>();
            if (LeftChild != null)
            {
                children.Add(LeftChild);
            }
            if (RightChild != null)
            {
                children.Add(RightChild);
            }
            return children;
        }

        /// <summary>
        /// Gets the immediate grand children of a node. This is the children of the children of the node.
        /// </summary>
        /// <returns>The list of grand children of the node.</returns>
        public List<TNode> GetGrandChildren()
        {
            List<TNode> grandChildren = new List<TNode>();
            if (LeftChild != null)
                grandChildren.AddRange(LeftChild.GetChildren());
            if (RightChild != null)
                grandChildren.AddRange(RightChild.GetChildren());
            return grandChildren;
        }

        public bool Equals(TNode other)
        {
            if (other == null) return false;
            if (Key.CompareTo(other.Key) == 0) return true;
            return false;
        }
    }
}
