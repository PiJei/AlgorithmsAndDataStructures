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

namespace CSFundamentalAlgorithms
{
    //TODO: Very similar to space complexity, ideally unify
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class TimeComplexityAttribute : Attribute
    {
        public string Complexity { get; private set; }
        public Case ExecutionCase { get; private set; }

        public TimeComplexityAttribute(Case executionCase, string complexity)
        {
            ExecutionCase = executionCase;
            Complexity = complexity;
        }
    }

    public enum Case
    {
        Average,
        Best,
        Worst
    }
}
