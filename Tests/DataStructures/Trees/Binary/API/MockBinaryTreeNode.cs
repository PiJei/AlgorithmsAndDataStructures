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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using AlgorithmsAndDataStructures.DataStructures.Trees.Binary.API;

namespace AlgorithmsAndDataStructuresTests.DataStructures.Trees.Binary.API
{
    /// <summary>
    /// This class is only created for testing purposes. 
    /// TreeNode is an abstract class with generic types, and some method implementations. 
    /// We need to test those methods without using any child class in production code. 
    /// Therefore this mock class is created. 
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in a tree.</typeparam>
    /// <typeparam name="TValue">type of the values in a tree.</typeparam>
    public class MockBinaryTreeNode<TKey, TValue> : BinaryTreeNode<MockBinaryTreeNode<TKey, TValue>, TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Parameter-less constructor. 
        /// </summary>
        public MockBinaryTreeNode()
        {
        }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="key">Type of the key stored in the node. </param>
        /// <param name="value">Type of the value stored in the node. </param>
        public MockBinaryTreeNode(TKey key, TValue value) : base(key, value)
        {
        }

        /// <summary>
        /// Is a reference to the left child of the current node. 
        /// </summary>
        public override MockBinaryTreeNode<TKey, TValue> LeftChild { get; set; }

        /// <summary>
        /// Is a reference to the right child of the current node. 
        /// </summary>
        public override MockBinaryTreeNode<TKey, TValue> RightChild { get; set; }

        /// <summary>
        /// Is a reference to the parent of the current node. 
        /// </summary>
        public override MockBinaryTreeNode<TKey, TValue> Parent { get; set; }
    }
}
