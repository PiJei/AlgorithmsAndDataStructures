#region copyright
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

namespace AlgorithmsAndDataStructures.DataStructures.StringStructures
{
    /// <summary>
    /// Stores information about a suffix of a string. 
    /// </summary>
    public class StringSuffix : IEquatable<StringSuffix>, IComparable<StringSuffix>
    {
        /// <summary>
        /// The 0-based starting index of this suffix in the string
        /// Notice that there is no need to store the end index, as it is always string.Length - 1, based on the suffix definition. 
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// The rank for (starting char, second char) of the suffix. If second char does not exist, -1 rather than rank. 
        /// Rank of a character is computing using: 'char'-'a'. 
        /// </summary>
        public int[] RankPair { get; set; } = new int[2];


        /// <summary>
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="firstChar"></param>
        /// <param name="secondChar">If -1, means there is no second char. </param>
        public StringSuffix(int startIndex, char firstChar, char secondChar)
        {
            StartIndex = startIndex;
            RankPair[0] = firstChar - 'a';
            RankPair[1] = secondChar != '\0' ? secondChar - 'a' : -1;
        }

        /// <summary>
        /// Compares the current object to the given object for equality. 
        /// </summary>
        /// <param name="other">An object of type StringSuffix. </param>
        /// <returns>True if the two objects are equal, and false otherwise. </returns>
        public bool Equals(StringSuffix other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (RankPair[0] == other.RankPair[0] && RankPair[1] == other.RankPair[1])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compares the current object to the given object.
        /// </summary>
        /// <param name="obj">An object to compare to the current object. </param>
        /// <returns>True if the two objects are equal, and false otherwise. </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return Equals((StringSuffix)obj);
        }

        /// <summary>
        /// Computes a hash code for this object. 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return RankPair[0].GetHashCode() * 17 + RankPair[1].GetHashCode();
        }

        /// <summary>
        /// Compares the current object to another object of the same type. 
        /// </summary>
        /// <param name="other">An object of type StringSuffix. </param>
        /// <returns>0 if they are equal, 1 if the current object is bigger and -1 otherwise. </returns>
        public int CompareTo(StringSuffix other)
        {
            if (Equals(other))
            {
                return 0;
            }

            if (RankPair[0] == other.RankPair[0])
            {
                return RankPair[1].CompareTo(other.RankPair[1]);
            }
            return RankPair[0].CompareTo(other.RankPair[0]);
        }

        /// <summary>
        /// Overrides smaller than /equal operator. 
        /// </summary>
        /// <param name="current">Current object of type StringSuffix. </param>
        /// <param name="other">Another object of type StringSuffix. </param>
        /// <returns>True if the current object is smaller than or equal to the other object. </returns>
        public static bool operator <=(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) <= 0;
        }

        /// <summary>
        /// Overrides bigger than/equal operator. 
        /// </summary>
        /// <param name="current">Current object of type StringSuffix. </param>
        /// <param name="other">Another object of type StringSuffix. </param>
        /// <returns>True if the current object is bigger than or equal to the other object. </returns>
        public static bool operator >=(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) >= 0;
        }

        /// <summary>
        /// Overrides smaller than  operator. 
        /// </summary>
        /// <param name="current">Current object of type StringSuffix. </param>
        /// <param name="other">Another object of type StringSuffix. </param>
        /// <returns>True if the current object is smaller than the other object. </returns>
        public static bool operator <(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) < 0;
        }

        /// <summary>
        /// Overrides bigger than operator. 
        /// </summary>
        /// <param name="current">Current object of type StringSuffix. </param>
        /// <param name="other">Another object of type StringSuffix. </param>
        /// <returns>True if the current object is bigger than the other object. </returns>
        public static bool operator >(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) > 0;
        }

        /// <summary>
        /// Overrides equality operator. 
        /// </summary>
        /// <param name="current">Current object of type StringSuffix. </param>
        /// <param name="other">Another object of type StringSuffix. </param>
        /// <returns>True if the current object is equal to the other object. </returns>
        public static bool operator ==(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) == 0;
        }

        /// <summary>
        /// Overrides inequality operator. 
        /// </summary>
        /// <param name="current">Current object of type StringSuffix. </param>
        /// <param name="other">Another object of type StringSuffix. </param>
        /// <returns>True if the current object is not equal to the other object. </returns>
        public static bool operator !=(StringSuffix current, StringSuffix other)
        {
            return current.CompareTo(other) != 0;
        }
    }
}
