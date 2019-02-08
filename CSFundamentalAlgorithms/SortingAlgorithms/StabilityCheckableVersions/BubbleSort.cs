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
using CSFundamentalAlgorithms.SortingAlgorithms.StabilityCheckableVersions;

namespace CSFundamentalAlgorithms.SortingAlgorithms
{
    public partial class BubbleSort
    {
        /// <summary>
        /// Implements bubble sort iteraively, elements are bubbled down or up the array till they are at their final correct positions. 
        /// </summary>
        /// <param name="values"></param>
        public static void Sort_Iterative(List<Element> values)
        {
            /* Bubble sort iterates many times over an array, and stops iterating when no swap happens any more. */
            while (true)
            {
                bool swapHappened = false;
                for (int i = 0; i < values.Count - 1; i++)
                {
                    if (values[i + 1].Value < values[i].Value)
                    {
                        Utils.Swap(values, i + 1, i);
                        swapHappened = true;
                    }
                    values[i].Move(i);
                }
                if (!swapHappened) /* If no swap happened in this pass, then the array is sorted. break out of the loop. */
                {
                    break;
                }
            }
        }
    }
}
