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

namespace CSFundamentalAlgorithms.SortingAlgorithms
{
    public class SelectionSort
    {
        /// <summary>
        /// Implements selection sort, which is in-situ and unstable, and at each step, the array would look as one sorted part, and one unsorted part. 
        /// </summary>
        /// <param name="values">Specifies the list of integers that are to be sorted.</param>
        public static void SelectionSort_Iteratively(List<int> values)
        {
            /*Notice that the loop does not have to repeat over the last element of the array, as by then the last element is already the largest element in the array.*/
            for (int i = 0; i < values.Count - 1; i++) /* Iteration i, determines the ith smallest/min value. */
            {
                int minIndex = i;
                for (int j = i; j < values.Count; j++) /* This loop finds an element in the un-sorted part of the array that is smaller than the current value at index i. */
                {
                    if (values[j] < values[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Common.Swap(values, i, minIndex); /* Eventhough if minIndex has not changed, the swap happens. Can be made efficient by adding an if check. */
            }
        }
    }
}
