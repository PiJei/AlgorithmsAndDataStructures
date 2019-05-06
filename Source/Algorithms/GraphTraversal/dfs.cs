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
 * along with CSFundamentals.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System.Collections.Generic;

namespace CSFundamentals.Algorithms.GraphTraversal
{
    /// <summary>
    /// Implements Depth First Search algorithm for graph traversal.
    /// </summary>
    public class DFS
    {
        /// <summary>
        /// An iterative version of Depth First Search algorithm for traversing a graph that might have cycles.
        /// </summary>
        /// <remarks>
        /// A graph can have many DFS orderings. Each ordering depends on (i) the start node, and (ii) the order by which each node's adjacent nodes are visited. 
        /// </remarks>
        /// <typeparam name="TValue">Type of the values stored in graph nodes.</typeparam>
        /// <param name="startNode">A node in the graph from which traversal starts. </param>
        /// <returns>A sequence of all graph nodes, put into a DFS ordering.</returns>
        public static List<GraphNode<TValue>> DFS_Iterative<TValue>(GraphNode<TValue> startNode)
        {
            var stack = new Stack<GraphNode<TValue>>();

            startNode.IsInserted = true;
            startNode.DistanceFromStartNode = 0;
            stack.Push(startNode);

            /* Stores a DFS ordering of the nodes. */
            var dfsOrdering = new List<GraphNode<TValue>>();
            while (stack.Count > 0) /* while stack is not empty. */
            {
                GraphNode<TValue> nextNode = stack.Pop();
                dfsOrdering.Add(nextNode);
                foreach (GraphEdge<TValue> edge in nextNode.Adjacents)
                {
                    if (!edge.Node.IsInserted) /* Without this check, while loop could never terminate in case graph contains cycles.*/
                    {
                        edge.Node.IsInserted = true;
                        edge.Node.DistanceFromStartNode = nextNode.DistanceFromStartNode + 1;
                        stack.Push(edge.Node);
                    }
                }

            }
            return dfsOrdering;
        }

        /// <summary>
        /// A recursive version of Depth First Search algorithm for traversing a graph that might have cycles.
        /// </summary>
        /// <remarks>
        /// A graph can have many DFS orderings. Each ordering depends on (i) the start node, and (ii) the order by which each node's adjacent nodes are visited. 
        /// </remarks>
        /// <typeparam name="TValue">Type of the values stored in graph nodes.</typeparam>
        /// <param name="startNode">A node in the graph from which traversal starts. </param>
        /// <param name="dfsOrdering">A sequence of all graph nodes, put into a DFS ordering</param>
        public static void DFS_Recursive<TValue>(GraphNode<TValue> startNode, List<GraphNode<TValue>> dfsOrdering)
        {
            startNode.IsInserted = true;
            dfsOrdering.Add(startNode);

            foreach (GraphEdge<TValue> edge in startNode.Adjacents)
            {
                if (!edge.Node.IsInserted)
                {
                    DFS_Recursive(edge.Node, dfsOrdering);
                }
            }
        }
    }
}
