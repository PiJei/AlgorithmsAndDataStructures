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
    [TestClass]
    public class DfsTests
    {
        private GraphNode<int> A = new GraphNode<int>(4);
        private GraphNode<int> B = new GraphNode<int>(1);
        private GraphNode<int> C = new GraphNode<int>(20);
        private GraphNode<int> D = new GraphNode<int>(6);
        private GraphNode<int> E = new GraphNode<int>(3);
        private GraphNode<int> F = new GraphNode<int>(11);
        private GraphNode<int> G = new GraphNode<int>(5);

        /// <summary>
        /// Initializes/Resets variables before executing each unit test in this class. 
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            A.Adjacents.Add(new GraphEdge<int>(B, 0));
            A.Adjacents.Add(new GraphEdge<int>(C, 0));
            A.Adjacents.Add(new GraphEdge<int>(D, 0));

            B.Adjacents.Add(new GraphEdge<int>(E, 0));
            B.Adjacents.Add(new GraphEdge<int>(F, 0));
            B.Adjacents.Add(new GraphEdge<int>(A, 0));

            C.Adjacents.Add(new GraphEdge<int>(G, 0));
            C.Adjacents.Add(new GraphEdge<int>(A, 0));

            D.Adjacents.Add(new GraphEdge<int>(F, 0));
            D.Adjacents.Add(new GraphEdge<int>(A, 0));

            F.Adjacents.Add(new GraphEdge<int>(D, 0));
            F.Adjacents.Add(new GraphEdge<int>(B, 0));

            E.Adjacents.Add(new GraphEdge<int>(B, 0));
        }

        public void ResetGraph() // It seems that this step is unnecessary. Even though the same instance is used across all the test methods. 
        {
            A.IsInserted = false;
            B.IsInserted = false;
            C.IsInserted = false;
            D.IsInserted = false;
            E.IsInserted = false;
            F.IsInserted = false;
            G.IsInserted = false;
        }
        [TestMethod]
        public void Iterative_StartFromA()
        {
            List<GraphNode<int>> dfsOrdering = DFS.DFS_Iterative(A);
            Assert.AreEqual(7, dfsOrdering.Count);

            Assert.AreEqual(4, dfsOrdering[0].Value);
            Assert.AreEqual(6, dfsOrdering[1].Value);
            Assert.AreEqual(11, dfsOrdering[2].Value);
            Assert.AreEqual(20, dfsOrdering[3].Value);
            Assert.AreEqual(5, dfsOrdering[4].Value);
            Assert.AreEqual(1, dfsOrdering[5].Value);
            Assert.AreEqual(3, dfsOrdering[6].Value);

            ResetGraph();
        }

        [TestMethod]
        public void Iterative_StartFromE()
        {
            List<GraphNode<int>> dfsOrdering = DFS.DFS_Iterative(E);
            Assert.AreEqual(7, dfsOrdering.Count);

            Assert.AreEqual(3, dfsOrdering[0].Value);
            Assert.AreEqual(1, dfsOrdering[1].Value);
            Assert.AreEqual(4, dfsOrdering[2].Value);
            Assert.AreEqual(6, dfsOrdering[3].Value);
            Assert.AreEqual(20, dfsOrdering[4].Value);
            Assert.AreEqual(5, dfsOrdering[5].Value);
            Assert.AreEqual(11, dfsOrdering[6].Value);

            ResetGraph();
        }

        [TestMethod]
        public void Recursive_StartFromA()
        {
            ResetGraph();
            var dfsOrdering = new List<GraphNode<int>>();
            DFS.DFS_Recursive(A, dfsOrdering);

            Assert.AreEqual(7, dfsOrdering.Count);

            Assert.AreEqual(4, dfsOrdering[0].Value);
            Assert.AreEqual(1, dfsOrdering[1].Value);
            Assert.AreEqual(3, dfsOrdering[2].Value);
            Assert.AreEqual(11, dfsOrdering[3].Value);
            Assert.AreEqual(6, dfsOrdering[4].Value);
            Assert.AreEqual(20, dfsOrdering[5].Value);
            Assert.AreEqual(5, dfsOrdering[6].Value);

            ResetGraph();
        }

        [TestMethod]
        public void Recursive_StartFromE()
        {
            ResetGraph();
            var dfsOrdering = new List<GraphNode<int>>();
            DFS.DFS_Recursive(E, dfsOrdering);

            Assert.AreEqual(7, dfsOrdering.Count);

            Assert.AreEqual(3, dfsOrdering[0].Value);
            Assert.AreEqual(1, dfsOrdering[1].Value);
            Assert.AreEqual(11, dfsOrdering[2].Value);
            Assert.AreEqual(6, dfsOrdering[3].Value);
            Assert.AreEqual(4, dfsOrdering[4].Value);
            Assert.AreEqual(20, dfsOrdering[5].Value);
            Assert.AreEqual(5, dfsOrdering[6].Value);

            ResetGraph();
        }
    }
}
