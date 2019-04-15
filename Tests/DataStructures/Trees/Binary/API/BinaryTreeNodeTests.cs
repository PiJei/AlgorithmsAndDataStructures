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

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO: Make tests in one test file to use the init and just it 

namespace CSFundamentalsTests.DataStructures.Trees.Binary.API
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
        public void IsLeftChild_Failure()
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
        public void IsLeftChild_Success()
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
        public void IsRightChild_Success()
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
        public void IsRightChild_Failure()
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
        public void IsRoot()
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
        public void GetSibling()
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
        public void GetUncle()
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
        public void GetGrandParent()
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
        public void IsLeaf()
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
        public void FormsLine()
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
        public void FormsTriangle()
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

        [TestMethod]
        public void IsComplete()
        {
            MockBinaryTreeNode<int, string> node1 = new MockBinaryTreeNode<int, string>(10, "str1");
            node1.LeftChild = null;
            node1.RightChild = null;

            Assert.IsFalse(node1.IsComplete());
            node1.LeftChild = new MockBinaryTreeNode<int, string>(5, "str2");

            Assert.IsFalse(node1.IsComplete());

            node1.RightChild = new MockBinaryTreeNode<int, string>(15, "str3");
            Assert.IsTrue(node1.IsComplete());
        }

        [TestMethod]
        public void GetChildren()
        {
            List<MockBinaryTreeNode<int, string>> rootChildren = _root.GetChildren();
            Assert.AreEqual(2, rootChildren.Count);
            Assert.AreEqual(rootChildren[0].Value, "B", ignoreCase: false);
            Assert.AreEqual(rootChildren[1].Value, "C", ignoreCase: false);

            List<MockBinaryTreeNode<int, string>> cChildren = _root.RightChild.GetChildren();
            Assert.AreEqual(0, cChildren.Count);

            List<MockBinaryTreeNode<int, string>> bChildren = _root.LeftChild.GetChildren();
            Assert.AreEqual(2, bChildren.Count);
            Assert.AreEqual(bChildren[0].Value, "D", ignoreCase: false);
            Assert.AreEqual(bChildren[1].Value, "E", ignoreCase: false);

            List<MockBinaryTreeNode<int, string>> dChildren = _root.LeftChild.LeftChild.GetChildren();
            Assert.AreEqual(0, dChildren.Count);

            List<MockBinaryTreeNode<int, string>> eChildren = _root.LeftChild.RightChild.GetChildren();
            Assert.AreEqual(2, eChildren.Count);
            Assert.AreEqual(eChildren[0].Value, "F", ignoreCase: false);
            Assert.AreEqual(eChildren[1].Value, "G", ignoreCase: false);

            List<MockBinaryTreeNode<int, string>> fChildren = _root.LeftChild.RightChild.LeftChild.GetChildren();
            Assert.AreEqual(0, fChildren.Count);

            List<MockBinaryTreeNode<int, string>> gChildren = _root.LeftChild.RightChild.RightChild.GetChildren();
            Assert.AreEqual(0, gChildren.Count);
        }

        [TestMethod]
        public void GetGrandChildren()
        {
            List<MockBinaryTreeNode<int, string>> rootGrandChildren = _root.GetGrandChildren();
            Assert.AreEqual(2, rootGrandChildren.Count);
            Assert.AreEqual(rootGrandChildren[0].Value, "D", ignoreCase: false);
            Assert.AreEqual(rootGrandChildren[1].Value, "E", ignoreCase: false);

            List<MockBinaryTreeNode<int, string>> cGrandChildren = _root.RightChild.GetGrandChildren();
            Assert.AreEqual(0, cGrandChildren.Count);

            List<MockBinaryTreeNode<int, string>> bGrandChildren = _root.LeftChild.GetGrandChildren();
            Assert.AreEqual(2, bGrandChildren.Count);
            Assert.AreEqual(bGrandChildren[0].Value, "F", ignoreCase: false);
            Assert.AreEqual(bGrandChildren[1].Value, "G", ignoreCase: false);

            List<MockBinaryTreeNode<int, string>> dGrandChildren = _root.LeftChild.LeftChild.GetGrandChildren();
            Assert.AreEqual(0, dGrandChildren.Count);

            List<MockBinaryTreeNode<int, string>> eGrandChildren = _root.LeftChild.RightChild.GetGrandChildren();
            Assert.AreEqual(0, eGrandChildren.Count);

            List<MockBinaryTreeNode<int, string>> fGrandChildren = _root.LeftChild.RightChild.LeftChild.GetGrandChildren();
            Assert.AreEqual(0, fGrandChildren.Count);

            List<MockBinaryTreeNode<int, string>> gGrandChildren = _root.LeftChild.RightChild.RightChild.GetGrandChildren();
            Assert.AreEqual(0, gGrandChildren.Count);
        }
    }
}
