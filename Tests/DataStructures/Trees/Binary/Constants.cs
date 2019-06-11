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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System.Collections.Generic;
namespace AlgorithmsAndDataStructuresTests.DataStructures.Trees.Binary
{
    /// <summary>
    /// A collection of constants used in testing binary tree implementation. 
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// A set of key-value pairs to be inserted in trees.
        /// </summary>
        public static readonly List<KeyValuePair<int, string>> KeyValues = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(40, "E"),
                new KeyValuePair<int, string>(50, "C"),
                new KeyValuePair<int, string>(47, "A"),
                new KeyValuePair<int, string>(45, "G"),
                new KeyValuePair<int, string>(20, "D"),
                new KeyValuePair<int, string>(35, "F"),
                new KeyValuePair<int, string>(30, "B"),
                new KeyValuePair<int, string>(10, "H"),
                new KeyValuePair<int, string>(80, "I"),
                new KeyValuePair<int, string>(42, "J")
            };
    }
}
