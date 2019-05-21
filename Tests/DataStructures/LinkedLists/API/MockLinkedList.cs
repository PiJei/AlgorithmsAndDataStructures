#region copyright
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
#endregion
using System;
using CSFundamentals.DataStructures.LinkedLists.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.DataStructures.LinkedLists.API
{
    /// <summary>
    /// Implements a mock for testing <see cref="LinkedListBase{TNode, TValue}"/> class.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    public class MockLinkedList<T1> : LinkedListBase<MockLinkedNode<T1>, T1> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Parameter-less constructor.
        /// </summary>
        public MockLinkedList()
        {
        }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="head">Head/starting node of the list. </param>
        public MockLinkedList(MockLinkedNode<T1> head)
        {
            _head = head;
        }

        /// <summary>
        /// Deletes a node with the given value from the list. If no node with the given value exists, fails the operation and returns false.
        /// </summary>
        /// <param name="value">The value that is being searched for.</param>
        /// <returns>True in case of success, and false otherwise. </returns>
        public override bool Delete(T1 value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts a new value in the list.
        /// </summary>
        /// <param name="newValue">The value of the new node. </param>
        /// <returns>True in case of success.</returns>
        public override bool Insert(T1 newValue)
        {
            throw new NotImplementedException();
        }
    }
}
