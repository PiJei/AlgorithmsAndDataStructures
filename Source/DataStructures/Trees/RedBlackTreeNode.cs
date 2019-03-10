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

namespace CSFundamentals.DataStructures.Trees
{
    public class RedBlackTreeNode<T1, T2> where T1 : IComparable<T1>, IEquatable<T1>
    {
        /// <summary>
        /// Is a unique identifier to distinguish between nodes in a tree. 
        /// Key is also the value over which RedBlackTree order properties should hold.
        /// </summary>
        public T1 Key { get; set; }

        /// <remarks>
        /// This can be converted to a list of values alternatively, to handle duplicate keys. 
        /// </remarks>
        /// <summary>
        /// Is the value (information) stored in a node. 
        /// </summary> 
        public T2 Value { get; set; }

        public RedBlackTreeNode<T1, T2> LeftChild { get; set; }

        public RedBlackTreeNode<T1, T2> RightChild { get; set; }

        public RedBlackTreeNode<T1, T2> Parent { get; set; }

        public Color Color { get; set; }

        public RedBlackTreeNode(T1 key, T2 value, Color color = Color.Red)
        {
            Key = key;
            Value = value;
            Color = color;
        }

        public bool Equals(RedBlackTreeNode<T1, T2> other)
        {
            if (other == null) return false;
            if (Key.Equals(other.Key)) return true;
            return false;
        }

        //TODO: ADD test
        public bool IsLeaf()
        {
            if (LeftChild == null && RightChild == null)
            {
                return true;
            }
            return false;
        }

        public RedBlackTreeNode<T1, T2> GetUncle()
        {

            if (Parent == null) return null;
            if (Parent.Parent == null) return null;
            if (Parent.Parent.LeftChild != null && Parent.Parent.LeftChild.Key.CompareTo(Parent.Key) == 0)
            {
                return Parent.Parent.RightChild;
            }
            else if (Parent.Parent.RightChild != null && Parent.Parent.RightChild.Key.CompareTo(Parent.Key) == 0)
            {
                return Parent.Parent.LeftChild;
            }
            return null;
        }

        public RedBlackTreeNode<T1, T2> GetSibling()
        {
            if (Parent == null) return null;
            if (Parent.LeftChild != null && Parent.LeftChild.Equals(this))
                return Parent.RightChild;
            return Parent.LeftChild;
        }

        public RedBlackTreeNode<T1, T2> GetGrandParent()
        {
            if (Parent == null) return null;
            if (Parent.Parent == null) return null;
            return Parent.Parent;
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

        public void FlipColor()
        {
            if (Color == Color.Red)
            {
                Color = Color.Black;
            }
            else if (Color == Color.Black)
            {
                Color = Color.Red;
            }
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
        /// This node is the bottom-most node of a sequence that is being checked for triangle alignment.</param>
        public bool FormsTriangle()
        {
            if (Parent == null) return false;
            if (IsLeftChild() && Parent.IsRightChild()) return true;
            if (IsRightChild() && Parent.IsLeftChild()) return true;
            return false;
        }
    }

    public enum Color
    {
        Unknown = 0,
        Red = 1,
        Black = 2
    }
}
