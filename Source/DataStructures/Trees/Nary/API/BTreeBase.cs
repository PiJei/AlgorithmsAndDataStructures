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
using CSFundamentals.Decoration;

namespace CSFundamentals.DataStructures.Trees.Nary.API
{
    public abstract class BTreeBase<TNode, TKey, TValue>
        where TNode : IBTreeNode<TNode, TKey, TValue>, IComparable<TNode>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Is the root of the tree. 
        /// </summary>
        public TNode Root = default(TNode);

        /// <summary>
        /// Is the maximum number of children for a non-leaf node in this B-Tree. 
        /// </summary>
        public int MaxBranchingDegree { get; private set; }

        public BTreeBase(int maxBranchingDegree)
        {
            MaxBranchingDegree = maxBranchingDegree;
        }

        /// <summary>
        /// Given the set of key values, builds a b-tree by inserting all the key-value pairs. 
        /// </summary>
        /// <param name="keyValues">Is the list of key values to be inserted in the tree. </param>
        /// <returns>Root of the tree. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(nLog(n))")]// todo: bases are incorrect
        [TimeComplexity(Case.Average, "O(n(Log(n))")] // todo
        public TNode Build(Dictionary<TKey, TValue> keyValues)
        {
            foreach (KeyValuePair<TKey, TValue> keyValue in keyValues)
            {
                Insert(keyValue);
            }
            return Root;
        }

        // TODO: In time complexities subscripts and superscripts do not look good.
        /// <summary>
        /// Inserts a new key-value pair in the tree and returns root of the tree. 
        /// </summary>
        /// <param name="keyValue">Is the key-value pair to be inserted in the tree. </param>
        /// <returns>Root of the tree. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "Fist key in the tree is inserted.")]
        [TimeComplexity(Case.Worst, "O(D Log(n)(base:D)")] // where D is max branching factor of the tree. 
        [TimeComplexity(Case.Average, "O(d Log(n)(base d))")] // where d is min branching factor of the tree.  
        public TNode Insert(KeyValuePair<TKey, TValue> keyValue)
        {
            /* Find the leaf node that should contain the new key-value pair. The leaf is found such that the order property of the B-Tree is preserved. */
            TNode leaf = FindLeafToInsertKey(Root, keyValue.Key);

            /* Insert the new keyValue pair in the leaf node. */
            InsertInLeaf(leaf, keyValue);

            return Root;
        }

        /// <summary>
        /// Deletes the given key from the tree if it exists. 
        /// </summary>
        /// <param name="key">The key to be deleted from the tree. </param>
        /// <returns>True in case of success, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "For example, there is only one key left in the tree.")]
        [TimeComplexity(Case.Worst, "O(D Log(n)(base D))")] // where D is max branching factor of the tree. 
        [TimeComplexity(Case.Average, "O(d Log(n) base d)")] // where d is min branching factor of the tree.  
        public bool Delete(TKey key)
        {
            try
            {
                /* Find the container node of the key, and if this node exists, delete key from it.*/
                TNode node = Search(Root, key);

                return Delete(node, key);
            }
            catch (KeyNotFoundException) /* This means that the key does not exist in the tree, and thus the operation is not successful.*/
            {
                return false;
            }
        }

        public abstract TNode InsertInLeaf(TNode leaf, KeyValuePair<TKey, TValue> keyValue);

        public abstract bool Delete(TNode node, TKey key);

        /// <summary>
        /// Gets the sorted list of all the key-values in the tree rooted at <paramref name="node">. 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public abstract List<KeyValuePair<TKey, TValue>> GetSortedKeyValues(TNode node);

        public abstract TNode FindLeafToInsertKey(TNode root, TKey key);

        public abstract TNode Search(TNode root, TKey key);

        /// <summary>
        /// Finds the node that contains the maximum key of the subtree rooted at node.
        /// </summary>
        /// <param name="node">The node at which (sub)tree is rooted. </param>
        /// <returns>The node containing the maximum key of the (sub)tree rooted at <paramref name="node">. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "when node is leaf.")]
        [TimeComplexity(Case.Worst, "O(Log(n))")] // todo base is wrong
        [TimeComplexity(Case.Average, "O(Log(n))")]// todo: base is wrong, .. .
        public TNode GetMaxNode(TNode node)
        {
            if (node.IsLeaf())
            {
                return node;
            }

            return GetMaxNode(node.GetChild(node.ChildrenCount - 1));
        }

        /// <summary>
        /// Finds the node that contains the minimum key of the subtree rooted at <paramref name="node">.
        /// </summary>
        /// <param name="node">The node at which (sub)tree is rooted.</param>
        /// <returns>The node containing the minimum key of the (sub)tree rooted at <paramref name="node">.</returns>
        public TNode GetMinNode(TNode node)
        {
            if (node.IsLeaf())
            {
                return node;
            }
            return GetMinNode(node.GetChild(0));
        }

    }
}
