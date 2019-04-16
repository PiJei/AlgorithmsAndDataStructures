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

using CSFundamentals.DataStructures.LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.DataStructures.LinkedLists
{
    [TestClass]
    public class DoublyLinkedNodeTests
    {
        [TestMethod]
        public void IsHead()
        {
            var node = new DoublyLinkedNode<int>(10);
            Assert.IsTrue(node.IsHead());
            node.Next = new DoublyLinkedNode<int>(50);
            Assert.IsTrue(node.IsHead());
            node.Previous = new DoublyLinkedNode<int>(100);
            Assert.IsFalse(node.IsHead());
        }

        [TestMethod]
        public void IsTail()
        {
            var node = new DoublyLinkedNode<int>(10);
            Assert.IsTrue(node.IsTail());
            node.Previous = new DoublyLinkedNode<int>(100);
            Assert.IsTrue(node.IsTail());
            node.Next = new DoublyLinkedNode<int>(50);
            Assert.IsFalse(node.IsTail());
        }
    }
}
