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
using CSFundamentals.DataStructures.LinkedLists.API;
using CSFundamentals.Styling;

namespace CSFundamentals.DataStructures.LinkedLists
{
    public class SinglyLinkedList<T1> : LinkedListBase<SinglyLinkedNode<T1>, T1> where T1 : IComparable<T1>
    {
        public SinglyLinkedList()
        {
        }

        public SinglyLinkedList(SinglyLinkedNode<T1> head)
        {
            _head = head;
        }

        public override bool Delete(T1 value)
        {
            SinglyLinkedNode<T1> previousNode = null;
            SinglyLinkedNode<T1> currentNode = _head;
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
        /// <param name="newValue">Is the value of the new node in the list.</param>
        /// <returns>True in case of success.</returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(1)")]
        [TimeComplexity(Case.Average, "O(1)")]
        public override bool Insert(T1 newValue)
        {
            SinglyLinkedNode<T1> newNode = new SinglyLinkedNode<T1>(newValue)
            {
                Next = _head
            };
            _head = newNode;
            return true;
        }
    }
}
