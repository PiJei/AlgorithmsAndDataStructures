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
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public static bool Search_ContiguousChild(List<int> parent, List<int> child)
        {
            int prevIndex = -1;
            // I am not even able to write the brute force yet for this simple algorithm, ... 
            for (int i = 0; i < child.Count; i++)
            {
                bool found = false;
                for (int j = prevIndex + 1; j < parent.Count; j++)
                {
                    if (parent[j] == child[i])
                    {
                        found = true;
                        prevIndex = j;
                        break;
                    }
                }
                if (!found)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Search_UnContiguousChild(List<int> parent, List<int> child)
        {
            // TODO
            return true;
        }
    }
}
