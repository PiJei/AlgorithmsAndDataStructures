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

namespace AlgorithmsAndDataStructures.DataStructures.LinkedLists.API
{
    /// <summary>
    /// Implements a node in a linked list. 
    /// </summary>
    /// <typeparam name="TNode">Type of the nodes in the linked list. </typeparam>
    /// <typeparam name="TValue">Type of the values stored in the linked list. </typeparam>
    [Serializable]
    public class LinkedNode<TNode, TValue> where TNode : LinkedNode<TNode, TValue> where TValue : IComparable<TValue>
    {
        /// <value>Is the value stored in the node. </value>
        public TValue Value { get; set; }

        /// <value>Is a reference to the next immediate node in the list. </value>
        public TNode Next { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The value to be stored in the node. </param>
        public LinkedNode(TValue value)
        {
            Value = value;
        }

        /// <summary>
        /// This constructor is for Serializability.
        /// </summary>
        public LinkedNode()
        {
        }

        /// <summary>
        /// Checks whether the current node is tail. A node is tail if it has no next node. 
        /// </summary>
        /// <returns>True in case the node is tail, and false otherwise.</returns>
        public bool IsTail()
        {
            if (Next == null)
            {
                return true;
            }

            return false;
        }
    }
}
