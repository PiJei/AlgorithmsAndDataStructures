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
using System;
using System.Collections.Generic;

namespace CSFundamentals.Algorithms.Search
{
    public class HashTableSearch
    {
        // TODO: Implement 
        [Algorithm(AlgorithmType.Search, "HashTable")]
        [SpaceComplexity("O(n)", InPlace = false)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)", When = "All the elements are mapped to the same key (for example due to lots of conflicts in the hashing method).")]
        [TimeComplexity(Case.Average, "O(1)")]
        public static int Search(List<int> values, int searchValue)
        {
            throw new NotImplementedException();
        }
    }
}
