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

namespace CSFundamentals.DataStructures.Trees.Nary.API
{
    public interface IBTreeNode<TNode, TKey, TValue> :
        IComparable<TNode>
        where TKey : IComparable<TKey>
    {
        int MaxBranchingDegree { get; set; }

        int MinBranchingDegree { get; }

        int MaxKeys { get; }

        int MinKeys { get;}

        /// <summary>
        /// Is the count of key-value pairs in the node. 
        /// </summary>
        int KeyCount { get; }

        /// <summary>
        /// Is the count of the children of the node. 
        /// </summary>
        int ChildrenCount { get; }

        void Clear();

        bool IsLeaf();

        bool IsRoot();

        bool IsFull();

        bool IsOverFlown();

        bool IsUnderFlown();

        bool IsMinFull();

        bool IsMinOneFull();

        bool IsEmpty();

        bool HasLeftSibling();

        bool HasRightSibling();

        KeyValuePair<TKey, TValue> GetMinKey();

        KeyValuePair<TKey, TValue> GetMaxKey();

        TNode GetChild(int index);

        TNode GetParent();

        void SetParent(TNode parent);

        int GetChildIndex(TNode child);

        TKey GetKey(int index);

        KeyValuePair<TKey, TValue> GetKeyValue(int index);

        void InsertKeyValue(KeyValuePair<TKey, TValue> keyVal);

        void InsertChild(TNode child);

        int GetIndexAtParentChildren();

        void RemoveKeyByIndex(int index);

        void RemoveKey(TKey key);

        void RemoveChildByIndex(int index);
    }
}
