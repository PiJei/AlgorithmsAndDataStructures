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

using CSFundamentalAlgorithms.Sort.StabilityCheckableVersions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalAlgorithmsTests.SortTests.StabilityCheckableVersionsTests
{
    [TestClass]
    public class ElementTests
    {
        [TestMethod]
        public void Element_Equals_Test()
        {
            Element element1 = new Element(1, 0);
            Assert.IsFalse(element1.Equals(null));

            Element element2 = new Element(1, 3);
            Assert.IsTrue(element1.Equals(element2));
        }

        [TestMethod]
        public void Element_IsStable_Test()
        {
            Element element1 = new Element(1, 0); // Element1: 1, 0, -1
            Element element2 = new Element(2, 0); // Element2: 2, 0, -1

            Assert.IsFalse(element1.IsStable(element2));

            Element element3 = new Element(1, 2); // Element3 : 1, 2, -1 
            Assert.IsFalse(element1.IsStable(element3)); /* Expects false, as newIndex is not decided yet. */

            element1.Move(5); // Element1: 1, 0, 5
            element3.Move(3); // Element3 : 1, 2, 3 
            Assert.IsFalse(element1.IsStable(element3)); /* Expects false, as element3 's old index is bigger but new index is smaller*/

            element3.Move(8); // Element3: 1, 2, 8 
            Assert.IsTrue(element1.IsStable(element3));
        }
    }
}
