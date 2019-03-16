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
using CSFundamentals.DataStructures.Trees.API;

namespace CSFundamentalsTests.DataStructures.Trees.API
{
    public class MockBinarySearchTreeBase<T1, T2> : BinarySearchTreeBase<MockBinaryTreeNode<T1, T2>, T1, T2> where T1 : IComparable<T1>
    {
        public override MockBinaryTreeNode<T1, T2> Build(List<MockBinaryTreeNode<T1, T2>> keyValues)
        {
            throw new NotImplementedException();
        }

        public override MockBinaryTreeNode<T1, T2> Delete(MockBinaryTreeNode<T1, T2> root, T1 key)
        {
            throw new NotImplementedException();
        }

        public override MockBinaryTreeNode<T1, T2> FindMax(MockBinaryTreeNode<T1, T2> root)
        {
            return FindMax_BST(root);
        }

        public override MockBinaryTreeNode<T1, T2> FindMin(MockBinaryTreeNode<T1, T2> root)
        {
            return FindMin_BST(root);
        }

        public override MockBinaryTreeNode<T1, T2> Insert(MockBinaryTreeNode<T1, T2> root, MockBinaryTreeNode<T1, T2> newNode)
        {
            return Insert_BST(root, newNode);
        }

        public override MockBinaryTreeNode<T1, T2> Search(MockBinaryTreeNode<T1, T2> root, T1 key)
        {
            return Search_BST(root, key);
        }

        public override bool Update(MockBinaryTreeNode<T1, T2> root, T1 key, T2 value)
        {
            return Update_BST(root, key, value);
        }
    }
}
