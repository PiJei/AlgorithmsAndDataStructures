﻿#region copyright
/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of AlgorithmsAndDataStructures project.
 *
 * AlgorithmsAndDataStructures is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AlgorithmsAndDataStructures is distributed in the hope that it will be useful,
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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.DataStructures.LinkedLists.API
{
    /// <summary>
    /// Implements a mock class for testing <see cref="LinkedNode{TNode, TValue}"/>.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    public class MockLinkedNode<T1> : LinkedNode<MockLinkedNode<T1>, T1> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">Value to be stored in the node. </param>
        public MockLinkedNode(T1 value) : base(value) { }
    }
}
