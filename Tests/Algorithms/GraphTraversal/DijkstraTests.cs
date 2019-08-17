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
using System.Collections.Generic;
using AlgorithmsAndDataStructures.Algorithms.GraphTraversal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.Algorithms.GraphTraversal
{
    /// <summary>
    /// Tests methods in <see cref="Dictionary{TKey, TValue}"/> class. 
    /// </summary>
    [TestClass]
    public class DijkstraTests
    {
        /// <summary>
        /// Tests the correctness of shortest distance computation. Root is node A. 
        /// To visualize the graph see: <img src = "../Images/Graphs/Disjkstra.png"/>.
        /// </summary>
        [TestMethod]
        public void GetShortestDistancesFromRoot()
        {
            var A = new GraphNode<string>("A");
            var B = new GraphNode<string>("B");
            var C = new GraphNode<string>("C");
            var D = new GraphNode<string>("D");
            var E = new GraphNode<string>("E");
            var F = new GraphNode<string>("F");
            var G = new GraphNode<string>("G");
            var H = new GraphNode<string>("H");
            var I = new GraphNode<string>("I");

            A.Adjacents.Add(new GraphEdge<string>(B, 4));
            A.Adjacents.Add(new GraphEdge<string>(C, 8));

            B.Adjacents.Add(new GraphEdge<string>(A, 4));
            B.Adjacents.Add(new GraphEdge<string>(C, 11));
            B.Adjacents.Add(new GraphEdge<string>(D, 8));

            C.Adjacents.Add(new GraphEdge<string>(A, 8));
            C.Adjacents.Add(new GraphEdge<string>(B, 11));
            C.Adjacents.Add(new GraphEdge<string>(E, 7));
            C.Adjacents.Add(new GraphEdge<string>(F, 1));

            D.Adjacents.Add(new GraphEdge<string>(B, 8));
            D.Adjacents.Add(new GraphEdge<string>(E, 2));
            D.Adjacents.Add(new GraphEdge<string>(G, 7));
            D.Adjacents.Add(new GraphEdge<string>(H, 4));

            E.Adjacents.Add(new GraphEdge<string>(D, 2));
            E.Adjacents.Add(new GraphEdge<string>(C, 7));
            E.Adjacents.Add(new GraphEdge<string>(F, 6));

            F.Adjacents.Add(new GraphEdge<string>(C, 1));
            F.Adjacents.Add(new GraphEdge<string>(E, 6));
            F.Adjacents.Add(new GraphEdge<string>(H, 2));

            G.Adjacents.Add(new GraphEdge<string>(D, 7));
            G.Adjacents.Add(new GraphEdge<string>(H, 14));
            G.Adjacents.Add(new GraphEdge<string>(I, 9));

            H.Adjacents.Add(new GraphEdge<string>(F, 2));
            H.Adjacents.Add(new GraphEdge<string>(D, 4));
            H.Adjacents.Add(new GraphEdge<string>(G, 14));
            H.Adjacents.Add(new GraphEdge<string>(I, 10));

            I.Adjacents.Add(new GraphEdge<string>(G, 9));
            I.Adjacents.Add(new GraphEdge<string>(H, 10));

            List<GraphNode<string>> distancesFromRoot = Dijkstra.GetShortestDistancesFromRoot(A);

            Assert.AreEqual("A", distancesFromRoot[0].Value);
            Assert.AreEqual(0, distancesFromRoot[0].DistanceFromStartNode);

            Assert.AreEqual("B", distancesFromRoot[1].Value);
            Assert.AreEqual(4, distancesFromRoot[1].DistanceFromStartNode);

            Assert.AreEqual("C", distancesFromRoot[2].Value);
            Assert.AreEqual(8, distancesFromRoot[2].DistanceFromStartNode);

            Assert.AreEqual("F", distancesFromRoot[3].Value);
            Assert.AreEqual(9, distancesFromRoot[3].DistanceFromStartNode);

            Assert.AreEqual("H", distancesFromRoot[4].Value);
            Assert.AreEqual(11, distancesFromRoot[4].DistanceFromStartNode);

            Assert.AreEqual("D", distancesFromRoot[5].Value);
            Assert.AreEqual(12, distancesFromRoot[5].DistanceFromStartNode);

            Assert.AreEqual("E", distancesFromRoot[6].Value);
            Assert.AreEqual(14, distancesFromRoot[6].DistanceFromStartNode);

            Assert.AreEqual("G", distancesFromRoot[7].Value);
            Assert.AreEqual(19, distancesFromRoot[7].DistanceFromStartNode);

            Assert.AreEqual("I", distancesFromRoot[8].Value);
            Assert.AreEqual(21, distancesFromRoot[8].DistanceFromStartNode);
        }
    }
}
