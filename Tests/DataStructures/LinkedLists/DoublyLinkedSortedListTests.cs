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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals.DataStructures.LinkedLists;

namespace CSFundamentalsTests.DataStructures.LinkedLists
{
    [TestClass]
    public class DoublyLinkedSortedListTests
    {
        [TestMethod]
        public void DoublyLinkedSortedList_Insert_Test_1()
        {
            DoublyLinkedSortedList<int> list = new DoublyLinkedSortedList<int>();
            Assert.AreEqual(0, list.Count());

            /* Testing insert with an empty list. */
            Assert.IsTrue(list.Insert(10));
            Assert.AreEqual(1, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));

            /* Testing insert with a list with 1 node, whereas the new node will replace the head. */
            list.Insert(5);
            Assert.AreEqual(2, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));

            /* Testing insert with a list with 2 nodes, whereas the new node will replace the tail. */
            list.Insert(15);
            Assert.AreEqual(3, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));

            /* Testing insert with a list with 3 nodes, whereas the new node will be at the middle. */
            list.Insert(11);
            Assert.AreEqual(4, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));
        }

        [TestMethod]
        public void DoublyLinkedSortedList_Insert_Test_2()
        {
            DoublyLinkedSortedList<int> list = new DoublyLinkedSortedList<int>();
            Assert.AreEqual(0, list.Count());

            /* Testing insert with an empty list. */
            Assert.IsTrue(list.Insert(5));
            Assert.AreEqual(1, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));

            /* Testing insert with a list with 1 node, whereas the new node will replace the tail. */
            list.Insert(10);
            Assert.AreEqual(2, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));
        }

        [TestMethod]
        public void DoublyLinkedSortedList_Delete_Test()
        {
            DoublyLinkedSortedList<int> list = new DoublyLinkedSortedList<int>();
            Assert.AreEqual(0, list.Count());

            /* Testing delete when list is empty.*/
            Assert.IsFalse(list.Delete(20));
            Assert.AreEqual(0, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));

            /* Testing delete when list has one member, but the value to be deleted does not exist in the list.*/
            list.Insert(10);
            Assert.AreEqual(1, list.Count());
            Assert.IsFalse(list.Delete(20));
            Assert.AreEqual(1, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));

            /* Testing delete when list has one member, and the value to be deleted is that member. */
            Assert.IsTrue(list.Delete(10));
            Assert.AreEqual(0, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));

            /* Testing with deleting head, when list has 2 members. */
            list.Insert(10);
            list.Insert(5);
            Assert.AreEqual(2, list.Count());
            Assert.IsFalse(list.Delete(6));
            Assert.AreEqual(2, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));

            Assert.IsTrue(list.Delete(5));
            Assert.AreEqual(1, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));

            /* Testing with deleting tail, when list has 2 members. */
            list.Insert(5);
            Assert.AreEqual(2, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));

            Assert.IsTrue(list.Delete(10));
            Assert.AreEqual(1, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));

            /* Testing with deleting a node in the middle. */
            list.Insert(10);
            list.Insert(15);
            list.Insert(11);
            Assert.IsTrue(list.Delete(10));
            Assert.AreEqual(3, list.Count());
            Assert.IsTrue(IsSorted(list.Head()));
        }

        public bool IsSorted<T>(DoublyLinkedNode<T> head) where T : IComparable<T>
        {
            var current = head;

            while (current != null && current.Next != null)
            {
                Assert.IsTrue(current.Value.CompareTo(current.Next.Value) <= 0);
                current = current.Next;
            }
            return true;
        }
    }
}
