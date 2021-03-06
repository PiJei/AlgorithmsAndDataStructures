﻿#region copyright
/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of AlgorithmsAndDataStructures project.
 *
 * AlgorithmsAndDataStructures is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AlgorithmsAndDataStructures is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.Trees.Binary.API;
using AlgorithmsAndDataStructures.Decoration;

namespace AlgorithmsAndDataStructures.DataStructures.Trees.Binary
{
    /// <summary>
    /// Implements a binary search tree, and its operations. In a binary search tree, each node's key is larger than its left child's key, and smaller than its right child's key.
    /// A binary Search Tree can be used as a key-value store. 
    /// </summary>
    /// <typeparam name="TKey">The type of the key in tree nodes.</typeparam>
    /// <typeparam name="TValue">The type of the value in tree nodes. </typeparam>
    [DataStructure("BinarySearchTree (aka BST)")]
    public class BinarySearchTreeBase<TKey, TValue> : BinarySearchTreeBase<BinarySearchTreeNode<TKey, TValue>, TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Builds the tree to include the given nodes.
        /// </summary>
        /// <param name="keyValues">A list of key-value pairs to be inserted in the tree.</param>
        /// <returns>Root of the tree.</returns>
        [TimeComplexity(Case.Best, "O(n)", When = "Every new node is inserted in the very first locations.")]
        [TimeComplexity(Case.Worst, "O(n²)", When = "Tree is unbalanced such that it is turned into a linked list.")]
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        [SpaceComplexity("O(n)")]
        public override BinarySearchTreeNode<TKey, TValue> Build(List<KeyValuePair<TKey, TValue>> keyValues)
        {
            return Build_BST(keyValues);
        }

        /// <summary>
        /// Inserts a new node in the tree
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which insert operation should be started.</param>
        /// <param name="newNode">New node to be inserted in the tree. </param>
        /// <returns>New root of the tree (might or might not change during operation).</returns>
        [TimeComplexity(Case.Best, "O(1)", When = "The tree is empty, and the first node is added.")]
        [TimeComplexity(Case.Worst, "O(n)", When = "Tree is imbalanced such that it is like one sequential branch (linked list), every node except the leaf having exactly one child.")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)] /* Notice that a new node is allocated for a new key, thus can be considered as O(Size(TreeNode))*/
        public override BinarySearchTreeNode<TKey, TValue> Insert(BinarySearchTreeNode<TKey, TValue> root, BinarySearchTreeNode<TKey, TValue> newNode)
        {
            return Insert_BST(root, newNode);
        }

        /// <summary>
        /// Deletes a node with the given key from th tree.
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which delete operation should be started. </param>
        /// <param name="key">The key of the node to be deleted. </param>
        /// <returns>New root of the tree (might or might not change during the operation).</returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)", When = "Tree is imbalanced such that it is like one sequential branch (linked list), every node except the leaf having exactly one child.")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public override BinarySearchTreeNode<TKey, TValue> Delete(BinarySearchTreeNode<TKey, TValue> root, TKey key)
        {
            return Delete_BST(root, key);
        }

        /// <summary>
        /// Implements Search/Lookup/Find operation for a BinarySearchTree. 
        /// </summary>
        /// <param name="root">The root of the tree.</param>
        /// <param name="key">The key, the method should look for. </param>
        /// <returns>The tree node that has the key. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)", When = "Tree is imbalanced such that it is like one sequential branch (linked list), every node except the leaf having exactly one child.")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public override BinarySearchTreeNode<TKey, TValue> Search(BinarySearchTreeNode<TKey, TValue> root, TKey key)
        {
            return Search_BST(root, key);
        }

        /// <summary>
        /// Implements Update operation for a BinarySearchTree.
        /// </summary>
        /// <param name="root">The root of the tree.</param>
        /// <param name="key">The key of the node for which the value should be updated. </param>
        /// <param name="value">The new value for the given key. </param>
        /// <returns>True in case of success, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "o(n)")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public override bool Update(BinarySearchTreeNode<TKey, TValue> root, TKey key, TValue value)
        {
            return Update_BST(root, key, value);
        }

        /// <summary>
        /// Finds the minimum key in the (sub)tree rooted at <paramref name="root"/> node. 
        /// </summary>
        /// <param name="root">The node at which (sub)tree is rooted. </param>
        /// <returns>The node containing the minimum key. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public override BinarySearchTreeNode<TKey, TValue> FindMin(BinarySearchTreeNode<TKey, TValue> root)
        {
            return FindMin_BST(root);
        }

        /// <summary>
        /// Finds the maximum key in the (sub)tree rooted at <paramref name="root"/> node. 
        /// </summary>
        /// <param name="root">The node at which (sub)tree is rooted. </param>
        /// <returns>The node containing the maximum key. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public override BinarySearchTreeNode<TKey, TValue> FindMax(BinarySearchTreeNode<TKey, TValue> root)
        {
            return FindMax_BST(root);
        }
    }
}
