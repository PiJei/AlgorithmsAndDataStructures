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

using System;

namespace CSFundamentalAlgorithms.SortingAlgorithms.StabilityCheckableVersions
{
    public class Element : IEquatable<Element>, IComparable<Element>
    {
        public int Value { get; private set; }
        public int OldArrayIndex { get; private set; }
        public int NewArrayIndex { get; set; } = -1;

        public Element(int value, int oldArrayIndex)
        {
            Value = value;
            OldArrayIndex = oldArrayIndex;
        }

        public bool Equals(Element other)
        {
            if (ReferenceEquals(other, null)) { return false; }
            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            int hashCode = Value.GetHashCode() * 17;
            return hashCode;
        }

        /// <summary>
        /// Given two Elements, if the order between their new array index is the same order between their old array index, the element has been stable.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool IsStable(Element other)
        {
            if (!Equals(other)) { return false; }
            if (NewArrayIndex == -1 || other.NewArrayIndex == -1) { return false; }
            if (OldArrayIndex == other.OldArrayIndex) { return NewArrayIndex == other.NewArrayIndex; }
            if (OldArrayIndex < other.OldArrayIndex) { return NewArrayIndex < other.NewArrayIndex; }
            if (OldArrayIndex > other.OldArrayIndex) { return NewArrayIndex > other.NewArrayIndex; }
            return false;
        }

        /// <summary>
        /// this Less than other : return less than 0 , this == other return 0, this > other return > 0 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Element other)
        {
            if (ReferenceEquals(other, null)) return 1;
            if (Value == other.Value) return 0;
            if (Value < other.Value) return -1;
            return 1;
        }

    }
}
