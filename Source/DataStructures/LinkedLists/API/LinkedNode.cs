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

namespace CSFundamentals.DataStructures.LinkedLists.API
{
    [Serializable]
    public class LinkedNode<TNode, TValue> where TNode : LinkedNode<TNode, TValue> where TValue : IComparable<TValue>
    {
        public TValue Value { get; set; }

        public TNode Next { get; set; }

        public LinkedNode(TValue value)
        {
            Value = value;
        }

        /// <summary>
        /// This constructor is for Serializability.
        /// </summary>
        public LinkedNode()
        {
        }
        /// <summary>
        /// Checks whether the current node is tail. A node is tail if it has no next node. 
        /// </summary>
        /// <returns>True in case the node is tail, and false otherwise.</returns>
        public bool IsTail()
        {
            if (Next == null)
            {
                return true;
            }

            return false;
        }
    }
}
