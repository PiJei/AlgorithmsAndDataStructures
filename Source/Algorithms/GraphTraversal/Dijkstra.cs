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
using CSFundamentals.DataStructures.BinaryHeaps;
using CSFundamentals.Styling;

namespace CSFundamentals.Algorithms.GraphTraversal
{
    public class Dijkstra
    {
        /// <summary>
        /// Implements Dijkstra's ShortestPath algorithm using MinBinaryHeap
        /// </summary>
        /// <param name="root">Specifies </param>
        /// <returns>All the nodes in the graph, in the order that they were visited with their shortest distance from the root computed. </returns>
        [Algorithm(AlgorithmType.GraphRouteSearch, "Dijkstra's shortest path", IsGreedy = true)]
        [SpaceComplexity("O(3V)", InPlace = false)]
        [TimeComplexity(Case.Average, "O((E+V)Log(V))")]
        public static List<GraphNode> GetShortestDistancesFromRoot(GraphNode root)
        {
            //1- Get the list of all vertices in the graph .
            List<GraphNode> bfsOrdering = BFS.BFS_Iterative(root); /* Extra space usage O(V) for bfsOrdering. */

            //2- Set the distance of all the nodes from the root node to infinite. 
            foreach (GraphNode node in bfsOrdering)
            {
                node.DistanceFromRoot = int.MaxValue; // aka. Infinite. 
            }
            //3- Set the distance of the root node from the root node to zero. 
            root.DistanceFromRoot = 0;

            //4- Build a MinHeap over all the nodes in the array.
            var minHeap = new MinBinaryHeap<GraphNode>(bfsOrdering); /* Extra space usage O(V) for heapArray. */

            List<GraphNode> shortestDistanceFromRoot = new List<GraphNode>(); /* Extra space usage O(V) for tracking shortest distances of all the nodes from the root node. */

            while (true) // Repeat until minHeap is empty. 
            {
                //5- Update the distance of all the adjacent nodes of the current minimum node. 
                if (minHeap.TryFindRoot(out GraphNode currentMinNode, minHeap.HeapArray.Count))
                {
                    foreach (GraphEdge edge in currentMinNode.Adjacents)
                    {
                        if (!shortestDistanceFromRoot.Contains(edge.Node))
                        {
                            if (edge.Node.DistanceFromRoot > currentMinNode.DistanceFromRoot + edge.Weight)
                            {
                                edge.Node.DistanceFromRoot = currentMinNode.DistanceFromRoot + edge.Weight;
                                int index = minHeap.FindIndex(edge.Node); /* Can be O(1) if the index of each element is stored with the element. */
                                if (index >= 0)
                                    minHeap.BubbleUp_Iteratively(index, minHeap.HeapArray.Count);
                            }
                        }
                    }
                    if (minHeap.TryRemoveRoot(out currentMinNode, minHeap.HeapArray.Count))
                    {
                        shortestDistanceFromRoot.Add(currentMinNode);
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
