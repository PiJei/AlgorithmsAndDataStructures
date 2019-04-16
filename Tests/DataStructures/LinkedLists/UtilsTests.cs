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
    public class UtilsTests
    {
        [TestMethod]
        public void DeepCopy()
        {
            var alice = new Person("Alice");
            alice.Parent = new Person("Bob");

            var aliceCopy = Utils.DeepCopy(alice);
            /* Making sure after the deep copy the values in the copy are exactly as in the original version. */
            Assert.AreEqual("Alice", aliceCopy.Name, ignoreCase: false);
            Assert.AreEqual("Bob", aliceCopy.Parent.Name, ignoreCase: false);

            /* Changing the values in the copy. The expectation is that the values in the original object should not change. */
            aliceCopy.Name = "Barbara";
            aliceCopy.Parent = new Person("Ted");

            /* Expects the original object to be as it was initialized. */
            Assert.AreEqual("Alice", alice.Name, ignoreCase: false);
            Assert.AreEqual("Bob", alice.Parent.Name, ignoreCase: false);

            /* Expects the copy to have been changed. */
            Assert.AreEqual("Barbara", aliceCopy.Name, ignoreCase: false);
            Assert.AreEqual("Ted", aliceCopy.Parent.Name, ignoreCase: false);
        }

        public class Person
        {
            public string Name { get; set; }
            public Person Parent { get; set; }

            public Person(string name)
            {
                Name = name;
            }

            public Person()
            {

            }
        }
    }
}
