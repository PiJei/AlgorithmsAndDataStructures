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
    public partial class MergeSort
    {
        /// <summary>
        /// Implements a basic version of merge sort recursively. 
        /// </summary>
        /// <param name="values">Specifies the list of integer values to be sorted. </param>
        /// <param name="lowIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="highIndex">Specifies the higher index in the array, inclusive. </param>
        public static void Sort_Recursively(List<Element> values, int lowIndex, int highIndex)
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
        public static void Merge(List<Element> values, int lowIndex, int middleIndex, int highIndex)
        {
            //Making a copy of the values
            List<Element> valuesOriginal = new List<Element>(values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                valuesOriginal.Add(new Element(values[i]));
            }

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
                if (valuesOriginal[leftHalfCounter].Value <= valuesOriginal[rightHalfCounter].Value) /* Favors left half values over right half values when there are duplicates. */
                {
                    valuesOriginal[leftHalfCounter].Move(mainArrayCounter);
                    values[mainArrayCounter] = valuesOriginal[leftHalfCounter];
                    leftHalfCounter++;
                }
                else if (valuesOriginal[leftHalfCounter].Value > valuesOriginal[rightHalfCounter].Value)
                {
                    valuesOriginal[rightHalfCounter].Move(mainArrayCounter);
                    values[mainArrayCounter] = valuesOriginal[rightHalfCounter];
                    rightHalfCounter++;
                }
                mainArrayCounter++;
            }

            while (leftHalfCounter <= high1)
            {
                valuesOriginal[leftHalfCounter].Move(mainArrayCounter);
                values[mainArrayCounter] = valuesOriginal[leftHalfCounter];
                leftHalfCounter++;
                mainArrayCounter++;
            }

            while (rightHalfCounter <= high2)
            {
                valuesOriginal[rightHalfCounter].Move(mainArrayCounter);
                values[mainArrayCounter] = valuesOriginal[rightHalfCounter];
                rightHalfCounter++;
                mainArrayCounter++;
            }
        }

        /// <summary>
        /// This is to be able to call MergeSort sort methods with only the list that needs to be sorted, and independet of the indexes. 
        /// This is needed for methods that receive other sort methods as parameters, and would ideally like to have similar signature for all the methods that are passed as parameters, 
        /// In sort methods the signature is: void SortMethod(List<int> values); 
        /// </summary>
        /// <param name="values">Specifies the list of integers to be sorted. </param>
        public static void MergeSort_Recursively_Wrapper(List<Element> values)
        {
            Sort_Recursively(values, 0, values.Count - 1);
        }
    }
}
