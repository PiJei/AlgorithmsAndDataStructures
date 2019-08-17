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
    public partial class InsertionSort
    {
        /// <summary>
        /// Implements an iterative version of Insertion sort. 
        /// </summary>
        /// <param name="list"></param>
        public static void Sort_Iterative_V2(List<Element> list)
        {
            // In this version, we will overwrite the list location for element (i) by shifting each element to the right if bigger than (i) till finding its correct position
            for (int i = 1; i < list.Count; i++)
            {
                Element listValueAtIndexI = list[i];
                int correctIndex = i;

                for (int j = i - 1; j >= 0 && list[j].Value > listValueAtIndexI.Value; j--)
                {
                    list[j].Move(j + 1);
                    list[j + 1] = list[j];

                    correctIndex = j;
                }

                listValueAtIndexI.Move(correctIndex);
                list[correctIndex] = listValueAtIndexI;
            }
        }
    }
}
