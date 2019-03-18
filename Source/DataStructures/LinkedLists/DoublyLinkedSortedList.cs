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
    public class DoublyLinkedSortedList<T1> : LinkedListBase<DoublyLinkedNode<T1>, T1> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Is the last node in the list. Note that some implementations of DLL do not have Tail. 
        /// </summary>
        public DoublyLinkedNode<T1> Tail { get; private set; } = null;

        // TODO: Deletes do not support duplicates deletion, ... 
        [TimeComplexity(Case.Best, "O(1)", When = "The value is at head position.")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public override bool Delete(T1 value)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0) /* If the key is found. */
                {
                    if (currentNode.Previous == null && currentNode.Next == null) /* This means the list has only one node.*/
                    {
                        Head = null;
                        Tail = null;
                        return true;
                    }
                    else if (currentNode.Previous == null) /* This means we are deleting the head. */
                    {
                        Head = Head.Next;
                        Head.Previous = null;
                        return true;
                    }
                    else if (currentNode.Next == null) /*This means we are deleting the tail.*/
                    {
                        Tail = Tail.Previous;
                        Tail.Next = null;
                        return true;
                    }
                    else /* Node is in the middle and has not-null next and previous nodes. */
                    {
                        currentNode.Previous.Next = currentNode.Next;
                        currentNode.Next.Previous = currentNode.Previous;
                        return true;
                    }
                }
                else if (currentNode.Value.CompareTo(value) > 0) /* Since the list is sorted, this means the value does not exist in the list. */
                {
                    return false;
                }
                else /* Keep moving forward in the list. */
                {
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }

        // Allowing duplicates, should first find the proper spot, ... 
        /// <summary>
        /// Inserts a new node with <paramref name="newValue"/> as its value in its proper position in the sorted list. 
        /// </summary>
        /// <param name="newValue">Is the value of the new node. </param>
        /// <returns>True in case of success. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "Insert happens at the head position. ")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public override bool Insert(T1 newValue)
        {
            DoublyLinkedNode<T1> newNode = new DoublyLinkedNode<T1>(newValue);

            var currentNode = Head;
            while (currentNode != null && currentNode.Value.CompareTo(newValue) < 0) /* Navigate a long the list, until a node is found whose value is bigger than or equal to newValue. */
            {
                currentNode = currentNode.Next;
            }
            // At this point, if currentNode != null should insert before CurrentNode

            if (currentNode == null) /* Means the newValue will be inserted at the tail of the list.*/
            {
                if (Tail != null)
                    Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
                if (Head == null)
                {
                    Head = newNode;
                }
                return true;
            }
            else
            {
                if (currentNode.Next == null && currentNode.Previous == null) /* meaning there is only one node in the list. */
                {
                    currentNode.Previous = newNode;
                    newNode.Next = currentNode;
                    Head = newNode;
                    return true;
                }
                else
                {
                    newNode.Previous = currentNode.Previous;
                    newNode.Next = currentNode;
                    if (newNode.Previous != null)
                        newNode.Previous.Next = newNode;
                    currentNode.Previous = newNode;
                    return true;
                }
            }
        }

        [TimeComplexity(Case.Best, "O(1)", When = "The value is at head position.")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public override DoublyLinkedNode<T1> Search(T1 value)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return currentNode;
                }
                else if (currentNode.Value.CompareTo(value) > 0) /*Since the sort is listed, we can break out of the loop as soon as a larger value is encountered. */
                {
                    throw new NotFoundException($"Value {value.ToString()} does not exist in the list.");
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
            throw new NotFoundException($"Value {value.ToString()} does not exist in the list.");
        }
    }
}
