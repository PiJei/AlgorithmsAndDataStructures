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
using CSFundamentalAlgorithms.Sort.StabilityCheckableVersions;

namespace CSFundamentalAlgorithms.Sort
{
    public partial class SelectionSort
    {
        public static void Sort_Iteratively(List<Element> values)
        {
            /*Notice that the loop does not have to repeat over the last element of the array, as by then the last element is already the largest element in the array.*/
            for (int i = 0; i < values.Count - 1; i++) /* Iteration i, determines the i-th smallest/min value. */
            {
                int minIndex = i;
                for (int j = i; j < values.Count; j++) /* This loop finds an element in the unsorted part of the array that is smaller than the current value at index i. */
                {
                    if (values[j].Value < values[minIndex].Value)
                    {
                        minIndex = j;
                    }
                }
                Utils.Swap(values, i, minIndex); /* Even though if minIndex has not changed, the swap happens. Can be made efficient by adding an if check. */
            }
        }
    }
}
