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
using CSFundamentals.DataStructures.Trees.Binary.API;

namespace CSFundamentalsTests.DataStructures.Trees.Binary.API
{
    /// <summary>
    /// Implements a mock class to enable testing <see cref="BinarySearchTreeBase{TNode, TKey, TValue}"/>.
    /// </summary>
    /// <typeparam name="TKey">Type of the keys stored in the tree. </typeparam>
    /// <typeparam name="TValue">Type of the values stored in the tree. </typeparam>
    public class MockBinarySearchTreeBase<TKey, TValue> : BinarySearchTreeBase<MockBinaryTreeNode<TKey, TValue>, TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Builds the tree to include the given nodes.
        /// </summary>
        /// <param name="keyValues">Is a list of key-value pairs to be inserted in the tree.</param>
        /// <returns>Root of the tree.</returns>
        public override MockBinaryTreeNode<TKey, TValue> Build(List<KeyValuePair<TKey, TValue>> keyValues)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a node with the given key from th tree.
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which delete operation should be started. </param>
        /// <param name="key">Specifies the key of the node to be deleted. </param>
        /// <returns>New root of the tree (might or might not change during the operation).</returns>
        public override MockBinaryTreeNode<TKey, TValue> Delete(MockBinaryTreeNode<TKey, TValue> root, TKey key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the maximum key in the (sub)tree rooted at <paramref name="root"/> node. 
        /// </summary>
        /// <param name="root">Is the node at which (sub)tree is rooted. </param>
        /// <returns>The node containing the maximum key. </returns>
        public override MockBinaryTreeNode<TKey, TValue> FindMax(MockBinaryTreeNode<TKey, TValue> root)
        {
            return FindMax_BST(root);
        }

        /// <summary>
        /// Finds the minimum key in the (sub)tree rooted at <paramref name="root"/> node. 
        /// </summary>
        /// <param name="root">Is the node at which (sub)tree is rooted. </param>
        /// <returns>The node containing the minimum key. </returns>
        public override MockBinaryTreeNode<TKey, TValue> FindMin(MockBinaryTreeNode<TKey, TValue> root)
        {
            return FindMin_BST(root);
        }

        /// <summary>
        /// Inserts a new node in the tree
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which insert operation should be started.</param>
        /// <param name="newNode">New node to be inserted in the tree. </param>
        /// <returns>New root of the tree (might or might not change during operation).</returns>
        public override MockBinaryTreeNode<TKey, TValue> Insert(MockBinaryTreeNode<TKey, TValue> root, MockBinaryTreeNode<TKey, TValue> newNode)
        {
            return Insert_BST(root, newNode);
        }

        /// <summary>
        /// Searches for the given key in the tree. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which search operation should be started. </param>
        /// <param name="key">Specifies the key to be searched. </param>
        /// <returns>Returns the tree node that contains key. </returns>
        public override MockBinaryTreeNode<TKey, TValue> Search(MockBinaryTreeNode<TKey, TValue> root, TKey key)
        {
            return Search_BST(root, key);
        }

        /// <summary>
        /// Updates the tree node of the specified key with the new given value. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which update operation should be started.</param>
        /// <param name="key">Specifies the key of the node whose value should be updated.</param>
        /// <param name="value">Specifies the new value. </param>
        /// <returns>true in case of success and false otherwise.</returns>
        public override bool Update(MockBinaryTreeNode<TKey, TValue> root, TKey key, TValue value)
        {
            return Update_BST(root, key, value);
        }
    }
}
