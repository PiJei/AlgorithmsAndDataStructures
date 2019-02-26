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

// TODO Make all sorting algorithms generic

namespace CSFundamentalAlgorithms.Sort
{
    public partial class MergeSort
    {
        /// <summary>
        /// Implements a basic version of merge sort recursively. 
        /// </summary>
        /// <param name="values">Specifies the list of integer values to be sorted. </param>
        /// <param name="startIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="endIndex">Specifies the higher index in the array, inclusive. </param>
        [Algorithm("Sort", "MergeSort")]
        public static void Sort_Recursively<T>(List<T> values, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (startIndex < endIndex)
            {
                int middleIndex = (startIndex + endIndex) / 2;
                Sort_Recursively(values, startIndex, middleIndex);
                Sort_Recursively(values, middleIndex + 1, endIndex);
                Merge(values, startIndex, middleIndex, endIndex);
            }
        }

        /// <summary>
        /// Merges two sub arrays [startIndex, middleIndex], [middleIndex+1, endIndex] such to end up with a sorted list. 
        /// </summary>
        /// <param name="values">Specifies the list of integer values to be sorted. </param>
        /// <param name="startIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="middleIndex">Specifies the middle index of the array. </param>
        /// <param name="endIndex">Specifies the higher index in the array, inclusive. </param>
        public static void Merge<T>(List<T> values, int startIndex, int middleIndex, int endIndex) where T : IComparable<T>
        {
            //Making a copy of the values
            List<T> valuesOriginal = new List<T>(values);

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
                    values[mainArrayCounter] = valuesOriginal[leftHalfCounter];
                    leftHalfCounter++;
                }
                else
                {
                    values[mainArrayCounter] = valuesOriginal[rightHalfCounter];
                    rightHalfCounter++;
                }
                mainArrayCounter++;
            }

            while (leftHalfCounter <= end1)
            {
                values[mainArrayCounter] = valuesOriginal[leftHalfCounter];
                leftHalfCounter++;
                mainArrayCounter++;
            }

            while (rightHalfCounter <= end2)
            {
                values[mainArrayCounter] = valuesOriginal[rightHalfCounter];
                rightHalfCounter++;
                mainArrayCounter++;
            }
        }

        /// <summary>
        /// Provides an iterative version for MergeSort. 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public static void Sort_Iteratively(List<int> values, int startIndex, int endIndex)
        {
            throw new NotImplementedException();
        }
    }
}
