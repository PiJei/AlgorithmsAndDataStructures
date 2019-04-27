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

// TODO Make all sorting algorithms generic

namespace CSFundamentals.Algorithms.Sort
{
    /// <summary>
    /// Implements Merge sort algorithm. 
    /// </summary>
    public partial class MergeSort
    {
        /// <summary>
        /// Implements merge sort recursively. 
        /// </summary>
        /// <param name="list">Specifies the list of values (of type T, e.g., int) to be sorted. </param>
        /// <param name="startIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="endIndex">Specifies the higher index in the array, inclusive. </param>
        [Algorithm(AlgorithmType.Sort, "MergeSort")]
        [SpaceComplexity("O(n)", InPlace = false)]
        [TimeComplexity(Case.Best, "O(nLog(n))")]
        [TimeComplexity(Case.Worst, "O(nLog(n))")]
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        public static void Sort_Recursively<T>(List<T> list, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (startIndex < endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                Sort_Recursively(list, startIndex, middleIndex);
                Sort_Recursively(list, middleIndex + 1, endIndex);
                Merge(list, startIndex, middleIndex, endIndex);
            }
        }

        /// <summary>
        /// Merges two sub arrays [startIndex, middleIndex], [middleIndex+1, endIndex] such to end up with a sorted list. 
        /// </summary>
        /// <param name="list">Specifies the list of values (of type T, e.g., int) to be sorted. </param>
        /// <param name="startIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="middleIndex">Specifies the middle index of the array. </param>
        /// <param name="endIndex">Specifies the higher index in the array, inclusive. </param>
        public static void Merge<T>(List<T> list, int startIndex, int middleIndex, int endIndex) where T : IComparable<T>
        {
            //Making a copy of the values
            var valuesOriginal = new List<T>(list); /* This is where the extra space complexity of O(n) for merge sort comes from. */

            //Inclusive boundaries of the first sub-array
            int start1 = startIndex;
            int end1 = middleIndex;

            //Inclusive boundaries of the second sub-array
            int start2 = middleIndex + 1;
            int end2 = endIndex;

            // Pointer on the first (left) sub-array
            int leftHalfCounter = start1;

            // Pointer on the second (right) sub-array
            int rightHalfCounter = start2;

            // Pointer on the Values array.
            int mainArrayCounter = start1;

            while (leftHalfCounter <= end1 && rightHalfCounter <= end2)
            {
                if (valuesOriginal[leftHalfCounter].CompareTo(valuesOriginal[rightHalfCounter]) <= 0) /* Favors left half values over right half values when there are duplicates thus checking for equality as well. */
                {
                    list[mainArrayCounter] = valuesOriginal[leftHalfCounter];
                    leftHalfCounter++;
                }
                else
                {
                    list[mainArrayCounter] = valuesOriginal[rightHalfCounter];
                    rightHalfCounter++;
                }
                mainArrayCounter++;
            }

            while (leftHalfCounter <= end1)
            {
                list[mainArrayCounter] = valuesOriginal[leftHalfCounter];
                leftHalfCounter++;
                mainArrayCounter++;
            }

            while (rightHalfCounter <= end2)
            {
                list[mainArrayCounter] = valuesOriginal[rightHalfCounter];
                rightHalfCounter++;
                mainArrayCounter++;
            }
        }

        /// <summary>
        /// Provides an iterative version for MergeSort. 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public static void Sort_Iteratively(List<int> list, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }
    }
}
