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
using CSFundamentals.Algorithms.GraphTraversal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.Algorithms.GraphTraversal
{
    /// <summary>
    /// Tests methods in <see cref="Dictionary{TKey, TValue}"/> class. 
    /// </summary>
    [TestClass]
    public class DijkstraTests
    {
        /// <summary>
        /// Tests the correctness of shortest distance computation 
        /// </summary>
        [TestMethod]
        public void GetShortestDistancesFromRoot()
        {
            var node1 = new GraphNode<int>(0);
            var node2 = new GraphNode<int>(1);
            var node3 = new GraphNode<int>(7);
            var node4 = new GraphNode<int>(2);
            var node5 = new GraphNode<int>(8);
            var node6 = new GraphNode<int>(6);
            var node7 = new GraphNode<int>(3);
            var node8 = new GraphNode<int>(5);
            var node9 = new GraphNode<int>(4);

            node1.Adjacents.Add(new GraphEdge<int>(node2, 4));
            node1.Adjacents.Add(new GraphEdge<int>(node3, 8));

            node2.Adjacents.Add(new GraphEdge<int>(node1, 4));
            node2.Adjacents.Add(new GraphEdge<int>(node3, 11));
            node2.Adjacents.Add(new GraphEdge<int>(node4, 8));

            node3.Adjacents.Add(new GraphEdge<int>(node1, 8));
            node3.Adjacents.Add(new GraphEdge<int>(node2, 11));
            node3.Adjacents.Add(new GraphEdge<int>(node5, 7));
            node3.Adjacents.Add(new GraphEdge<int>(node6, 1));

            node4.Adjacents.Add(new GraphEdge<int>(node2, 8));
            node4.Adjacents.Add(new GraphEdge<int>(node5, 2));
            node4.Adjacents.Add(new GraphEdge<int>(node7, 7));
            node4.Adjacents.Add(new GraphEdge<int>(node8, 4));

            node5.Adjacents.Add(new GraphEdge<int>(node4, 2));
            node5.Adjacents.Add(new GraphEdge<int>(node3, 7));
            node5.Adjacents.Add(new GraphEdge<int>(node6, 6));

            node6.Adjacents.Add(new GraphEdge<int>(node3, 1));
            node6.Adjacents.Add(new GraphEdge<int>(node5, 6));
            node6.Adjacents.Add(new GraphEdge<int>(node8, 2));

            node7.Adjacents.Add(new GraphEdge<int>(node4, 7));
            node7.Adjacents.Add(new GraphEdge<int>(node8, 14));
            node7.Adjacents.Add(new GraphEdge<int>(node9, 9));

            node8.Adjacents.Add(new GraphEdge<int>(node6, 2));
            node8.Adjacents.Add(new GraphEdge<int>(node4, 4));
            node8.Adjacents.Add(new GraphEdge<int>(node7, 14));
            node8.Adjacents.Add(new GraphEdge<int>(node9, 10));

            node9.Adjacents.Add(new GraphEdge<int>(node7, 9));
            node9.Adjacents.Add(new GraphEdge<int>(node8, 10));

            List<GraphNode<int>> distancesFromRoot = Dijkstra.GetShortestDistancesFromRoot(node1);

            Assert.AreEqual(0, distancesFromRoot[0].Value);
            Assert.AreEqual(0, distancesFromRoot[0].DistanceFromRoot);

            Assert.AreEqual(1, distancesFromRoot[1].Value);
            Assert.AreEqual(4, distancesFromRoot[1].DistanceFromRoot);

            Assert.AreEqual(7, distancesFromRoot[2].Value);
            Assert.AreEqual(8, distancesFromRoot[2].DistanceFromRoot);

            Assert.AreEqual(6, distancesFromRoot[3].Value);
            Assert.AreEqual(9, distancesFromRoot[3].DistanceFromRoot);

            Assert.AreEqual(5, distancesFromRoot[4].Value);
            Assert.AreEqual(11, distancesFromRoot[4].DistanceFromRoot);

            Assert.AreEqual(2, distancesFromRoot[5].Value);
            Assert.AreEqual(12, distancesFromRoot[5].DistanceFromRoot);

            Assert.AreEqual(8, distancesFromRoot[6].Value);
            Assert.AreEqual(14, distancesFromRoot[6].DistanceFromRoot);

            Assert.AreEqual(3, distancesFromRoot[7].Value);
            Assert.AreEqual(19, distancesFromRoot[7].DistanceFromRoot);

            Assert.AreEqual(4, distancesFromRoot[8].Value);
            Assert.AreEqual(21, distancesFromRoot[8].DistanceFromRoot);
        }
    }
}
