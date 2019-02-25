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

namespace CSFundamentalAlgorithms.SortingAlgorithms
{
    public partial class MergeSort
    {
        /// <summary>
        /// Implements a basic version of merge sort recursively. 
        /// </summary>
        /// <param name="values">Specifies the list of integer values to be sorted. </param>
        /// <param name="lowIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="highIndex">Specifies the higher index in the array, inclusive. </param>
        [Algorithm("Sort", "MergeSort")]
        public static void Sort_Recursively<T>(List<T> values, int lowIndex, int highIndex) where T : IComparable<T>
        {
            if (lowIndex < highIndex)
            {
                int middleIndex = (lowIndex + highIndex) / 2;
                Sort_Recursively(values, lowIndex, middleIndex);
                Sort_Recursively(values, middleIndex + 1, highIndex);
                Merge(values, lowIndex, middleIndex, highIndex);
            }
        }

        /// <summary>
        /// Merges two sub arrays [lowIndex, middleIndex], [middleIndex+1, highIndex] such to end up with a sorted list. 
        /// </summary>
        /// <param name="values">Specifies the list of integer values to be sorted. </param>
        /// <param name="lowIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="middleIndex">Specifies the middle index of the array. </param>
        /// <param name="highIndex">Specifies the higher index in the array, inclusive. </param>
        public static void Merge<T>(List<T> values, int lowIndex, int middleIndex, int highIndex) where T : IComparable<T>
        {
            //Making a copy of the values
            List<T> valuesOriginal = new List<T>(values);

            //Inclusive boundaries of the first sub-array
            int low1 = lowIndex;
            int high1 = middleIndex;

            //Inclusive boundaries of the second sub-array
            int low2 = middleIndex + 1;
            int high2 = highIndex;

            // Pointer on the first (left) sub-array
            int leftHalfCounter = low1;

            // Pointer on the second (right) sub-array
            int rightHalfCounter = low2;

            // Pointer on the Values array.
            int mainArrayCounter = low1;

            while (leftHalfCounter <= high1 && rightHalfCounter <= high2)
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

            while (leftHalfCounter <= high1)
            {
                values[mainArrayCounter] = valuesOriginal[leftHalfCounter];
                leftHalfCounter++;
                mainArrayCounter++;
            }

            while (rightHalfCounter <= high2)
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
        /// <param name="lowIndex"></param>
        /// <param name="highIndex"></param>
        public static void Sort_Iteratively(List<int> values, int lowIndex, int highIndex)
        {
            // TODO 
        }
    }
}
