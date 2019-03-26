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
using System.Linq;

namespace CSFundamentals.DataStructures.Trees
{
    /// <summary>
    /// Implements a B-Tree node. A B-tree node is an ordered sequence of K keys, and K+1 children.
    /// </summary>
    /// <typeparam name="T1">Is the type of the keys in the tree. </typeparam>
    /// <typeparam name="T2">Is the type of the values in the tree. </typeparam>
    public class BTreeNode<T1, T2> : IComparable<BTreeNode<T1, T2>> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Is the minimum number of keys in a B-tree internal/leaf node. (Notice that a root has no lower bound on the number of keys. Intuitively when the tree is just being built it might start with 1, and grow afterwards.)
        /// </summary>
        public int MinKeys { get; private set; }

        /// <summary>
        /// Is the maximum number of keys in a B-tree internal/leaf/root node. This is often 2 times the MinKeys.
        /// </summary>
        public int MaxKeys { get; private set; }

        /// <summary>
        /// Is the minimum number of branches/children a B-tree internal node can have. 
        /// </summary>
        public int MinBranchingDegree { get; private set; }

        /// <summary>
        /// Is the maximum number of branches/children a B-tree internal or root node can have. Leaf nodes contain 0 children. 
        /// </summary>
        public int MaxBranchingDegree { get; private set; }

        // TODO: Because of splits and merges, I feel the best way is to have these two lists as linked lists
        // TODO: Shall i implement a sorted list myself? as a data structure here? 
        /// <summary>
        /// 
        /// Notice that SortedList does not allow duplicates. 
        /// </summary>
        private SortedList<T1, T2> _keyValues;

        /// <summary>
        /// Contract: Keys of the child at index i are all smaller than key at index i of _keyValues
        /// Contract: Keys of the child at index i are all greater than key at index i-1 of _keyValues
        /// In otherWords for key at index i, left children are at index i of _children
        /// And right children are at index i+1 of _children. 
        /// </summary>
        private SortedList<BTreeNode<T1, T2>, bool> _children;

        /// <summary>
        /// Is the parent of the current node.
        /// </summary>
        public BTreeNode<T1, T2> Parent = null;

        public BTreeNode(int maxBranchingDegree)
        {
            Init(maxBranchingDegree);
        }

        public BTreeNode(int maxBranchingDegree, KeyValuePair<T1, T2> keyValue) : this(maxBranchingDegree)
        {
            InsertKey(keyValue);
        }

        public BTreeNode(int maxBranchingDegree, List<KeyValuePair<T1, T2>> keyValues, List<BTreeNode<T1, T2>> children) : this(maxBranchingDegree)
        {
            foreach (var keyVal in keyValues)
            {
                InsertKey(keyVal);
            }
            foreach (BTreeNode<T1, T2> child in children)
            {
                InsertChild(child);
            }
        }

        private void Init(int maxBranchingDegree)
        {
            MaxBranchingDegree = maxBranchingDegree;
            MinBranchingDegree = Convert.ToInt32(Math.Ceiling(Math.Round(MaxBranchingDegree / (double)2, MidpointRounding.AwayFromZero)));
            MinKeys = MinBranchingDegree - 1;
            MaxKeys = MaxBranchingDegree - 1;

            _keyValues = new SortedList<T1, T2>();
            _children = new SortedList<BTreeNode<T1, T2>, bool>();
        }

        /// <summary>
        /// Splits this node to 2 nodes if it is overflown. Such that each node have at least MinKeys keys.
        /// </summary>
        /// <returns>The new node. </returns>
        public BTreeNode<T1, T2> Split()
        {
            if (IsOverFlown())
            {
                /* A valid BtreeNode should at least have MinKey keys.*/
                List<KeyValuePair<T1, T2>> newNodeKeys = _keyValues.TakeLast(MinKeys).ToList();

                /* A valid non-leaf BTree node with MinKeys should have MinChildren children. */
                Dictionary<BTreeNode<T1, T2>, bool> newNodeChildren = _children
                    .TakeLast(MinBranchingDegree)
                    .ToDictionary(keyVal => keyVal.Key, keyVal => keyVal.Value);

                /* Remove the last MinKeys from this node.*/
                foreach (KeyValuePair<T1, T2> keyVal in newNodeKeys)
                {
                    _keyValues.Remove(keyVal.Key);
                }

                /* Remove last MinBranchingFactor children from this node. */
                foreach (KeyValuePair<BTreeNode<T1, T2>, bool> child in newNodeChildren)
                {
                    _children.Remove(child.Key);
                }

                return new BTreeNode<T1, T2>(MaxBranchingDegree, newNodeKeys, newNodeChildren.Keys.ToList());
            }

            return null;
        }

        public KeyValuePair<T1, T2> KeyToMoveUp()
        {
            return _keyValues.ElementAt(MinKeys); /* since the indexes start at 0, this means that the node has MinKeys+1 keys. */
        }

        /// <summary>
        /// Checks whether the current node is leaf. A node is leaf if it has no children. 
        /// </summary>
        /// <returns>True if the current node is leaf, and false otherwise. </returns>
        public bool IsLeaf()
        {
            if (_children.Count == 0)
                return true;
            return false;
        }

        /// <summary>
        /// Checks whether the current node is root. A node is root if it has no parent.
        /// </summary>
        /// <returns>True if the current node is root, and false otherwise.</returns>
        public bool IsRoot()
        {
            if (Parent == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Detects whether the node is full. A node is full, if it has MaxKeys keys. 
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return _keyValues.Count == MaxKeys;
        }

        /// <summary>
        /// Detects whether the node is overflown. A node is overflown, if its key count exceeds MaxKeys. 
        /// </summary>
        /// <returns>True if the node is overflown, and false otherwise. </returns>
        public bool IsOverFlown()
        {
            return _keyValues.Count > MaxKeys;
        }

        /// <summary>
        /// Detects whether the node is UnderFlown. A node is UnderFlown, if its key count falls lower than MinKeys.
        /// </summary>
        /// <returns>Truce if the node is UnderFlown, and false otherwise. </returns>
        public bool IsUnderFlown()
        {
            return _keyValues.Count < MinKeys;
        }

        public int GetIndexAtParentChildren()
        {
            if (Parent != null)
                return Parent._children.IndexOfKey(this);
            return -1;
        }

        // TODO: Test for all these methods, ... 
        // todo: perform tests of all these methods with 1 max degree, and 2 max degree, etc.. as some may reveal issues in the code, ... 


        public bool HasLeftSibling()
        {
            int index = GetIndexAtParentChildren();
            if (index == -1 || index == 0)
            {
                return false;
            }
            return true;
        }

        public bool HasRightSibling()
        {
            int index = GetIndexAtParentChildren();
            if (index == -1 || index == Parent._children.Count - 1)
            {
                return false;
            }
            return true;
        }

        public int GetRightSiblingIndexAtParentChildren()
        {
            int index = GetIndexAtParentChildren();
            if (index == -1 || index == Parent._children.Count - 1)
            {
                return -1;
            }
            return index + 1;
        }

        public int GetLeftSiblingIndexAtParentChildren()
        {
            int index = GetIndexAtParentChildren();
            if (index == -1 || index == 0)
            {
                return -1;
            }
            return index - 1;
        }

        public BTreeNode<T1, T2> GetLeftSibling()
        {
            int index = GetLeftSiblingIndexAtParentChildren();
            return index == -1 ? null : Parent._children.ElementAt(index).Key;
        }

        public bool IsMinFull()
        {
            return _keyValues.Count == MinKeys;
        }

        // TODO: Bette rname
        public bool IsMin1Full()
        {
            return _keyValues.Count == MinKeys + 1;
        }

        public BTreeNode<T1, T2> GetRightSibling()
        {
            int index = GetRightSiblingIndexAtParentChildren();
            return index == -1 ? null : Parent._children.ElementAt(index).Key;
        }
        public bool IsEmpty()
        {
            return _keyValues.Count == 0;
        }

        public KeyValuePair<T1, T2> GetMaxKey()
        {
            if (_keyValues.Any())
                return _keyValues.ElementAt(_keyValues.Count - 1);
            throw new KeyNotFoundException();
        }

        public KeyValuePair<T1, T2> GetMinKey()
        {
            if (_keyValues.Any())
                return _keyValues.ElementAt(0);
            throw new KeyNotFoundException();
        }

        public void RemoveKey(T1 key)
        {
            if (_keyValues.ContainsKey(key))
                _keyValues.Remove(key);
        }

        public void RemoveKey(int index)
        {
            if (_keyValues.Count > index)
                _keyValues.RemoveAt(index);
        }

        public void RemoveChild(int index)
        {
            if (index < _children.Count)
                _children.RemoveAt(index);
        }

        public void RemoveChild(BTreeNode<T1, T2> child)
        {
            if (_children.ContainsKey(child))
                _children.Remove(child);
        }

        public KeyValuePair<T1, T2> GetKeyValue(int index)
        {
            if (_keyValues.Count > index)
                return _keyValues.ElementAt(index);
            throw new KeyNotFoundException();
        }

        public T1 GetKey(int index)
        {
            if (_keyValues.Count > index)
                return _keyValues.ElementAt(index).Key;
            throw new KeyNotFoundException();
        }

        public BTreeNode<T1, T2> GetChild(int index)
        {
            if (_children.Count > index)
            {
                return _children.ElementAt(index).Key;
            }
            throw new KeyNotFoundException();
        }

        public int KeyCount => _keyValues.Count;

        public int ChildrenCount => _children.Count;

        public void Clear()
        {
            _keyValues.Clear();
        }

        //TODO  shall I have a getkey to just return key, and then a kevalue? because calling getkey.key makes no sense, ... 
        public int GetKeyIndex(T1 key)
        {
            if (_keyValues.ContainsKey(key))
                return _keyValues.IndexOfKey(key);
            throw new KeyNotFoundException();
        }

        public int GetChildIndex(BTreeNode<T1,T2> child)
        {
            if (_children.ContainsKey(child))
            {
                return _children.IndexOfKey(child);
            }
            throw new KeyNotFoundException();
        }

        //todo: a link to the sibling? etc, left and right siblings? or just not?

        //TODO: How can  make tis to use the binary search I have implemented in this project?
        // Expects inclusive indexes, ...
        public int Search(T1 key, int startIndex, int endIndex)
        {
            if (startIndex <= endIndex &&
                endIndex <= _keyValues.Count - 1 &&
                _keyValues.Keys[startIndex].CompareTo(key) >= 0
                && _keyValues.Keys[endIndex].CompareTo(key) <= 0)
            {
                int middleIndex = (startIndex + endIndex) / 2;

                if (_keyValues.Keys[middleIndex].CompareTo(key) == 0)
                {
                    return middleIndex;
                }
                else if (_keyValues.Keys[middleIndex].CompareTo(key) < 0)
                {
                    return Search(key, startIndex, middleIndex - 1);
                }
                else if (_keyValues.Keys[middleIndex].CompareTo(key) > 0)
                {
                    return Search(key, middleIndex + 1, endIndex);
                }
            }

            return -1;
        }

        public void InsertKey(KeyValuePair<T1, T2> keyVal)
        {
            /* Since KeyValues is a sorted list, the new key value pair will be inserted at its correct position. */
            if (!_keyValues.ContainsKey(keyVal.Key)) /* SortedList does not allow for duplicates, yet checking this as otherwise it will throw an exception.*/
                _keyValues.Add(keyVal.Key, keyVal.Value);
        }

        public void InsertChild(BTreeNode<T1, T2> child)
        {
            /* Since Children is a sorted list, Child will be inserted at its correct position based on the Compare() method, to preserve the ordering. */
            _children.Add(child, true);
            child.Parent = this;
        }

        public bool GetMinKey(out T1 minKey)
        {
            if (_keyValues.Keys.Any())
            {
                minKey = _keyValues.Keys[0];
                return true;
            }
            minKey = default(T1);
            return false;
        }

        public bool GetMaxKey(out T1 maxKey)
        {
            if (_keyValues.Keys.Any())
            {
                maxKey = _keyValues.Keys[_keyValues.Count - 1];
                return true;
            }
            maxKey = default(T1);
            return false;
        }

        // todo; summaries
        //todo; complexites
        //todo: somehow should not allow comparisons to nodes with other degrees, ... how can degree be considered, ...?
        // i want a not-applicable node, some what, ..write a test for it as well.. 
        public int CompareTo(BTreeNode<T1, T2> other)
        {
            if (other == null)
            {
                return 1;
            }

            bool resultThis = GetMinKey(out T1 minKeyThis);
            bool resultOther = other.GetMinKey(out T1 minKeyOther);

            if (!resultThis && !resultOther)
            {
                return 0;
            }

            if (!resultThis)
            {
                return -1;
            }

            if (!resultOther)
            {
                return 1;
            }

            if (minKeyThis.CompareTo(minKeyOther) < 0)
            {
                return -1;
            }
            else if (minKeyThis.CompareTo(minKeyOther) == 0)
            {
                return 0;
            }
            else if (minKeyThis.CompareTo(minKeyOther) > 0)
            {
                return 1;
            }
            return -1;
        }
    }
}
