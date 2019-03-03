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

using System.Collections.Generic;

namespace CSFundamentals.Algorithms.GraphTraversal
{
    public class BFS
    {
        /// <summary>
        /// Implements an iterative, recursion-free version of Breadth First Search algorithm for a graph (that can well have cycles);
        /// </summary>
        /// <param name="root">Specifies a node in the graph from which the search starts. </param>
        /// <returns>A BFS ordering of the graph's nodes.</returns>
        public static List<GraphNode> BFS_Iterative(GraphNode root) /* Root is the node from which the search starts.*/
        {
            Queue<GraphNode> queue = new Queue<GraphNode>();

            root.IsInserted = true;
            root.DistanceFromRoot = 0;
            queue.Enqueue(root);

            /* To store a BFS ordering of the nodes, starting from root. */
            List<GraphNode> bfsOrdering = new List<GraphNode>();

            while (queue.Count > 0) /* While queue is not empty.*/
            {
                GraphNode nextNode = queue.Dequeue();
                bfsOrdering.Add(nextNode); /* Appending the queue head to bfsOrdering.*/

                /* Enqueue all the adjacent neighbors of nextNode. */
                foreach (GraphEdge edge in nextNode.Adjacents)
                {
                    if (!edge.Node.IsInserted) /* Without this, and in the presence of cycles, the loop will be endless, the program can get out of memory exceptions. */
                    {
                        edge.Node.IsInserted = true;
                        edge.Node.DistanceFromRoot = nextNode.DistanceFromRoot + 1;
                        queue.Enqueue(edge.Node);
                    }
                }
            }

            return bfsOrdering;
        }


        /// <summary>
        /// Is the recursive version of BFS_Iterative algorithm. Expects the queue to already have the root node in it. 
        /// </summary>
        public static void BFS_Recursive(Queue<GraphNode> queue, List<GraphNode> bfsOrdering)
        {
            if (queue.Count == 0)
            {
                return;
            }

            GraphNode node = queue.Dequeue();
            bfsOrdering.Add(node);

            foreach (GraphEdge edge in node.Adjacents)
            {
                if (!edge.Node.IsInserted) /* To prevent endless recursion in case graph has cycles. */
                {
                    edge.Node.IsInserted = true;
                    queue.Enqueue(edge.Node);
                }
            }
            BFS_Recursive(queue, bfsOrdering);
        }

    }
}
// TODO: In recursive versions of bfs and dfs also compute distance from root. 