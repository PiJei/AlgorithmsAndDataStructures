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
using CSFundamentals.Decoration;

namespace CSFundamentals.DataStructures.Trees.Nary
{
    [DataStructure("B+ Tree")]
    public class BPlusTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        // Insert is different in that, when split happens, 
        // The key-value should stay in the leaf, and only a copy of the key to be moved up, so 
        // The question is in which leaf do we keep the key? left or right? 

        //start here... 

    }
}
