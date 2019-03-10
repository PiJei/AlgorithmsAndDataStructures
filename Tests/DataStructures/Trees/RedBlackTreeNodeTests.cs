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

//TODO: Move most of these to binary tree node

namespace CSFundamentalsTests.DataStructures.Trees
{
    [TestClass]
    public class RedBlackTreeNodeTests
    {
        [TestMethod]
        public void RedBlackTree_GetUncle_Test()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(8, "A");
            RedBlackTreeNode<int, string> B = new RedBlackTreeNode<int, string>(2, "B");
            RedBlackTreeNode<int, string> C = new RedBlackTreeNode<int, string>(10, "C");
            RedBlackTreeNode<int, string> D = new RedBlackTreeNode<int, string>(9, "D");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = C;

            B.Parent = A;
            B.LeftChild = null;
            B.RightChild = null;

            C.Parent = A;
            C.LeftChild = D;
            C.RightChild = null;

            D.Parent = C;
            D.LeftChild = null;
            D.RightChild = null;

            RedBlackTreeTests.HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();
            Assert.IsTrue(A.GetUncle() == null);
            Assert.IsTrue(B.GetUncle() == null);
            Assert.IsTrue(C.GetUncle() == null);
            Assert.IsTrue(D.GetUncle().Equals(B));
        }

        [TestMethod]
        public void RedBlackTree_GetGrandParent_Test()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(50, "A");
            RedBlackTreeNode<int, string> B = new RedBlackTreeNode<int, string>(30, "B");
            RedBlackTreeNode<int, string> C = new RedBlackTreeNode<int, string>(20, "C");
            RedBlackTreeNode<int, string> D = new RedBlackTreeNode<int, string>(40, "D");
            RedBlackTreeNode<int, string> E = new RedBlackTreeNode<int, string>(35, "E");
            RedBlackTreeNode<int, string> F = new RedBlackTreeNode<int, string>(45, "F");
            RedBlackTreeNode<int, string> G = new RedBlackTreeNode<int, string>(47, "G");

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
            D.RightChild = F;

            E.Parent = D;
            E.LeftChild = null;
            E.RightChild = null;

            F.Parent = D;
            F.LeftChild = null;
            F.RightChild = G;

            G.Parent = F;
            G.LeftChild = null;
            G.RightChild = null;

            RedBlackTreeTests.HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();
            Assert.IsTrue(A.GetGrandParent() == null);
            Assert.IsTrue(B.GetGrandParent() == null);
            Assert.IsTrue(C.GetGrandParent().Equals(A));
            Assert.IsTrue(D.GetGrandParent().Equals(A));
            Assert.IsTrue(E.GetGrandParent().Equals(B));
            Assert.IsTrue(F.GetGrandParent().Equals(B));
            Assert.IsTrue(G.GetGrandParent().Equals(D));
        }

        [TestMethod]
        public void RedBlackTree_IsLeftChild_Test_Failure()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(5, "A");
            RedBlackTreeNode<int, string> B = new RedBlackTreeNode<int, string>(10, "B");
            RedBlackTreeNode<int, string> C = new RedBlackTreeNode<int, string>(20, "C");

            A.Parent = null;
            A.LeftChild = null;
            A.RightChild = B;

            B.Parent = A;
            B.LeftChild = null;
            B.RightChild = C;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            RedBlackTreeTests.HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();
            Assert.IsFalse(A.IsLeftChild());
            Assert.IsFalse(B.IsLeftChild());
            Assert.IsFalse(C.IsLeftChild());
        }

        [TestMethod]
        public void RedBlackTree_IsLeftChild_Test_Success()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(10, "A");
            RedBlackTreeNode<int, string> B = new RedBlackTreeNode<int, string>(5, "B");
            RedBlackTreeNode<int, string> C = new RedBlackTreeNode<int, string>(2, "C");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = null;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = null;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            RedBlackTreeTests.HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsTrue(B.IsLeftChild());
            Assert.IsTrue(C.IsLeftChild());
        }

        [TestMethod]
        public void RedBlackTree_IsRightChild_Test_Success()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(5, "A");
            RedBlackTreeNode<int, string> B = new RedBlackTreeNode<int, string>(10, "B");
            RedBlackTreeNode<int, string> C = new RedBlackTreeNode<int, string>(20, "C");

            A.Parent = null;
            A.LeftChild = null;
            A.RightChild = B;

            B.Parent = A;
            B.LeftChild = null;
            B.RightChild = C;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            RedBlackTreeTests.HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsTrue(B.IsRightChild());
            Assert.IsTrue(C.IsRightChild());
        }

        [TestMethod]
        public void RedBlackTree_IsRightChild_Test_Failure()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(10, "A");
            RedBlackTreeNode<int, string> B = new RedBlackTreeNode<int, string>(5, "B");
            RedBlackTreeNode<int, string> C = new RedBlackTreeNode<int, string>(2, "C");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = null;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = null;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            RedBlackTreeTests.HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsFalse(A.IsRightChild());
            Assert.IsFalse(B.IsRightChild());
            Assert.IsFalse(C.IsRightChild());
        }

        [TestMethod]
        public void RedBlackTree_IsRoot_Test()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(10, "A");
            RedBlackTreeNode<int, string> B = new RedBlackTreeNode<int, string>(5, "B");
            RedBlackTreeNode<int, string> C = new RedBlackTreeNode<int, string>(2, "C");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = null;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = null;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            RedBlackTreeTests.HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsTrue(A.IsRoot());
            Assert.IsFalse(B.IsRoot());
            Assert.IsFalse(C.IsRoot());
        }

        [TestMethod]
        public void RedBlackTree_FlipColor_Test()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(2, "A", Color.Red);
            Assert.AreEqual(Color.Red, A.Color);

            var tree = new RedBlackTree<int, string>();

            A.FlipColor();
            Assert.AreEqual(Color.Black, A.Color);
            A.FlipColor();
            Assert.AreEqual(Color.Red, A.Color);
        }

        [TestMethod]
        public void RedBlackTree_FormsLine_Test()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(50, "A");
            RedBlackTreeNode<int, string> B = new RedBlackTreeNode<int, string>(30, "B");
            RedBlackTreeNode<int, string> C = new RedBlackTreeNode<int, string>(20, "C");
            RedBlackTreeNode<int, string> D = new RedBlackTreeNode<int, string>(40, "D");
            RedBlackTreeNode<int, string> E = new RedBlackTreeNode<int, string>(35, "E");
            RedBlackTreeNode<int, string> F = new RedBlackTreeNode<int, string>(45, "F");
            RedBlackTreeNode<int, string> G = new RedBlackTreeNode<int, string>(47, "G");
            RedBlackTreeNode<int, string> H = new RedBlackTreeNode<int, string>(25, "h");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = null;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = D;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = H;

            D.Parent = B;
            D.LeftChild = E;
            D.RightChild = F;

            E.Parent = D;
            E.LeftChild = null;
            E.RightChild = null;

            F.Parent = D;
            F.LeftChild = null;
            F.RightChild = G;

            G.Parent = F;
            G.LeftChild = null;
            G.RightChild = null;

            H.Parent = C;
            H.LeftChild = null;
            H.RightChild = null;

            RedBlackTreeTests.HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsFalse(A.FormsLine());
            Assert.IsFalse(B.FormsLine());
            Assert.IsTrue(C.FormsLine());
            Assert.IsFalse(D.FormsLine());
            Assert.IsFalse(E.FormsLine());
            Assert.IsTrue(F.FormsLine());
            Assert.IsTrue(G.FormsLine());
            Assert.IsFalse(H.FormsLine());
        }

        [TestMethod]
        public void RedBlackTree_FormsTriangle_Test()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(50, "A");
            RedBlackTreeNode<int, string> B = new RedBlackTreeNode<int, string>(30, "B");
            RedBlackTreeNode<int, string> C = new RedBlackTreeNode<int, string>(20, "C");
            RedBlackTreeNode<int, string> D = new RedBlackTreeNode<int, string>(40, "D");
            RedBlackTreeNode<int, string> E = new RedBlackTreeNode<int, string>(35, "E");
            RedBlackTreeNode<int, string> F = new RedBlackTreeNode<int, string>(45, "F");
            RedBlackTreeNode<int, string> G = new RedBlackTreeNode<int, string>(47, "G");
            RedBlackTreeNode<int, string> H = new RedBlackTreeNode<int, string>(25, "h");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = null;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = D;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = H;

            D.Parent = B;
            D.LeftChild = E;
            D.RightChild = F;

            E.Parent = D;
            E.LeftChild = null;
            E.RightChild = null;

            F.Parent = D;
            F.LeftChild = null;
            F.RightChild = G;

            G.Parent = F;
            G.LeftChild = null;
            G.RightChild = null;

            H.Parent = C;
            H.LeftChild = null;
            H.RightChild = null;

            RedBlackTreeTests.HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsFalse(A.FormsTriangle());
            Assert.IsFalse(B.FormsTriangle());
            Assert.IsFalse(C.FormsTriangle());
            Assert.IsTrue(D.FormsTriangle());
            Assert.IsTrue(E.FormsTriangle());
            Assert.IsFalse(F.FormsTriangle());
            Assert.IsFalse(G.FormsTriangle());
            Assert.IsTrue(H.FormsTriangle());
        }

        [TestMethod]
        public void RedBlackTree_GetSibling_Test()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(10, "A");
            RedBlackTreeNode<int, string> B = new RedBlackTreeNode<int, string>(5, "B");
            RedBlackTreeNode<int, string> C = new RedBlackTreeNode<int, string>(20, "C");
            RedBlackTreeNode<int, string> D = new RedBlackTreeNode<int, string>(30, "D");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = C;

            B.Parent = A;
            B.LeftChild = null;
            B.RightChild = null;

            C.Parent = A;
            C.LeftChild = null;
            C.RightChild = D;

            D.Parent = C;
            D.LeftChild = null;
            D.RightChild = null;

            RedBlackTreeTests.HasBinarySearchTreeOrderProperty(A);

            var tree = new RedBlackTree<int, string>();

            Assert.IsTrue(A.GetSibling() == null);
            Assert.IsTrue(B.GetSibling().Equals(C));
            Assert.IsTrue(C.GetSibling().Equals(B));
            Assert.IsTrue(D.GetSibling() == null);
        }
    }
}
