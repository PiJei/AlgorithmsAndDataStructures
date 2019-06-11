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
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using AlgorithmsAndDataStructures.DataStructures.Trees.Nary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.DataStructures.Trees.Nary
{
    /// <summary>
    /// Tests BTreeNode implementation by a 2-3-4 BTree Node.
    /// </summary>
    [TestClass]
    public class _2_3_4_BTreeNodeTests
    {
        /// <summary>
        /// Tests the correctness of constructor. 
        /// </summary>
        [TestMethod]
        public void Constructor_CheckingDegrees()
        {
            var node = new BTreeNode<int, string>(4);
            Assert.AreEqual(2, node.MinBranchingDegree);
            Assert.AreEqual(4, node.MaxBranchingDegree);
            Assert.AreEqual(1, node.MinKeys);
            Assert.AreEqual(3, node.MaxKeys);
        }
    }
}
