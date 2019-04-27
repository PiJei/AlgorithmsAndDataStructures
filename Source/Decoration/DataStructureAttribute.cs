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

namespace CSFundamentals.Decoration
{
    /// <summary>
    /// Implements an attribute for decorating data structures. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class DataStructureAttribute : Attribute
    {
        /// <summary>
        /// Is the name of data structure. 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="name">Name of the data structure. </param>
        public DataStructureAttribute(string name)
        {
            Name = name;
        }
    }
}
