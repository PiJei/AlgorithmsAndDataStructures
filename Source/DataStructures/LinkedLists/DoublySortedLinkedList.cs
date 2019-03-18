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
using CSFundamentals.DataStructures.LinkedLists.API;

namespace CSFundamentals.DataStructures.LinkedLists
{
    public class DoublySortedLinkedList<T1> : LinkedListBase<DoublyLinkedNode<T1>, T1> where T1 : IComparable<T1>
    {
        //TODO: Should I have a build method as well?
        // TODO Insert can make sense for sorted list, because it is then similar to binary search tree, there is only one suitable location to insert, ...
        //TODO I could have an Insert method that calls Append inside, or prepend, prepend will be O(1), and so will be Append: O(1).  just for the sake of Interface. //
        public override bool Delete(T1 alue)
        {
            throw new NotImplementedException();
            // if nt found up to some point, then break, an return false, ... 
        }

        public override bool Insert(T1 newValue)
        {
            throw new NotImplementedException();
            // should always find the proper spot or inserting... 
        }

        public override DoublyLinkedNode<T1> Search(T1 alue)
        {
            throw new NotImplementedException();
            // TODO can stop the search as soon as the next element is bigger,
        }
    }
}
