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
using CSFundamentalAlgorithms.StringDataStructures;
using System.Collections.Generic;

namespace CSFundamentalAlgorithmsTests.StringDataStructuresTests
{
    [TestClass]
    public class SuffixArrayTests
    {
        [TestMethod]
        public void StringSuffix_SortSuffixes_Test()
        {
            List<StringSuffix> suffixes = new List<StringSuffix>();
            suffixes.Add(new StringSuffix(0, 'b', 'a'));
            suffixes.Add(new StringSuffix(1, 'a', 'n'));
            suffixes.Add(new StringSuffix(2, 'n', 'a'));
            suffixes.Add(new StringSuffix(3, 'a', 'n'));
            suffixes.Add(new StringSuffix(4, 'n', 'a'));
            suffixes.Add(new StringSuffix(5, 'a', '\0'));

        }
    }
}
