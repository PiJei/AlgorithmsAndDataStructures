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
using System.Collections.Generic;
using CSFundamentals.Algorithms.Sort.StabilityCheckableVersions;

namespace CSFundamentals.Algorithms.Sort
{
    public partial class MergeSort
    {
        /// <summary>
        /// Implements a basic version of merge sort recursively. 
        /// </summary>
        /// <param name="values">Specifies the list of integer values to be sorted. </param>
        /// <param name="startIndex">Specifies the lower index in the array, inclusive. </param>
        /// <param name="endIndex">Specifies the higher index in the array, inclusive. </param>
        public static void Sort_Recursively(List<Element> values, int startIndex, int endIndex)
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
        public static void Merge(List<Element> values, int startIndex, int middleIndex, int endIndex)
        {
            //Making a copy of the values
            var valuesOriginal = new List<Element>(values.Count);
            for (int i = 0; i < values.Count; i++)
            {
                valuesOriginal.Add(new Element(values[i]));
            }

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

            while (leftHalfCounter <= end1)
            {
                valuesOriginal[leftHalfCounter].Move(mainArrayCounter);
                values[mainArrayCounter] = valuesOriginal[leftHalfCounter];
                leftHalfCounter++;
                mainArrayCounter++;
            }

            while (rightHalfCounter <= end2)
            {
                valuesOriginal[rightHalfCounter].Move(mainArrayCounter);
                values[mainArrayCounter] = valuesOriginal[rightHalfCounter];
                rightHalfCounter++;
                mainArrayCounter++;
            }
        }

        /// <summary>
        /// This is to be able to call MergeSort sort methods with only the list that needs to be sorted, and independent of the indexes. 
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
