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

namespace CSFundamentals.Algorithms.Sort.StabilityCheckableVersions
{
    /// <summary>
    /// 
    /// </summary>
    public class Element : IEquatable<Element>, IComparable<Element>
    {
        /// <summary>
        /// Is the value stored in this object. 
        /// </summary>
        public int Value { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int FirstArrayIndex { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int LatestArrayIndex { get; private set; } = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="firstArrayIndex"></param>
        public Element(int value, int firstArrayIndex)
        {
            Value = value;
            FirstArrayIndex = firstArrayIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public Element(Element e)
        {
            Value = e.Value;
            FirstArrayIndex = e.FirstArrayIndex;
            LatestArrayIndex = e.LatestArrayIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newIndex"></param>
        public void Move(int newIndex)
        {
            LatestArrayIndex = newIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Element other)
        {
            if (ReferenceEquals(other, null)) { return false; }
            return Value == other.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
            if (LatestArrayIndex == -1 || other.LatestArrayIndex == -1) { return false; }
            if (FirstArrayIndex == other.FirstArrayIndex) { return LatestArrayIndex == other.LatestArrayIndex; }
            if (FirstArrayIndex < other.FirstArrayIndex) { return LatestArrayIndex < other.LatestArrayIndex; }
            if (FirstArrayIndex > other.FirstArrayIndex) { return LatestArrayIndex > other.LatestArrayIndex; }
            return false;
        }

        /// <summary>
        /// this Less than other : return less than 0 , this == other return 0, this > other return > 0 
        /// </summary>
        /// <param name="other">An object of type Element. </param>
        /// <returns></returns>
        public int CompareTo(Element other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Value == other.Value)
            {
                return 0;
            }

            if (Value < other.Value)
            {
                return -1;
            }

            return 1;
        }
    }
}
