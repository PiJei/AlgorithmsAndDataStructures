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
using CSFundamentals.DataStructures.Trees.Binary.API;

namespace CSFundamentals.DataStructures.Trees.Binary
{
    public class RedBlackTreeNode<TKey, TValue> : 
        BinaryTreeNode<RedBlackTreeNode<TKey, TValue>, TKey, TValue> 
        where TKey : IComparable<TKey>
    {
        public Color Color { get; set; }
        public override RedBlackTreeNode<TKey, TValue> LeftChild { get; set; }
        public override RedBlackTreeNode<TKey, TValue> RightChild { get; set; }
        public override RedBlackTreeNode<TKey, TValue> Parent { get; set; }

        public RedBlackTreeNode(TKey key, TValue value, Color color = Color.Red) : base(key, value)
        {
            Color = color;
        }

        public void FlipColor()
        {
            if (Color == Color.Red)
            {
                Color = Color.Black;
            }
            else if (Color == Color.Black)
            {
                Color = Color.Red;
            }
        }
    }

    public enum Color
    {
        Unknown = 0,
        Red = 1,
        Black = 2
    }
}
