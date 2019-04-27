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
    public partial class RadixSort
    {
        /// <summary>
        /// Implements Radix sort for base 10 (decimal integers) using queues. 
        /// </summary>
        public static void Sort_Iterative_V1(List<Element> list)
        {
            Element maxElement = Utils.GetMaxElement(list);
            int digitsCountForMaxElement = Utils.GetDigitsCount(maxElement.Value);

            /* Creating an array of 10 queues. One queue per each possible digit in base 10 (decimal) numbers: (0, 1, 2, ..., 9)*/
            var queues = new Queue<Element>[10];
            for (int j = 0; j < 10; j++)
            {
                queues[j] = new Queue<Element>();
            }

            for (int d = 1; d <= digitsCountForMaxElement; d++) /* the sorting should happen as many as digitsCount of the max element times. */
            {
                /* Enqueue each number in the correct queue based on its (d)th least significant digit (right most). */
                for (int i = 0; i < list.Count; i++)
                {
                    /* Get the d(th) least significant digit of element i in the array.  */
                    int digit = Utils.GetNthDigitFromRight(list[i].Value, d);
                    queues[digit].Enqueue(list[i]);
                }

                /* Dequeue each queue from 0 to 9*/
                int nextIndex = 0;
                for (int i = 0; i < 10; i++)
                {
                    while (queues[i].Count > 0)
                    {
                        Element element = queues[i].Dequeue();
                        element.Move(nextIndex);
                        list[nextIndex] = element;
                        nextIndex++;
                    }
                }
            }
        }
    }
}
