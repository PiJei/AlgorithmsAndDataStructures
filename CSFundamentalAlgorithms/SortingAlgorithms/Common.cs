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

namespace CSFundamentalAlgorithms.SortingAlgorithms
{
    public class Common
    {
        public static void Swap(List<int> values, int index1, int index2)
        {
            int temp = values[index1];
            values[index1] = values[index2];
            values[index2] = temp;
        }

        /// <summary>
        /// Gets the max element in the array. Alternatively we could use Linq.Max operator. However using this version so that the time complexity is obvious.
        /// </summary>
        /// <param name="values">Specifies a list of integers. </param>
        /// <returns>maximum element in the array. </returns>
        public static int GetMaxElement(List<int> values)
        {
            /* This method assumes values has at least one member. Otherwise this will throw a null reference exception . */
            int max = values[0];
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                }
            }
            return max;
        }

        /// <summary>
        /// Computes the number of digits in a number. 
        /// An alternative is : 
        /// digitsCount = (n == 0 ? 1 : Math.Floor(Math.Log10(Math.Abs(n)) + 1));
        /// </summary>
        /// <param name="number">Specifies the integer for which we want to compute its digit count. </param>
        /// <returns>The number of digits in the given integer number. </returns>
        public static int GetDigitsCount(int number)
        {
            number = Math.Abs(number); /* To be able to compute the number of digits for negative integers as well. */
            int digitsCount = 1; /* In case number is 0, this approach will cover its digit count as well. */
            number = number / 10;
            while (number > 0)
            {
                digitsCount++;
                number = number / 10;
            }
            return digitsCount;
        }

        /// <summary>
        /// Gets the i(th) = whichDigit of the given integer number. For example in number 145, second digit is 4, and the thris is 1, and th first is 5. 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="whichDigit"></param>
        /// <returns>The i(th) = whichDigit(th) digit from th eright, or the least significant digit. </returns>
        public static int GetNthDigitFromRight(int number, int whichDigit)
        {
            int digit = (int)((Math.Abs(number) / Math.Pow(10, whichDigit - 1)) % 10);
            return digit;
        }

        /// <summary>
        /// Detects whether the given sort method is stable. A sort method is stable, if it preserves the ordering of duplicate values in the original array. 
        /// </summary>
        /// <param name="sortMethod"></param>
        /// <returns>True in case the method is stable, and false otherwise. </returns>
        public static bool IsSortMethodStable(Action<List<int>> sortMethod, List<int> values)
        {
            var positionsBeforeSort = HashListToIndexes(values);
            sortMethod(values);
            var positionsAfterSort = HashListToIndexes(values);

            return AreMapsEqual(positionsBeforeSort, positionsAfterSort);
        }

        /// <summary>
        /// Per each value in the array, makes a list of their indexes in the array. 
        /// Notice that the array may include duplicate values, thus a list of indexes rather than one index.
        /// </summary>
        /// <param name="values">An array of integers. </param>
        /// <returns>A hashtable/dictionary mapping each value to the list of its indixes in the array. </returns>
        public static Dictionary<int, List<int>> HashListToIndexes(List<int> values)
        {
            /* Such that the keyes in the dictionary are the values in the array, and the values in the dictionary are the list of indexes for each value in the array. */
            Dictionary<int, List<int>> positions = new Dictionary<int, List<int>>();
            if(values == null)
            {
                return positions;
            }

            for (int index = 0; index < values.Count; index++)
            {
                if (positions.TryGetValue(values[index], out List<int> indexes))
                {
                    positions[values[index]].Add(index);
                }
                else
                {
                    positions.Add(values[index], new List<int> { index});
                }
            }
            return positions;
        }

        // TODO: What is the better way to implement this method. 
        /// <summary>
        /// Giveb the two dictionaries compares them to see if they are equal, in terms of the values per key. It is very important to compare the values (lists) in their original order and expect the same position for each element. 
        /// </summary>
        /// <param name="map1">Specifies the first map. </param>
        /// <param name="map2">Specifies the second map. </param>
        /// <returns>True in case the maps are equal, false otherwise. </returns>
        public static bool AreMapsEqual(Dictionary<int, List<int>> map1, Dictionary<int, List<int>> map2)
        {
            if (map1 == null && map2 == null)
            {
                return true;
            }

            if (map1 == null || map2 == null)
            {
                return false;
            }

            if (map1.Keys.Count != map2.Keys.Count)
            {
                return false;
            }

            foreach (int key in map1.Keys)
            {
                if (map2.TryGetValue(key, out List<int> value2))
                {
                    if (map1[key].Count != map2[key].Count)
                    {
                        return false;
                    }
                    for (int index = 0; index < map1[key].Count; index++)
                    {
                        if (map1[key][index] != map2[key][index])
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
