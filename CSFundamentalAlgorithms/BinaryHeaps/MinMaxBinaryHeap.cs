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
 * along with CSFundamentalAlgorithms.  If not, see <http://www.gnu.org/licenses/>.
 */

using System.Collections.Generic;
using System.Linq;

namespace CSFundamentalAlgorithms.BinaryHeaps
{
    /// <summary>
    /// Implements a MinMaxBinaryHeap and its main operations.
    /// </summary>
    public class MinMaxBinaryHeap : BinaryHeapBase
    {
        public MinMaxBinaryHeap(List<int> array) : base(array)
        {

        }

        public override void BuildHeap_Recursively()
        {

        }

        public override void Insert(int value)
        {

        }

        public override bool TryRemoveRoot(out int rootValue)
        {
            if (HeapArray.Any())
            {
                // TODO
            }

            rootValue = int.MaxValue;
            return false;
        }

        public override bool TryFindRoot(out int rootValue)
        {
            if (HeapArray.Any())
            {
                rootValue = HeapArray[0];
                return true;
            }
            rootValue = int.MaxValue;
            return false;
        }

        public override void BubbleUp_Iteratively(int index)
        {

        }

        public override void BubbleDown_Recursively(int rootIndex)
        {
            // TODO NEXT
        }

        public void BubbleDownMin_Recursively()
        {

        }

        public void BubbleDownMax_Recursively()
        {

        }

        public void TryRemoveMax()
        {

        }

        public void TryFindMax()
        {

        }

        public override void BuildHeap_Iteratively()
        {
            throw new System.NotImplementedException();
        }

        public override void BubbleDown_Iteratively(int rootIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}
