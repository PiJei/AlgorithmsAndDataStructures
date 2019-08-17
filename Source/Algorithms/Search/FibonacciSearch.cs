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
using AlgorithmsAndDataStructures.Decoration;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    /// <summary>
    /// Implements Fibonacci search algorithm for finding a specific value in a sorted list.
    /// </summary>
    public class FibonacciSearch
    {
        /// <summary>
        /// Implements Fibonacci search. 
        /// </summary>
        /// <typeparam name="T">Type of the values in the sorted list.</typeparam>
        /// <param name="sortedList">A sorted list of any comparable type. </param>
        /// <param name="key">The value that is being searched for. </param>
        /// <returns>The index of the <paramref name="key"/> in the list, and -1 if it does not exist in the list. </returns>
        [Algorithm(AlgorithmType.Search, "FibonacciSearch", Assumptions = "List is sorted with an ascending order.")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        public static int Search<T>(List<T> sortedList, T key) where T : IComparable<T>
        {
            /* If key is NOT in the range, terminate search. Since the input list is sorted this early check is feasible. */
            if (key.CompareTo(sortedList[0]) < 0 || key.CompareTo(sortedList[sortedList.Count - 1]) > 0)
            {
                return -1;
            }

            FibonacciElement fib = GetSmallestFibonacciBiggerThanNumber(sortedList.Count);
            int startIndex = -1;

            /* Note that fib numbers indicate indexes in the list to look at, and not values. */
            while (fib.FibN > 1) /*  meaning in the sequence {0, 1, 1, 2, 3, ...} the while loop will stop when fibN = 2, thus fibN2 can at least be 1 */
            {
                /* First compare to the value at index FibN2 */
                int index = Math.Min(startIndex + fib.FibN2, sortedList.Count - 1);
                if (key.CompareTo(sortedList[index]) == 0)
                {
                    return index;
                }

                if (key.CompareTo(sortedList[index]) < 0)
                {
                    // Shift backward twice as checked against FibN2
                    fib.ShiftBackward();
                    fib.ShiftBackward();
                }

                if (key.CompareTo(sortedList[index]) > 0)
                {
                    fib.ShiftBackward();
                    startIndex = index; /* Which is the previous Fib2*/
                }
            }

            if (fib.FibN1 == 1 && (startIndex + 1) < sortedList.Count && sortedList[startIndex + 1].CompareTo(key) == 0)
            {
                return startIndex + 1;
            }

            return -1;
        }

        /// <summary>
        /// Computes the smallest Fibonacci number that is greater than <paramref name="number"/>. 
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
        /// Is a Fibonacci number: FibN = FibN1 {aka. fib(n-1)} + FibN2 {aka. fib(n-2)} 
        /// </summary>
        public int FibN { get; set; }

        /// <summary>
        /// Is the Fibonacci number immediately before FibN
        /// </summary>
        public int FibN1 { get; set; }

        /// <summary>
        /// Is the Fibonacci number immediately before FibN1
        /// </summary>
        public int FibN2 { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fibN2">Second Fibonacci number. </param>
        /// <param name="fibN1">First Fibonacci number</param>
        public FibonacciElement(int fibN2, int fibN1)
        {
            FibN2 = fibN2;
            FibN1 = fibN1;
            FibN = FibN1 + FibN2;
        }

        /// <summary>
        /// Shifts Fibonacci number one element forward in the sequence. 
        /// </summary>
        public void ShiftForward()
        {
            FibN2 = FibN1;
            FibN1 = FibN;
            FibN = FibN1 + FibN2;
        }

        /// <summary>
        /// Shifts Fibonacci number one element backward in the sequence. 
        /// </summary>
        public void ShiftBackward()
        {
            FibN = FibN1;
            FibN1 = FibN2;
            FibN2 = FibN - FibN1;
        }
    }
}
