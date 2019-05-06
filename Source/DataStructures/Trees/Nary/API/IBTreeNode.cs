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
using System;
using System.Collections.Generic;

namespace CSFundamentals.DataStructures.Trees.Nary.API
{
    /// <summary>
    /// Provides an interface for B-Tree nodes. 
    /// </summary>
    /// <typeparam name="TNode">Type of a B-Tree node. </typeparam>
    /// <typeparam name="TKey">Type of the key stored in the node. </typeparam>
    /// <typeparam name="TValue">Type of the value stored in the node. </typeparam>
    public interface IBTreeNode<TNode, TKey, TValue> :
        IComparable<TNode>
        where TKey : IComparable<TKey>
    {
        /// <value>Maximum branching degree or maximum number of children the node can have.</value>
        int MaxBranchingDegree { get; set; }

        /// <value>Minimum branching degree or the minimum number of children the node can have. </value>
        int MinBranchingDegree { get; }

        /// <value>Maximum number of keys that can be stored in a tree. </value>
        int MaxKeys { get; }

        /// <value>Minimum number of keys that can be stored in a tree. </value>
        int MinKeys { get; }

        /// <value>Is the count of key-value pairs in the node.</value>
        int KeyCount { get; }

        /// <value>Is the count of the children of the node.  </value>
        int ChildrenCount { get; }

        /// <summary>
        /// Clears the current node's key-values.
        /// </summary>
        void Clear();

        /// <summary>
        /// Checks whether the current node is a leaf node. 
        /// </summary>
        /// <returns>True if leaf and false otherwise. </returns>
        bool IsLeaf();

        /// <summary>
        /// Checks whether the current node is a root node. 
        /// </summary>
        /// <returns>True if root and false otherwise. </returns>
        bool IsRoot();

        /// <summary>
        /// Checks whether the current node has MaxKeys keys stored in it (meaning it is full). 
        /// </summary>
        /// <returns>True if the node is full, and false otherwise. </returns>
        bool IsFull();

        /// <summary>
        /// Checks whether the current node has more than MaxKeys stored in it (meaning it is overFlown). 
        /// </summary>
        /// <returns>True if the node is overflown and false otherwise. </returns>
        bool IsOverFlown();

        /// <summary>
        /// Checks whether the current node has less than MinKeys stored in it (meaning it is underFlown)
        /// </summary>
        /// <returns>True if the node is underFlown, and false otherwise. </returns>
        bool IsUnderFlown();

        /// <summary>
        /// Checks whether the current node has exactly MinKeys stored in it (meaning it is minFull). 
        /// </summary>
        /// <returns>True if the node is minFull, and false otherwise. </returns>
        bool IsMinFull();

        /// <summary>
        /// Checks whether the current node has exactly MinKeys+1 stored in it (meaning it is minOneFull).
        /// </summary>
        /// <returns>True if the node is MinOneFull, and false otherwise. </returns>
        bool IsMinOneFull();

        /// <summary>
        /// Checks whether the current node has 0 keys stored in it (meaning is empty).
        /// </summary>
        /// <returns>True if the node is empty, and false otherwise. </returns>
        bool IsEmpty();

        /// <summary>
        /// Checks whether the current node has a left sibling.
        /// </summary>
        /// <returns>True if the current node has a left sibling, and false otherwise. </returns>
        bool HasLeftSibling();

        /// <summary>
        /// Checks whether the current node has a right sibling. 
        /// </summary>
        /// <returns>True if the current node has a right sibling, and false otherwise. </returns>
        bool HasRightSibling();

        /// <summary>
        /// Gets the minimum key in the current node. 
        /// </summary>
        /// <returns></returns>
        KeyValuePair<TKey, TValue> GetMinKey();

        /// <summary>
        /// Gets the maximum key in the current node. 
        /// </summary>
        /// <returns></returns>
        KeyValuePair<TKey, TValue> GetMaxKey();

        /// <summary>
        /// Gets the child at index <paramref name="index"/>
        /// </summary>
        /// <param name="index">An index to be evaluated in the _children array.</param>
        /// <returns>The child node. </returns>
        TNode GetChild(int index);

        /// <summary>
        /// Gets the parent of the current node. 
        /// </summary>
        /// <returns>Parent node. </returns>
        TNode GetParent();

        /// <summary>
        /// Sets the parent node of the current node. 
        /// </summary>
        /// <param name="parent">Parent node. </param>
        void SetParent(TNode parent);

        /// <summary>
        /// Gets the index of the given child in _children array. 
        /// </summary>
        /// <param name="child">The child node. </param>
        /// <returns>Index of the child node in the _children array. </returns>
        int GetChildIndex(TNode child);

        /// <summary>
        /// Gets the key in index <paramref name="index"/> of _keyValues array. 
        /// </summary>
        /// <param name="index">An index to be evaluated in _keyValues array. </param>
        /// <returns>The key at the given index. </returns>
        TKey GetKey(int index);

        /// <summary>
        /// Gets the key-value pair at index <paramref name="index"/> of _keyValues array. 
        /// </summary>
        /// <param name="index">An index to be evaluated in _keyValues array. </param>
        /// <returns>The key-value pair at the given index. </returns>
        KeyValuePair<TKey, TValue> GetKeyValue(int index);

        /// <summary>
        /// Inserts the given key-value pair in the _keyValues array.
        /// </summary>
        /// <param name="keyVal">A key-value pair to be inserted in the _keyValues array. </param>
        void InsertKeyValue(KeyValuePair<TKey, TValue> keyVal);

        /// <summary>
        /// Inserts the given child node in the _children array. 
        /// </summary>
        /// <param name="child">A tree node. </param>
        void InsertChild(TNode child);

        /// <summary>
        /// Gets the index of the current node in its parent's _children array. 
        /// </summary>
        /// <returns>index of the current node in its parent's _children array</returns>
        int GetIndexAtParentChildren();

        /// <summary>
        /// Removes the key at the given index in _keyValues array. 
        /// </summary>
        /// <param name="index">An index in _keyValues array.</param>
        void RemoveKeyByIndex(int index);

        /// <summary>
        /// Removes the given key from _keyValues array. 
        /// </summary>
        /// <param name="key">A key to be removed. </param>
        void RemoveKey(TKey key);

        /// <summary>
        /// Removes the child at the given index from _children array. 
        /// </summary>
        /// <param name="index">An index in the _children array. </param>
        void RemoveChildByIndex(int index);
    }
}
