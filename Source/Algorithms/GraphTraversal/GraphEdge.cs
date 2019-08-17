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

namespace AlgorithmsAndDataStructures.Algorithms.GraphTraversal
{
    /// <summary>
    /// A generic graph edge. For sample use-cases <see cref="DFS"/>, <see cref="BFS"/>, <see cref="Dijkstra"/>.
    /// </summary>
    public class GraphEdge<TValue>
    {
        /// <value> GraphNode at the other end of this edge. </value>
        public GraphNode<TValue> Node { get; set; }

        /// <value> Weight of this edge. Used in <see cref="Dijkstra"/>.</value>
        public int Weight { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="node">The node at the end of this edge. </param>
        /// <param name="weight">Weight of this edge. </param>
        public GraphEdge(GraphNode<TValue> node, int weight)
        {
            Node = node;
            Weight = weight;
        }
    }
}
