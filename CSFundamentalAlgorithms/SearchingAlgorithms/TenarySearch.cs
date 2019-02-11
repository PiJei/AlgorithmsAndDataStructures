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

using System;
using System.Collections.Generic;
using System.Text;

namespace CSFundamentalAlgorithms.SearchingAlgorithms
{
    public class TenarySearch
    {
        /// <summary>
        /// Implements tenary search recursively on a list of integeres. 
        /// This search is inspired by binary search (hence the naming, 3 versus 2).
        /// The difference being that rather than dividing the array into 2 sections, divides it into 3 equal sections and performs the search inside each one of those separately.
        /// </summary>
        /// <param name="values">A sorted list of integeres. </param>
        /// <param name="lowIndex">Specifies the lowest (left-most) index of the array - inclusive. </param>
        /// <param name="highIndex">Specifies the highest (right-most) index of the array - inclusive. </param>
        /// <param name="searchValue">Specifies the value that is being searched for. </param>
        /// <returns>The index of the searchValue in the array values, and -1 if it does not exist in the array. </returns>
        public static int Search(List<int> values, int lowIndex, int highIndex, int searchValue)
        {
            if (lowIndex <= highIndex)
            {
                /* Dividing array by ((highIndex - lowIndex) / 3) size in2o 3 sections. */
                int middleIndex1 = lowIndex + (highIndex - lowIndex) / 3;
                int middleIndex2 = middleIndex1 + (highIndex - lowIndex) / 3;

                int middleValue1 = values[middleIndex1];
                int middleValue2 = values[middleIndex2];

                if (searchValue == middleValue1)
                {
                    return middleIndex1;
                }

                if (searchValue == middleValue2)
                {
                    return middleIndex2;
                }

                if (searchValue < middleValue1)
                {
                    return Search(values, lowIndex, middleIndex1 - 1, searchValue);
                }

                if (searchValue > middleValue1 && searchValue < middleValue2)
                {
                    return Search(values, middleIndex1 + 1, middleIndex2 - 1, searchValue);
                }

                if (searchValue > middleValue2)
                {
                    return Search(values, middleIndex2 + 1, highIndex, searchValue);
                }
            }
            return -1;
        }
    }
}
