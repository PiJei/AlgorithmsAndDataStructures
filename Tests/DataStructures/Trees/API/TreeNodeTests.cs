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
    public class TreeNodeTests
    {
        private MockTreeNode<int, string> _root = null;

        [TestInitialize]
        public void Init()
        {
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(30, "B");
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(47, "A");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(50, "C");
            MockTreeNode<int, string> D = new MockTreeNode<int, string>(20, "D");
            MockTreeNode<int, string> E = new MockTreeNode<int, string>(40, "E");
            MockTreeNode<int, string> F = new MockTreeNode<int, string>(35, "F");
            MockTreeNode<int, string> G = new MockTreeNode<int, string>(45, "G");

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
        public void TreeNode_IsLeftChild_Test_Failure()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(5, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(10, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(20, "C");

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
        public void TreeNode_IsLeftChild_Test_Success()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(10, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(5, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(2, "C");

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
        public void TreeNode_IsRightChild_Test_Success()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(5, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(10, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(20, "C");

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
        public void TreeNode_IsRightChild_Test_Failure()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(10, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(5, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(2, "C");

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
        public void TreeNode_IsRoot_Test()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(10, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(5, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(2, "C");

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
        public void TreeNode_GetSibling_Test()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(10, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(5, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(20, "C");
            MockTreeNode<int, string> D = new MockTreeNode<int, string>(30, "D");

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
        public void TreeNode_GetUncle_Test()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(8, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(2, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(10, "C");
            MockTreeNode<int, string> D = new MockTreeNode<int, string>(9, "D");

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
        public void TreeNode_GetGrandParent_Test()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(50, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(30, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(20, "C");
            MockTreeNode<int, string> D = new MockTreeNode<int, string>(40, "D");
            MockTreeNode<int, string> E = new MockTreeNode<int, string>(35, "E");
            MockTreeNode<int, string> F = new MockTreeNode<int, string>(45, "F");
            MockTreeNode<int, string> G = new MockTreeNode<int, string>(47, "G");

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
        public void TreeNode_IsLeaf_Test()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(50, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(20, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(10, "C");
            MockTreeNode<int, string> D = new MockTreeNode<int, string>(40, "D");
            MockTreeNode<int, string> E = new MockTreeNode<int, string>(30, "E");

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
        public void TreeNode_FormsLine_Test()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(50, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(30, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(20, "C");
            MockTreeNode<int, string> D = new MockTreeNode<int, string>(40, "D");
            MockTreeNode<int, string> E = new MockTreeNode<int, string>(35, "E");
            MockTreeNode<int, string> F = new MockTreeNode<int, string>(45, "F");
            MockTreeNode<int, string> G = new MockTreeNode<int, string>(47, "G");
            MockTreeNode<int, string> H = new MockTreeNode<int, string>(25, "h");

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
        public void TreeNode_FormsTriangle_Test()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(50, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(30, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(20, "C");
            MockTreeNode<int, string> D = new MockTreeNode<int, string>(40, "D");
            MockTreeNode<int, string> E = new MockTreeNode<int, string>(35, "E");
            MockTreeNode<int, string> F = new MockTreeNode<int, string>(45, "F");
            MockTreeNode<int, string> G = new MockTreeNode<int, string>(47, "G");
            MockTreeNode<int, string> H = new MockTreeNode<int, string>(25, "h");

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
