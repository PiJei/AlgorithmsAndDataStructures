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
    public class MergeSort
    {
        /// <summary>
        /// Implements a basic version of merge sort recursively. 
        /// </summary>
        /// <param name="values">Specifies the list of integer values to be sorted. </param>
        /// <param name="lowIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="highIndex">Specifies the higher index in the array, inclusive. </param>
        public static void MergeSort_Recursively(List<int> values, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int middleIndex = (lowIndex + highIndex) / 2;
                MergeSort_Recursively(values, lowIndex, middleIndex);
                MergeSort_Recursively(values, middleIndex + 1, highIndex);
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
        public static void Merge(List<int> values, int lowIndex, int middleIndex, int highIndex)
        {
            //Making a copy of the values, to sort in-situ
            List<int> valuesOriginal = new List<int>(values);

            //Inclusive boundries of the first sub-array
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
                if (valuesOriginal[leftHalfCounter] <= valuesOriginal[rightHalfCounter])
                {
                    values[mainArrayCounter] = valuesOriginal[leftHalfCounter];
                    leftHalfCounter++;
                }
                else if (valuesOriginal[leftHalfCounter] > valuesOriginal[rightHalfCounter])
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
        public static void MergeSort_Iteratively(List<int> values, int lowIndex, int highIndex)
        {
            // TODO 
        }
    }
}
