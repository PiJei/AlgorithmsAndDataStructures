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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Sort.StabilityCheckableVersions;

namespace AlgorithmsAndDataStructures.Algorithms.Sort
{
    /// <summary>
    /// Is a collection of helper methods used by sort algorithms. 
    /// </summary>
    public partial class Utils
    {
        /// <summary>
        /// Converts a list of integers to a list of Elements. 
        /// </summary>
        /// <param name="list">A list of integers. </param>
        /// <returns>A list of Elements. </returns>
        public static List<Element> Convert(List<int> list)
        {
            var newValues = new List<Element>();
            for (int i = 0; i < list.Count; i++)
            {
                newValues.Add(new Element(list[i], i));
            }
            return newValues;
        }

        /// <summary>
        /// Detects whether the given sort method is stable. A sort method is stable, if it preserves the ordering of duplicate values in the original array. 
        /// </summary>
        /// <param name="sortMethod">The name of a method with the signature specified by the Action (void return type) </param>
        /// <param name="list">A list of Elements. </param>
        /// <returns>True in case the method is stable, and false otherwise. </returns>
        public static bool IsSortMethodStable(Action<List<Element>> sortMethod, List<Element> list)
        {
            sortMethod(list);
            return IsMapStable(HashListToIndexes(list));
        }

        /// <summary>
        /// Per each value in the array, makes a list of their indexes in the array. 
        /// Notice that the array may include duplicate values, thus a list of indexes rather than one index.
        /// </summary>
        /// <param name="list">An array of integers. </param>
        /// <returns>A hash table/dictionary mapping each value to the list of its indexes in the array. </returns>
        public static Dictionary<Element, List<Element>> HashListToIndexes(List<Element> list)
        {
            /* Keys in the dictionary are the values in the array, and the values in the dictionary are the list of indexes for each value in the array. */
            var positions = new Dictionary<Element, List<Element>>();
            if (list == null)
            {
                return positions;
            }

            for (int index = 0; index < list.Count; index++)
            {
                if (positions.TryGetValue(list[index], out _))
                {
                    positions[list[index]].Add(list[index]);
                }
                else
                {
                    positions.Add(list[index], new List<Element> { list[index] });
                }
            }
            return positions;
        }

        /// <summary>
        /// Given the two dictionaries compares them to see if they are equal, in terms of the values per key. It is very important to compare the values (lists) in their original order and expect the same position for each element. 
        /// </summary>
        /// <param name="map">A dictionary with one Element as the key and a list of Elements as the value per entry. </param>
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

        /// <summary>
        /// Swaps values in indexes <paramref name="index1"/> and <paramref name="index2"/> in the <paramref name="list"/> array. 
        /// </summary>
        /// <param name="list">A list of Elements. </param>
        /// <param name="index1">The first index. </param>
        /// <param name="index2">The second index. </param>
        public static void Swap(List<Element> list, int index1, int index2)
        {
            var temp = new Element(list[index1]);

            list[index2].Move(index1);
            list[index1] = list[index2];

            temp.Move(index2);
            list[index2] = temp;
        }

        /// <summary>
        /// Gets the max element in the array. Alternatively we could use Linq.Max operator. However using this version so that the time complexity is obvious.
        /// </summary>
        /// <param name="list">A list of integers. </param>
        /// <returns>Maximum element in the array. </returns>
        public static Element GetMaxElement(List<Element> list)
        {
            /* This method assumes values has at least one member. Otherwise this will throw a null reference exception . */
            Element max = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Value > max.Value)
                {
                    max = list[i];
                }
            }
            return max;
        }

    }
}
