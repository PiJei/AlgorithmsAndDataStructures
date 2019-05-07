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
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using CSFundamentals.Algorithms.Sort;
using CSFundamentals.DataStructures.BinaryHeaps.API;
using CSFundamentals.Decoration;

namespace CSFundamentals.DataStructures.BinaryHeaps
{
    /// <summary>
    /// Implements a MinMaxBinaryHeap and its main operations. Notice that a MaxMinHeapBinaryHeap can be implemented in a very similar way.
    /// </summary>
    [DataStructure("MinMaxBinaryHeap")]
    public class MinMaxBinaryHeap<TKey, TValue> : BinaryHeapBase<TKey, TValue> where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">An array containing key-value pairs</param>
        public MinMaxBinaryHeap(List<KeyValuePair<TKey, TValue>> array) : base(array)
        {
        }

        /// <summary>
        /// Builds an in-place MinMax heap on the given array. 
        /// </summary>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public override void BuildHeap_Recursively(int heapArrayLength)
        {
            for (int i = heapArrayLength / 2; i >= 0; i--)
            {
                BubbleDown_Recursively(i, heapArrayLength);
            }
        }

        /// <summary>
        /// Inserts a new value into the Min Heap. 
        /// </summary>
        /// <param name="keyValue">The new key-value pair to be inserted in the tree.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public override void Insert(KeyValuePair<TKey, TValue> keyValue, int heapArrayLength)
        {
            HeapArray.Add(keyValue);
            int index = heapArrayLength;
            BubbleUp_Recursively(index, heapArrayLength + 1);
        }

        /// <summary>
        /// Bubbles up the node at the given index. 
        /// </summary>
        /// <param name="index">The index of a node in the heap array.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public void BubbleUp_Recursively(int index, int heapArrayLength)
        {
            int level = GetNodeLevel(index);
            int parentIndex = GetParentIndex(index);

            if (parentIndex < heapArrayLength && parentIndex >= 0 && parentIndex != index) /* Bubble up only makes sense, if the node has a parent.*/
            {
                if (IsMinLevel(level))
                {
                    if (HeapArray[index].Key.CompareTo(HeapArray[parentIndex].Key) > 0) /* Parent is in a max level, and if its child is larger than it, then a swap should happen.*/
                    {
                        Utils.Swap(HeapArray, index, parentIndex);
                        BubbleUpMax_Recursively(parentIndex, heapArrayLength); /* At this point, the value is pushed to a max level, and the next bubble up shall happen via max level, which at any point can again switch the bubble up to a min level.*/
                    }
                    else
                    {
                        BubbleUpMin_Recursively(index, heapArrayLength); /* If the value at index on a min level is smaller than its parent, then compare to the next min level, by calling this method recursively.*/
                    }
                }
                else /* meaning the node is located on a max / odd level. */
                {
                    if (HeapArray[index].Key.CompareTo(HeapArray[parentIndex].Key) < 0) /* Parent is in a min level, and if its child is smaller than it, then a swap should happen.*/
                    {
                        Utils.Swap(HeapArray, index, parentIndex);
                        BubbleUpMin_Recursively(parentIndex, heapArrayLength); /* At this point, the value is pushed to a min level, and the next bubble up shall happen via min level, which at any point can again switch the bubble up to a max level. */
                    }
                    else
                    {
                        BubbleUpMax_Recursively(index, heapArrayLength); /* if the value at index on a max level is bigger than its parent, then compare to the next max level.*/
                    }
                }
            }
        }

        /// <summary>
        /// Bubbles up the node at the given index which is assumed to be on a min/even level. 
        /// </summary>
        /// <param name="index">The index of a node in the heap array.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public void BubbleUpMin_Recursively(int index, int heapArrayLength)
        {
            int parentIndex = GetParentIndex(index);
            int grandParentindex = GetParentIndex(parentIndex);
            if (grandParentindex >= 0 && grandParentindex < heapArrayLength)
            {
                if (HeapArray[index].Key.CompareTo(HeapArray[grandParentindex].Key) < 0)
                {
                    Utils.Swap(HeapArray, index, grandParentindex);
                    BubbleUpMin_Recursively(grandParentindex, heapArrayLength);
                }
            }
        }

        /// <summary>
        /// Bubbles up the node at the given index which is assumed to be on a max/odd level.
        /// </summary>
        /// <param name="index">The index of a node in the heap array.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public void BubbleUpMax_Recursively(int index, int heapArrayLength)
        {
            int parentIndex = GetParentIndex(index);
            int grandParentIndex = GetParentIndex(parentIndex);
            if (grandParentIndex >= 0 && grandParentIndex != parentIndex && grandParentIndex < heapArrayLength)
            {
                if (HeapArray[index].Key.CompareTo(HeapArray[grandParentIndex].Key) > 0)
                {
                    Utils.Swap(HeapArray, index, grandParentIndex);
                    BubbleUpMax_Recursively(grandParentIndex, heapArrayLength);
                }
            }
        }

        /// <summary>
        /// Removes the min element from the heap.
        /// </summary>
        /// <param name="keyValue">If the operation is successful, contains the minimum element in the array.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        /// <returns></returns>
        public override bool TryRemoveRoot(out KeyValuePair<TKey, TValue> keyValue, int heapArrayLength)
        {
            keyValue = new KeyValuePair<TKey, TValue>((TKey)typeof(TKey).GetField("MinValue").GetValue(null), default(TValue));

            if (heapArrayLength == 0)
            {
                return false;
            }
            if (heapArrayLength == 1)
            {
                keyValue = HeapArray[0];
                HeapArray.Clear();
                return true;
            }

            keyValue = HeapArray[0];
            HeapArray[0] = HeapArray[heapArrayLength - 1];
            HeapArray.RemoveAt(heapArrayLength - 1);
            BubbleDownMin_Recursively(0, heapArrayLength - 1); /* Calling this method, because this is a min-max heap and 0 is expected to be on a min level.*/ /* Also notice that the array is shorter by one value now, thus the new array length is one smaller. */
            return true;
        }

        /// <summary>
        /// This method is for finding the root of the heap, without removing it. 
        /// </summary>
        /// <param name="keyValue">The key-value of the root.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        /// <returns>True in case of success, and false in case of failure.</returns>
        public override bool TryFindRoot(out KeyValuePair<TKey, TValue> keyValue, int heapArrayLength)
        {
            if (HeapArray.Any())
            {
                keyValue = HeapArray[0];
                return true;
            }
            keyValue = new KeyValuePair<TKey, TValue>((TKey)typeof(TKey).GetField("MaxValue").GetValue(null), default(TValue));
            return false;
        }

        /// <summary>
        /// Recursively bubbles down/trickles down the given rootIndex.
        /// </summary>
        /// <param name="rootIndex">The index of the node for which bubble down starts. </param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public override void BubbleDown_Recursively(int rootIndex, int heapArrayLength)
        {
            int level = GetNodeLevel(rootIndex);
            if (IsMinLevel(level))
            {
                BubbleDownMin_Recursively(rootIndex, heapArrayLength);
            }
            else
            {
                BubbleDownMax_Recursively(rootIndex, heapArrayLength);
            }
        }

        /// <summary>
        /// Bubbles/trickles down the node at the given index, which is on a min/even level. 
        /// </summary>
        /// <param name="rootIndex">The index of a node at a min level, from which bubble down starts recursively.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public void BubbleDownMin_Recursively(int rootIndex, int heapArrayLength)
        {
            List<int> childrenIndexes = GetChildrenIndexes(new List<int> { rootIndex }, heapArrayLength);
            List<int> grandChildrenIndexes = GetChildrenIndexes(childrenIndexes, heapArrayLength);

            /* Find the index of the descendants of rootIndex that has the minimum value */
            int minDescendentIndex = int.MaxValue;
            if (!TryFindIndexOfMinSmallerThanReference(HeapArray, childrenIndexes.Union(grandChildrenIndexes).ToList(), (TKey)typeof(TKey).GetField("MaxValue").GetValue(null), out int minIndex))
            {
                return;
            }

            minDescendentIndex = minIndex;
            Contract.Assert(minDescendentIndex != int.MaxValue);
            Contract.Assert(minDescendentIndex != int.MinValue);

            /* If rootIndex has a descendant that has a value lower than itself, then shall swap the root with its descendant, as the nodes in min levels should be the smallest in their subtrees, rooted at them.*/
            if (HeapArray[minDescendentIndex].Key.CompareTo(HeapArray[rootIndex].Key) < 0)
            {
                Utils.Swap(HeapArray, minDescendentIndex, rootIndex);

                /* If the descendant was a direct child, meaning it is located in a max/odd layer, there is no need for further action, as where it was before (in the child index) it was for sure larger than all the elements in the subtree rooted at it. */
                /* However, if the descendant was a grand child, now we shall compare the root which is now located in the former grand child's index, with its parent, and if larger than the parent, shall swap to position it in a max level. and then Shall bubble down the former parent, who is now located on a min level, to find its correct position.*/
                if (grandChildrenIndexes.Contains(minDescendentIndex))
                {
                    int parentIndex = GetParentIndex(minDescendentIndex);
                    if (parentIndex >= 0 && parentIndex < heapArrayLength && HeapArray[minDescendentIndex].Key.CompareTo(HeapArray[parentIndex].Key) > 0)
                    {
                        Utils.Swap(HeapArray, minDescendentIndex, parentIndex);
                    }
                    BubbleDownMin_Recursively(minDescendentIndex, heapArrayLength);
                }
            }
        }

        /// <summary>
        /// Bubbles/trickles down the node at the given index, which is on a max/even level. 
        /// </summary>
        /// <param name="rootIndex">The index of the node at a max level, from which bubble down starts recursively.</param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        public void BubbleDownMax_Recursively(int rootIndex, int heapArrayLength)
        {
            List<int> childrenIndexes = GetChildrenIndexes(new List<int> { rootIndex }, heapArrayLength);
            List<int> grandChildrenIndexes = GetChildrenIndexes(childrenIndexes, heapArrayLength);

            int maxDescendentIndex = int.MinValue;
            if (!TryFindIndexOfMaxBiggerThanReference(HeapArray, heapArrayLength, childrenIndexes.Union(grandChildrenIndexes).ToList(), (TKey)typeof(TKey).GetField("MinValue").GetValue(null), out int maxIndex))
            {
                return;
            }

            maxDescendentIndex = maxIndex;
            Contract.Assert(maxDescendentIndex != int.MinValue);
            Contract.Assert(maxDescendentIndex != int.MaxValue);

            if (HeapArray[maxDescendentIndex].Key.CompareTo(HeapArray[rootIndex].Key) > 0)
            {
                Utils.Swap(HeapArray, maxDescendentIndex, rootIndex);
                if (grandChildrenIndexes.Contains(maxDescendentIndex))
                {
                    int parentIndex = GetParentIndex(maxDescendentIndex);
                    if (parentIndex >= 0 && parentIndex < heapArrayLength && HeapArray[maxDescendentIndex].Key.CompareTo(HeapArray[parentIndex].Key) < 0)
                    {
                        Utils.Swap(HeapArray, maxDescendentIndex, parentIndex);
                    }
                    BubbleDownMax_Recursively(maxDescendentIndex, heapArrayLength);
                }
            }
        }

        /// <summary>
        /// Given a node level in a MinMax heap, returns true if that node is on an even level, meaning on a Min level. and false otherwise/ 
        /// </summary>
        /// <param name="level">The level of a node in a MinMax heap.</param>
        /// <returns>True in case of success, and false otherwise. </returns>
        public bool IsMinLevel(int level)
        {
            /* In a Min-Max heap nodes at even levels (0,2,4,...) are at Min Levels. */
            return level % 2 == 0;
        }

        /// <summary>
        /// Gets the list of indexes of all the children of all the given indexes. 
        /// </summary>
        /// <param name="indexes">The indexes of the nodes for which their children's indexes shall be computed. </param>
        /// <param name="heapArrayLength">The length of the heap array. </param>
        /// <returns>List of all the children of all the indexes. </returns>
        private List<int> GetChildrenIndexes(List<int> indexes, int heapArrayLength)
        {
            var childrenIndexes = new List<int>();
            foreach (int index in indexes.Where(index => index < heapArrayLength))
            {
                int leftChildIndex = GetLeftChildIndexInHeapArray(index);
                int rightChildIndex = GetRightChildIndexInHeapArray(index);

                if (leftChildIndex < heapArrayLength)
                {
                    childrenIndexes.Add(leftChildIndex);
                }
                if (rightChildIndex < heapArrayLength)
                {
                    childrenIndexes.Add(rightChildIndex);
                }

            }
            return childrenIndexes;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="heapArrayLength"></param>
        public override void BuildHeap_Iteratively(int heapArrayLength)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="rootIndex"></param>
        /// <param name="heapArrayLength"></param>
        public override void BubbleDown_Iteratively(int rootIndex, int heapArrayLength)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="index"></param>
        /// <param name="heapArrayLength"></param>
        public override void BubbleUp_Iteratively(int index, int heapArrayLength)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void TryRemoveMax()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// TODO
        /// </summary>
        public void TryFindMax()
        {
            throw new System.NotImplementedException();
        }
    }
}
