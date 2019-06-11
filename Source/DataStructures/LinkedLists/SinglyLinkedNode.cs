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
using AlgorithmsAndDataStructures.DataStructures.LinkedLists.API;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedLists
{
    /// <summary>
    /// Implements a node in a singly linked list. 
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    [Serializable]
    public class SinglyLinkedNode<TValue> : LinkedNode<SinglyLinkedNode<TValue>, TValue> where TValue : IComparable<TValue>
    {
        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="value">The value to be stored in the list. </param>
        public SinglyLinkedNode(TValue value) : base(value)
        {
        }
    }
}
