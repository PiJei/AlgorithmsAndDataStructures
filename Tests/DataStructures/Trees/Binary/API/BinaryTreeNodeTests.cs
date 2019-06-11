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
using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.Trees.Binary.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO: Make tests in one test file to use the init and just it 

namespace AlgorithmsAndDataStructuresTests.DataStructures.Trees.Binary.API
{
    /// <summary>
    /// Tests methods in <see cref="BinaryTreeNode{TNode, TKey, TValue}"/> using <see cref="MockBinaryTreeNode{TKey, TValue}"/> class. 
    /// </summary>
    [TestClass]
    public class BinaryTreeNodeTests
    {
        private MockBinaryTreeNode<int, string> _root = null;

        /// <summary>
        /// Initializes/Resets variables before executing each unit test in this class. 
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            var B = new MockBinaryTreeNode<int, string>(30, "B");
            var A = new MockBinaryTreeNode<int, string>(47, "A");
            var C = new MockBinaryTreeNode<int, string>(50, "C");
            var D = new MockBinaryTreeNode<int, string>(20, "D");
            var E = new MockBinaryTreeNode<int, string>(40, "E");
            var F = new MockBinaryTreeNode<int, string>(35, "F");
            var G = new MockBinaryTreeNode<int, string>(45, "G");

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

        /// <summary>
        /// Tests the correctness of detecting whether a node is the left child of its parent, when it is not. 
        /// </summary>
        [TestMethod]
        public void IsLeftChild_Failure()
        {
            var A = new MockBinaryTreeNode<int, string>(5, "A");
            var B = new MockBinaryTreeNode<int, string>(10, "B");
            var C = new MockBinaryTreeNode<int, string>(20, "C");

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

        /// <summary>
        /// Tests the correctness of detecting whether a node is the left child of its parent, when it is. 
        /// </summary>
        [TestMethod]
        public void IsLeftChild_Success()
        {
            var A = new MockBinaryTreeNode<int, string>(10, "A");
            var B = new MockBinaryTreeNode<int, string>(5, "B");
            var C = new MockBinaryTreeNode<int, string>(2, "C");

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

        /// <summary>
        /// Tests the correctness of detecting whether a node is the right child of its parent, when it is. 
        /// </summary>
        [TestMethod]
        public void IsRightChild_Success()
        {
            var A = new MockBinaryTreeNode<int, string>(5, "A");
            var B = new MockBinaryTreeNode<int, string>(10, "B");
            var C = new MockBinaryTreeNode<int, string>(20, "C");

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

        /// <summary>
        /// Tests the correctness of detecting whether a node is the right child of its parent, when it is not. 
        /// </summary>
        [TestMethod]
        public void IsRightChild_Failure()
        {
            var A = new MockBinaryTreeNode<int, string>(10, "A");
            var B = new MockBinaryTreeNode<int, string>(5, "B");
            var C = new MockBinaryTreeNode<int, string>(2, "C");

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

        /// <summary>
        /// Tests the correctness of detecting whether a node is root. 
        /// </summary>
        [TestMethod]
        public void IsRoot()
        {
            var A = new MockBinaryTreeNode<int, string>(10, "A");
            var B = new MockBinaryTreeNode<int, string>(5, "B");
            var C = new MockBinaryTreeNode<int, string>(2, "C");

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

        /// <summary>
        /// Tests the correctness of getting a node's sibling. 
        /// </summary>
        [TestMethod]
        public void GetSibling()
        {
            var A = new MockBinaryTreeNode<int, string>(10, "A");
            var B = new MockBinaryTreeNode<int, string>(5, "B");
            var C = new MockBinaryTreeNode<int, string>(20, "C");
            var D = new MockBinaryTreeNode<int, string>(30, "D");

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

        /// <summary>
        /// Tests the correctness of getting a node's uncle. 
        /// </summary>
        [TestMethod]
        public void GetUncle()
        {
            var A = new MockBinaryTreeNode<int, string>(8, "A");
            var B = new MockBinaryTreeNode<int, string>(2, "B");
            var C = new MockBinaryTreeNode<int, string>(10, "C");
            var D = new MockBinaryTreeNode<int, string>(9, "D");

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

        /// <summary>
        /// Tests the correctness of getting a node's grand parent.
        /// </summary>
        [TestMethod]
        public void GetGrandParent()
        {
            var A = new MockBinaryTreeNode<int, string>(50, "A");
            var B = new MockBinaryTreeNode<int, string>(30, "B");
            var C = new MockBinaryTreeNode<int, string>(20, "C");
            var D = new MockBinaryTreeNode<int, string>(40, "D");
            var E = new MockBinaryTreeNode<int, string>(35, "E");
            var F = new MockBinaryTreeNode<int, string>(45, "F");
            var G = new MockBinaryTreeNode<int, string>(47, "G");

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

        /// <summary>
        /// Tests the correctness of detecting whether a node is a leaf node. 
        /// </summary>
        [TestMethod]
        public void IsLeaf()
        {
            var A = new MockBinaryTreeNode<int, string>(50, "A");
            var B = new MockBinaryTreeNode<int, string>(20, "B");
            var C = new MockBinaryTreeNode<int, string>(10, "C");
            var D = new MockBinaryTreeNode<int, string>(40, "D");
            var E = new MockBinaryTreeNode<int, string>(30, "E");

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

        /// <summary>
        /// Tests the correctness of detecting whether a node forms a line with its parent and grand parent. 
        /// </summary>
        [TestMethod]
        public void FormsLine()
        {
            var A = new MockBinaryTreeNode<int, string>(50, "A");
            var B = new MockBinaryTreeNode<int, string>(30, "B");
            var C = new MockBinaryTreeNode<int, string>(20, "C");
            var D = new MockBinaryTreeNode<int, string>(40, "D");
            var E = new MockBinaryTreeNode<int, string>(35, "E");
            var F = new MockBinaryTreeNode<int, string>(45, "F");
            var G = new MockBinaryTreeNode<int, string>(47, "G");
            var H = new MockBinaryTreeNode<int, string>(25, "h");

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

        /// <summary>
        /// Tests the correctness of detecting whether a node forms a triangle with its parent and grand parent. 
        /// </summary>
        [TestMethod]
        public void FormsTriangle()
        {
            var A = new MockBinaryTreeNode<int, string>(50, "A");
            var B = new MockBinaryTreeNode<int, string>(30, "B");
            var C = new MockBinaryTreeNode<int, string>(20, "C");
            var D = new MockBinaryTreeNode<int, string>(40, "D");
            var E = new MockBinaryTreeNode<int, string>(35, "E");
            var F = new MockBinaryTreeNode<int, string>(45, "F");
            var G = new MockBinaryTreeNode<int, string>(47, "G");
            var H = new MockBinaryTreeNode<int, string>(25, "h");

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

        /// <summary>
        /// Tests the correctness of detecting whether a node is complete (meaning have left and right children).
        /// </summary>
        [TestMethod]
        public void IsComplete()
        {
            var node1 = new MockBinaryTreeNode<int, string>(10, "str1")
            {
                LeftChild = null,
                RightChild = null
            };

            Assert.IsFalse(node1.IsComplete());
            node1.LeftChild = new MockBinaryTreeNode<int, string>(5, "str2");

            Assert.IsFalse(node1.IsComplete());

            node1.RightChild = new MockBinaryTreeNode<int, string>(15, "str3");
            Assert.IsTrue(node1.IsComplete());
        }

        /// <summary>
        /// Tests the correctness of getting the list of children of a node. 
        /// </summary>
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

        /// <summary>
        /// Tests the correctness of getting the list of a grand children of a node. 
        /// </summary>
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
