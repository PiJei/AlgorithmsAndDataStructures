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
    public partial class InsertionSort
    {
        /// <summary>
        /// Implements an iterative version of Insertion sort. 
        /// </summary>
        /// <param name="list"></param>
        public static void Sort_Iterative_V2(List<Element> list)
        {
            // In this version, we will overwrite the array location for element (i) by shifting each element to the right if bigger than (i) till finding its correct position
            for (int i = 1; i < list.Count; i++)
            {
                Element arrayValueAtIndexI = list[i];
                int correctIndex = i;

                for (int j = i - 1; j >= 0 && list[j].Value > arrayValueAtIndexI.Value; j--)
                {
                    list[j].Move(j + 1);
                    list[j + 1] = list[j];

                    correctIndex = j;
                }

                arrayValueAtIndexI.Move(correctIndex);
                list[correctIndex] = arrayValueAtIndexI;
            }
        }
    }
}
