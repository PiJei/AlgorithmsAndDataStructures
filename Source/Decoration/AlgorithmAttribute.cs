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
    /// Implements an attribute for decorating algorithms. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AlgorithmAttribute : Attribute
    {
        /// <summary>
        /// The type of the algorithm. 
        /// </summary>
        public AlgorithmType Type { get; private set; }

        /// <summary>
        /// Is the name of the algorithm. 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Is set to true if the algorithm has a greedy approach. 
        /// </summary>
        public bool IsGreedy { get; set; }

        /// <summary>
        /// A string list of assumptions made by the algorithm. 
        /// </summary>
        public string Assumptions { get; set; }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="type">Type of the algorithm. </param>
        /// <param name="name">Name of the algorithm. </param>
        public AlgorithmAttribute(AlgorithmType type, string name)
        {
            Type = type;
            Name = name;
        }
    }

    /// <summary>
    /// Specifies algorithm categories. 
    /// </summary>
    public enum AlgorithmType
    {
        /// <summary>
        /// Used for tagging sort algorithms. 
        /// </summary>
        Sort = 1,

        /// <summary>
        /// Used for tagging search algorithms. 
        /// </summary>
        Search = 2,

        /// <summary>
        /// Used for tagging pattern search algorithms. 
        /// </summary>
        PatternSearch = 3,

        /// <summary>
        /// Used for tagging hashing algorithms. 
        /// </summary>
        Hash = 4,

        /// <summary>
        /// Used for graph path/route search algorithms. 
        /// </summary>
        GraphRouteSearch = 5
    }
}
