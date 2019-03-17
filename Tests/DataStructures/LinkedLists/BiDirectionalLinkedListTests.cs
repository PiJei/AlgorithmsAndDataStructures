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
            Assert.AreEqual(0, list.Length());

            list.Head = node1;
            Assert.AreEqual(1, list.Length());

            list.Head.Next = new BiDirectionalLinkedListNode<int>(2);
            Assert.AreEqual(2, list.Length());

            list.Head.Next.Next = new BiDirectionalLinkedListNode<int>(20);
            Assert.AreEqual(3, list.Length());

            list.Head.Next.Next.Next = new BiDirectionalLinkedListNode<int>(3);
            Assert.AreEqual(4, list.Length());
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
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>(new BiDirectionalLinkedListNode<int>(5));
            Assert.IsTrue(list.InsertAfter(5, 2));
            
            Assert.AreEqual(2, list.Length());
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
            BiDirectionalLinkedList<int> list = new BiDirectionalLinkedList<int>(new BiDirectionalLinkedListNode<int>(5));
            Assert.IsTrue(list.InsertAfter(5, 2));
            Assert.IsTrue(list.InsertAfter(5, 3));

            Assert.AreEqual(3, list.Length());
            Assert.AreEqual(5, list.Head.Value);
            Assert.AreEqual(2, list.Tail.Value);
            Assert.IsNotNull(list.Head.Next);
            Assert.IsNull(list.Head.Previous);
            Assert.IsNull(list.Tail.Next);
            Assert.IsNotNull(list.Tail.Previous);
        }

        [TestMethod]
        public void BiDirectionalLinkedList_InsertBefore_Test()
        {
            // should test all the branches in the code, and all the possible combinations of the list
            // no node
            // one node
            // 2 nodes
            // 3 nodes
        }

        [TestMethod]
        public void BiDirectionalLinkedList_Append_Test()
        {

        }

        [TestMethod]
        public void BiDirectionalLinkedList_Prepend_Test()
        {

        }

        [TestMethod]
        public void BiDirectionalLinkedList_Search_Test()
        {

        }

        [TestMethod]
        public void BiDirectionalLinkedList_Delete_Test()
        {

        }
    }
}
