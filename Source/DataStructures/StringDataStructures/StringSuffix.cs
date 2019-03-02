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

namespace CSFundamentalAlgorithms.DataStructures.StringDataStructures
{
    /// <summary>
    /// Stores information about a suffix of a string. 
    /// </summary>
    public class StringSuffix : IEquatable<StringSuffix>, IComparable<StringSuffix>
    {
        /// <summary>
        /// Specifies the 0-based starting index of this suffix in the string
        /// Notice that there is no need to store the end index, as it is always string.Length - 1, based on the suffix definition. 
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// Specifies the rank for (starting char, second char) of the suffix. If second char does not exist, -1 rather than rank. 
        /// Rank of a character is computing using: 'char'-'a'. 
        /// </summary>
        public int[] RankPair { get; set; } = new int[2];

        /// <param name="secondChar">If -1, means there is no second char. </param>
        public StringSuffix(int startIndex, char firstChar, char secondChar)
        {
            StartIndex = startIndex;
            RankPair[0] = firstChar - 'a';
            RankPair[1] = secondChar != '\0' ? secondChar - 'a' : -1;
        }

        public bool Equals(StringSuffix other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (RankPair[0] == other.RankPair[0] && RankPair[1] == other.RankPair[1]) return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((StringSuffix)obj);
        }

        public override int GetHashCode()
        {
            return RankPair[0].GetHashCode() * 17 + RankPair[1].GetHashCode();
        }

        public int CompareTo(StringSuffix other)
        {
            if (Equals(other)) return 0;
            if (RankPair[0] == other.RankPair[0])
            {
                return RankPair[1].CompareTo(other.RankPair[1]);
            }
            return RankPair[0].CompareTo(other.RankPair[0]);
        }

        public static bool operator <=(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) <= 0;
        }
        public static bool operator >=(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) >= 0;
        }

        public static bool operator <(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) < 0;
        }
        public static bool operator >(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) > 0;
        }
        public static bool operator ==(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) == 0;
        }
        public static bool operator !=(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) != 0;
        }
    }
}
