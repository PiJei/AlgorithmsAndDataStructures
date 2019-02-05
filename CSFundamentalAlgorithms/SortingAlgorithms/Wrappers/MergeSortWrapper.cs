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

// TODO: When referencing other classes, like in the commenting area, use proper annotation for it. 

using System.Collections.Generic;

namespace CSFundamentalAlgorithms.SortingAlgorithms.Wrappers
{
    /// <summary>
    /// Provides some wrappers for methods in MergeSort class. 
    /// </summary>
    public class MergeSortWrapper
    {
        /// <summary>
        /// This is to be able to call MergeSort sort methods with only the list that needs to be sorted, and independet of the indexes. 
        /// This is needed for methods that receive other sort methods as parameters, and would ideally like to have similar signature for all the methods that are passed as parameters, 
        /// In sort methods the signature is: void SortMethod(List<int> values); 
        /// </summary>
        /// <param name="values">Specifies the list of integers to be sorted. </param>
        public static void MergeSort_Recursively_Wrapper(List<int> values)
        {
            MergeSort.MergeSort_Recursively(values, 0, values.Count - 1);
        }
    }
}
