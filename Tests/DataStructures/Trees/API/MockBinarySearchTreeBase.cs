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
    public class MockBinarySearchTreeBase<T1, T2> : BinarySearchTreeBase<MockTreeNode<T1, T2>, T1, T2> where T1 : IComparable<T1>
    {
        public override MockTreeNode<T1, T2> Build(List<MockTreeNode<T1, T2>> keyValues)
        {
            throw new NotImplementedException();
        }

        public override MockTreeNode<T1, T2> Delete(MockTreeNode<T1, T2> root, T1 key)
        {
            throw new NotImplementedException();
        }

        public override MockTreeNode<T1, T2> FindMax(MockTreeNode<T1, T2> root)
        {
            throw new NotImplementedException();
        }

        public override MockTreeNode<T1, T2> FindMin(MockTreeNode<T1, T2> root)
        {
            throw new NotImplementedException();
        }

        public override MockTreeNode<T1, T2> Insert(MockTreeNode<T1, T2> root, MockTreeNode<T1, T2> newNode)
        {
            throw new NotImplementedException();
        }

        public override MockTreeNode<T1, T2> Search(MockTreeNode<T1, T2> root, T1 key)
        {
            throw new NotImplementedException();
        }

        public override bool Update(MockTreeNode<T1, T2> root, T1 key, T2 value)
        {
            throw new NotImplementedException();
        }
    }
}
