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

namespace CSFundamentals.Algorithms.GraphTraversal
{
    /// <summary>
    /// Problem: Given a 'connected directed graph', and a start node (called root (note it does not have the same meaning as in a tree, since this is a graph)), find the shortest paths from this node to all the other nodes in the graph. 
    /// TODO: Revisit the summary: is the graph undirected and connected?
    /// </summary>
    public class Dijkstra
    {
        // Traverse all vertices using BFS , and use a min heap to store vertices not yet included in SPT array (meaning shortest path is not finalized yet)
        public static List<GraphNode> GetShortestDistancesFromRoot(GraphNode root)
        {
            //1- Get the list of all vertices in the graph .
            List<GraphNode> bfsOrdering = BFS.BFS_Iterative(root);

            //2- Set the distance of all the nodes from the root node to infinite. 
            foreach (GraphNode node in bfsOrdering)
            {
                node.DistanceFromRoot = int.MaxValue; // aka. Infinite. 
            }
            //3- Set the distance of the root node from the root node to zero. 
            root.DistanceFromRoot = 0;

            //4- Build a MinHeap over all the nodes in the array.
            var minHeap = new MinBinaryHeap<GraphNode>(bfsOrdering);

            List<GraphNode> shortestDistanceFromRoot = new List<GraphNode>();

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

                                // Find index in the array
                                int index = 0;
                                for (int i = 0; i < minHeap.HeapArray.Count; i++)
                                {
                                    if (minHeap.HeapArray[i].Equals(edge.Node))
                                    {
                                        index = i;
                                        break;
                                    }
                                }
                                // bubble up the node. 
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
