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
using System;
using System.Collections.Generic;

namespace CSFundamentals.Algorithms.GraphTraversal
{
    /// <summary>
    /// Implements a generic graph node. 
    /// </summary>
    /// <typeparam name="TValue">Is the type of the value stored in the node. </typeparam>
    public class GraphNode<TValue> : IComparable<GraphNode<TValue>>
    {
        /// <summary>
        /// The value stored in the node. 
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// The list of all the adjacent nodes of this node. It means all the nodes that are connected to this node by a direct edge.
        /// </summary>
        public List<GraphEdge<TValue>> Adjacents { get; set; } = new List<GraphEdge<TValue>>();

        /// <summary>
        /// Is the distance of this node from a node at which traversal of the graph containing current node starts.
        /// </summary>
        public int DistanceFromStartNode { get; set; } = 0;

        /// <summary>
        /// Determines whether this node, in a particular instance of a traversal algorithm has been already visited : inserted in the queue/stack. 
        /// </summary>
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
        /// <returns></returns>
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
        /// Specifies the minimum value for GraphNode type. 
        /// </summary>
        public static readonly GraphNode<TValue> MinValue = new GraphNode<TValue>(default(TValue));

        /// <summary>
        /// Specifies the maximum value for GraphNode type.
        /// </summary>
        public static readonly GraphNode<TValue> MaxValue = new GraphNode<TValue>(default(TValue));
    }
}
