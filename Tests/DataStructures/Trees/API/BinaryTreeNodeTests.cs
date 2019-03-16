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

// TODO: Make tests in one test file to use the init and just it 

namespace CSFundamentalsTests.DataStructures.Trees.API
{
    [TestClass]
    public class BinaryTreeNodeTests
    {
        private MockBinaryTreeNode<int, string> _root = null;

        [TestInitialize]
        public void Init()
        {
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(30, "B");
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(47, "A");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(50, "C");
            MockBinaryTreeNode<int, string> D = new MockBinaryTreeNode<int, string>(20, "D");
            MockBinaryTreeNode<int, string> E = new MockBinaryTreeNode<int, string>(40, "E");
            MockBinaryTreeNode<int, string> F = new MockBinaryTreeNode<int, string>(35, "F");
            MockBinaryTreeNode<int, string> G = new MockBinaryTreeNode<int, string>(45, "G");

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
        public void BinaryTreeNode_IsLeftChild_Test_Failure()
        {
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(5, "A");
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(10, "B");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(20, "C");

            A.Parent = null;
            A.LeftChild = null;
            A.RightChild = B;

            B.Parent = A;
            B.LeftChild = null;
            B.RightChild = C;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            Assert.IsFalse(A.IsLeftChild());
            Assert.IsFalse(B.IsLeftChild());
            Assert.IsFalse(C.IsLeftChild());
        }

        [TestMethod]
        public void BinaryTreeNode_IsLeftChild_Test_Success()
        {
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(10, "A");
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(5, "B");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(2, "C");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = null;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = null;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            Assert.IsTrue(B.IsLeftChild());
            Assert.IsTrue(C.IsLeftChild());
        }

        [TestMethod]
        public void BinaryTreeNode_IsRightChild_Test_Success()
        {
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(5, "A");
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(10, "B");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(20, "C");

            A.Parent = null;
            A.LeftChild = null;
            A.RightChild = B;

            B.Parent = A;
            B.LeftChild = null;
            B.RightChild = C;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            Assert.IsTrue(B.IsRightChild());
            Assert.IsTrue(C.IsRightChild());
        }

        [TestMethod]
        public void BinaryTreeNode_IsRightChild_Test_Failure()
        {
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(10, "A");
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(5, "B");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(2, "C");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = null;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = null;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            Assert.IsFalse(A.IsRightChild());
            Assert.IsFalse(B.IsRightChild());
            Assert.IsFalse(C.IsRightChild());
        }

        [TestMethod]
        public void BinaryTreeNode_IsRoot_Test()
        {
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(10, "A");
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(5, "B");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(2, "C");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = null;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = null;

            C.Parent = B;
            C.LeftChild = null;
            C.RightChild = null;

            Assert.IsTrue(A.IsRoot());
            Assert.IsFalse(B.IsRoot());
            Assert.IsFalse(C.IsRoot());
        }

        [TestMethod]
        public void BinaryTreeNode_GetSibling_Test()
        {
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(10, "A");
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(5, "B");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(20, "C");
            MockBinaryTreeNode<int, string> D = new MockBinaryTreeNode<int, string>(30, "D");

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

            Assert.IsTrue(A.GetSibling() == null);
            Assert.IsTrue(B.GetSibling().Equals(C));
            Assert.IsTrue(C.GetSibling().Equals(B));
            Assert.IsTrue(D.GetSibling() == null);
        }

        [TestMethod]
        public void BinaryTreeNode_GetUncle_Test()
        {
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(8, "A");
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(2, "B");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(10, "C");
            MockBinaryTreeNode<int, string> D = new MockBinaryTreeNode<int, string>(9, "D");

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

            Assert.IsTrue(A.GetUncle() == null);
            Assert.IsTrue(B.GetUncle() == null);
            Assert.IsTrue(C.GetUncle() == null);
            Assert.IsTrue(D.GetUncle().Equals(B));
        }

        [TestMethod]
        public void BinaryTreeNode_GetGrandParent_Test()
        {
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(50, "A");
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(30, "B");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(20, "C");
            MockBinaryTreeNode<int, string> D = new MockBinaryTreeNode<int, string>(40, "D");
            MockBinaryTreeNode<int, string> E = new MockBinaryTreeNode<int, string>(35, "E");
            MockBinaryTreeNode<int, string> F = new MockBinaryTreeNode<int, string>(45, "F");
            MockBinaryTreeNode<int, string> G = new MockBinaryTreeNode<int, string>(47, "G");

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

            Assert.IsTrue(A.GetGrandParent() == null);
            Assert.IsTrue(B.GetGrandParent() == null);
            Assert.IsTrue(C.GetGrandParent().Equals(A));
            Assert.IsTrue(D.GetGrandParent().Equals(A));
            Assert.IsTrue(E.GetGrandParent().Equals(B));
            Assert.IsTrue(F.GetGrandParent().Equals(B));
            Assert.IsTrue(G.GetGrandParent().Equals(D));
        }

        [TestMethod]
        public void BinaryTreeNode_IsLeaf_Test()
        {
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(50, "A");
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(20, "B");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(10, "C");
            MockBinaryTreeNode<int, string> D = new MockBinaryTreeNode<int, string>(40, "D");
            MockBinaryTreeNode<int, string> E = new MockBinaryTreeNode<int, string>(30, "E");

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

            Assert.IsFalse(A.IsLeaf());
            Assert.IsFalse(B.IsLeaf());
            Assert.IsTrue(C.IsLeaf());
            Assert.IsFalse(D.IsLeaf());
            Assert.IsTrue(E.IsLeaf());
        }

        [TestMethod]
        public void BinaryTreeNode_FormsLine_Test()
        {
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(50, "A");
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(30, "B");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(20, "C");
            MockBinaryTreeNode<int, string> D = new MockBinaryTreeNode<int, string>(40, "D");
            MockBinaryTreeNode<int, string> E = new MockBinaryTreeNode<int, string>(35, "E");
            MockBinaryTreeNode<int, string> F = new MockBinaryTreeNode<int, string>(45, "F");
            MockBinaryTreeNode<int, string> G = new MockBinaryTreeNode<int, string>(47, "G");
            MockBinaryTreeNode<int, string> H = new MockBinaryTreeNode<int, string>(25, "h");

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
        public void BinaryTreeNode_FormsTriangle_Test()
        {
            MockBinaryTreeNode<int, string> A = new MockBinaryTreeNode<int, string>(50, "A");
            MockBinaryTreeNode<int, string> B = new MockBinaryTreeNode<int, string>(30, "B");
            MockBinaryTreeNode<int, string> C = new MockBinaryTreeNode<int, string>(20, "C");
            MockBinaryTreeNode<int, string> D = new MockBinaryTreeNode<int, string>(40, "D");
            MockBinaryTreeNode<int, string> E = new MockBinaryTreeNode<int, string>(35, "E");
            MockBinaryTreeNode<int, string> F = new MockBinaryTreeNode<int, string>(45, "F");
            MockBinaryTreeNode<int, string> G = new MockBinaryTreeNode<int, string>(47, "G");
            MockBinaryTreeNode<int, string> H = new MockBinaryTreeNode<int, string>(25, "h");

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
