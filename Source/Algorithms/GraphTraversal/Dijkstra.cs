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
using System.Linq;
using CSFundamentals.DataStructures.BinaryHeaps;
using CSFundamentals.Decoration;

namespace CSFundamentals.Algorithms.GraphTraversal
{
    public class Dijkstra
    {
        /// <summary>
        /// Implements Dijkstra's ShortestPath algorithm using MinBinaryHeap
        /// </summary>
        /// <param name="root">Specifies a node from which we want to compute shortest paths to all the other nodes in the graph. </param>
        /// <returns>All the nodes in the graph, in the order that they were visited with their shortest distance from the root computed. </returns>
        [Algorithm(AlgorithmType.GraphRouteSearch, "Dijkstra's shortest path", IsGreedy = true)]
        [SpaceComplexity("O(3V)", InPlace = false)]
        [TimeComplexity(Case.Average, "O((E+V)Log(V))")]
        public static List<GraphNode<TValue>> GetShortestDistancesFromRoot<TValue>(GraphNode<TValue> root)
        {
            //1- Get the list of all vertices in the graph .
            List<GraphNode<TValue>> bfsOrdering = BFS.BFS_Iterative(root); /* Extra space usage O(V) for bfsOrdering. */

            //2- Set the distance of all the nodes from the root node to infinite. 
            foreach (GraphNode<TValue> node in bfsOrdering)
            {
                node.DistanceFromRoot = int.MaxValue; // aka. Infinite. 
            }
            //3- Set the distance of the root node from the root node to zero. 
            root.DistanceFromRoot = 0;

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
                            if (edge.Node.DistanceFromRoot > currentMinNode.Key.DistanceFromRoot + edge.Weight)
                            {
                                edge.Node.DistanceFromRoot = currentMinNode.Key.DistanceFromRoot + edge.Weight;
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
