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

namespace CSFundamentals.Algorithms.GraphTraversal
{
    public class GraphNode : IComparable<GraphNode>
    {
        public int Value { get; set; }
        public List<GraphEdge> Adjacents { get; set; } = new List<GraphEdge>();
        public int DistanceFromRoot { get; set; } = int.MaxValue; /* aka infinite, assuming at start a node is not reachable from root.*/

        /// <summary>
        /// Determines whether this node, in a particular instance of a traversal algorithm has been already visited : inserted in the queue/stack. 
        /// </summary>
        public bool IsInserted { get; set; }
        public GraphNode(int value)
        {
            Value = value;
        }

        public int CompareTo(GraphNode other)
        {
            if (other == null) return 1;
            if (ReferenceEquals(this, other)) return 0;
            if (GetType() != other.GetType()) return 1;
            if (DistanceFromRoot < other.DistanceFromRoot) return -1;
            if (DistanceFromRoot == other.DistanceFromRoot) return 0;
            if (DistanceFromRoot > other.DistanceFromRoot) return 1;
            return 0;
        }
    }
}
