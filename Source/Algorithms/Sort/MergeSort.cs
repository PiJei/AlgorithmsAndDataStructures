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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Decoration;

// TODO Make all sorting algorithms generic

namespace AlgorithmsAndDataStructures.Algorithms.Sort
{
    /// <summary>
    /// Implements Merge sort algorithm. 
    /// </summary>
    public partial class MergeSort
    {
        /// <summary>
        /// Implements merge sort recursively. 
        /// </summary>
        /// <param name="list">The list of values (of type T, e.g., int) to be sorted. </param>
        /// <param name="startIndex">The lower index in the list, inclusive. </param>
        /// <param name="endIndex">The higher index in the list, inclusive. </param>
        [Algorithm(AlgorithmType.Sort, "MergeSort")]
        [SpaceComplexity("O(n)", InPlace = false)]
        [TimeComplexity(Case.Best, "O(nLog(n))")]
        [TimeComplexity(Case.Worst, "O(nLog(n))")]
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        public static void Sort<T>(List<T> list, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (startIndex < endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                Sort(list, startIndex, middleIndex);
                Sort(list, middleIndex + 1, endIndex);
                Merge(list, startIndex, middleIndex, endIndex);
            }
        }

        /// <summary>
        /// Merges two sub-lists [startIndex, middleIndex], [middleIndex+1, endIndex] such to end up with a sorted list. 
        /// </summary>
        /// <param name="list">The list of values (of type T, e.g., int) to be sorted. </param>
        /// <param name="startIndex">The lower index in the list, inclusive. </param>
        /// <param name="middleIndex">The middle index of the list. </param>
        /// <param name="endIndex">The higher index in the list, inclusive. </param>
        public static void Merge<T>(List<T> list, int startIndex, int middleIndex, int endIndex) where T : IComparable<T>
        {
            //Making a copy of the list
            var listCopy = new List<T>(list); /* This is where the extra space complexity of O(n) for merge sort comes from. */

            //Inclusive boundaries of the first sub-list
            int start1 = startIndex;
            int end1 = middleIndex;

            //Inclusive boundaries of the second sub-list
            int start2 = middleIndex + 1;
            int end2 = endIndex;

            // Pointer on the first (left) sub-list
            int leftHalfPointer = start1;

            // Pointer on the second (right) sub-list
            int rightHalfPointer = start2;

            // Pointer on the main list
            int listPointer = start1;

            while (leftHalfPointer <= end1 && rightHalfPointer <= end2)
            {
                if (listCopy[leftHalfPointer].CompareTo(listCopy[rightHalfPointer]) <= 0) /* Favors left half values over right half values when there are duplicates thus checking for equality as well. */
                {
                    list[listPointer] = listCopy[leftHalfPointer];
                    leftHalfPointer++;
                }
                else
                {
                    list[listPointer] = listCopy[rightHalfPointer];
                    rightHalfPointer++;
                }
                listPointer++;
            }

            while (leftHalfPointer <= end1)
            {
                list[listPointer] = listCopy[leftHalfPointer];
                leftHalfPointer++;
                listPointer++;
            }

            while (rightHalfPointer <= end2)
            {
                list[listPointer] = listCopy[rightHalfPointer];
                rightHalfPointer++;
                listPointer++;
            }
        }
    }
}
