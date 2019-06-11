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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.DataStructures.BinaryHeaps;
using AlgorithmsAndDataStructures.Decoration;

namespace AlgorithmsAndDataStructures.Algorithms.GraphTraversal
{
    /// <summary>
    /// Implements Dijkstra's algorithm for finding shortest paths from a given node to all the other nodes in a graph.
    /// </summary>
    public class Dijkstra
    {
        /// <summary>
        /// Implements Dijkstra's ShortestPath algorithm using <see cref="MinBinaryHeap{TKey, TValue}"/>.
        /// </summary>
        /// <param name="startNode">A node from which shortest paths to all the other nodes in the graph are computed. </param>
        /// <returns>All the nodes in the graph, in the order visited with their shortest distance computed from <paramref name="startNode"/>. </returns>
        [Algorithm(AlgorithmType.GraphRouteSearch, "Dijkstra's shortest path", IsGreedy = true)]
        [SpaceComplexity("O(3V)", InPlace = false)]
        [TimeComplexity(Case.Average, "O((E+V)Log(V))")]
        public static List<GraphNode<TValue>> GetShortestDistancesFromRoot<TValue>(GraphNode<TValue> startNode)
        {
            //1- Get the list of all vertexes in the graph .
            List<GraphNode<TValue>> bfsOrdering = BFS.BFS_Iterative(startNode); /* Extra space usage O(V) for bfsOrdering. */

            //2- Set the distance of all the nodes from the root node to infinite. 
            foreach (GraphNode<TValue> node in bfsOrdering)
            {
                node.DistanceFromStartNode = int.MaxValue; // aka. Infinite. 
            }
            //3- Set the distance of the root node from the root node to zero. 
            startNode.DistanceFromStartNode = 0;

            //4- Build a MinHeap over all the nodes in the array.
            var minHeap = new MinBinaryHeap<GraphNode<TValue>, TValue>(bfsOrdering.Select(o => new KeyValuePair<GraphNode<TValue>, TValue>(o, o.Value)).ToList()); /* Extra space usage O(V) for heapArray. */

            var shortestDistanceFromRoot = new List<GraphNode<TValue>>(); /* Extra space usage O(V) for tracking shortest distances of all the nodes from the root node. */

            while (true) // Repeat until minHeap is empty. 
            {
                //5- Update the distance of all the adjacent nodes of the current minimum node. 
                if (minHeap.TryFindRoot(out KeyValuePair<GraphNode<TValue>, TValue> currentMinNode, minHeap.HeapArray.Count))
                {
                    foreach (GraphEdge<TValue> edge in currentMinNode.Key.Adjacents)
                    {
                        if (!shortestDistanceFromRoot.Contains(edge.Node))
                        {
                            if (edge.Node.DistanceFromStartNode > currentMinNode.Key.DistanceFromStartNode + edge.Weight)
                            {
                                edge.Node.DistanceFromStartNode = currentMinNode.Key.DistanceFromStartNode + edge.Weight;
                                int index = minHeap.FindIndex(edge.Node); /* Can be O(1) if the index of each element is stored with the element. */
                                if (index >= 0)
                                {
                                    minHeap.BubbleUp_Iteratively(index, minHeap.HeapArray.Count);
                                }
                            }
                        }
                    }
                    if (minHeap.TryRemoveRoot(out currentMinNode, minHeap.HeapArray.Count))
                    {
                        shortestDistanceFromRoot.Add(currentMinNode.Key);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return shortestDistanceFromRoot;
        }
    }
}
