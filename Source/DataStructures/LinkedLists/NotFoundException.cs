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
using System;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedLists
{
    // TODO: Maybe I could use this with all the search methods, string search, etc, ...
    /// <summary>
    /// Defines a customized exception for cases where the value is not found in a search. 
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">The text message to display with exception. </param>
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
