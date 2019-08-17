#region copyright
/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of AlgorithmsAndDataStructures project.
 *
 * AlgorithmsAndDataStructures is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AlgorithmsAndDataStructures is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.Sort.StabilityCheckableVersions;

namespace AlgorithmsAndDataStructures.Algorithms.Sort
{
    public partial class MergeSort
    {
        /// <summary>
        /// Implements a basic version of merge sort recursively. 
        /// </summary>
        /// <param name="list">The list of integer values to be sorted. </param>
        /// <param name="startIndex">The lower index in the list, inclusive. </param>
        /// <param name="endIndex">The higher index in the list, inclusive. </param>
        public static void Sort_Recursively(List<Element> list, int startIndex, int endIndex)
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
        /// Merges two sub list [startIndex, middleIndex], [middleIndex+1, endIndex] such to end up with a sorted list. 
        /// </summary>
        /// <param name="list">The list of integer values to be sorted. </param>
        /// <param name="startIndex">The lower index in the list, inclusive. </param>
        /// <param name="middleIndex">The middle index of the list. </param>
        /// <param name="endIndex">The higher index in the list, inclusive. </param>
        public static void Merge(List<Element> list, int startIndex, int middleIndex, int endIndex)
        {
            //Making a copy of the list
            var listCopy = new List<Element>(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                listCopy.Add(new Element(list[i]));
            }

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

            // Pointer on the list.
            int listPointer = start1;

            while (leftHalfPointer <= end1 && rightHalfPointer <= end2)
            {
                if (listCopy[leftHalfPointer].Value <= listCopy[rightHalfPointer].Value) /* Favors left half values over right half values when there are duplicates. */
                {
                    listCopy[leftHalfPointer].Move(listPointer);
                    list[listPointer] = listCopy[leftHalfPointer];
                    leftHalfPointer++;
                }
                else if (listCopy[leftHalfPointer].Value > listCopy[rightHalfPointer].Value)
                {
                    listCopy[rightHalfPointer].Move(listPointer);
                    list[listPointer] = listCopy[rightHalfPointer];
                    rightHalfPointer++;
                }
                listPointer++;
            }

            while (leftHalfPointer <= end1)
            {
                listCopy[leftHalfPointer].Move(listPointer);
                list[listPointer] = listCopy[leftHalfPointer];
                leftHalfPointer++;
                listPointer++;
            }

            while (rightHalfPointer <= end2)
            {
                listCopy[rightHalfPointer].Move(listPointer);
                list[listPointer] = listCopy[rightHalfPointer];
                rightHalfPointer++;
                listPointer++;
            }
        }

        /// <summary>
        /// This is to be able to call MergeSort sort methods with only the list that needs to be sorted, and independent of the indexes. 
        /// This is needed for methods that receive other sort methods as parameters, and would ideally like to have similar signature for all the methods that are passed as parameters, 
        /// In sort methods the signature is: void SortMethod(List{int} list); 
        /// </summary>
        /// <param name="list">The list of integers to be sorted. </param>
        public static void MergeSort_Recursively_Wrapper(List<Element> list)
        {
            Sort_Recursively(list, 0, list.Count - 1);
        }
    }
}
