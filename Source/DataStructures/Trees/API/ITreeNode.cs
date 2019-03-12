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

namespace CSFundamentals.DataStructures.Trees.API
{
    public interface ITreeNode<T, T1, T2> : IComparable<T> where T1 : IComparable<T1>, IEquatable<T1>
    {
        T1 Key { get; set; }

        /// <remarks>
        /// This can be converted to a list of values alternatively, to handle duplicate keys. 
        /// </remarks>
        /// <summary>
        /// Is the value (information) stored in a node. 
        /// </summary> 
        T2 Value { get; set; }

        T LeftChild { get; set; }
        T RightChild { get; set; }
        T Parent { get; set; }

        bool IsLeftChild();

        bool IsRightChild();
    }
}
