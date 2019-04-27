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
using System.Linq;

namespace CSFundamentals.DataStructures.Trees.Nary.API
{
    /// <summary>
    /// Implements a base B-Tree node. 
    /// </summary>
    /// <typeparam name="TNode">Type of B-Tree node.</typeparam>
    /// <typeparam name="TKey">Type of the key stored in the B-Tree node. </typeparam>
    /// <typeparam name="TValue">Type of the value stored in the B-Tree node. </typeparam>
    public abstract class BTreeNodeBase<TNode, TKey, TValue> :
        IBTreeNode<TNode, TKey, TValue>,
        IComparable<TNode>
        where TNode : IBTreeNode<TNode, TKey, TValue>, new()
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// A list of key-value pairs stored in this node. 
        /// Notice that SortedList does not allow duplicates. 
        /// </summary>
        protected SortedList<TKey, TValue> _keyValues;

        /// <summary>
        /// Children of the current node. 
        /// Contract: Keys of the child at index i are all smaller than key at index i of _keyValues
        /// Contract: Keys of the child at index i are all greater than key at index i-1 of _keyValues
        /// In otherWords for key at index i, left children are at index i of _children
        /// And right children are at index i+1 of _children. 
        /// </summary>
        protected SortedList<TNode, bool> _children;

        /// <summary>
        /// Is the parent of the current node.
        /// </summary>
        protected TNode _parent;

        /// <summary>
        /// Is the minimum number of keys in a B-tree internal/leaf node. (Notice that a root has no lower bound on the number of keys. Intuitively when the tree is just being built it might start with 1, and grow afterwards.)
        /// </summary>
        public int MinKeys => MinBranchingDegree - 1;

        /// <summary>
        /// Is the maximum number of keys in a B-tree internal/leaf/root node. This is often 2 times the MinKeys.
        /// </summary>
        public int MaxKeys => MaxBranchingDegree - 1;

        /// <summary>
        /// Is the minimum number of branches/children a B-tree internal node can have. 
        /// </summary>
        public int MinBranchingDegree => Convert.ToInt32(Math.Ceiling(Math.Round(MaxBranchingDegree / (double)2, MidpointRounding.AwayFromZero)));

        /// <summary>
        /// Is the maximum number of branches/children a B-tree internal or root node can have. Leaf nodes contain 0 children. 
        /// </summary>
        public int MaxBranchingDegree { get; set; }

        /// <summary>
        /// Parameter-less constructor.
        /// </summary>
        public BTreeNodeBase()
        {
            _keyValues = new SortedList<TKey, TValue>();
            _children = new SortedList<TNode, bool>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxBranchingDegree">Maximum branching factor or the maximum number of children the node can have. </param>
        public BTreeNodeBase(int maxBranchingDegree) : this()
        {
            MaxBranchingDegree = maxBranchingDegree;
        }

        /// <summary>
        /// Creates a node with 1 key. 
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        /// <param name="keyValue">Is a key-value pair to be inserted in the tree. </param>
        public BTreeNodeBase(int maxBranchingDegree, KeyValuePair<TKey, TValue> keyValue) : this(maxBranchingDegree)
        {
            InsertKeyValue(keyValue);
        }

        /// <summary>
        /// Creates a node with a set of keys and children.
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        /// <param name="keyValues">Is a set of key-value pairs to be inserted in the new node. </param>
        /// <param name="children">Is a set of children of the node. Expectancy is that the count of children is one bigger than the count of key-value pairs in the node. </param>
        public BTreeNodeBase(int maxBranchingDegree, List<KeyValuePair<TKey, TValue>> keyValues, List<TNode> children) : this(maxBranchingDegree)
        {
            foreach (var keyVal in keyValues)
            {
                InsertKeyValue(keyVal);
            }
            foreach (TNode child in children)
            {
                InsertChild(child);
            }
        }

        /// <summary>
        /// Is the count of key-value pairs in the node. 
        /// </summary>
        public int KeyCount
        {
            get
            {
                return _keyValues.Count;
            }
        }

        /// <summary>
        /// Is the count of the children of the node. 
        /// </summary>
        public int ChildrenCount
        {
            get
            {
                return _children.Count;
            }
        }

        /// <summary>
        /// Removes all the keys from the node. 
        /// </summary>
        public void Clear()
        {
            _keyValues.Clear();
            _children.Clear();
        }

        /// <summary>
        /// Returns the list of key-value pairs stored in this node. 
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<TKey, TValue>> GetKeyValues()
        {
            return _keyValues.ToList();
        }

        /// <summary>
        /// Checks whether the current node is leaf. A node is leaf if it has no children. 
        /// </summary>
        /// <returns>True if the current node is leaf, and false otherwise. </returns>
        public bool IsLeaf()
        {
            return ChildrenCount == 0 ? true : false;
        }

        /// <summary>
        /// Checks whether the current node is root. A node is root if it has no parent.
        /// </summary>
        /// <returns>True if the current node is root, and false otherwise.</returns>
        public bool IsRoot()
        {
            return _parent == null ? true : false;
        }

        /// <summary>
        /// Detects whether the node is full. A node is full, if it has MaxKeys keys. 
        /// </summary>
        /// <returns>Truce if the node is full, and false otherwise. </returns>
        public bool IsFull()
        {
            return KeyCount == MaxKeys;
        }

        /// <summary>
        /// Checks whether the node is overflown. A node is overflown, if its key count exceeds MaxKeys. 
        /// </summary>
        /// <returns>True if the node is overflown, and false otherwise. </returns>
        public bool IsOverFlown()
        {
            return KeyCount > MaxKeys;
        }

        /// <summary>
        /// Checks whether the node is UnderFlown. A node is UnderFlown, if its key count falls lower than MinKeys.
        /// </summary>
        /// <returns>Truce if the node is UnderFlown, and false otherwise. </returns>
        public bool IsUnderFlown()
        {
            return KeyCount < MinKeys;
        }

        /// <summary>
        /// Checks whether a node is MinFull: meaning it has exactly MinKeys key-value pairs. 
        /// </summary>
        /// <returns>True if case is MinFull, false otherwise. </returns>
        public bool IsMinFull()
        {
            return KeyCount == MinKeys;
        }

        /// <summary>
        /// Checks whether a node is MinOneFull: meaning it has exactly MinKeys+1 key-value pairs. 
        /// </summary>
        /// <returns>True if it is MinOneFull, false otherwise. </returns>
        public bool IsMinOneFull()
        {
            return KeyCount == MinKeys + 1;
        }

        /// <summary>
        /// Checks whether a node is empty: meaning has no key-value pairs. 
        /// </summary>
        /// <returns>True if the node is free, and false otherwise. </returns>
        public bool IsEmpty()
        {
            return KeyCount == 0;
        }

        /// <summary>
        /// Gets the index of the current node in its parent's <see cref="_children"/> list.
        /// </summary>
        /// <returns>Index at parent's <see cref="_children"/> list.</returns>
        public abstract int GetIndexAtParentChildren();

        /// <summary>
        /// Inserts a child in <see cref="_children"/> array.
        /// </summary>
        /// <param name="child">the new child to be inserted in <see cref="_children"/> array. </param>
        public abstract void InsertChild(TNode child);

        /// <summary>
        /// Checks whether the current node has a left sibling (a sibling to its left in the parent). 
        /// </summary>
        /// <returns>True if the node has a left sibling, and false otherwise. </returns>
        public bool HasLeftSibling()
        {
            int index = GetIndexAtParentChildren();

            /* If this node is the left-most child at its parent, it does not have a left sibling.*/
            return index == 0 ? false : true;
        }

        /// <summary>
        /// Checks whether the current node has a right sibling (a sibling to its right in the parent).
        /// </summary>
        /// <returns>True if the node has a right sibling, and false otherwise. </returns>
        public bool HasRightSibling()
        {
            int index = GetIndexAtParentChildren();

            /* If this node is the right-most child at its parent, it does not have a right sibling.*/
            return index == _parent.ChildrenCount - 1 ? false : true;
        }

        /// <summary>
        /// Gets the node's left sibling node. 
        /// </summary>
        /// <returns>Node's left sibling node if it exists, and null otherwise. </returns>
        public TNode GetLeftSibling()
        {
            int selfIndex = GetIndexAtParentChildren();
            if (selfIndex == 0)
            {
                return default(TNode);
            }
            int leftSiblingIndex = selfIndex - 1;
            return _parent.GetChild(leftSiblingIndex);
        }

        /// <summary>
        /// Gets the node's right sibling node. 
        /// </summary>
        /// <returns>Node's right sibling node if it exists and null otherwise. </returns>
        public TNode GetRightSibling()
        {
            int selfIndex = GetIndexAtParentChildren();
            if (selfIndex == _parent.ChildrenCount - 1)
            {
                return default(TNode);
            }
            int rightSiblingIndex = selfIndex + 1;
            return _parent.GetChild(rightSiblingIndex);
        }

        /// <summary>
        /// Gets the key-value pair of the maximum key in the node.
        /// </summary>
        /// <returns>Key-value pair of the maximum key in this node. </returns>
        public KeyValuePair<TKey, TValue> GetMaxKey()
        {
            return _keyValues.Any() ? _keyValues.ElementAt(KeyCount - 1) : throw new KeyNotFoundException();
        }

        /// <summary>
        /// Gets the key-value pair of the minimum key in the node. 
        /// </summary>
        /// <returns>Key-value pair of the minimum key in this node. </returns>
        public KeyValuePair<TKey, TValue> GetMinKey()
        {
            return _keyValues.Any() ? _keyValues.ElementAt(0) : throw new KeyNotFoundException();
        }

        /// <summary>
        /// Removes key <paramref name="key"/> from the node's <see cref="_keyValues"/> array. 
        /// </summary>
        /// <param name="key">Is the key to be removed.</param>
        public void RemoveKey(TKey key)
        {
            if (_keyValues.ContainsKey(key))
            {
                _keyValues.Remove(key);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        /// <summary>
        /// Removes key at index <paramref name="index"/> from the node's <see cref="_keyValues"/> array. 
        /// </summary>
        /// <param name="index">The index of the key to be removed from the node. </param>
        public void RemoveKeyByIndex(int index)
        {
            if (index < KeyCount)
            {
                _keyValues.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException($"The node contains {KeyCount} keys, can not remove a non-existing key at index {index}.");
            }
        }

        /// <summary>
        /// Removes child at index <paramref name="index"/> from the node's <see cref="_children"/> array.
        /// </summary>
        /// <param name="index">The child index. </param>
        public void RemoveChildByIndex(int index)
        {
            if (index < _children.Count)
            {
                _children.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Removes child <paramref name="child"/> from the node's <see cref="_children"/> array.
        /// </summary>
        /// <param name="child">Child to be removed. </param>
        public void RemoveChild(TNode child)
        {
            if (_children.ContainsKey(child))
            {
                _children.Remove(child);
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        /// <summary>
        /// Gets (reads) the key-value pair at index <paramref name="index"/> of node's <see cref="_keyValues"/> array. 
        /// </summary>
        /// <param name="index">The index of the key-value pair wanted. </param>
        /// <returns>Key-value pair located at index <paramref name="index"/> of node's <see cref="_keyValues"/> array. </returns>
        public KeyValuePair<TKey, TValue> GetKeyValue(int index)
        {
            return index < KeyCount ? _keyValues.ElementAt(index) : throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Gets (reads)the key of the key-value pair at index <paramref name="index"/> of node's <see cref="_keyValues"/> array.
        /// </summary>
        /// <param name="index">The index of the key-value pair whose key is wanted. </param>
        /// <returns>Key at index <paramref name="index"/> of node's <see cref="_keyValues"/> array. </returns>
        public TKey GetKey(int index)
        {
            return GetKeyValue(index).Key;
        }

        /// <summary>
        /// Gets the index of the key <paramref name="key"/> at node's <see cref="_keyValues"/> array. 
        /// </summary>
        /// <param name="key">The key to search for and return its index.</param>
        /// <returns>Index of the key <paramref name="key"/> at node's <see cref="_keyValues"/> array. </returns>
        public int GetKeyIndex(TKey key)
        {
            return _keyValues.ContainsKey(key) ? _keyValues.IndexOfKey(key) : throw new KeyNotFoundException();
        }

        /// <summary>
        /// Gets (reads) the child at index <paramref name="index"/> of node's <see cref="_children"/> array.
        /// </summary>
        /// <param name="index">The index of the child node wanted. </param>
        /// <returns>Child node at index <paramref name="index"/> of node's <see cref="_children"/> array.</returns>
        public TNode GetChild(int index)
        {
            return ChildrenCount > index ? _children.ElementAt(index).Key : throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// Looks for <paramref name="child"/> in node's <see cref="_children"/> array, and returns its index.
        /// </summary>
        /// <param name="child">Child whose index is wanted. </param>
        /// <returns>Index of <paramref name="child"/> in node's <see cref="_children"/> array</returns>
        public int GetChildIndex(TNode child)
        {
            return _children.ContainsKey(child) ? _children.IndexOfKey(child) : throw new KeyNotFoundException();
        }

        /// <summary>
        /// Inserts the given key-value pair in <see cref="_keyValues"/> array. 
        /// </summary>
        /// <param name="keyVal">the new key-value pair to be inserted in <see cref="_keyValues"/> array. </param>
        public void InsertKeyValue(KeyValuePair<TKey, TValue> keyVal)
        {
            /* Since KeyValues is a sorted list, the new key value pair will be inserted at its correct position. */
            if (!_keyValues.ContainsKey(keyVal.Key)) /* SortedList does not allow for duplicates, yet checking this as otherwise it will throw an exception.*/
            {
                _keyValues.Add(keyVal.Key, keyVal.Value);
            }
        }

        /// <summary>
        /// Sets the parent node of the current node. 
        /// </summary>
        /// <param name="parent">Parent node of the current node. </param>
        public void SetParent(TNode parent)
        {
            _parent = parent;
        }

        /// <summary>
        /// Gets the parent node of the current node. 
        /// </summary>
        /// <returns>Parent node of the current node. </returns>
        public TNode GetParent()
        {
            return _parent;
        }

        /// <summary>
        /// Splits this node to 2 nodes if it is overflown, such that each node has at least MinKeys keys.
        /// </summary>
        /// <returns>The new node. </returns>
        public TNode Split()
        {
            if (IsOverFlown())
            {
                /* Create a new node (aka left sibling, as it is taking the right most key-values )*/
                var newNode = new TNode
                {
                    MaxBranchingDegree = MaxBranchingDegree
                };

                /* A valid BtreeNode should at least have MinKey keys.*/
                var newNodeKeys = _keyValues.TakeLast(MinKeys).ToList();

                /* A valid non-leaf BTree node with MinKeys should have MinChildren children. */
                var newNodeChildren = _children
                    .TakeLast(MinBranchingDegree)
                    .ToDictionary(keyVal => keyVal.Key, keyVal => keyVal.Value);

                /* Remove the last MinKeys from this node.*/
                foreach (KeyValuePair<TKey, TValue> keyVal in newNodeKeys)
                {
                    _keyValues.Remove(keyVal.Key);
                    newNode.InsertKeyValue(keyVal);
                }

                /* Remove last MinBranchingFactor children from this node. */
                foreach (KeyValuePair<TNode, bool> child in newNodeChildren)
                {
                    _children.Remove(child.Key);
                    newNode.InsertChild(child.Key);
                }

                return newNode;
            }

            return default(TNode);
        }

        /// <summary>
        /// When a node is being split into two nodes, gets the key that shall be moved to the parent of this node.
        /// This operation is expected to only be called upon a node that is full. Yet to prevent issues, first checks for the key count. 
        /// </summary>
        /// <returns>The key at the middle of the key-value pairs that shall be moved to the parent. </returns>
        public KeyValuePair<TKey, TValue> KeyValueToMoveUp()
        {
            if (IsMinOneFull())
            {
                return _keyValues.ElementAt(MinKeys); /* since the indexes tart at 0, this means that the node has MinKeys+1 keys. */
            }

            throw new ArgumentException($"Failed to get a key to move up to parent. The node has less or more than {MinKeys + 1} keys.");
        }

        /// <summary>
        /// Compares current node to another node. 
        /// </summary>
        /// <param name="other">A tree node. </param>
        /// <returns>0 if they are equal, 1 if the current node is bigger and -1 otherwise. </returns>
        public int CompareTo(TNode other)
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
