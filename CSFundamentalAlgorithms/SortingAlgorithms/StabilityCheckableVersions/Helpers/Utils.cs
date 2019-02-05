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

using System;
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentalAlgorithms.SortingAlgorithms.StabilityCheckableVersions.Helpers
{
    public class Utils
    {
        public static List<Element> Convert(List<int> values)
        {
            List<Element> newValues = new List<Element>();
            for (int i = 0; i < values.Count; i++)
            {
                newValues.Add(new Element(values[i], i));
            }
            return newValues;
        }

        // TODO: Correct the comments of the next 3 methods

        /// <summary>
        /// Detects whether the given sort method is stable. A sort method is stable, if it preserves the ordering of duplicate values in the original array. 
        /// </summary>
        /// <param name="sortMethod">Specifies the name of a method with the signature specified by the Action (void return type) </param>
        /// <returns>True in case the method is stable, and false otherwise. </returns>
        public static bool IsSortMethodStable(Action<List<Element>> sortMethod, List<Element> values)
        {
            sortMethod(values);
            return IsMapStable(HashListToIndexes(values));
        }

        /// <summary>
        /// Per each value in the array, makes a list of their indexes in the array. 
        /// Notice that the array may include duplicate values, thus a list of indexes rather than one index.
        /// </summary>
        /// <param name="values">An array of integers. </param>
        /// <returns>A hashtable/dictionary mapping each value to the list of its indixes in the array. </returns>
        public static Dictionary<Element, List<Element>> HashListToIndexes(List<Element> values)
        {
            /* Such that the keyes in the dictionary are the values in the array, and the values in the dictionary are the list of indexes for each value in the array. */
            Dictionary<Element, List<Element>> positions = new Dictionary<Element, List<Element>>();
            if (values == null)
            {
                return positions;
            }

            for (int index = 0; index < values.Count; index++)
            {
                if (positions.TryGetValue(values[index], out List<Element> indexes))
                {
                    positions[values[index]].Add(values[index]);
                }
                else
                {
                    positions.Add(values[index], new List<Element> { values[index] });
                }
            }
            return positions;
        }

        // TODO: What is the better way to implement this method. 
        /// <summary>
        /// Giveb the two dictionaries compares them to see if they are equal, in terms of the values per key. It is very important to compare the values (lists) in their original order and expect the same position for each element. 
        /// </summary>
        /// <param name="map1">Specifies the first map. </param>
        /// <returns>True in case the maps are equal, false otherwise. </returns>
        public static bool IsMapStable(Dictionary<Element, List<Element>> map)
        {
            foreach (KeyValuePair<Element, List<Element>> keyVaL in map.Where(keyval => map[keyval.Key].Count > 1))
            {
                for (int index1 = 0; index1 < keyVaL.Value.Count; index1++)
                {
                    for (int index2 = index1 + 1; index2 < keyVaL.Value.Count; index2++)
                    {
                        if (!keyVaL.Value[index1].IsStable(keyVaL.Value[index2]))
                        {
                            return false;
                        }
                    }
                }

            }
            return true;
        }
    }
}
