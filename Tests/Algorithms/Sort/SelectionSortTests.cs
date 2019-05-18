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
using CSFundamentals.Algorithms.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.Algorithms.Sort
{
    /// <summary>
    /// Tests methods in <see cref="SelectionSort"/> class.
    /// </summary>
    [TestClass]
    public partial class SelectionSortTests
    {
        /// <summary>
        /// Tests the correctness of Selection sort algorithm.
        /// To visualize how the array evolves while executing selection sort on <see cref="Constants.ArrayWithDistinctValues"/> see: <img src = "../Images/Sorts/SelectionSort.png"/>.
        /// </summary>
        [TestMethod]
        public void Sort_WithDifferentInputs()
        {
            SortTests.TestSortMethodWithDifferentInputs(SelectionSort.Sort);
        }
    }
}
