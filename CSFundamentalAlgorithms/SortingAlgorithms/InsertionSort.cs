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
    /// <summary>
    /// This class contains 3 different implementations of Insertion Sort. The sort is called insertion, as at each iteration, it finds the correct position of an element, and "inserts" it in that position. 
    /// </summary>
    public class InsertionSort
    {
        /// <summary>
        /// Implements insertion sort iteratively, and in-situ, using many Swaps.
        /// </summary>
        /// <param name="values">Specifies the list of integers to be sorted. </param>
        public static void InsertionSort_Iterative_V1(List<int> values)
        {
            for (int i = 1; i < values.Count; i++)
            {
                // At each iteration finding the correct position of element (i) and inserting it in the correct position. 
                // Will do so by moving element i, to the left of the array until there is no element to the left of i that is bigger than i
                for (int j = i - 1; j >= 0 && values[j] > values[j + 1]; j--) /* Having the second condition in the code, speeds up the algorithm, as it stops immediately as soon as reaching a point in th graph that element in [j-1] is no longer bigger than element in [j]*/
                {
                    Common.Swap(values, j, j + 1); // meaning that we are moving element at (i) to the left at each step.
                }
            }
        }

        /// <summary>
        /// Implements insertion sort iteratively, and in-situ, using only one swap per element.
        /// </summary>
        /// <param name="values">Specifies the list of integers to be sorted. </param>
        public static void InsertionSort_Iterative_V2(List<int> values)
        {
            // In this version, we will overwite the array location for element (i) by shifting each element to the right if bigger than (i) till finding its correct position
            for (int i = 1; i < values.Count; i++)
            {
                int arrayValueAtIndexI = values[i];
                int correctIndex = i;

                for (int j = i - 1; j >= 0 && values[j] > arrayValueAtIndexI; j--)
                {
                    values[j + 1] = values[j];
                    correctIndex = j;
                }
                
                values[correctIndex] = arrayValueAtIndexI;
            }
        }

        /// <summary>
        /// Implements insertion sort recursively. Iniial call shall be InsertionSort_Recursive(values, values.Count-1);
        /// </summary>
        /// <param name="values">Specifies the list of integers to be sorted. </param>
        public static void InsertionSort_Recursive(List<int> values, int n)
        {
            if (n >= 1) // Similar to iterative versions that we start from 1st helement, and not the one at 0th, as always need to compare to the left. 
            {
                InsertionSort_Recursive(values, n - 1);
                // The rest is exactly the same code in method InsertionSort_Iterative_V2() inside the first for loop. 
                int valueAtPositionN = values[n];
                int correctIndex = n;
                for (int j = n - 1; j >= 0 && values[j] > valueAtPositionN; j--)
                {
                    values[j + 1] = values[j];
                    correctIndex = j;
                }
                values[correctIndex] = valueAtPositionN;
            }
        }
    }
}
