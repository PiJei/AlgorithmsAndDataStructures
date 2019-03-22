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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals.DataStructures.Trees;

namespace CSFundamentalsTests.DataStructures.Trees
{
    [TestClass]
    public class BTreeTests
    {
        public bool HasBTreeProperties<T1, T2>(BTreeNode<T1, T2> root) where T1 : IComparable<T1>
        {
            List<BTreeNode<T1, T2>> nodes = new List<BTreeNode<T1, T2>>();
            DFS(root, nodes);

            /* Checking whether all the nodes are proper BTree nodes. */
            foreach (BTreeNode<T1, T2> node in nodes)
            {
                Assert.IsTrue(BTreeNodeTests.HasBTreeNodeProperties(node));
            }

            /* Check all the leave nodes are at the same level, or one level apart? */

            return true;
        }

        /// <summary>
        /// TODO: How to make this to use the dfs I have in the algorithms? 
        /// </summary>
        public void DFS<T1, T2>(BTreeNode<T1, T2> node, List<BTreeNode<T1, T2>> nodes) where T1 : IComparable<T1>
        {
            nodes.Add(node);
            foreach (KeyValuePair<BTreeNode<T1, T2>, bool> n in node.Children)
            {
                DFS(n.Key, nodes);
            }
        }
   }
}
