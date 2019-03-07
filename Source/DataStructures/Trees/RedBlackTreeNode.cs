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
    }

    public enum Color
    {
        Unknown = 0,
        Red = 1,
        Black = 2
    }
}
