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

using CSFundamentals.DataStructures.BinaryHeaps;
using System;
using System.Collections.Generic;

namespace CSFundamentalsTests.DataStructures.BinaryHeaps
{
    public class MockBinaryHeap<T> : BinaryHeapBase<T> where T : IComparable<T>
    {
        public MockBinaryHeap(List<T> array) : base(array)
        {

        }

        public override void BubbleDown_Iteratively(int rootIndex, int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        public override void BubbleDown_Recursively(int rootIndex, int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        public override void BubbleUp_Iteratively(int index, int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        public override void BuildHeap_Iteratively(int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        public override void BuildHeap_Recursively(int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        public override void Insert(T value, int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        public override bool TryFindRoot(out T rootValue, int heapArrayLength)
        {
            throw new NotImplementedException();
        }

        public override bool TryRemoveRoot(out T rootValue, int heapArrayLength)
        {
            throw new NotImplementedException();
        }
    }
}
