#region copyright
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
#endregion
using System;
using System.Collections.Generic;
using CSFundamentals.Decoration;

namespace CSFundamentals.Algorithms.Sort
{
    /// <summary>
    /// Implements Bubble sort algorithm. 
    /// </summary>
    public partial class BubbleSort
    {
        /// <summary>
        /// Implements bubble sort iteratively, elements are bubbled down or up the array till they are at their final correct positions. 
        /// </summary>
        /// <param name="list">The list of values (of type T, e.g., int) to be sorted.</param>
        [Algorithm(AlgorithmType.Sort, "BubbleSort")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(n)", When = "Input array is already sorted.")]
        [TimeComplexity(Case.Worst, "O(n²)")]
        [TimeComplexity(Case.Average, "O(n²)")]
        public static void Sort_Iterative<T>(List<T> list) where T : IComparable<T>
        {
            /* Bubble sort iterates many times over an array, and stops iterating when no swap happens any more. */
            while (true)
            {
                bool swapHappened = false;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (list[i + 1].CompareTo(list[i]) < 0)
                    {
                        Utils.Swap(list, i + 1, i);
                        swapHappened = true;
                    }
                }
                if (!swapHappened) /* If no swap happened in this pass, then the array is sorted. Break out of the loop. */
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Is the recursive version of Bubble sort.
        /// </summary>
        /// <param name="list"></param>
        public static void Sort_Recursive(List<int> list)
        {
            throw new NotImplementedException();
        }
    }
}
