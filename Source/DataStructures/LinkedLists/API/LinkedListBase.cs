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
using AlgorithmsAndDataStructures.Decoration;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedLists.API
{
    /// <summary>
    /// Is the abstract class for a Linked List
    /// </summary>
    /// <typeparam name="TNode">Type of the nodes in linked list. </typeparam>
    /// <typeparam name="TValue">Type of the values stored in the linked list. </typeparam>
    public abstract class LinkedListBase<TNode, TValue> where TNode : LinkedNode<TNode, TValue> where TValue : IComparable<TValue>
    {
        /// <summary>
        /// Is the first node in the list. 
        /// </summary>
        protected TNode _head = null;

        /// <summary>
        /// Gets a copy of the head node. 
        /// </summary>
        /// <returns>A copy of the head node. </returns>
        public TNode Head()
        {
            return Utils.DeepCopy(_head);
        }

        /// <summary>
        /// Inserts a new value in the list.
        /// </summary>
        /// <param name="newValue">The value of the new node. </param>
        /// <returns>True in case of success.</returns>
        public abstract bool Insert(TValue newValue);

        /// <summary>
        /// Deletes a node with the given value from the list. If no node with the given value exists, fails the operation and returns false.
        /// </summary>
        /// <param name="value">The value that is being searched for.</param>
        /// <returns>True in case of success, and false otherwise. </returns>
        public abstract bool Delete(TValue value);

        /// <summary>
        /// Searches for the specified <paramref name="value"/>. Since there is no assumption about the order of the values in the list, starts from the Head node and performs a linear search.
        /// </summary>
        /// <exception cref="NotFoundException"> Throws if <paramref name="value"/> does not exist in the list. </exception>
        /// <param name="value">The value of the node that is being searched for.</param>
        /// <returns>The node containing <paramref name="value"/>, and if no node is found throws an exception. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "The first node (Head) contains the value.")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public virtual TNode Search(TValue value)
        {
            var currentNode = _head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return currentNode;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
            throw new NotFoundException($"Value {value.ToString()} does not exist in the list.");
        }

        /// <summary>
        /// Computes the length of the linked list. Length is the number of the nodes in the list.
        /// </summary>
        /// <returns>Number of nodes in the list. </returns>
        [TimeComplexity(Case.Best, "O(n)")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public int Count()
        {
            int length = 0;
            var current = _head;
            while (current != null)
            {
                length++;
                current = current.Next;
            }
            return length;
        }
    }
}
