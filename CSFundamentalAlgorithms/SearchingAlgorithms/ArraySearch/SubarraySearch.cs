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

namespace CSFundamentalAlgorithms.SearchingAlgorithms.ArraySearch
{
    public class SubarraySearch
    {
        /// <summary>
        /// Detects whether parent list contains child list contiguously. For example list {1, 3, 7, 2, 10} contains sublist {7,2}, but does not contain {7,10}.
        /// Easier to implement this with linked lists due to the contiguous search. 
        /// </summary>
        /// <param name="list">The list in which we are searching for a sublist.</param>
        /// <param name="subList">The sublist</param>
        /// <returns>True if the list contains the sublist, and false otherwise. </returns>
        public static bool Search_ContiguousSublist(List<int> list, List<int> subList)
        {
            for (int i = 0; i < list.Count; i++) /* this specifies at which point we are starting the search. As many indexes in the parent might match the starting element of the child. we should look for all of these until we find atleast one, from which we can find a match. */
            {
                int parentStartIndex = i;
                bool childFullyMatched = true;

                for (int j = 0; j < subList.Count; j++)
                {
                    if (list[parentStartIndex] == subList[j])
                    {
                        parentStartIndex += 1; /* Since elements should match consecutively. */
                    }
                    else
                    {
                        childFullyMatched = false;
                        break;
                    }
                }
                if (childFullyMatched)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Search_UnContiguousChild(List<int> parent, List<int> child)
        {
            // TODO
            return true;
        }
    }
}
