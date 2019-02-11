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

using System.Collections.Generic;

namespace CSFundamentalAlgorithms.SearchingAlgorithms
{
    public class InterpolationSearch
    {
        /// <summary>
        /// Searches in a sorted list of integeres where values have a uniform distribution. Is an improvement over binary search, and has a very similar implementation, the only main difference is where (which index in the array) the search starts at.
        /// The search is named inter-polation, as it always has two main poles that it moves back and forth between them, these poles are the start index and the end index of the array. 
        /// Notice that only works if the given array is sorted. 
        /// </summary>
        /// <param name="values">A sorted list of integeres that are also uniformly distributed. </param>
        /// <param name="lowIndex">Specifies the lowest (left-most) index of the array - inclusive. </param>
        /// <param name="highIndex">Specifies the highest (right-most) index of the array - inclusive. </param>
        /// <param name="searchValue">Specifies the value that is being searched for. </param>
        /// <returns>The index of the searchValue in the array values, and -1 if it does not exist in the array. </returns>
        public static int Search(List<int> values, int lowIndex, int highIndex, int searchValue)
        {
            if (lowIndex <= highIndex && searchValue >= values[lowIndex] && searchValue <= values[highIndex])
            {
                int searchStartIndex = GetSearchStartingIndex(values, lowIndex, highIndex, searchValue);
                if (!(searchStartIndex >= lowIndex && searchStartIndex <= highIndex))
                {
                    return -1;
                }

                int searchStartValue = values[searchStartIndex];

                if (searchValue == searchStartValue)
                {
                    return searchStartIndex;
                }

                if (searchValue < searchStartValue)
                {
                    return Search(values, lowIndex, searchStartIndex - 1, searchValue);
                }

                if (searchValue > searchStartValue)
                {
                    return Search(values, searchStartIndex + 1, highIndex, searchValue);
                }
            }

            return -1;
        }

        /// <summary>
        /// Computes an index to start the search from. Dependent on the value we are after. 
        /// This formula is such that if the search value is closer to the value in the lower index, the search start point will be chosen closer to the lowIndex, and if the search value is closer to the value in the high index, the search start point will be chosen closer to the highIndex.
        /// </summary>
        /// <param name="values">A sorted list of integeres that are also uniformly distributed. </param>
        /// <param name="lowIndex">Specifies the lowest (left-most) index of the array - inclusive. </param>
        /// <param name="highIndex">Specifies the highest (right-most) index of the array - inclusive. </param>
        /// <param name="searchValue">Specifies the value that is being searched for. </param>
        /// <returns>The index in the array at which to start the search. </returns>
        public static int GetSearchStartingIndex(List<int> values, int lowIndex, int highIndex, int searchValue)
        {
            double distanceFromLowIndex = (double)(searchValue - values[lowIndex]) / (double)(values[highIndex] - values[lowIndex]);
            distanceFromLowIndex = distanceFromLowIndex * (highIndex - lowIndex);
            int index = (int)(lowIndex + distanceFromLowIndex);
            return index;
        }

        // TODO: Implement using binary search, ... where the location of the array is computed by a method, which I will pass here: 
        // also means that I can make a parent class for all the search algorithms, and enforce them to implment their own find the next search position

        // TODO: Implement iterative versions and recursive versions for each search algorithm.. 

        // TODO: Implement methods to count the number of elements each search algorithm checks before finding a value and measure it in average?
    }
}
