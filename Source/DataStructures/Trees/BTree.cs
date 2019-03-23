﻿/* 
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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CSFundamentals")]

namespace CSFundamentals.DataStructures.Trees
{
    public class BTree<T1, T2> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Is the root of the tree. 
        /// </summary>
        public BTreeNode<T1, T2> Root = null;

        /// <summary>
        /// Is the maximum number of children for an internal or root node in this B-Tree. 
        /// </summary>
        public int MaxBranchingDegree { get; private set; }

        public BTree(int maxBranchingDegree)
        {
            MaxBranchingDegree = maxBranchingDegree;
        }

        public BTreeNode<T1, T2> Insert(BTreeNode<T1, T2> root, KeyValuePair<T1, T2> keyValue)
        {
            if (root == null)
            {
                root = new BTreeNode<T1, T2>(MaxBranchingDegree, keyValue);
                return root;
            }
            else
            {
                // This is a method on its own, ... 
                // but must first find the leaf node at which to insert the node
                // this is why the tree is growing from bottom to top... 
                root.InsertKey(keyValue);
                Split(root);
            }

            return Root;
        }

        internal void Split(BTreeNode<T1, T2> node)
        {
            while (node.IsOverFlown())
            {
                BTreeNode<T1, T2> sibling = node.Split();
                KeyValuePair<T1, T2> keyToMoveToParent = node.KeyToMoveUp();
                node.KeyValues.Remove(keyToMoveToParent.Key);

                if (node.Parent == null) /* Meaning the overflown node is the root. */
                {
                    Root = new BTreeNode<T1, T2>(MaxBranchingDegree, keyToMoveToParent); /* Creating a new root for the tree. */
                    Root.InsertChild(node); /* Notice that this method adjusts node's parent internally. */
                    Root.InsertChild(sibling);
                    break;
                }
                else
                {
                    node.Parent.InsertKey(keyToMoveToParent);
                    node.Parent.InsertChild(sibling);
                    node = node.Parent; /* Repeat while loop with the parent node that might itself be overflown now after inserting a new key.*/
                }
            }
        }

        // TODO: Test 
        /// <summary>
        ///  search seems to be logK in logN....uses binary search within each node.... could we call the search in the node here?  
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public BTreeNode<T1, T2> Search(BTreeNode<T1, T2> root, T1 key)
        {
            if (root != null)
            {
                int startIndex = 0;
                int endIndex = root.KeyValues.Count - 1;
                while (startIndex <= endIndex)
                {
                    int middleIndex = (startIndex + endIndex) / 2;
                    if (root.KeyValues.Keys[middleIndex].CompareTo(key) == 0)
                    {
                        return root;
                    }
                    else if (root.KeyValues.Keys[middleIndex].CompareTo(key) > 0) /* search left-half of the root.*/
                    {
                        endIndex = middleIndex - 1;
                    }
                    else if (root.KeyValues.Keys[middleIndex].CompareTo(key) > 0) /* search right-half of the root. */
                    {
                        startIndex = middleIndex + 1;
                    }
                }
                if (startIndex > endIndex)
                {
                    return Search(root.Children.Keys[startIndex], key); // todo: not sure, ... 
                }
            }
            throw new KeyNotFoundException($"{key.ToString()} is not found in the tree.");
        }

        // todo: test  for all methods here, .
        // todo: summary
        // todo: complexity
        public void InOrderTraversal(BTreeNode<T1, T2> node, List<KeyValuePair<T1, T2>> sortedKeys)
        {
            if (node != null)
            {
                for (int i = 0; i < node.Children.Count; i++)
                {
                    InOrderTraversal(node.Children.Keys[i], sortedKeys);
                    if (i < node.KeyValues.Count)
                        sortedKeys.Add(node.KeyValues.ElementAt(i));
                }
            }
        }
    }
}