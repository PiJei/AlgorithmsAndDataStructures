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

using System;
using System.Collections.Generic;
using CSFundamentals.Styling;

namespace CSFundamentals.Algorithms.Sort
{
    public partial class RadixSort
    {
        /// <summary>
        /// Implements Radix sort for base 10 (decimal integers) using queues. 
        /// </summary>
        [Algorithm(AlgorithmType.Sort, "RadixSort")]
        // TODO: Specify the time and space complexities
        // todo: explain why is not generic: due to get the max digits of
        public static void Sort_Iterative_V1(List<int> values)
        {
            int maxElement = Utils.GetMaxElement(values);
            int digitsCountForMaxElement = Utils.GetDigitsCount(maxElement);

            /* Creating an array of 10 queues. One queue per each possible digit in base 10 (decimal) numbers: (0, 1, 2, ..., 9)*/
            Queue<int>[] queues = new Queue<int>[10];
            for (int j = 0; j < 10; j++)
            {
                queues[j] = new Queue<int>();
            }

            for (int d = 1; d <= digitsCountForMaxElement; d++) /* the sorting should happen as many as digitsCount of the max element times. */
            {
                /* Enqueue each number in the correct queue based on its (d)th least significant digit (right most). */
                for (int i = 0; i < values.Count; i++)
                {
                    /* Get the d(th) least significant digit of element i in the array.  */
                    int digit = Utils.GetNthDigitFromRight(values[i], d);
                    queues[digit].Enqueue(values[i]);
                }

                /* Dequeue each queue from 0 to 9*/
                int nextIndex = 0;
                for (int i = 0; i < 10; i++)
                {
                    while (queues[i].Count > 0)
                    {
                        values[nextIndex] = queues[i].Dequeue();
                        nextIndex++;
                    }
                }
            }
        }

        /// <summary>
        /// Implements Radix Sort based on count sort.
        /// </summary>
        public static void Sort_Iterative_V2(List<int> values)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implements a recursive version of Radix Sort. 
        /// </summary>
        public static void Sort_Recursive(List<int> values)
        {
            throw new NotImplementedException();
        }
    }
}
