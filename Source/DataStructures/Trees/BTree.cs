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
using System.Collections.Generic;
using System.Linq;

namespace CSFundamentals.DataStructures.Trees
{
    public class BTree<T1, T2> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Is the root of the tree. 
        /// </summary>
        public BTreeNode<T1, T2> root;

        /// <summary>
        /// Is the maximum number of children for an internal or root node in this B-Tree. 
        /// </summary>
        public int MaxBranchingDegree { get; private set; }

        public BTree(int maxBranchingDegree)
        {
            MaxBranchingDegree = maxBranchingDegree;
        }

        public bool Insert(BTreeNode<T1, T2> root, KeyValuePair<T1, T2> keyValue)
        {
            if (root == null)
            {
                root = new BTreeNode<T1, T2>(MaxBranchingDegree, keyValue);
                return true;
            }
            else

            {
                // This is a method on its own, ... 
                // but must first find the leaf node at which to insert the node
                // this is why the tree is growing from bottom to top... 
                root.InsertKey(keyValue);
                if (root.IsOverFlown()) // SOhuld check because the key might have been duplicate and insert did not happen
                {
                    // split into 2 nodes, and a new root.  I should have a node.split method which does this:

                    // first half of the keys and children stay to the root (min-keys)
                    // second half of the keys and children move to sibling (min-keys count)
                    // take the key in the middle and 

                    // what happens here is a method on its own,,,, Split I would call it, ... 
                    var siblingKeys = root.KeyValues.TakeLast(root.MinKeys).ToList();
                    Dictionary<BTreeNode<T1, T2>, bool> siblingChildren = root.Children.TakeLast(root.MinBranchingDegree).ToDictionary(keyVal => keyVal.Key, keyVal => keyVal.Value);
                    var sibling = new BTreeNode<T1, T2>(MaxBranchingDegree, siblingKeys, siblingChildren.Keys.ToList());

                    // todo: also change the method signatures so that i can pass ienumerables, etc, or a sorted list
                    // what is the difference between sorted dictionary? ... why not to use the dictionary now? ... 
                    // delete sibling keys from the node
                    //Delet sibling children from node
                    // insert  node's last key to parent : which means call this method again and again

                }
            }

            throw new NotImplementedException();
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
