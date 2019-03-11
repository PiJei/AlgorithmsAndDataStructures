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
using System.Text;

namespace CSFundamentals.DataStructures.Trees
{
    public class AVLTreeNode<T1, T2> : TreeNode<AVLTreeNode<T1, T2>, T1, T2> where T1 : IComparable<T1>, IEquatable<T1>
    {
        public override AVLTreeNode<T1, T2> LeftChild { get; set; }
        public override AVLTreeNode<T1, T2> RightChild { get; set; }
        public override AVLTreeNode<T1, T2> Parent { get; set; }

        public AVLTreeNode(T1 key, T2 value) : base(key, value)
        {
        }

        private int GetBalanceFactor()
        {
            return (RightChild == null ? 0 : RightChild.GetHeight()) - (LeftChild == null ? 0 : LeftChild.GetHeight());
        }

        public int GetHeight()
        {
            List<List<AVLTreeNode<T1, T2>>> paths = GetAllPathToNullLeaves(this);
            int height = paths[0].Count;
            for (int i = 1; i < paths.Count; i++)
            {
                if (paths[i].Count > height)
                {
                    height = paths[i].Count;
                }
            }
            return height;
        }

        public bool Equals(AVLTreeNode<T1, T2> other)
        {
            if (other == null) return false;
            if (Key.Equals(other.Key)) return true;
            return false;
        }
    }
}
