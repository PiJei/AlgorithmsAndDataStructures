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
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Sort
{
    public partial class Utils
    {
        /// <summary>
        /// Swaps the values at given indexes of the list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">A list of values. </param>
        /// <param name="index1">First index.</param>
        /// <param name="index2">Second index.</param>
        public static void Swap<T>(List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        /// <summary>
        /// Gets the max element in the list. Alternatively we could use Linq.Max operator. However using this version so that the time complexity is obvious.
        /// </summary>
        /// <param name="list">A list of values (of type T, e.g., int). </param>
        /// <returns>Maximum element in the list. </returns>
        public static T GetMaxElement<T>(List<T> list) where T : IComparable<T>
        {
            /* This method assumes values has at least one member. Otherwise this will throw a null reference exception . */
            T max = list[0];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(max) > 0)
                {
                    max = list[i];
                }
            }
            return max;
        }

        /// <summary>
        /// Computes the number of digits in a number. 
        /// An alternative is : 
        /// digitsCount = (n == 0 ? 1 : Math.Floor(Math.Log10(Math.Abs(n)) + 1));
        /// </summary>
        /// <param name="number">The integer for which we want to compute its digit count. </param>
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
        /// Gets the i(th) = whichDigit of the given integer number. For example in number 145, second digit is 4, and the third is 1, and th first is 5. 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="whichDigit"></param>
        /// <returns>The i(th) = whichDigit(th) digit from the right, or the least significant digit. </returns>
        public static int GetNthDigitFromRight(int number, int whichDigit)
        {
            int digit = (int)((Math.Abs(number) / Math.Pow(10, whichDigit - 1)) % 10);
            return digit;
        }
    }
}
