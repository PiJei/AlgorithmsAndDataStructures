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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals.DataStructures.Trees;
using System.Collections.Generic;

namespace CSFundamentalsTests.DataStructures.Trees
{
    [TestClass]
    public class TreeNodeTests
    {
        private BinarySearchTreeNode<int, string> _root = null;

        [TestInitialize]
        public void Init()
        {
            BinarySearchTreeNode<int, string> B = new BinarySearchTreeNode<int, string>(30, "B");
            BinarySearchTreeNode<int, string> A = new BinarySearchTreeNode<int, string>(47, "A");
            BinarySearchTreeNode<int, string> C = new BinarySearchTreeNode<int, string>(50, "C");
            BinarySearchTreeNode<int, string> D = new BinarySearchTreeNode<int, string>(20, "D");
            BinarySearchTreeNode<int, string> E = new BinarySearchTreeNode<int, string>(40, "E");
            BinarySearchTreeNode<int, string> F = new BinarySearchTreeNode<int, string>(35, "F");
            BinarySearchTreeNode<int, string> G = new BinarySearchTreeNode<int, string>(45, "G");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = C;

            B.Parent = A;
            B.LeftChild = D;
            B.RightChild = E;

            C.Parent = A;
            C.LeftChild = null;
            C.RightChild = null;

            D.Parent = B;
            D.LeftChild = null;
            D.RightChild = null;

            E.Parent = B;
            E.LeftChild = F;
            E.RightChild = G;

            F.Parent = E;
            F.LeftChild = null;
            F.RightChild = null;

            G.Parent = E;
            G.LeftChild = null;
            G.RightChild = null;

            _root = A;
        }

        [TestMethod]
        public void GetAllPathToNullLeaves_Test()
        {
            List<List<BinarySearchTreeNode<int, string>>> pathsFromA = TreeNode<BinarySearchTreeNode<int, string>, int, string>.GetAllPathToNullLeaves(_root);
            Assert.AreEqual(4, pathsFromA.Count);
            Assert.AreEqual(3, pathsFromA[0].Count);
            Assert.AreEqual(4, pathsFromA[1].Count);
            Assert.AreEqual(4, pathsFromA[2].Count);
            Assert.AreEqual(2, pathsFromA[3].Count);
        }
    }
}
