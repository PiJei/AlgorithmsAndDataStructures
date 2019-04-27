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
using CSFundamentals.DataStructures.Trees.Binary.API;

namespace CSFundamentals.DataStructures.Trees.Binary
{
    /// <summary>
    /// Implements a RedBlack tree node.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class RedBlackTreeNode<TKey, TValue> :
        BinaryTreeNode<RedBlackTreeNode<TKey, TValue>, TKey, TValue>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Is the color of the node. 
        /// </summary>
        public RedBlackTreeNodeColor Color { get; set; }

        /// <summary>
        /// Is a reference to the left child of the current node. 
        /// </summary>
        public override RedBlackTreeNode<TKey, TValue> LeftChild { get; set; }

        /// <summary>
        /// Is a reference to the right child of the current node.
        /// </summary>
        public override RedBlackTreeNode<TKey, TValue> RightChild { get; set; }

        /// <summary>
        /// Is a reference to the parent of the current node.
        /// </summary>
        public override RedBlackTreeNode<TKey, TValue> Parent { get; set; }

        /// <summary>
        /// Parameter-less constructor. 
        /// </summary>
        public RedBlackTreeNode()
        {
            Color = RedBlackTreeNodeColor.Red;
        }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="key">Is the key to be stored in the node. </param>
        /// <param name="value">Is the value to be stored in the node. </param>
        /// <param name="color">Is the color of the node, default is red. </param>
        public RedBlackTreeNode(TKey key, TValue value, RedBlackTreeNodeColor color = RedBlackTreeNodeColor.Red) : base(key, value)
        {
            Color = color;
        }

        /// <summary>
        /// Flips the current color of the node between red and black. 
        /// </summary>
        public void FlipColor()
        {
            if (Color == RedBlackTreeNodeColor.Red)
            {
                Color = RedBlackTreeNodeColor.Black;
            }
            else if (Color == RedBlackTreeNodeColor.Black)
            {
                Color = RedBlackTreeNodeColor.Red;
            }
        }
    }

    /// <summary>
    /// Represents the color of the RedBlack tree node. 
    /// </summary>
    public enum RedBlackTreeNodeColor
    {
        /// <summary>
        /// Unknown color. 
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Red color.
        /// </summary>
        Red = 1,

        /// <summary>
        /// Black color. 
        /// </summary>
        Black = 2
    }
}
