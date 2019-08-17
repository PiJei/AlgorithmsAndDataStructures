#region copyright
/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of AlgorithmsAndDataStructures project.
 *
 * AlgorithmsAndDataStructures is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AlgorithmsAndDataStructures is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using AlgorithmsAndDataStructures.DataStructures.LinkedLists.API;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedLists
{
    /// <summary>
    /// Implements a node in a DoublyLinkedList. 
    /// </summary>
    /// <typeparam name="TValue">The type of the values stored in a node.</typeparam>
    [Serializable]
    public class DoublyLinkedNode<TValue> : LinkedNode<DoublyLinkedNode<TValue>, TValue> where TValue : IComparable<TValue>
    {
        /// <summary>
        /// Is a reference to the node before this one in the list. 
        /// </summary>
        public DoublyLinkedNode<TValue> Previous = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The value to be stored in the node. </param>
        public DoublyLinkedNode(TValue value) : base(value)
        {
        }

        /// <summary>
        /// Checks whether the current node is head, a node is head if it has no previous node.
        /// </summary>
        /// <returns>True in case the node is head, and false otherwise. </returns>
        public bool IsHead()
        {
            if (Previous == null)
            {
                return true;
            }

            return false;
        }
    }
}
