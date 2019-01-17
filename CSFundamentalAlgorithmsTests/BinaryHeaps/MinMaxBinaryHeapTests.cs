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
 * along with CSFundamentalAlgorithms.  If not, see <http://www.gnu.org/licenses/>.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CSFundamentalAlgorithms.BinaryHeaps;

namespace CSFundamentalAlgorithmsTests.BinaryHeaps
{
    [TestClass]
    public class MinMaxBinaryHeapTests
    {
        [TestMethod]
        public void MinMaxBinaryHeap_BuildHeapRecursively_Test1()
        {
            List<int> values = new List<int> { 70, 21, 220, 10, 1, 34, 3, 150, 85 };
            var heap = new MinMaxBinaryHeap(values);
            heap.BuildHeap_Recursively();

            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(70))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(21))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(220))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(10))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(1))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(34))));
            Assert.IsTrue(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(3))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(150))));
            Assert.IsFalse(heap.IsMinLevel(heap.GetNodeLevel(values.IndexOf(85))));
        }
    }
}
