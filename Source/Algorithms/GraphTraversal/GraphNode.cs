#region copyright
/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of AlgorithmsAndDataStructures project.
 *
 * AlgorithmsAndDataStructures is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AlgorithmsAndDataStructures is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.GraphTraversal
{
    /// <summary>
    /// A generic graph node. For sample use-cases <see cref="DFS"/>, <see cref="BFS"/>, <see cref="Dijkstra"/>.
    /// </summary>
    /// <typeparam name="TValue">The type of the value stored in the node. </typeparam>
    public class GraphNode<TValue> : IComparable<GraphNode<TValue>>
    {
        /// <value> The value stored in the node. </value>
        public TValue Value { get; set; }

        /// <value> The list of all the adjacent nodes of this node. These are the nodes that are connected to this node by a direct edge. </value>
        public List<GraphEdge<TValue>> Adjacents { get; set; } = new List<GraphEdge<TValue>>();

        /// <value> The distance of this node from a node at which traversal of the graph containing current node starts. Used in <see cref="BFS"/>, and <see cref="DFS"/>. </value>
        public int DistanceFromStartNode { get; set; } = 0;

        /// <value> Determines whether this node, in a particular instance of a traversal algorithm has been already visited : inserted in the queue/stack. </value>
        public bool IsInserted { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value"> The value to be stored in the node. </param>
        public GraphNode(TValue value)
        {
            Value = value;
        }

        /// <summary>
        /// Compares this node to another node of type GraphNode.
        /// </summary>
        /// <param name="other">A graph node</param>
        /// <returns>0 if equal, 1 if current node is bigger than <paramref name="other"/>, and -1 otherwise. </returns>
        public int CompareTo(GraphNode<TValue> other)
        {
            if (other == null)
            {
                return 1;
            }

            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (DistanceFromStartNode < other.DistanceFromStartNode)
            {
                return -1;
            }

            if (DistanceFromStartNode == other.DistanceFromStartNode)
            {
                return 0;
            }

            if (DistanceFromStartNode > other.DistanceFromStartNode)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// The minimum value for GraphNode type. 
        /// </summary>
        public static readonly GraphNode<TValue> MinValue = new GraphNode<TValue>(default(TValue));

        /// <summary>
        /// The maximum value for GraphNode type.
        /// </summary>
        public static readonly GraphNode<TValue> MaxValue = new GraphNode<TValue>(default(TValue));
    }
}
