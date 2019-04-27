#region copyright
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
#endregion
using CSFundamentals.Algorithms.Hashing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.Hashing
{
    [TestClass]
    public class RollingHashTests
    {
        private const int NumCharactersInAlphabet = 256;
        private const int Prime = 101;

        [TestMethod]
        public void Hash()
        {
            string s1 = "abc";
            Assert.AreEqual(90, RollingHash.GetHash(s1, Prime, NumCharactersInAlphabet));

            string s2 = "bcd";
            Assert.AreEqual(31, RollingHash.GetHash(s2, Prime, NumCharactersInAlphabet));

            /*Note that:  string s = "abcd"; // Hash(bcd) = Hash(abc) - hash (a) + hash(d) */

            int hashConstant = RollingHash.ComputeHashConstantForRollingHash(3, Prime, NumCharactersInAlphabet);

            // Assuming we are rolling the hash window over string s above. 
            Assert.AreEqual(31, RollingHash.GetHashRollingForward(90, 'a', 'd', 3, hashConstant, Prime, NumCharactersInAlphabet));
        }
    }
}
