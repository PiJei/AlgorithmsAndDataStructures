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
using AlgorithmsAndDataStructures.Decoration;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedLists
{
    /// <summary>
    /// Implements a singly linked list. 
    /// </summary>
    /// <typeparam name="TValue">Type of the values stored in the list.</typeparam>
    public class SinglyLinkedList<TValue> : LinkedListBase<SinglyLinkedNode<TValue>, TValue> where TValue : IComparable<TValue>
    {
        /// <summary>
        /// Parameter-less Constructor.
        /// </summary>
        public SinglyLinkedList()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="head">Head/starting node in the list. </param>
        public SinglyLinkedList(SinglyLinkedNode<TValue> head)
        {
            _head = head;
        }

        /// <summary>
        /// Deletes a node with the given value from the list. If no node with the given value exists, fails the operation and returns false.
        /// </summary>
        /// <param name="value">The value that is being searched for.</param>
        /// <returns>True in case of success, and false otherwise. </returns>
        public override bool Delete(TValue value)
        {
            SinglyLinkedNode<TValue> previousNode = null;
            SinglyLinkedNode<TValue> currentNode = _head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    if (previousNode == null) /* Means we are deleting the head. */
                    {
                        _head = currentNode.Next;
                        return true;
                    }
                    else
                    {
                        previousNode.Next = currentNode.Next;
                        return true;
                    }
                }
                else
                {
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }

        /// <summary>
        /// Inserts a new node in the beginning of the list. Insert in a singly linked list is the fastest when treated as a prepend, meaning adding to the beginning of the list. 
        /// Notice that the current implementation allows duplicates.
        /// </summary>
        /// <param name="newValue">The value of the new node in the list.</param>
        /// <returns>True in case of success.</returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(1)")]
        [TimeComplexity(Case.Average, "O(1)")]
        public override bool Insert(TValue newValue)
        {
            var newNode = new SinglyLinkedNode<TValue>(newValue)
            {
                Next = _head
            };
            _head = newNode;
            return true;
        }
    }
}
