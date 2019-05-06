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

//TODO: Specify the time and space complexity of all the code in this project
using System;

namespace CSFundamentals.Decoration
{
    /// <summary>
    /// Implements an attribute for decorating space complexity of algorithms. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class SpaceComplexityAttribute : Attribute
    {
        /// <summary>
        /// The complexity of space / memory used in algorithm implementation. 
        /// </summary>
        public string Complexity { get; private set; }

        /// <summary>
        /// If set to true means the algorithm is in place and thus does not use any auxiliary space. 
        /// </summary>
        public bool InPlace { get; set; }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="complexity">Space complexity. </param>
        /// <param name="inPlace">Specifies whether the algorithm is in place or not. </param>
        public SpaceComplexityAttribute(string complexity, bool inPlace = false)
        {
            Complexity = complexity;
            InPlace = inPlace;
        }
    }
}
