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

//TODO: nOT SURE WHY TO HAVE BOTH KEY AND Value
//TODO: How to prevent de-genration /imbalance?

namespace CSFundamentals.DataStructures.Trees
{
    [DataStructure("BinarySearchTree (aka BST)")]
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Is the root of the binary search tree. 
        /// </summary>
        private BinaryTreeNode<T> _root = null;

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)", When = "Tree is imbalanced such that it is like one sequential branch (linked list), every node except the leaf having exactly one child.")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public BinaryTreeNode<T> Search(BinaryTreeNode<T> root, T value)
        {
            if (root == null)
            {
                return root;
            }

            if (root.Value.Equals(value))
            {
                return root;
            }

            if (root.Value.CompareTo(value) < 0)
            {
                return Search(root.RightChild, value);
            }

            return Search(root.LeftChild, value);
        }

        [TimeComplexity(Case.Average, "")]
        [SpaceComplexity("", InPlace =)]
        public bool Insert(T value)
        {
            throw new NotImplementedException();
        }

        [TimeComplexity(Case.Average, "")]
        [SpaceComplexity("", InPlace =)]
        public bool Delete(T value)
        {
            throw new NotImplementedException();
        }

        [TimeComplexity(Case.Average, "")]
        [SpaceComplexity("", InPlace =)]
        public T GetMinValue()
        {
            throw new NotImplementedException();
        }

        [TimeComplexity(Case.Average, "")]
        [SpaceComplexity("", InPlace =)]
        public T GetMaxValue()
        {
            throw new NotImplementedException();
        }

        [TimeComplexity(Case.Average, "")]
        [SpaceComplexity("", InPlace =)]
        public List<T> GetSortedList()
        {
            throw new NotImplementedException();
        }

    }
}
