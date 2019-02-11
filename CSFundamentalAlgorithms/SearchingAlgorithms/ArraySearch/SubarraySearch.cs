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
        /// Detects whether parent list contains child list contiguously 
        /// Easier to implement this with linked lists due to the contiguous search. 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public static bool Search_ContiguousChild(List<int> parent, List<int> child)
        {
            for (int i = 0; i < parent.Count; i++) /* this specifies at which point we are starting the search. As many indexes in the parent might match the starting element of the child. we should look for all of these until we find atleast one, from which we can find a match. */
            {
                int parentStartIndex = i;
                bool childFullyMatched = true;

                for (int j = 0; j < child.Count; j++)
                {
                    if (parent[parentStartIndex] == child[j])
                    {
                        parentStartIndex += 1;
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
