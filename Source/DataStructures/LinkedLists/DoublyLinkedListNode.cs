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

namespace CSFundamentals.DataStructures.LinkedLists
{
    /// <summary>
    /// Implements a node in a DoublyLinkedList. 
    /// </summary>
    /// <typeparam name="T">Is the type of the values stored in a node.</typeparam>
    public class DoublyLinkedListNode<T1> : LinkedListNode<DoublyLinkedListNode<T1>, T1> where T1 : IComparable<T1>
    {
        public DoublyLinkedListNode<T1> Previous = null;

        public DoublyLinkedListNode(T1 value) : base(value)
        {
        }

        /// <summary>
        /// Checks whether the current node is head, a node is head if it has no previous node.
        /// </summary>
        /// <returns>True in case the node is head, and false otherwise. </returns>
        public bool IsHead()
        {
            if (Previous == null)
                return true;
            return false;
        }
    }
}
