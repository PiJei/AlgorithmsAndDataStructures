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

namespace CSFundamentals.DataStructures.Trees
{
    [DataStructure("BinarySearchTree (aka BST)")]
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _root = null;

        public bool Search(T value)
        {
            throw new NotImplementedException();
        }

        public bool Insert(T value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T value)
        {
            throw new NotImplementedException();
        }

        public T GetMinValue()
        {
            throw new NotImplementedException();
        }

        public T GetMaxValue()
        {
            throw new NotImplementedException();
        }

        public List<T> GetSortedList()
        {
            throw new NotImplementedException();
        }

    }
}
