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
using CSFundamentals.DataStructures.Trees.Nary.API;

namespace CSFundamentals.DataStructures.Trees.Nary
{
    public class BPlusTreeNode<TKey, TValue> :
        BTreeNodeBase<BPlusTreeNode<TKey, TValue>, TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Only used by leaf nodes, and points to the leaf to its right (note that the right leaf may or may not be a sibling of the current leaf)
        /// </summary>
        public BPlusTreeNode<TKey, TValue> NextLeaf { get; set; }

        /// <summary>
        /// Only used by leaf nodes, and points to the leaf to its left (note that the left leaf may or may not be a sibling of the current leaf)
        /// </summary>
        public BPlusTreeNode<TKey, TValue> PreviousLeaf { get; set; }

        /// <summary>
        /// Creates a node with no keys. 
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        public BPlusTreeNode(int maxBranchingDegree) : base(maxBranchingDegree)
        {
        }

        public void InsertKey(TKey key)
        {
            /* Since KeyValues is a sorted list, the new key value pair will be inserted at its correct position. */
            if (!_keyValues.ContainsKey(key)) /* SortedList does not allow for duplicates, yet checking this as otherwise it will throw an exception.*/
            {
                _keyValues.Add(key, default(TValue));
            }
        }

        public override int GetIndexAtParentChildren()
        {
            throw new NotImplementedException();
        }

        public override void InsertChild(BPlusTreeNode<TKey, TValue> child)
        {
            throw new NotImplementedException();
        }

        // Should implement insertKey on top of insertKeyvalue
        // If however encounter a method in B-TRee that this class doesn't need, then, create the hierarchy, .. 
        // ...
    }
}
