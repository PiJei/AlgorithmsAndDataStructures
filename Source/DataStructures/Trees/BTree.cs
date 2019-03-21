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
using System.Text;

namespace CSFundamentals.DataStructures.Trees
{
    public class BTree<T1, T2> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Is the root of the tree. 
        /// </summary>
        public BTreeNode<T1, T2> root;

        /// <summary>
        /// Is the minimum number of keys in internal and leaf nodes of this tree. 
        /// </summary>
        public int MinKeys { get; private set; }

        public BTree(int minKeys)
        {
            MinKeys = minKeys;
        }


        public void InOrderTraversal(BTreeNode<T1, T2> node, List<KeyValuePair<T1, T2>> sortedKeys)
        {
            if (node != null)
            {
                for (int i = 0; i < node.Children.Count; i++)
                {
                    InOrderTraversal(node.Children[i], sortedKeys);
                    if (i < node.KeyValues.Count)
                        sortedKeys.Add(node.KeyValues[i]);
                }
            }
        }

        public BTreeNode<T1, T2> Search(BTreeNode<T1, T2> root, T1 key)
        {
            throw new NotImplementedException();
            /*if (key.CompareTo(root.KeyValues[0].Key) < 0)
            {
                return Search(root.Children[0], key);
            }
            else if (key.CompareTo(root.KeyValues[root.KeyValues.Count - 1].Key) > 0)
            {
                return root.Children[root.KeyValues.Count - 1];
            }
            else
            {
                int middle = (root.KeyValues.Count - 1) / 2;
                if (key.CompareTo(root.KeyValues[middle].Key) == 0)
                {
                    return root;
                }
                else
                {
                    // I want to do a binary search over the key values, ... 
                }
            }
            */
        }

        public List<BTree<T1, T2>> Traverse()
        {
            throw new NotImplementedException();
        }


    }
}
