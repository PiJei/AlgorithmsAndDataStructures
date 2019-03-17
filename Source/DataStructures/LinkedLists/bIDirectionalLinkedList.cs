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

// TODO: In all operations keep head and tail updated, ... 
// TODO: Add summaries and space complexities, and then implement insert for Sorted arrays, ...
// TODO: Have a sorted linked list also implemented 
namespace CSFundamentals.DataStructures.LinkedLists
{
    public class BiDirectionalLinkedList<T> where T : IComparable<T>
    {
        public BiDirectionalLinkedListNode<T> Head = null;
        public BiDirectionalLinkedListNode<T> Tail = null;

        public BiDirectionalLinkedList()
        {

        }

        public BiDirectionalLinkedList(BiDirectionalLinkedListNode<T> head)
        {
            Head = head;
            Tail = head;
        }

        //TODO: Should I have a build method as well?
        //TODO: Test
        public int Length()
        {
            int length = 0;
            var current = Head;
            while (current != null)
            {
                length++;
                current = current.Next;
            }
            return length;
        }

        // TODO: Could also call Append, with a node, after all this class does not have an insert method anyways, ...
        // TODO Insert can make sense for sorted list, because it is then similar to binary search tree, there is only one suitable location to insert, ...
        // But with a normal linked list there can be as many locations for inserts, ...
        // do not allow null
        //TODO  expects at least one node in the list, as node = null is not allowed. expects relevant nodes, meaning if you pass a node that does not exist in the list you can get arbitrary results
        // all these corner cases make me think that this whole thing is strange, unless you search for the value first and then insert it.
        public bool InsertAfter(T value, T newValue)
        {
            var node = Search(value);
            if (node == null)
            {
                return false;
            }

            BiDirectionalLinkedListNode<T> newNode = new BiDirectionalLinkedListNode<T>(newValue);
            newNode.Previous = node;
            newNode.Next = node?.Next;
            node.Next = newNode;

            if (newNode.Next == null)
            {
                Tail = newNode;
            }
            else
            {
                newNode.Next.Previous = newNode;
            }

            if (newNode.Previous == null)
            {
                Head = newNode;
            }
            return true;
        }

        public bool InsertBefore(T value, T newValue)
        {
            var node = Search(value);
            if (node == null)
            {
                return false;
            }

            BiDirectionalLinkedListNode<T> newNode = new BiDirectionalLinkedListNode<T>(newValue);
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous = newNode;
            if (newNode.Previous == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Previous.Next = newNode;
            }
            if (newNode.Next == null)
            {
                Tail = newNode;
            }
            return true;
        }

        //TODO I could have an Insert method that calls Append inside.  just for the sake of Interface. //
        public bool Append(T newValue)
        {
            BiDirectionalLinkedListNode<T> newNode = new BiDirectionalLinkedListNode<T>(newValue);
            if (Tail != null)
            {
                Tail.Next = newNode;
            }

            newNode.Previous = Tail;
            Tail = newNode;

            if (Head == null)
            {
                Head = newNode;
            }
            return true;
        }

        public bool PrePend(T newValue)
        {
            BiDirectionalLinkedListNode<T> newNode = new BiDirectionalLinkedListNode<T>(newValue);
            if (Head != null)
            {
                Head.Previous = newNode;
            }

            newNode.Next = Head;
            Head = newNode;
            if (Tail == null)
            {
                Tail = newNode;
            }
            return true;
        }

        // Assuming no order between the nodes, boils down to linear search, ...
        public BiDirectionalLinkedListNode<T> Search(T value)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return currentNode;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
            throw new NotFoundException($"Value {value.ToString()} does not exist in the list.");
        }

        // TODO: Test with empty list, with one node, with 2 nodes, delete head delete tail, test with 3 nodes, and more, delete head, delete tail, delete in between, 
        public bool Delete(T value)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0) /* If the key is found. */
                {
                    if (currentNode.Previous == null && currentNode.Next == null) /* This means the list has only one node.*/
                    {
                        Head = null;
                        Tail = null;
                        return true;
                    }
                    else if (currentNode.Previous == null) /* This means we are deleting the head. */
                    {
                        Head = Head.Next;
                        Head.Previous = null;
                        return true;
                    }
                    else if (currentNode.Next == null) /*This means we are deleting the tail.*/
                    {
                        Tail = Tail.Previous;
                        Tail.Next = null;
                        return true;
                    }
                }
                else /* Keep moving forward in the list. */
                {
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }
    }
}
