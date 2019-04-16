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
using CSFundamentals.Decoration;

namespace CSFundamentals.DataStructures.LinkedLists
{
    /// <summary>
    /// Implements a bi-directional/doubly linked list (aka. DLL). 
    /// </summary>
    /// <typeparam name="TValue">Is the type of the keys in the list. </typeparam>
    public class DoublyLinkedList<TValue> : LinkedListBase<DoublyLinkedNode<TValue>, TValue> where TValue : IComparable<TValue>
    {
        /// <summary>
        /// Is the last node in the list. Note that some implementations of DLL do not have Tail. 
        /// </summary>
        private DoublyLinkedNode<TValue> _tail = null;

        public DoublyLinkedList()
        {

        }

        public DoublyLinkedList(DoublyLinkedNode<TValue> head)
        {
            _head = head;
            _tail = head;
        }

        /// <summary>
        /// Tail can be read, but to prevent any modification outside the API in this class, only a deep copy of the tail can be returned for reading purposes.
        /// </summary>
        /// <returns></returns>
        public DoublyLinkedNode<TValue> Tail()
        {
            return Utils.DeepCopy(_tail);
        }

        /// <summary>
        /// Inserts a new node at the beginning of the list, thus changing the head node.
        /// </summary>
        /// <param name="newValue">Is the new value of the new node to be added as the head of the list. </param>
        /// <returns>True in case of success.</returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(1)")]
        [TimeComplexity(Case.Average, "O(1)")]
        public override bool Insert(TValue newValue)
        {
            return PrePend(newValue);
        }

        /// <summary>
        /// Inserts a new node with <paramref name="newValue"/> as its value in the list after the node containing <paramref name="Value"/> as its value. If a node with <paramref name="Value"/> does not exist, fails the insert and returns false. 
        /// </summary>
        /// <param name="value">The value of the node, that <paramref name="newValue"/> will be inserted after.</param>
        /// <param name="newValue">The value of the new node that is meant to be inserted in the list. </param>
        /// <returns>True in case the operation is successful, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "Inserting after the first node in the list.")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public bool InsertAfter(TValue value, TValue newValue)
        {
            var node = Search(value);
            if (node == null)
            {
                return false;
            }

            return InsertAfter(node, newValue);
        }

        /// <summary>
        /// Inserts a new node with <paramref name="newValue"/> as its value in the list after the given node <paramref name="node"/>.
        /// </summary>
        /// <param name="node">The node that a new node with value <paramref name="newValue"/> will be inserted after.</param>
        /// <param name="newValue">The value of the new node that is meant to be inserted in the list. </param>
        /// <returns>True in case the operation is successful</returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(1)")]
        [TimeComplexity(Case.Average, "O(1)")]
        public bool InsertAfter(DoublyLinkedNode<TValue> node, TValue newValue)
        {
            var newNode = new DoublyLinkedNode<TValue>(newValue)
            {
                Previous = node,
                Next = node?.Next
            };

            node.Next = newNode;

            if (newNode.Next == null)
            {
                _tail = newNode;
            }
            else
            {
                newNode.Next.Previous = newNode;
            }

            if (newNode.Previous == null)
            {
                _head = newNode;
            }
            return true;
        }

        /// <summary>
        /// Inserts a new node with <paramref name="newValue"/> as its value in the list before the node containing <paramref name="Value"/> as its value. If a node with <paramref name="Value"/> does not exist, fails the insert and returns false. 
        /// </summary>
        /// <param name="value">The value of the node, that <paramref name="newValue"/> will be inserted before.</param>
        /// <param name="newValue">The value of the new node that is meant to be inserted in the list. </param>
        /// <returns>True in case the operation is successful, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "Inserting before the first node in the list.")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public bool InsertBefore(TValue value, TValue newValue)
        {
            var node = Search(value);
            if (node == null)
            {
                return false;
            }
            return InsertBefore(node, newValue);
        }

        /// <summary>
        /// Inserts a new node with <paramref name="newValue"/> as its value in the list before the given node.
        /// </summary>
        /// <param name="node">The node that a new node with value <paramref name="newValue"/> will be inserted before.</param>
        /// <param name="newValue">The value of the new node that is meant to be inserted in the list. </param>
        /// <returns>True in case the operation is successful. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(1)")]
        [TimeComplexity(Case.Average, "O(1)")]
        public bool InsertBefore(DoublyLinkedNode<TValue> node, TValue newValue)
        {
            var newNode = new DoublyLinkedNode<TValue>(newValue)
            {
                Next = node,
                Previous = node.Previous
            };
        
            node.Previous = newNode;
            if (newNode.Previous == null)
            {
                _head = newNode;
            }
            else
            {
                newNode.Previous.Next = newNode;
            }
            if (newNode.Next == null)
            {
                _tail = newNode;
            }
            return true;
        }

        /// <summary>
        /// Adds a new node to the end of the list. Changing the Tail node.
        /// </summary>
        /// <param name="newValue">The value of the new node that is meant to be appended in the list. </param>
        /// <returns>True in case the operation is successful, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(1)")]
        [TimeComplexity(Case.Average, "O(1)")]
        public bool Append(TValue newValue)
        {
            var newNode = new DoublyLinkedNode<TValue>(newValue);
            if (_tail != null)
            {
                _tail.Next = newNode;
            }

            newNode.Previous = _tail;
            _tail = newNode;

            if (_head == null)
            {
                _head = newNode;
            }
            return true;
        }

        /// <summary>
        /// Ands a new node to the beginning of the list. Changing the Head node. 
        /// </summary>
        /// <param name="newValue">The value of the new node that is meant to be prepended to the list. </param>
        /// <returns>True in case operation is successful, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(1)")]
        [TimeComplexity(Case.Average, "O(1)")]
        public bool PrePend(TValue newValue)
        {
            var newNode = new DoublyLinkedNode<TValue>(newValue);
            if (_head != null)
            {
                _head.Previous = newNode;
            }

            newNode.Next = _head;
            _head = newNode;
            if (_tail == null)
            {
                _tail = newNode;
            }
            return true;
        }

        /// <summary>
        /// Deletes a node from the list with the given value. If no node with the <paramref name="value"/> is found fails the operation and returns false.
        /// </summary>
        /// <param name="value">Is the value of the node to be deleted. </param>
        /// <returns>True in case the operation is successful, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "The first node (Head) contains the value.")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public override bool Delete(TValue value)
        {
            var currentNode = _head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0) /* If the key is found. */
                {
                    if (currentNode.Previous == null && currentNode.Next == null) /* This means the list has only one node.*/
                    {
                        _head = null;
                        _tail = null;
                        return true;
                    }
                    else if (currentNode.Previous == null) /* This means we are deleting the head. */
                    {
                        _head = _head.Next;
                        _head.Previous = null;
                        return true;
                    }
                    else if (currentNode.Next == null) /*This means we are deleting the tail.*/
                    {
                        _tail = _tail.Previous;
                        _tail.Next = null;
                        return true;
                    }
                    else /* Node is in the middle and has not-null next and previous nodes. */
                    {
                        currentNode.Previous.Next = currentNode.Next;
                        currentNode.Next.Previous = currentNode.Previous;
                        return true;
                    }
                }
                else /* Keep moving forward in the list. */
                {
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }
    }
}
