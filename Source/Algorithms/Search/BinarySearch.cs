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

using System.Collections.Generic;
using CSFundamentals.Styling;

namespace CSFundamentals.Algorithms.Search
{
    public class BinarySearch
    {
        /// <summary>
        /// Searches in a sorted list of integers, and returns the index of the searchValue using binary search, and -1 if it is not found. 
        /// </summary>
        /// <param name="values">A sorted list of integers. </param>
        /// <param name="startIndex">Specifies the lowest (left-most) index of the array - inclusive. </param>
        /// <param name="endIndex">Specifies the highest (right-most) index of the array - inclusive. </param>
        /// <param name="searchValue">Specifies the value that is being searched for. </param>
        /// <returns>The index of the searchValue in the array values, and -1 if it does not exist in the array. </returns>
        [Algorithm(AlgorithmType.Search, "BinarySearch")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)", When = "Tree is imbalanced such that it is one sequential branch, every node except the leaf having exactly one child.")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        public static int Search(List<int> values, int startIndex, int endIndex, int searchValue)
        {
            if (startIndex <= endIndex && searchValue >= values[startIndex] && searchValue <= values[endIndex])
            {
                int middleIndex = (startIndex + endIndex) / 2;
                int middleValue = values[middleIndex];

                if (searchValue == middleValue)
                {
                    return middleIndex;
                }
                if (searchValue < middleValue)
                {
                    return Search(values, startIndex, middleIndex - 1, searchValue);
                }
                if (searchValue > middleValue)
                {
                    return Search(values, middleIndex + 1, endIndex, searchValue);
                }
            }
            return -1;
        }
    }
}
