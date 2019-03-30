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
using CSFundamentals.DataStructures.Trees.API;

namespace CSFundamentalsTests.DataStructures.Trees.API
{
    /// <summary>
    /// This class is only created for testing purposes. 
    /// TreeNode is an abstract class with generic types, and some method implementations. 
    /// We need to test those methods without using any child class in production code. 
    /// Therefore this mock class is created. 
    /// </summary>
    /// <typeparam name="TKey">Specifies the type of the keys in a tree.</typeparam>
    /// <typeparam name="TValue">Specifies type of the values in a tree.</typeparam>
    public class MockBinaryTreeNode<TKey, TValue> : BinaryTreeNode<MockBinaryTreeNode<TKey, TValue>, TKey, TValue> where TKey : IComparable<TKey>
    {
        public MockBinaryTreeNode(TKey key, TValue value) : base(key, value)
        {
        }

        public override MockBinaryTreeNode<TKey, TValue> LeftChild { get; set; }
        public override MockBinaryTreeNode<TKey, TValue> RightChild { get; set; }
        public override MockBinaryTreeNode<TKey, TValue> Parent { get; set; }
    }
}
