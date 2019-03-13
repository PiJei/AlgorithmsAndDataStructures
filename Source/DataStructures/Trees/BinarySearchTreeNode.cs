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

using CSFundamentals.DataStructures.Trees.API;
using System;

namespace CSFundamentals.DataStructures.Trees
{
    public class BinarySearchTreeNode<T1, T2> : TreeNode<BinarySearchTreeNode<T1, T2>, T1, T2> where T1 : IComparable<T1>
    {
        public BinarySearchTreeNode(T1 key, T2 value) : base(key, value)
        {
        }

        public override BinarySearchTreeNode<T1, T2> LeftChild { get; set; }
        public override BinarySearchTreeNode<T1, T2> RightChild { get; set; }
        public override BinarySearchTreeNode<T1, T2> Parent { get; set; }
    }
}
