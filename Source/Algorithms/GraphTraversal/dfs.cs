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

using System.Collections.Generic;

namespace CSFundamentalAlgorithms.Algorithms.GraphTraversal
{
    public class DFS
    {
        /// <summary>
        /// Implements an iterative, recursion-free version of Depth First Search algorithm for a graph (that can well have cycles);
        /// </summary>
        /// <param name="root">Specifies a node in the graph from which the search starts. </param>
        /// <returns>A DFS ordering of the graph's nodes.</returns>
        public static List<GraphNode> DFS_Iterative(GraphNode root)
        {
            Stack<GraphNode> stack = new Stack<GraphNode>();

            root.IsInserted = true;
            root.DistanceFromRoot = 0;
            stack.Push(root);

            /* To store a DFS ordering of the nodes, starting from root. */
            List<GraphNode> dfsOrdering = new List<GraphNode>();
            while (stack.Count > 0) /* while stack is not empty. */
            {
                GraphNode nextNode = stack.Pop();
                dfsOrdering.Add(nextNode);
                foreach (GraphNode node in nextNode.Adjacents)
                {
                    if (!node.IsInserted) /* Without this check, while loop could never terminate in case graph contains cycles.*/
                    {
                        node.IsInserted = true;
                        node.DistanceFromRoot = nextNode.DistanceFromRoot + 1;
                        stack.Push(node);
                    }
                }

            }
            return dfsOrdering;
        }

        /// <summary>
        /// Implements a recursive version of DFS, for returning a DFS ordering of the nodes. 
        /// </summary>
        /// <param name="root"> Specifies the node to start the search from.</param>
        /// <param name="dfsOrdering">Contains a serialization of the graph, with a DFS ordering.</param>
        public static void DFS_Recursive(GraphNode root, List<GraphNode> dfsOrdering)
        {
            root.IsInserted = true;
            dfsOrdering.Add(root);

            foreach (GraphNode node in root.Adjacents)
            {
                if (!node.IsInserted)
                {
                    DFS_Recursive(node, dfsOrdering);
                }
            }
        }
    }
}
