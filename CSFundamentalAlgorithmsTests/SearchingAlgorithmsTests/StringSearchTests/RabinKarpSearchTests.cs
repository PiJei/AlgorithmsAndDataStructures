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
using CSFundamentalAlgorithms.SearchingAlgorithms.StringSearch;

namespace CSFundamentalAlgorithmsTests.SearchingAlgorithmsTests.StringSearchTests
{
    [TestClass]
    public class RabinKarpSearchTests
    {
        [TestMethod]
        public void RabinKarpSearch_GetHash_Test()
        {
            RabinKarpSearch search = new RabinKarpSearch();

            string s1 = "abc";
            Assert.AreEqual(90, search.GetHash(s1));
            string s2 = "bcd";
            Assert.AreEqual(31, search.GetHash(s2));

            string s = "abcd"; /* Hash(bcd) = Hash(abc)- hash (a) + hash(d) */

            Assert.AreEqual(31, search.GetHashRollingForward(90, 'a', 'd', 3));
        }

        [TestMethod]
        public void RabinKarpSearch_Search_Test()
        {
            RabinKarpSearch search1 = new RabinKarpSearch("abcd", "bc");
            Assert.AreEqual(1, search1.Search());

            RabinKarpSearch search2 = new RabinKarpSearch("abcd", "cd");
            Assert.AreEqual(2, search2.Search());
            RabinKarpSearch search3 = new RabinKarpSearch("aaaaaakcdkaaaabcd", "aab");
            Assert.AreEqual(12, search3.Search());
        }
    }
}
