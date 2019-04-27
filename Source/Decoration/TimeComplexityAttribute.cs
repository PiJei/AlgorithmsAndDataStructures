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
    //TODO: Very similar to space complexity, ideally unify
    /// <summary>
    /// Implements an attribute for decorating algorithms with time complexity. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class TimeComplexityAttribute : Attribute
    {
        /// <summary>
        /// Specifies the time complexity of the algorithms. 
        /// </summary>
        public string Complexity { get; private set; }

        /// <summary>
        /// Specifies the case for time complexity, such as best, average, worst. 
        /// </summary>
        public Case ExecutionCase { get; private set; }

        /// <summary>
        /// Describes when the given ExecutionCase takes place, for example what conditions should the input have for the algorithm to be operating at the given ExecutionCase
        /// </summary>
        public string When { get; set; }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="executionCase">Case such as best, average, worst</param>
        /// <param name="complexity">Is the time complexity of the algorithm.</param>
        public TimeComplexityAttribute(Case executionCase, string complexity)
        {
            ExecutionCase = executionCase;
            Complexity = complexity;
        }
    }

    /// <summary>
    /// Is the execution case of an algorithm. 
    /// </summary>
    public enum Case
    {
        /// <summary>
        /// Average case, 
        /// </summary>
        Average,

        /// <summary>
        /// Best case, when some specific conditions are met. 
        /// </summary>
        Best,

        /// <summary>
        ///  Worst case. 
        /// </summary>
        Worst
    }
}
