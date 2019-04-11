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

namespace CSFundamentals.DataStructures.Trees.Nary.API
{
    public abstract class BTreeBase<TNode, TKey, TValue>
        where TNode : IBTreeNode<TNode, TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Is the root of the tree. 
        /// </summary>
        public BTreeNode<TKey, TValue> Root = null;

        /// <summary>
        /// Is the maximum number of children for a non-leaf node in this B-Tree. 
        /// </summary>
        public int MaxBranchingDegree { get; private set; }

        public BTreeBase(int maxBranchingDegree)
        {
            MaxBranchingDegree = maxBranchingDegree;
        }
    }
}
