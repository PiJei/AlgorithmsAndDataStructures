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

namespace CSFundamentals.Algorithms.Sort
{
    public partial class BubbleSort
    {
        /// <summary>
        /// Implements bubble sort iteratively, elements are bubbled down or up the array till they are at their final correct positions. 
        /// </summary>
        /// <param name="values">Specifies the list of values (of type T, e.g., int) to be sorted.</param>
        [Algorithm(AlgorithmType.Sort, "BubbleSort")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(n)", When = "Input array is already sorted.")]
        [TimeComplexity(Case.Worst, "O(n²)")]
        [TimeComplexity(Case.Average, "O(n²)")]
        public static void Sort_Iterative<T>(List<T> values) where T : IComparable<T>
        {
            /* Bubble sort iterates many times over an array, and stops iterating when no swap happens any more. */
            while (true)
            {
                bool swapHappened = false;
                for (int i = 0; i < values.Count - 1; i++)
                {
                    if (values[i + 1].CompareTo(values[i]) < 0)
                    {
                        Utils.Swap(values, i + 1, i);
                        swapHappened = true;
                    }
                }
                if (!swapHappened) /* If no swap happened in this pass, then the array is sorted. Break out of the loop. */
                {
                    break;
                }
            }
        }

        public static void Sort_Recursive(List<int> values)
        {
            throw new NotImplementedException();
        }
    }
}
