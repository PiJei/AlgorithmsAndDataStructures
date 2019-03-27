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

//TODO: part of me thinks that I should strengthen the inserts and etc,... because this should be a proper BTRee node, ... and shall not allow things that result in over flows, under flows, keys with no children, etc, ... ?//but this might make algorithms diff toimplement, .. 
//todo; complexites
//todo: somehow should not allow comparisons to nodes with other degrees, ... how can degree be considered, ...?
// i want a not-applicable node, some what, ..write a test for it as well.. 
// TODO: Test for search. ... 
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

        /// <summary>
        /// Creates a node with no keys. 
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        public BTreeNode(int maxBranchingDegree)
        {
            Init(maxBranchingDegree);
        }
        /// <summary>
        /// Creates a node with 1 key. 
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        /// <param name="keyValue">Is a key-value pair to be inserted in the tree. </param>
        public BTreeNode(int maxBranchingDegree, KeyValuePair<T1, T2> keyValue) : this(maxBranchingDegree)
        {
            InsertKeyValue(keyValue);
        }

        /// <summary>
        /// Creates a node with a set of keys and children.
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        /// <param name="keyValues">Is a set of key-value pairs to be inserted in the new node. </param>
        /// <param name="children">Is a set of children of the node. Expectancy is that the count of children is one bigger than the count of key-value pairs in the node. </param>
        public BTreeNode(int maxBranchingDegree, List<KeyValuePair<T1, T2>> keyValues, List<BTreeNode<T1, T2>> children) : this(maxBranchingDegree)
        {
            foreach (var keyVal in keyValues)
            {
                InsertKeyValue(keyVal);
            }
            foreach (BTreeNode<T1, T2> child in children)
            {
                InsertChild(child);
            }
        }

        /// <summary>
        /// Initializes the node.
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
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
        /// Is the count of key-value pairs in the node. 
        /// </summary>
        public int KeyCount => _keyValues.Count;

        /// <summary>
        /// Is the count of the children of the node. 
        /// </summary>
        public int ChildrenCount => _children.Count;

        /// <summary>
        /// Removes all the keys from the node. 
        /// </summary>
        public void Clear()
        {
            _keyValues.Clear();
        }

        /// <summary>
        /// Splits this node to 2 nodes if it is overflown, such that each node has at least MinKeys keys.
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

        /// <summary>
        /// When a node is being split into two nodes, gets the key that shall be moved to the parent of this node.
        /// This operation is expected to only be called upon a node that is full. Yet to prevent issues, first checks for the key count. 
        /// </summary>
        /// <returns>The key at the middle of the key-value pairs that shall be moved to the parent. </returns>
        public KeyValuePair<T1, T2> KeyValueToMoveUp()
        {
            if (MinKeys < _keyValues.Count)
                return _keyValues.ElementAt(MinKeys); /* since the indexes tart at 0, this means that the node has MinKeys+1 keys. */
            throw new KeyNotFoundException($"The node has less than {MinKeys + 1} keys. Can not return element at {MinKeys}.");
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
        /// <returns>Truce if the node is full, and false otherwise. </returns>
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

        /// <summary>
        /// Gets the index of the current node in its parent's <see cref="_children"/> list.
        /// </summary>
        /// <returns>Index at parent's <see cref="_children"/> list.</returns>
        public int GetIndexAtParentChildren()
        {
            if (Parent != null)
            {
                if (Parent._children.ContainsKey(this))
                {
                    return Parent._children.IndexOfKey(this);
                }
                else
                {
                    throw new KeyNotFoundException($"Parent does not have a child reference to this node. ");
                }
            }
            throw new ArgumentException($"Failed to get index of the node at its parent's children array. Parent is null.");
        }

        /// <summary>
        /// Detects whether the current node has a left sibling (a sibling to its left in the parent). 
        /// </summary>
        /// <returns>True if the node has a left sibling, and false otherwise. </returns>
        public bool HasLeftSibling()
        {
            int index = GetIndexAtParentChildren();
            if (index == 0) /* If this node is the left-most child at its parent, it does not have a left sibling.*/
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Detects whether the current node has a right sibling (a sibling to its right in the parent).
        /// </summary>
        /// <returns>True if the node has a right sibling, and false otherwise. </returns>
        public bool HasRightSibling()
        {
            int index = GetIndexAtParentChildren();
            if (index == Parent._children.Count - 1) /* If this node is the right-most child at its parent, it does not have a right sibling.*/
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets the index of the node's left sibling at its parent's <see cref="_children"/> array.
        /// </summary>
        /// <returns>Index of the left sibling at parent's <see cref="_children"/> array. </returns>
        public int GetLeftSiblingIndexAtParentChildren()
        {
            int index = GetIndexAtParentChildren();
            if (index == 0)
            {
                throw new ArgumentException($"Node does not have left sibling.");
            }
            return index - 1;
        }

        /// <summary>
        /// Gets the index of the node's right sibling at its parent's <see cref="_children"/> array.
        /// </summary>
        /// <returns>Index of the right sibling at parent's <see cref="_children"/> array. </returns>
        public int GetRightSiblingIndexAtParentChildren()
        {
            int index = GetIndexAtParentChildren();
            if (index == Parent._children.Count - 1)
            {
                throw new ArgumentException($"Node does not have right sibling.");
            }
            return index + 1;
        }

        /// <summary>
        /// Gets the node's left sibling node. 
        /// </summary>
        /// <returns>Node's left sibling node. </returns>
        public BTreeNode<T1, T2> GetLeftSibling()
        {
            int index = GetLeftSiblingIndexAtParentChildren();
            return Parent._children.ElementAt(index).Key;
        }

        /// <summary>
        /// Gets the node's right sibling node. 
        /// </summary>
        /// <returns>Node's right sibling node. </returns>
        public BTreeNode<T1, T2> GetRightSibling()
        {
            int index = GetRightSiblingIndexAtParentChildren();
            return Parent._children.ElementAt(index).Key;
        }

        /// <summary>
        /// Detects whether a node is MinFull: meaning it has exactly MinKeys key-value pairs. 
        /// </summary>
        /// <returns>True if case is MinFull, false otherwise. </returns>
        public bool IsMinFull()
        {
            return _keyValues.Count == MinKeys;
        }

        /// <summary>
        /// Detects whether a node is min1full: meaning it has exactly MinKeys+1 key-value pairs. 
        /// </summary>
        /// <returns>True if it is min1full, false otherwise. </returns>
        public bool IsMin1Full()
        {
            return _keyValues.Count == MinKeys + 1;
        }

        /// <summary>
        /// Detects whether a node is empty: meaning has no key-value pairs. 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _keyValues.Count == 0;
        }

        /// <summary>
        /// Gets the key-value pair of the maximum key in the node.
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<T1, T2> GetMaxKey()
        {
            if (_keyValues.Any())
                return _keyValues.ElementAt(_keyValues.Count - 1);
            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Gets the key-value pair of the minimum key in the node. 
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<T1, T2> GetMinKey()
        {
            if (_keyValues.Any())
                return _keyValues.ElementAt(0);
            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Removes key <paramref name="key"/> from the node's <see cref="_keyValues"> array. 
        /// </summary>
        /// <param name="key">Is the key to be removed.</param>
        public void RemoveKey(T1 key)
        {
            if (_keyValues.ContainsKey(key))
                _keyValues.Remove(key);
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Removes key at index <paramref name="index"/> from the node's <see cref="_keyValues"> array. 
        /// </summary>
        /// <param name="index">The index of the key to be removed from the node. </param>
        public void RemoveKeyByIndex(int index)
        {
            if (_keyValues.Count > index)
                _keyValues.RemoveAt(index);
            else
                throw new IndexOutOfRangeException($"The node contains {KeyCount} keys, can not remove a non-existing key at index {index}.");
        }

        /// <summary>
        /// Removes child at index <paramref name="index"/> from the node's <see cref="_children"> array.
        /// </summary>
        /// <param name="index">The child index. </param>
        public void RemoveChildByIndex(int index)
        {
            if (index < _children.Count)
                _children.RemoveAt(index);
            else
                throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Removes child <paramref name="child"/> from the node's <see cref="_children"> array.
        /// </summary>
        /// <param name="child">Child to be removed. </param>
        public void RemoveChild(BTreeNode<T1, T2> child)
        {
            if (_children.ContainsKey(child))
                _children.Remove(child);
            else
                throw new KeyNotFoundException();
        }

        /// <summary>
        /// Gets (reads) the key-value pair at index <paramref name="index"/> of node's <see cref="_keyValues"> array. 
        /// </summary>
        /// <param name="index">The index of the key-value pair wanted. </param>
        /// <returns>Key-value pair located at index <paramref name="index"/> of node's <see cref="_keyValues"> array. </returns>
        public KeyValuePair<T1, T2> GetKeyValue(int index)
        {
            if (_keyValues.Count > index)
                return _keyValues.ElementAt(index);
            throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Gets (reads)the key of the key-value pair at index <paramref name="index"/> of node's <see cref="_keyValues"> array.
        /// </summary>
        /// <param name="index">The index of the key-value pair whose key is wanted. </param>
        /// <returns>Key at index <paramref name="index"/> of node's <see cref="_keyValues"> array. </returns>
        public T1 GetKey(int index)
        {
            return GetKeyValue(index).Key;
        }

        /// <summary>
        /// Gets the index of the key <paramref name="key"/> at node's <see cref="_keyValues"> array. 
        /// </summary>
        /// <param name="key">The key to search for and return its index.</param>
        /// <returns>Index of the key <paramref name="key"/> at node's <see cref="_keyValues"> array. </returns>
        public int GetKeyIndex(T1 key)
        {
            if (_keyValues.ContainsKey(key))
                return _keyValues.IndexOfKey(key);
            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Gets (reads) the child at index <paramref name="index"/> of node's <see cref="_children"> array.
        /// </summary>
        /// <param name="index">The index of the child node wanted. </param>
        /// <returns>Child node at index <paramref name="index"/> of node's <see cref="_children"> array.</returns>
        public BTreeNode<T1, T2> GetChild(int index)
        {
            if (_children.Count > index)
            {
                return _children.ElementAt(index).Key;
            }
            throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Looks for <paramref name="child"/> in node's <see cref="_children"> array, and returns its index.
        /// </summary>
        /// <param name="child">Child whose index is wanted. </param>
        /// <returns>Index of <paramref name="child"/> in node's <see cref="_children"> array</returns>
        public int GetChildIndex(BTreeNode<T1, T2> child)
        {
            if (_children.ContainsKey(child))
            {
                return _children.IndexOfKey(child);
            }
            throw new KeyNotFoundException();
        }

        //TODO: How can  make tis to use the binary search I have implemented in this project?
        /// <summary>
        /// Performs a binary search over <see cref="_keyValues"/> array of the node. 
        /// </summary>
        /// <param name="key">Key we are searching for. </param>
        /// <param name="startIndex">Inclusive start index at <see cref="_keyValues"/> array. </param>
        /// <param name="endIndex">Inclusive end index at <see cref="_keyValues"/> array. </param>
        /// <returns>Index of the key in the <see cref="_keyValues"> array if it exists and -1 if it does not.</returns>
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

        /// <summary>
        /// Inserts the given key-value pair in <see cref="_keyValues"/> array. 
        /// </summary>
        /// <param name="keyVal">the new key-value pair to be inserted in <see cref="_keyValues"/> array. </param>
        public void InsertKeyValue(KeyValuePair<T1, T2> keyVal)
        {
            /* Since KeyValues is a sorted list, the new key value pair will be inserted at its correct position. */
            if (!_keyValues.ContainsKey(keyVal.Key)) /* SortedList does not allow for duplicates, yet checking this as otherwise it will throw an exception.*/
                _keyValues.Add(keyVal.Key, keyVal.Value);
        }

        /// <summary>
        /// Inserts a child in <see cref="_children"/> array.
        /// </summary>
        /// <param name="child">the new child to be inserted in <see cref="_children"/> array. </param>
        public void InsertChild(BTreeNode<T1, T2> child)
        {
            /* Since Children is a sorted list, Child will be inserted at its correct position based on the Compare() method, to preserve the ordering. */
            _children.Add(child, true);
            child.Parent = this;
        }

        
        public int CompareTo(BTreeNode<T1, T2> other)
        {
            if (other == null)
            {
                return 1;
            }
            if (KeyCount == 0 && other.KeyCount == 0)
            {
                return 0;
            }
            if (KeyCount == 0)
            {
                return -1;
            }
            if (other.KeyCount == 0)
            {
                return 1;
            }

            var minKeyThis = GetMinKey();
            var minKeyOther = other.GetMinKey();

            if (minKeyThis.Key.CompareTo(minKeyOther.Key) < 0)
            {
                return -1;
            }
            else if (minKeyThis.Key.CompareTo(minKeyOther.Key) == 0)
            {
                return 0;
            }
            else if (minKeyThis.Key.CompareTo(minKeyOther.Key) > 0)
            {
                return 1;
            }
            return -1;
        }
    }
}
