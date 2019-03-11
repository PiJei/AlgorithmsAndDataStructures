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
        [TestMethod]
        public void AVLTreeNode_GetHeight_Test()
        {
            AVLTreeNode<int, string> A = new AVLTreeNode<int, string>(50, "A");
            AVLTreeNode<int, string> B = new AVLTreeNode<int, string>(20, "B");
            AVLTreeNode<int, string> C = new AVLTreeNode<int, string>(10, "C");
            AVLTreeNode<int, string> D = new AVLTreeNode<int, string>(40, "D");
            AVLTreeNode<int, string> E = new AVLTreeNode<int, string>(30, "E");

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

            Assert.AreEqual(4, A.GetHeight());
        }
    }
}
