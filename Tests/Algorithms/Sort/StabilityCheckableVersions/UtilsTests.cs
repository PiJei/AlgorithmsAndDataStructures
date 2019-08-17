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
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Sort;
using AlgorithmsAndDataStructures.Algorithms.Sort.StabilityCheckableVersions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.Algorithms.Sort
{
    /// <summary>
    /// Tests methods in <see cref="Utils"/> class. 
    /// </summary>
    [TestClass]
    public partial class UtilsTests
    {
        /// <summary>
        /// Tests the correctness of converting a list of integers to a list of Elements. 
        /// </summary>
        [TestMethod]
        public void Convert()
        {
            var values = new List<int>() { 4, 3, 2, 4, 1 };
            List<Element> newValues = Utils.Convert(values);
            Assert.AreEqual(newValues.Count, values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                Assert.AreEqual(values[i], newValues[i].Value);
                Assert.AreEqual(i, newValues[i].FirstListIndex);
                Assert.AreEqual(i, newValues[i].LatestListIndex);
            }
        }

        /// <summary>
        /// Tests the correctness of checking whether a dictionary is stable. 
        /// </summary>
        [TestMethod]
        public void IsMapStable()
        {
            var element1 = new Element(4, 0);
            element1.Move(4);

            var element2 = new Element(4, 3);
            element2.Move(3);

            var map = new Dictionary<Element, List<Element>>
            {
                [element1] = new List<Element> { element1, element2 }
            };

            Assert.IsFalse(Utils.IsMapStable(map));

            element1.Move(3);
            element2.Move(4);

            Assert.IsTrue(Utils.IsMapStable(map));
        }

        /// <summary>
        /// Tests the correctness of hashing a list to indexes. 
        /// </summary>
        [TestMethod]
        public void HashListToIndexes()
        {
            Dictionary<Element, List<Element>> map = Utils.HashListToIndexes(null);
            Assert.AreEqual(0, map.Keys.Count);

            var element1 = new Element(4, 0);
            var element2 = new Element(2, 1);
            var element3 = new Element(3, 2);
            var element4 = new Element(4, 3);
            var element5 = new Element(1, 4);

            var values1 = new List<Element> {
                element1,
                element2,
                element3,
                element4,
                element5
            };

            Dictionary<Element, List<Element>> map1 = Utils.HashListToIndexes(values1);

            Assert.AreEqual(4, map1.Keys.Count);
            Assert.AreEqual(2, map1[element1].Count);
            Assert.AreEqual(0, map1[element1][0].FirstListIndex);
            Assert.AreEqual(3, map1[element1][1].FirstListIndex);

            Assert.AreEqual(1, map1[element2][0].FirstListIndex);
            Assert.AreEqual(2, map1[element3][0].FirstListIndex);
            Assert.AreEqual(4, map1[element5][0].FirstListIndex);
        }

        /// <summary>
        /// Tests the correctness of swap operation. 
        /// </summary>
        [TestMethod]
        public void Swap()
        {
            var values = new List<Element>();
            var element1 = new Element(10, 0);
            var element2 = new Element(5, 1);
            var element3 = new Element(16, 2);
            var element4 = new Element(3, 3);
            values.Add(element1);
            values.Add(element2);
            values.Add(element3);
            values.Add(element4);

            Utils.Swap(values, 0, 2);

            Assert.AreEqual(10, values[2].Value);
            Assert.AreEqual(0, values[2].FirstListIndex);
            Assert.AreEqual(2, values[2].LatestListIndex);

            Assert.AreEqual(16, values[0].Value);
            Assert.AreEqual(2, values[0].FirstListIndex);
            Assert.AreEqual(0, values[0].LatestListIndex);

            Utils.Swap(values, 0, 3);

            Assert.AreEqual(3, values[0].Value);
            Assert.AreEqual(3, values[0].FirstListIndex);
            Assert.AreEqual(0, values[0].LatestListIndex);

            Assert.AreEqual(16, values[3].Value);
            Assert.AreEqual(2, values[3].FirstListIndex);
            Assert.AreEqual(3, values[3].LatestListIndex);
        }
    }
}
