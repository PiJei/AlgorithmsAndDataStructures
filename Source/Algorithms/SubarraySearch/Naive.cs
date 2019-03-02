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

using System.Collections.Generic;

namespace CSFundamentals.Algorithms.SubarraySearch
{
    //TODO: Rename
    public class Naive
    {
        /// <summary>
        /// Detects whether parent list contains child list contiguously. For example list {1, 3, 7, 2, 10} contains sublist {7,2}, but does not contain {7,10}.
        /// Easier to implement this with linked lists due to the contiguous search. 
        /// </summary>
        /// <param name="list">The list in which we are searching for a sublist.</param>
        /// <param name="subList">The sublist</param>
        /// <returns>True if the list contains the sublist, and false otherwise. </returns>
        public static bool Search_NaiveContiguousSublist(List<int> list, List<int> subList)
        {
            /* Each iteration of this loop specifies at which index in list we are starting the search. 
             * Since list may contain duplicates, we should check matching starting at any index in list. 
             * Also we just look up to list.Count - subList.Count +1, as after this value, the list is short and sublist can not be found in it.
             */
            for (int i = 0; i < list.Count; i++)
            {
                int parentStartIndex = i;
                bool found = true;

                for (int j = 0; j < subList.Count; j++)
                {
                    if (list[parentStartIndex + j] != subList[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Searches whether subList can be built from the elements in list, while respecting the order at which elements appear in list. 
        /// For example given list {3, 4, 1, 6, 7, 1, 8, 7}, can we build subList{1, 7}?
        /// Yes, in several ways, indexes {2, 4} or {2, 7} or {5, 7}, we can build it in 3 different ways. 
        /// The approach this algorithm takes is to find the number of times the sublist can be built and returns true if this number higher than 0.
        /// </summary>
        /// <param name="list">The list in which we are searching for a sublist.</param>
        /// <param name="subList">The sublist</param>
        /// <returns>True if the list contains the sublist, and false otherwise. </returns>
        public static bool Search_UnContiguousSublist(List<int> list, List<int> subList)
        {
            // using elements in the list as the columns, and elements in the sublist as the rows
            int[,] possibilities = new int[subList.Count + 1, list.Count + 1]; /* the first row is for empty subList, and the first column is for empty list. */

            // Initializing the first row and first columns.
            for (int i = 0; i <= subList.Count; i++)
            {
                possibilities[i, 0] = 0; // meaning the number of times each element appears in a empty list is 0
            }

            for (int i = 0; i <= list.Count; i++)
            {
                possibilities[0, i] = 1;
            }

            for (int i = 1; i <= subList.Count; i++)
            {
                for (int j = 1; j <= list.Count; j++)
                {
                    if (list[j - 1] == subList[i - 1])
                    {
                        possibilities[i, j] = possibilities[i, j - 1] + possibilities[i - 1, j - 1];
                    }
                    else
                    {
                        possibilities[i, j] = possibilities[i, j - 1];
                    }
                }
            }

            return possibilities[subList.Count, list.Count] > 0 ? true : false;
        }
    }
}
