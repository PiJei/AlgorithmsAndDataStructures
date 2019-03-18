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
    public abstract class LinkedListBase<T, T1> where T : ILinkedNode<T, T1> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Is the first node in the list. 
        /// </summary>
        public T Head { get; set; }

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
        /// Searches/looks for a node with the given value. If the value is not found throws an exception.
        /// </summary>
        /// <param name="value">Is the value of the list node we are searching for. </param>
        /// <returns>The node containing the value, or throws an exception if no node exists. </returns>
        public abstract T Search(T1 value);
    }
}
