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

using CSFundamentalAlgorithms.SortingAlgorithms.StabilityCheckableVersions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalAlgorithmsTests.SortingAlgorithmsTests.StabilityCheckableVersionsTests
{
    [TestClass]
    public class ElementTests
    {
        [TestMethod]
        public void Element_Equals_Test()
        {
            Element element1 = new Element(1, 0);
            Assert.IsFalse(element1.Equals(null));

            Element element2 = new Element(1, 3);
            Assert.IsTrue(element1.Equals(element2));
        }

        [TestMethod]
        public void Element_IsStable_Test()
        {
            Element element1 = new Element(1, 0); // Element1: 1, 0, -1
            Element element2 = new Element(2, 0); // Element2: 2, 0, -1

            Assert.IsFalse(element1.IsStable(element2));

            Element element3 = new Element(1, 2); // Element3 : 1, 2, -1 
            Assert.IsFalse(element1.IsStable(element3)); /* Expects false, as newIndex is not decided yet. */

            element1.NewArrayIndex = 5; // Element1: 1, 0, 5
            element3.NewArrayIndex = 3; // Element3 : 1, 2, 3 
            Assert.IsFalse(element1.IsStable(element3)); /* Expects false, as element3 's old index is bigger but new index is smaller*/

            element3.NewArrayIndex = 8; // Element3: 1, 2, 8 
            Assert.IsTrue(element1.IsStable(element3));
        }

        /* We need to find "a" list with duplicate values, such that shows Quick sort is not stable. 
             * This does not mean that Quick sort is unstable for all arrays with duplicate values. */
        /*
        [TestMethod]
        public void QuickSort_IsStable_Test()
        {
            
            List<int> duplicateValues1 = new List<int> { 4, 2, 3, 4, 1 };
            bool isStable = CSFundamentalAlgorithms.SortingAlgorithms.Common.IsSortMethodStable(QuickSortWrapper.QuickSort_Recursively_Wrapper, duplicateValues1);
            Assert.IsFalse(isStable);
        }
    
        [TestMethod]
        public void MergeSort_IsStable_Test()
        {
            List<int> duplicateValues1 = new List<int> { 4, 3, 2, 4, 1 };
            bool isStable1 = Utils.IsSortMethodStable(MergeSortWrapper.MergeSort_Recursively_Wrapper, duplicateValues1);
            Assert.IsTrue(isStable1);

            List<int> duplicateValues2 = new List<int> (Constants.ArrayWithDuplicateValues);
            bool isStable2 = Utils.IsSortMethodStable(MergeSortWrapper.MergeSort_Recursively_Wrapper, duplicateValues2);
            Assert.IsTrue(isStable2);

            List<int> duplicateValues3 = new List<int>(Constants.ArrayWithSortedDuplicateValues);
            bool isStable3 = Utils.IsSortMethodStable(MergeSortWrapper.MergeSort_Recursively_Wrapper, duplicateValues3);
            Assert.IsTrue(isStable3);

            List<int> duplicateValues4 = new List<int>(Constants.ArrayWithReverselySortedDuplicateValues);
            bool isStable4 = Utils.IsSortMethodStable(MergeSortWrapper.MergeSort_Recursively_Wrapper, duplicateValues4);
            Assert.IsTrue(isStable4);

            List<int> duplicateValues5 = new List<int> { 3, 1, 1, 2, 2, 4, 1, 1, 2, 2 };
            bool isStable5 = Utils.IsSortMethodStable(MergeSortWrapper.MergeSort_Recursively_Wrapper, duplicateValues5);
            Assert.IsTrue(isStable5);

        }
    
        /// <summary>
        /// Tests if heap sort is stable or not. Heapsort by design is not stable. 
        /// </summary>
        [TestMethod]
        public void HeapSort_IsStable_Test()
        {
         
        List<int> duplicateValues1 = new List<int> { 4, 2, 3, 1, 4 };
        bool isStable = CSFundamentalAlgorithms.SortingAlgorithms.Common.IsSortMethodStable(HeapSort.HeapSort_Ascending, duplicateValues1);
        Assert.IsFalse(isStable);
        }
    */

        /* All we need to do is to find "a" list with a particular arrangements of duplicate values and other distnct values, such that breaks isStable sort question for heap sort.. 
          * Meaning that not finding this list, does not prove that the sort method is stable.
          * This also means that there might be lots of lists with duplicate values, for which heap sort acts as stable. 
          */

        /*
    [TestMethod]
    public void SelectionSort_IsStable_Test()
    {
        List<int> duplicateValues1 = new List<int> { 4, 2, 3, 4, 1 };
        bool isStable = CSFundamentalAlgorithms.SortingAlgorithms.Common.IsSortMethodStable(SelectionSort.SelectionSort_Iteratively, duplicateValues1);
        Assert.IsFalse(isStable);
    }
    */

        /* We need to find "a" list with duplicate values, such that shows Selection sort is not stable. 
 * This does not mean that Selection sort is unstable for all arrays with duplicate values. */

    }
}
