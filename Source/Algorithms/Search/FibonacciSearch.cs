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

namespace CSFundamentals.Algorithms.Search
{
    public class FibonacciSearch
    {
        [Algorithm(AlgorithmType.Search, "FibonacciSearch")]
        //todo: specify time and space complexity.
        public static int Search(List<int> values, int searchValue)
        {
            FibonacciElement fib = GetSmallestFibonacciBiggerThanNumber(values.Count);
            int startIndex = -1;

            /* Note that fib numbers indicate indexes in the array to look at, and not values. */
            while (fib.FibN > 1) /*  meaning in the sequence {0, 1, 1, 2, 3, ...} the while loop will stop when fibN = 2, thus fibN2 can at least be 1 */
            {
                /* First compare to the value at index FibN2 */
                int index = Math.Min(startIndex + fib.FibN2, values.Count - 1);
                if (searchValue == values[index])
                {
                    return index;
                }

                if (searchValue < values[index])
                {
                    // Shift backward twice as checked against FibN2
                    fib.ShiftBackward();
                    fib.ShiftBackward();
                }

                if (searchValue > values[index])
                {
                    fib.ShiftBackward();
                    startIndex = index; /* Which is the previous Fib2*/
                }
            }

            if (fib.FibN1 == 1 && (startIndex + 1) < values.Count && values[startIndex + 1] == searchValue)
            {
                return startIndex + 1;
            }

            return -1;
        }

        /// <summary>
        /// Computes the smallest Fibonacci number that is greater than number. 
        /// Fibonacci sequence: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, ...
        /// </summary>
        /// <param name="number">The integer we want to compute the closest Fibonacci to it that is bigger than or equal to it. </param>
        /// <returns>The Fibonacci number.</returns>
        public static FibonacciElement GetSmallestFibonacciBiggerThanNumber(int number)
        {
            var fib = new FibonacciElement(0, 1);
            while (fib.FibN < number)
            {
                fib.ShiftForward();
            }
            return fib;
        }
    }

    /// <summary>
    /// Represents a Fibonacci number at index n, and the two Fibonacci numbers at two preceding indexes, which are necessary for calculating this element's value.  
    /// </summary>
    public class FibonacciElement
    {
        /// <summary>
        // FibN = FibN1 {aka. fib(n-1)} + FibN2 {aka. fib(n-2)} 
        /// </summary>
        public int FibN { get; set; }
        public int FibN1 { get; set; }
        public int FibN2 { get; set; }

        public FibonacciElement(int fibN2, int fibN1)
        {
            FibN2 = fibN2;
            FibN1 = fibN1;
            FibN = FibN1 + FibN2;
        }

        public void ShiftForward()
        {
            FibN2 = FibN1;
            FibN1 = FibN;
            FibN = FibN1 + FibN2;
        }

        public void ShiftBackward()
        {
            FibN = FibN1;
            FibN1 = FibN2;
            FibN2 = FibN - FibN1;
        }
    }
}
