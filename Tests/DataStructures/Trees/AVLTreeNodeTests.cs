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
using System;
using System.Collections.Generic;

namespace CSFundamentalsTests.DataStructures.Trees
{
    [TestClass]
    public class AVLTreeNodeTests
    {
        private AVLTreeNode<int, string> A = new AVLTreeNode<int, string>(50, "A");
        private AVLTreeNode<int, string> B = new AVLTreeNode<int, string>(20, "B");
        private AVLTreeNode<int, string> C = new AVLTreeNode<int, string>(10, "C");
        private AVLTreeNode<int, string> D = new AVLTreeNode<int, string>(40, "D");
        private AVLTreeNode<int, string> E = new AVLTreeNode<int, string>(30, "E");

        [TestInitialize]
        public void Init()
        {
            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = null;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = D;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            D.Parent = B;
            D.LeftChild = E;
            D.RightChild = null;

            E.Parent = D;
            E.LeftChild = null;
            E.RightChild = null;

            BinarySearchTreeTests.HasBinarySearchTreeOrderProperty<AVLTreeNode<int, string>, int, string>(A);
        }

        [TestMethod]
        public void AVLTreeNode_GetHeight_Test()
        {

            Assert.AreEqual(4, A.GetHeight());
            Assert.AreEqual(3, B.GetHeight());
            Assert.AreEqual(1, C.GetHeight()); // Is a leaf node. 
            Assert.AreEqual(2, D.GetHeight());
            Assert.AreEqual(1, E.GetHeight()); // Is a leaf node. 
        }

        [TestMethod]
        public void AVLTreeNode_GetBalanceFactor_Test()
        {
            /* The constructed tree is not AVL, however the method GetBalanceFactor should work regardless. */
            // TODO Maybe this means that you should  move this up to tree base class.
            // TODO: Most of methods such as uncle, parent, etc can go up TreeNode using T template ... 
            // TODO ANd then these tests should all move up to the TreeNode tests, given that none has to do with the properties of a binary search tree
            // TODO Also given that avl and rb are binary search tree, I would expect some more inheritence there. .. for the tree itself besides the nodes

            Assert.AreEqual(-3, A.ComputeBalanceFactor());
            Assert.AreEqual(1, B.ComputeBalanceFactor());
            Assert.AreEqual(0, C.ComputeBalanceFactor());
            Assert.AreEqual(-1, D.ComputeBalanceFactor());
            Assert.AreEqual(0, E.ComputeBalanceFactor());
        }
    }
}
