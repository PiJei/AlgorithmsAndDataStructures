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
using CSFundamentals.Styling;
//TODO: Should I have a build method as well?

namespace CSFundamentals.DataStructures.LinkedLists.API
{
    public abstract class LinkedListBase<T, T1> where T : LinkedNode<T, T1> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Is the first node in the list. 
        /// </summary>
        protected T _head = null;

        public T Head()
        {
            return Utils.DeepCopy(_head);
        }

        /// <summary>
        /// Inserts a new value in the list.
        /// </summary>
        /// <param name="newValue">Is the value of the new node. </param>
        /// <returns>True in case of success.</returns>
        public abstract bool Insert(T1 newValue);

        /// <summary>
        /// Deletes a node with the given value from the list. If no node with the given value exists, fails the operation and returns false.
        /// </summary>
        /// <param name="value">Is the value that is being searched for.</param>
        /// <returns>True in case of success, and false otherwise. </returns>
        public abstract bool Delete(T1 value);

        /// <summary>
        /// Searches for the specified <paramref name="Value"/>. Since there is no assumption about the order of the values in the list, starts from the Head node and performs a linear search.
        /// </summary>
        /// <param name="value">Is the value of the node that is being searched for.</param>
        /// <returns>The node containing <paramref name="value"/>, and if no node is found throws an exception. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "The first node (Head) contains the value.")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public virtual T Search(T1 value)
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
