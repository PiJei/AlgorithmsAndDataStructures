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
    /// Tests methods in <see cref="DFS"/> class. 
    /// </summary>
    [TestClass]
    public class DfsTests
    {
        private readonly GraphNode<string> _nodeA = new GraphNode<string>("A");
        private readonly GraphNode<string> _nodeB = new GraphNode<string>("B");
        private readonly GraphNode<string> _nodeC = new GraphNode<string>("C");
        private readonly GraphNode<string> _nodeD = new GraphNode<string>("D");
        private readonly GraphNode<string> _nodeE = new GraphNode<string>("E");
        private readonly GraphNode<string> _nodeF = new GraphNode<string>("F");
        private readonly GraphNode<string> _nodeG = new GraphNode<string>("G");

        /// <summary>
        /// Initializes/Resets variables before executing each unit test in this class. 
        /// To visualize the graph see <img src = "../Images/Graphs/Graph-BFS-DFS.png"/>.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _nodeA.Adjacents.Add(new GraphEdge<string>(_nodeB, 0));
            _nodeA.Adjacents.Add(new GraphEdge<string>(_nodeC, 0));
            _nodeA.Adjacents.Add(new GraphEdge<string>(_nodeD, 0));

            _nodeB.Adjacents.Add(new GraphEdge<string>(_nodeE, 0));
            _nodeB.Adjacents.Add(new GraphEdge<string>(_nodeF, 0));
            _nodeB.Adjacents.Add(new GraphEdge<string>(_nodeA, 0));

            _nodeC.Adjacents.Add(new GraphEdge<string>(_nodeG, 0));
            _nodeC.Adjacents.Add(new GraphEdge<string>(_nodeA, 0));

            _nodeD.Adjacents.Add(new GraphEdge<string>(_nodeF, 0));
            _nodeD.Adjacents.Add(new GraphEdge<string>(_nodeA, 0));

            _nodeF.Adjacents.Add(new GraphEdge<string>(_nodeD, 0));
            _nodeF.Adjacents.Add(new GraphEdge<string>(_nodeB, 0));

            _nodeE.Adjacents.Add(new GraphEdge<string>(_nodeB, 0));
        }

        /// <summary>
        /// Tests the correctness of BFS iterative version, when starting from node <see cref="_nodeA"/>.
        /// To visualize the graph see <img src = "../Images/Graphs/DFS-Iterative-StartA.png"/>. 
        /// </summary>
        [TestMethod]
        public void Iterative_StartFromA()
        {
            List<GraphNode<string>> dfsOrdering = DFS.DFS_Iterative(_nodeA);
            Assert.AreEqual(7, dfsOrdering.Count);

            Assert.AreEqual("A", dfsOrdering[0].Value);
            Assert.AreEqual("D", dfsOrdering[1].Value);
            Assert.AreEqual("F", dfsOrdering[2].Value);
            Assert.AreEqual("C", dfsOrdering[3].Value);
            Assert.AreEqual("G", dfsOrdering[4].Value);
            Assert.AreEqual("B", dfsOrdering[5].Value);
            Assert.AreEqual("E", dfsOrdering[6].Value);
        }

        /// <summary>
        /// Tests the correctness of BFS iterative version, when starting from node <see cref="_nodeE"/>.
        /// To visualize the graph see <img src = "../Images/Graphs/DFS-Iterative-StartE.png"/>. 
        /// </summary>
        [TestMethod]
        public void Iterative_StartFromE()
        {
            List<GraphNode<string>> dfsOrdering = DFS.DFS_Iterative(_nodeE);
            Assert.AreEqual(7, dfsOrdering.Count);

            Assert.AreEqual("E", dfsOrdering[0].Value);
            Assert.AreEqual("B", dfsOrdering[1].Value);
            Assert.AreEqual("A", dfsOrdering[2].Value);
            Assert.AreEqual("D", dfsOrdering[3].Value);
            Assert.AreEqual("C", dfsOrdering[4].Value);
            Assert.AreEqual("G", dfsOrdering[5].Value);
            Assert.AreEqual("F", dfsOrdering[6].Value);
        }

        /// <summary>
        /// Tests the correctness of BFS recursive version, when starting from node <see cref="_nodeA"/>.
        /// </summary>
        [TestMethod]
        public void Recursive_StartFromA()
        {
            var dfsOrdering = new List<GraphNode<string>>();
            DFS.DFS_Recursive(_nodeA, dfsOrdering);

            Assert.AreEqual(7, dfsOrdering.Count);

            Assert.AreEqual("A", dfsOrdering[0].Value);
            Assert.AreEqual("B", dfsOrdering[1].Value);
            Assert.AreEqual("E", dfsOrdering[2].Value);
            Assert.AreEqual("F", dfsOrdering[3].Value);
            Assert.AreEqual("D", dfsOrdering[4].Value);
            Assert.AreEqual("C", dfsOrdering[5].Value);
            Assert.AreEqual("G", dfsOrdering[6].Value);
        }

        /// <summary>
        /// Tests the correctness of BFS recursive version, when starting from node <see cref="_nodeE"/>.
        /// </summary>
        [TestMethod]
        public void Recursive_StartFromE()
        {
            var dfsOrdering = new List<GraphNode<string>>();
            DFS.DFS_Recursive(_nodeE, dfsOrdering);

            Assert.AreEqual(7, dfsOrdering.Count);

            Assert.AreEqual("E", dfsOrdering[0].Value);
            Assert.AreEqual("B", dfsOrdering[1].Value);
            Assert.AreEqual("F", dfsOrdering[2].Value);
            Assert.AreEqual("D", dfsOrdering[3].Value);
            Assert.AreEqual("A", dfsOrdering[4].Value);
            Assert.AreEqual("C", dfsOrdering[5].Value);
            Assert.AreEqual("G", dfsOrdering[6].Value);
        }
    }
}
