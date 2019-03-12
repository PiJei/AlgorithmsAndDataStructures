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

using CSFundamentals.DataStructures.Trees.API;
using System;
using System.Collections.Generic;

//TODO: Shall inherit from BinarySearchTree

namespace CSFundamentals.DataStructures.Trees
{
    public class AVLTree<T1, T2> : BinarySearchTreeBase<AVLTreeNode<T1, T2>, T1, T2> where T1 : IComparable<T1>, IEquatable<T1>
    {
        public override AVLTreeNode<T1, T2> Build(List<AVLTreeNode<T1, T2>> keyValues)
        {
            throw new NotImplementedException();
            //TODO
        }

        public override AVLTreeNode<T1, T2> Delete(AVLTreeNode<T1, T2> root, T1 key)
        {
            throw new NotImplementedException();
            //TODO
        }

        public override AVLTreeNode<T1, T2> Insert(AVLTreeNode<T1, T2> root, AVLTreeNode<T1, T2> newNode)
        {
            throw new NotImplementedException();
            //TODO
        }
    }
}
