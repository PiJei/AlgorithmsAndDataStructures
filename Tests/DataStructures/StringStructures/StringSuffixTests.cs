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
using AlgorithmsAndDataStructures.DataStructures.StringStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.StringStructures
{
    /// <summary>
    /// Tests methods in <see cref="StringSuffix"/> class.
    /// </summary>
    [TestClass]
    public class StringSuffixTests
    {
        /// <summary>
        /// Tests the correctness of comparison operation. 
        /// </summary>
        [TestMethod]
        public void CompareTo()
        {
            var suffix1 = new StringSuffix(0, 'a', 'b');
            var suffix2 = new StringSuffix(0, 'a', 'b');
            Assert.AreEqual(0, suffix1.CompareTo(suffix2));

            var suffix3 = new StringSuffix(0, 'a', 'c');
            Assert.AreEqual(-1, suffix1.CompareTo(suffix3));
            Assert.AreEqual(-1, suffix2.CompareTo(suffix3));
            Assert.AreEqual(1, suffix3.CompareTo(suffix1));
            Assert.AreEqual(1, suffix3.CompareTo(suffix2));

            var suffix4 = new StringSuffix(0, 'b', 'd');
            Assert.AreEqual(1, suffix4.CompareTo(suffix1));
            Assert.AreEqual(1, suffix4.CompareTo(suffix2));
            Assert.AreEqual(1, suffix4.CompareTo(suffix3));
            Assert.AreEqual(-1, suffix1.CompareTo(suffix4));
            Assert.AreEqual(-1, suffix2.CompareTo(suffix4));
            Assert.AreEqual(-1, suffix3.CompareTo(suffix4));

            Assert.IsTrue(suffix1 == suffix2);
            Assert.IsTrue(suffix1 != suffix3);
            Assert.IsTrue(suffix1 != suffix4);

            Assert.IsTrue(suffix1 < suffix3);
            Assert.IsTrue(suffix1 <= suffix3);

            Assert.IsTrue(suffix4 > suffix3);
            Assert.IsTrue(suffix4 >= suffix3);
        }
    }
}
