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
    public class BinaryTreeNode<T1, T2> : IEquatable<BinaryTreeNode<T1, T2>> where T1 : IComparable<T1>, IEquatable<T1>
    {
        /// <summary>
        /// Is a unique identifier to distinguish between nodes in a tree. 
        /// Key is also the value over which BinarySearchTree properties should hold.
        /// </summary>
        public T1 Key { get; set; }

        /// <remarks>
        /// This can be converted to a list of values alternatively, to handle duplicate keys. 
        /// </remarks>
        /// <summary>
        /// Is the value (information) stored in a node. 
        /// </summary> 
        public T2 Value { get; set; }

        public BinaryTreeNode<T1, T2> LeftChild { get; set; }

        public BinaryTreeNode<T1, T2> RightChild { get; set; }

        public bool IsLeaf { get; set; }

        public bool IsRoot { get; set; }

        public bool IsIntermediate { get; set; }

        public BinaryTreeNode(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }

        public bool Equals(BinaryTreeNode<T1, T2> other)
        {
            if (other == null) return false;
            if (Key.Equals(other.Key)) return true;
            return false;
        }
    }
}
