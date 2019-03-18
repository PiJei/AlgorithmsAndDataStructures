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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals.DataStructures.LinkedLists;

namespace CSFundamentalsTests.DataStructures.LinkedLists
{
    [TestClass]
    public class DoublyLinkedListTests
    {
        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void DoublyLinkedList_InsertAfter_Test_Failure_1()
        {
            /* Testing the case where there is no node in the list, and the node after does not exist. */
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Assert.IsFalse(list.InsertAfter(1, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void DoublyLinkedList_InsertAfter_Test_Failure_2()
        {
            /* Testing the case where there is one node in the list, and the node after does not exist. */
            DoublyLinkedList<int> list = new DoublyLinkedList<int>(new DoublyLinkedNode<int>(5));
            Assert.IsFalse(list.InsertAfter(1, 2));
        }

        [TestMethod]
        public void DoublyLinkedList_InsertAfter_Test_Success_1()
        {
            /* Testing the case where there is one node in the list, and the node after exists. */
            DoublyLinkedList<int> list = new DoublyLinkedList<int>(new DoublyLinkedNode<int>(5));

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(5, list.Tail().Value);

            Assert.IsTrue(list.InsertAfter(5, 2));

            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(2, list.Tail().Value);
            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail().Next);
            Assert.IsNotNull(list.Tail().Previous);
        }

        [TestMethod]
        public void DoublyLinkedList_InsertAfter_Test_Success_2()
        {
            /* Testing the case where there are 2 nodes in the list, and the node after exists. */
            DoublyLinkedList<int> list = new DoublyLinkedList<int>(new DoublyLinkedNode<int>(5));
            Assert.IsTrue(list.InsertAfter(5, 2));
            Assert.IsTrue(list.InsertAfter(5, 3));

            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(2, list.Tail().Value);

            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail().Next);
            Assert.IsNotNull(list.Tail().Previous);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void DoublyLinkedList_InsertBefore_Test_Failure_1()
        {
            /* Testing the case where there is no node in the list, and the node before does not exist. */
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Assert.IsFalse(list.InsertBefore(1, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void DoublyLinkedList_InsertBefore_Test_Failure_2()
        {
            /* Testing the case where there is one node in the list, and the node before does not exist. */
            DoublyLinkedList<int> list = new DoublyLinkedList<int>(new DoublyLinkedNode<int>(5));
            Assert.IsFalse(list.InsertBefore(1, 2));
        }

        [TestMethod]
        public void DoublyLinkedList_InsertBefore_Test_Success_1()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>(new DoublyLinkedNode<int>(5));

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(5, list.Tail().Value);

            Assert.IsTrue(list.InsertBefore(5, 1));

            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(5, list.Tail().Value);

            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail().Next);
            Assert.IsNotNull(list.Tail().Previous);
        }

        [TestMethod]
        public void DoublyLinkedList_InsertBefore_Test_Success_2()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>(new DoublyLinkedNode<int>(5));

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(5, list.Tail().Value);

            Assert.IsTrue(list.InsertBefore(5, 1));
            Assert.IsTrue(list.InsertBefore(5, 0));

            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(1, list.Head.Value);
            Assert.AreEqual(5, list.Tail().Value);

            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail().Next);
            Assert.IsNotNull(list.Tail().Previous);

            Assert.AreEqual(0, list.Head.Next.Value);
            Assert.AreEqual(0, list.Tail().Previous.Value);
        }

        [TestMethod]
        public void DoublyLinkedList_Append_Test()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Assert.AreEqual(0, list.Count());

            Assert.IsTrue(list.Append(2));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(2, list.Tail().Value);

            Assert.IsTrue(list.Append(12));
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(12, list.Tail().Value);
            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail().Next);
            Assert.IsNotNull(list.Tail().Previous);
            Assert.AreEqual(12, list.Head.Next.Value);
            Assert.AreEqual(2, list.Tail().Previous.Value);

            Assert.IsTrue(list.Append(7));
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(7, list.Tail().Value);
            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail().Next);
            Assert.IsNotNull(list.Tail().Previous);
            Assert.AreEqual(12, list.Head.Next.Value);
            Assert.AreEqual(12, list.Tail().Previous.Value);
        }

        [TestMethod]
        public void DoublyLinkedList_Prepend_Test()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            Assert.AreEqual(0, list.Count());

            Assert.IsTrue(list.PrePend(2));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(2, list.Head.Value);
            Assert.AreEqual(2, list.Tail().Value);

            Assert.IsTrue(list.PrePend(12));
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(12, list.Head.Value);
            Assert.AreEqual(2, list.Tail().Value);
            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail().Next);
            Assert.IsNotNull(list.Tail().Previous);
            Assert.AreEqual(2, list.Head.Next.Value);
            Assert.AreEqual(12, list.Tail().Previous.Value);

            Assert.IsTrue(list.PrePend(7));
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(7, list.Head.Value);
            Assert.AreEqual(2, list.Tail().Value);
            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail().Next);
            Assert.IsNotNull(list.Tail().Previous);
            Assert.AreEqual(12, list.Head.Next.Value);
            Assert.AreEqual(12, list.Tail().Previous.Value);
        }

        [TestMethod]
        public void DoublyLinkedList_Delete_Test()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
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
            Assert.AreEqual(3, list.Tail().Value);

            list.Append(14);

            Assert.IsTrue(list.Delete(14));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(3, list.Head.Value);
            Assert.AreEqual(3, list.Tail().Value);

            list.Append(5);
            list.Append(4);
            list.Append(1);
            Assert.IsTrue(list.Delete(4));
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(3, list.Head.Value);
            Assert.AreEqual(1, list.Tail().Value);
        }

        [TestMethod]
        public void DoublyLinkedList_Append_Prepend_Test()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Append(10);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(10, list.Tail().Value);

            list.PrePend(20);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(20, list.Head.Value);
            Assert.AreEqual(10, list.Tail().Value);

            list.Append(30);
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(20, list.Head.Value);
            Assert.AreEqual(30, list.Tail().Value);
        }
    }
}
