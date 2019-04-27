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
    public class MockBinarySearchTreeBase<TKey, TValue> : BinarySearchTreeBase<MockBinaryTreeNode<TKey, TValue>, TKey, TValue> where TKey : IComparable<TKey>
    {
        public override MockBinaryTreeNode<TKey, TValue> Build(List<KeyValuePair<TKey, TValue>> keyValues)
        {
            throw new NotImplementedException();
        }

        public override MockBinaryTreeNode<TKey, TValue> Delete(MockBinaryTreeNode<TKey, TValue> root, TKey key)
        {
            throw new NotImplementedException();
        }

        public override MockBinaryTreeNode<TKey, TValue> FindMax(MockBinaryTreeNode<TKey, TValue> root)
        {
            return FindMax_BST(root);
        }

        public override MockBinaryTreeNode<TKey, TValue> FindMin(MockBinaryTreeNode<TKey, TValue> root)
        {
            return FindMin_BST(root);
        }

        public override MockBinaryTreeNode<TKey, TValue> Insert(MockBinaryTreeNode<TKey, TValue> root, MockBinaryTreeNode<TKey, TValue> newNode)
        {
            return Insert_BST(root, newNode);
        }

        public override MockBinaryTreeNode<TKey, TValue> Search(MockBinaryTreeNode<TKey, TValue> root, TKey key)
        {
            return Search_BST(root, key);
        }

        public override bool Update(MockBinaryTreeNode<TKey, TValue> root, TKey key, TValue value)
        {
            return Update_BST(root, key, value);
        }
    }
}
