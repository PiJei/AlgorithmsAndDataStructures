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

//TODO: Move most of these to binary tree node

namespace CSFundamentalsTests.DataStructures.Trees
{
    [TestClass]
    public class RedBlackTreeNodeTests
    {
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

            BinarySearchTreeTests.HasBinarySearchTreeOrderProperty<RedBlackTreeNode<int, string>, int, string>(A);
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

            BinarySearchTreeTests.HasBinarySearchTreeOrderProperty<RedBlackTreeNode<int, string>, int, string>(A);
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
    }
}
