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
using AlgorithmsAndDataStructures.DataStructures.LinkedLists;
using AlgorithmsAndDataStructures.DataStructures.LinkedLists.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.DataStructures.LinkedLists.API
{
    /// <summary>
    /// Tests methods in <see cref="LinkedListBase{TNode, TValue}"/> using <see cref="MockLinkedList{T1}"/> class. 
    /// </summary>
    [TestClass]
    public class LinkedListBaseTests
    {
        /// <summary>
        /// Tests the correctness of computing the length of a linked list. 
        /// </summary>
        [TestMethod]
        public void Length()
        {
            var list = new MockLinkedList<int>();
            Assert.AreEqual(0, list.Count());

            var head = new MockLinkedNode<int>(10);
            list = new MockLinkedList<int>(head);
            Assert.AreEqual(1, list.Count());

            head.Next = new MockLinkedNode<int>(2);
            list = new MockLinkedList<int>(head);
            Assert.AreEqual(2, list.Count());

            head.Next.Next = new MockLinkedNode<int>(20);
            list = new MockLinkedList<int>(head);
            Assert.AreEqual(3, list.Count());

            head.Next.Next.Next = new MockLinkedNode<int>(3);
            list = new MockLinkedList<int>(head);
            Assert.AreEqual(4, list.Count());
        }

        /// <summary>
        /// Tests the correctness of searching an empty list for a non existing key. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void Search_EmptyListAndNotExistingValue_ThrowsException()
        {
            var list = new MockLinkedList<int>();
            var result = list.Search(10);
        }

        /// <summary>
        /// Tests the correctness of searching a non empty list for a non existing key. Expects an exception to be thrown. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void Search_NonEmptyListAndNotExistingValue_ThrowsException()
        {
            var list = new MockLinkedList<int>(new MockLinkedNode<int>(20));
            var result = list.Search(10);
        }

        /// <summary>
        /// Tests the correctness of search operation over a list for existing keys. 
        /// </summary>
        [TestMethod]
        public void Search_Success()
        {
            var head = new MockLinkedNode<int>(20)
            {
                Next = new MockLinkedNode<int>(10)
            };
            head.Next.Next = new MockLinkedNode<int>(12) { };
            head.Next.Next.Next = new MockLinkedNode<int>(6);

            var list = new MockLinkedList<int>(head);
            var result = list.Search(20);
            Assert.IsNotNull(result);
            Assert.AreEqual(20, result.Value);

            result = list.Search(12);
            Assert.IsNotNull(result);
            Assert.AreEqual(12, result.Value);
        }
    }
}
