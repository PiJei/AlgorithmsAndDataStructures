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

namespace CSFundamentals.DataStructures.LinkedLists
{
    public class DoublySortedLinkedList<T1> : LinkedListBase<DoublyLinkedNode<T1>, T1> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Is the last node in the list. Note that some implementations of DLL do not have Tail. 
        /// </summary>
        public DoublyLinkedNode<T1> Tail { get; private set; } = null;

        public override bool Delete(T1 value)
        {
            throw new NotImplementedException();
            // if nt found up to some point, then break, an return false, ... 
        }

        // Allowing duplicates, should first find the proper spot, ... 
        /// <summary>
        /// Inserts a new node with <paramref name="newValue"/> as its value in its proper position in the sorted list. 
        /// </summary>
        /// <param name="newValue">Is the value of the new node. </param>
        /// <returns>True in case of success. </returns>
        public override bool Insert(T1 newValue)
        {
            DoublyLinkedNode<T1> newNode = new DoublyLinkedNode<T1>(newValue);

            var currentNode = Head;
            while (currentNode != null && currentNode.Value.CompareTo(newValue) < 0) /* Navigate a long the list, until a node is found whose value is bigger than or equal to newValue. */
            {
                currentNode = currentNode.Next;
            }

            if (currentNode == null) /* Means the newValue will be inserted at the tail of the list.*/
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
                newNode = Tail;
                return true;
            }
            else
            {
                if (currentNode.Previous == null) /* means the newly added node will be the new head. */
                {
                    newNode.Next = Head.Next;
                    newNode.Previous = Head.Previous;
                    Head = newNode;
                    return true;
                }
                else
                {
                    newNode.Previous = currentNode.Previous;
                    newNode.Next = currentNode;
                    newNode.Next.Previous = newNode;
                    newNode.Previous.Next = newNode;
                    return true;
                }
            }
        }

        public override DoublyLinkedNode<T1> Search(T1 value)
        {
            throw new NotImplementedException();
            // TODO can stop the search as soon as the next element is bigger,
        }
    }
}
