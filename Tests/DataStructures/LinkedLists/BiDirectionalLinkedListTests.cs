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
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals.DataStructures.LinkedLists;

namespace CSFundamentalsTests.DataStructures.LinkedLists
{
    [TestClass]
    public class BiDirectionalLinkedListTests
    {
        [TestMethod]
        public void BiDirectionalLinkedList_Length_Test()
        {
            BiDirectionalLinkedListNode<int> node1 = new BiDirectionalLinkedListNode<int>(10);
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>();
            Assert.AreEqual(0, list.Count());

            list.Head = node1;
            Assert.AreEqual(1, list.Count());

            list.Head.Next = new BiDirectionalLinkedListNode<int>(2);
            Assert.AreEqual(2, list.Count());

            list.Head.Next.Next = new BiDirectionalLinkedListNode<int>(20);
            Assert.AreEqual(3, list.Count());

            list.Head.Next.Next.Next = new BiDirectionalLinkedListNode<int>(3);
            Assert.AreEqual(4, list.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void BiDirectionalLinkedList_InsertAfter_Test_Failure_1()
        {
            /* Testing the case where there is no node in the list, and the node after does not exist. */
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>();
            Assert.IsFalse(list.InsertAfter(1, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void BiDirectionalLinkedList_InsertAfter_Test_Failure_2()
        {
            /* Testing the case where there is one node in the list, and the node after does not exist. */
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>(new BiDirectionalLinkedListNode<int>(5));
            Assert.IsFalse(list.InsertAfter(1, 2));
        }

        [TestMethod]
        public void BiDirectionalLinkedList_InsertAfter_Test_Success_1()
        {
            /* Testing the case where there is one node in the list, and the node after exists. */
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>(new BiDirectionalLinkedListNode<int>(5));

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(5, list.Tail.Value);

            Assert.IsTrue(list.InsertAfter(5, 2));

            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(2, list.Tail.Value);
            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail.Next);
            Assert.IsNotNull(list.Tail.Previous);
        }

        [TestMethod]
        public void BiDirectionalLinkedList_InsertAfter_Test_Success_2()
        {
            /* Testing the case where there are 2 nodes in the list, and the node after exists. */
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>(new BiDirectionalLinkedListNode<int>(5));
            Assert.IsTrue(list.InsertAfter(5, 2));
            Assert.IsTrue(list.InsertAfter(5, 3));

            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(2, list.Tail.Value);

            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail.Next);
            Assert.IsNotNull(list.Tail.Previous);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void BiDirectionalLinkedList_InsertBefore_Test_Failure_1()
        {
            /* Testing the case where there is no node in the list, and the node before does not exist. */
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>();
            Assert.IsFalse(list.InsertBefore(1, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void BiDirectionalLinkedList_InsertBefore_Test_Failure_2()
        {
            /* Testing the case where there is one node in the list, and the node before does not exist. */
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>(new BiDirectionalLinkedListNode<int>(5));
            Assert.IsFalse(list.InsertBefore(1, 2));
        }

        [TestMethod]
        public void BiDirectionalLinkedList_InsertBefore_Test_Success_1()
        {
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>(new BiDirectionalLinkedListNode<int>(5));

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(5, list.Tail.Value);

            Assert.IsTrue(list.InsertBefore(5, 1));

            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(5, list.Tail.Value);

            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail.Next);
            Assert.IsNotNull(list.Tail.Previous);
        }

        [TestMethod]
        public void BiDirectionalLinkedList_InsertBefore_Test_Success_2()
        {
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>(new BiDirectionalLinkedListNode<int>(5));

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(5, list.Tail.Value);

            Assert.IsTrue(list.InsertBefore(5, 1));
            Assert.IsTrue(list.InsertBefore(5, 0));

            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(5, list.Tail.Value);

            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail.Next);
            Assert.IsNotNull(list.Tail.Previous);

            Assert.AreEqual(0, list.Head.Next.Value);
            Assert.AreEqual(0, list.Tail.Previous.Value);
        }

        [TestMethod]
        public void BiDirectionalLinkedList_Append_Test()
        {
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>();
            Assert.AreEqual(0, list.Count());

            Assert.IsTrue(list.Append(2));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(2, list.Tail.Value);

            Assert.IsTrue(list.Append(12));
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(12, list.Tail.Value);
            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail.Next);
            Assert.IsNotNull(list.Tail.Previous);
            Assert.AreEqual(12, list.Head.Next.Value);
            Assert.AreEqual(2, list.Tail.Previous.Value);

            Assert.IsTrue(list.Append(7));
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(7, list.Tail.Value);
            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail.Next);
            Assert.IsNotNull(list.Tail.Previous);
            Assert.AreEqual(12, list.Head.Next.Value);
            Assert.AreEqual(12, list.Tail.Previous.Value);
        }

        [TestMethod]
        public void BiDirectionalLinkedList_Prepend_Test()
        {
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>();
            Assert.AreEqual(0, list.Count());

            Assert.IsTrue(list.PrePend(2));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(2, list.Tail.Value);

            Assert.IsTrue(list.PrePend(12));
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(12, list.Head.Value);
            Assert.AreEqual(2, list.Tail.Value);
            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail.Next);
            Assert.IsNotNull(list.Tail.Previous);
            Assert.AreEqual(2, list.Head.Next.Value);
            Assert.AreEqual(12, list.Tail.Previous.Value);

            Assert.IsTrue(list.PrePend(7));
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(7, list.Head.Value);
            Assert.AreEqual(2, list.Tail.Value);
            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail.Next);
            Assert.IsNotNull(list.Tail.Previous);
            Assert.AreEqual(12, list.Head.Next.Value);
            Assert.AreEqual(12, list.Tail.Previous.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void BiDirectionalLinkedList_Search_Test_Failure_1()
        {
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>();
            var result = list.Search(10);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void BiDirectionalLinkedList_Search_Test_Failure_2()
        {
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>(new BiDirectionalLinkedListNode<int>(20));
            var result = list.Search(10);
        }

        [TestMethod]
        public void BiDirectionalLinkedList_Search_Test_Success()
        {
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>(new BiDirectionalLinkedListNode<int>(20));
            var result = list.Search(20);
            Assert.IsNotNull(result);
            Assert.AreEqual(20, result.Value);

            list.Append(10);
            list.Append(12);
            list.Append(6);
            result = list.Search(12);
            Assert.IsNotNull(result);
            Assert.AreEqual(12, result.Value);
        }

        [TestMethod]
        public void BiDirectionalLinkedList_Delete_Test()
        {
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>();
            Assert.AreEqual(0, list.Count());
            Assert.IsFalse(list.Delete(5));
            list.Append(10);
            Assert.AreEqual(1, list.Count());

            Assert.IsTrue(list.Delete(10));
            Assert.AreEqual(0, list.Count());

            list.Append(10);
            list.Append(3);

            Assert.IsTrue(list.Delete(10));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(3, list.Head.Value);
            Assert.AreEqual(3, list.Tail.Value);

            list.Append(14);

            Assert.IsTrue(list.Delete(14));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(3, list.Head.Value);
            Assert.AreEqual(3, list.Tail.Value);

            list.Append(5);
            list.Append(4);
            list.Append(1);
            Assert.IsTrue(list.Delete(4));
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(3, list.Head.Value);
            Assert.AreEqual(1, list.Tail.Value);
        }

        [TestMethod]
        public void BiDirectionalLinkedList_Append_Prepend_Test()
        {
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>();
            list.Append(10);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(10, list.Tail.Value);

            list.PrePend(20);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(20, list.Head.Value);
            Assert.AreEqual(10, list.Tail.Value);

            list.Append(30);
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(20, list.Head.Value);
            Assert.AreEqual(30, list.Tail.Value);
        }
    }
}
