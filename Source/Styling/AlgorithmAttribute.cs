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

namespace CSFundamentals.Styling
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AlgorithmAttribute : Attribute
    {
        public AlgorithmType Type { get; private set; }

        public string Name { get; private set; }

        public bool IsGreedy { get; set; }

        public string Assumptions { get; set; }

        public AlgorithmAttribute(AlgorithmType type, string name)
        {
            Type = type;
            Name = name;
        }
    }

    public enum AlgorithmType
    {
        Sort = 1,
        Search = 2,
        PatternSearch = 3,
        Hash = 4,
        GraphRouteSearch = 5
    }
}
