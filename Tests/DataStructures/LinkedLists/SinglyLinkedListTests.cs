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
    public class SinglyLinkedListTests
    {
        [TestMethod]
        public void Insert()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            Assert.AreEqual(0, list.Count());

            /* Inserting into an empty list. */
            Assert.IsTrue(list.Insert(10));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(10, list.Head().Value);
            Assert.IsNull(list.Head().Next);

            /* Inserting into a list with one node. */
            Assert.IsTrue(list.Insert(10)); /* Checking duplicates. The current implementation allows duplicates. */
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(10, list.Head().Value);
            Assert.IsNotNull(list.Head().Next);

            /*Inserting into a list with 2 nodes. */
            Assert.IsTrue(list.Insert(5)); 
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(5, list.Head().Value);
            Assert.IsNotNull(list.Head().Next);
        }

        [TestMethod]
        public void Delete()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            Assert.AreEqual(0, list.Count());

            /* Deleting an item from an empty list. */
            Assert.IsFalse(list.Delete(10));

            /* Deleting a non-existing item from a list with one element. */
            list.Insert(5);
            Assert.AreEqual(1, list.Count());
            Assert.IsFalse(list.Delete(10));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(5, list.Head().Value);

            /* Deleting the only node from the list (aka. Head).*/
            Assert.AreEqual(1, list.Count());
            Assert.IsTrue(list.Delete(5));
            Assert.AreEqual(0, list.Count());
            Assert.IsNull(list.Head());

            /*Deleting a non-existing item from a list with 2 items. */
            var head = new SinglyLinkedNode<int>(5);
            head.Next = new SinglyLinkedNode<int>(10);
            list = new SinglyLinkedList<int>(head);

            Assert.AreEqual(2, list.Count());
            Assert.IsFalse(list.Delete(16));
            Assert.AreEqual(2, list.Count());

            /*Deleting an existing item from a list with 2 items*/
            Assert.AreEqual(2, list.Count());
            Assert.IsTrue(list.Delete(5));
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(10, list.Head().Value);
            Assert.IsNull(list.Head().Next);

            /* Deleting head from a list with 3 nodes.*/
            head = new SinglyLinkedNode<int>(10);
            head.Next = new SinglyLinkedNode<int>(3);
            head.Next.Next = new SinglyLinkedNode<int>(1);
            list = new SinglyLinkedList<int>(head);
            Assert.AreEqual(3, list.Count());
            Assert.IsTrue(list.Delete(10));
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(3, list.Head().Value);
        }
    }
}
