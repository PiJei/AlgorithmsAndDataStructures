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
    /// Tests methods in <see cref="BFS"/> class. 
    /// </summary>
    [TestClass]
    public class BfsTests
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
        /// To visualize the graph see images/Graph-BFS-DFS.png
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

        /// <summary>
        /// Tests the correctness of BFS iterative version, when starting from node <see cref="A"/>.
        /// </summary>
        [TestMethod]
        public void Iterative_StartFromA()
        {
            List<GraphNode<int>> bfsOrdering = BFS.BFS_Iterative(A);
            Assert.AreEqual(7, bfsOrdering.Count);
            Assert.AreEqual(4, bfsOrdering[0].Value);
            Assert.AreEqual(1, bfsOrdering[1].Value);
            Assert.AreEqual(20, bfsOrdering[2].Value);
            Assert.AreEqual(6, bfsOrdering[3].Value);
            Assert.AreEqual(3, bfsOrdering[4].Value);
            Assert.AreEqual(11, bfsOrdering[5].Value);
            Assert.AreEqual(5, bfsOrdering[6].Value);
        }

        /// <summary>
        /// Tests the correctness of BFS iterative version, when starting from node <see cref="E"/>.
        /// </summary>
        [TestMethod]
        public void Iterative_StartFromE()
        {
            List<GraphNode<int>> bfsOrdering = BFS.BFS_Iterative(E);
            Assert.AreEqual(7, bfsOrdering.Count);

            Assert.AreEqual(3, bfsOrdering[0].Value);
            Assert.AreEqual(1, bfsOrdering[1].Value);
            Assert.AreEqual(11, bfsOrdering[2].Value);
            Assert.AreEqual(4, bfsOrdering[3].Value);
            Assert.AreEqual(6, bfsOrdering[4].Value);
            Assert.AreEqual(20, bfsOrdering[5].Value);
            Assert.AreEqual(5, bfsOrdering[6].Value);
        }

        /// <summary>
        /// Tests the correctness of BFS recursive version, when starting from node <see cref="A"/>.
        /// </summary>
        [TestMethod]
        public void Recursive_StartFromA()
        {
            var queue = new Queue<GraphNode<int>>();
            A.IsInserted = true;
            queue.Enqueue(A);
            var bfsOrdering = new List<GraphNode<int>>();
            BFS.BFS_Recursive(queue, bfsOrdering);

            Assert.AreEqual(7, bfsOrdering.Count);

            Assert.AreEqual(4, bfsOrdering[0].Value);
            Assert.AreEqual(1, bfsOrdering[1].Value);
            Assert.AreEqual(20, bfsOrdering[2].Value);
            Assert.AreEqual(6, bfsOrdering[3].Value);
            Assert.AreEqual(3, bfsOrdering[4].Value);
            Assert.AreEqual(11, bfsOrdering[5].Value);
            Assert.AreEqual(5, bfsOrdering[6].Value);
        }

        /// <summary>
        /// Tests the correctness of BFS recursive version, when starting from node <see cref="E"/>.
        /// </summary>
        [TestMethod]
        public void Recursive_StartFromE()
        {
            var queue = new Queue<GraphNode<int>>();
            E.IsInserted = true;
            queue.Enqueue(E);
            var bfsOrdering = new List<GraphNode<int>>();
            BFS.BFS_Recursive(queue, bfsOrdering);

            Assert.AreEqual(7, bfsOrdering.Count);

            Assert.AreEqual(3, bfsOrdering[0].Value);
            Assert.AreEqual(1, bfsOrdering[1].Value);
            Assert.AreEqual(11, bfsOrdering[2].Value);
            Assert.AreEqual(4, bfsOrdering[3].Value);
            Assert.AreEqual(6, bfsOrdering[4].Value);
            Assert.AreEqual(20, bfsOrdering[5].Value);
            Assert.AreEqual(5, bfsOrdering[6].Value);
        }
    }
}
