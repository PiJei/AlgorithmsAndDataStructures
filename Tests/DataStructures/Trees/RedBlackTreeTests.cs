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
    public class RedBlackTreeTests
    {
        private RedBlackTree<int, string> _tree;
        private RedBlackTreeNode<int, string> _root;

        [TestInitialize]
        public void Init()
        {
            _tree = new RedBlackTree<int, string>();

            var keyVals = new Dictionary<int, string>
            {
                [40] = "D",
                [50] = "A",
                [47] = "G",
                [30] = "B",
                [20] = "C",
                [35] = "E",
                [45] = "F"
            };

            _root = _tree.Build(keyVals);
        }

        [TestMethod]
        public void RedBlackTree_Build_Test()
        {
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 7);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_1()
        {
            _root = _tree.Delete(_root, 47);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_2()
        {
            _root = _tree.Delete(_root, 30);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_3()
        {
            _root = _tree.Delete(_root, 50);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_4()
        {
            _root = _tree.Delete(_root, 20);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_5()
        {
            _root = _tree.Delete(_root, 40);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_6()
        {
            _root = _tree.Delete(_root, 35);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_7()
        {
            _root = _tree.Delete(_root, 45);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_8()
        {
            _root = _tree.Delete(_root, 15);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 7);
        }

        [TestMethod]
        public void RedBlackTree_Delete_Test_9()
        {
            _root = _tree.Delete(_root, 30);
            List<RedBlackTreeNode<int, string>> inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 6);

            _root = _tree.Delete(_root, 47);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 5);

            _root = _tree.Delete(_root, 20);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 4);

            _root = _tree.Delete(_root, 50);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 3);

            _root = _tree.Delete(_root, 35);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 2);

            _root = _tree.Delete(_root, 30);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 1);

            _root = _tree.Delete(_root, 40);
            inOrderTraversal = new List<RedBlackTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            HasRedBlackTreeProperties(_root, inOrderTraversal, 0);
        }


        [TestMethod]
        public void RedBlackTree_Insert_WithoutBalancing_Test()
        {
            var keyVals = new Dictionary<int, string>
            {
                [40] = "str3",
                [20] = "str1",
                [70] = "str6",
                [50] = "str4",
                [80] = "str7",
                [30] = "str2",
                [60] = "str5",
            };

            var tree = new RedBlackTree<int, string>();
            RedBlackTreeNode<int, string> root = null;

            root = tree.Insert_WithoutBalancing(root, new RedBlackTreeNode<int, string>(40, "str3", Color.Red));
            root = tree.Insert_WithoutBalancing(root, new RedBlackTreeNode<int, string>(20, "str1", Color.Red));
            root = tree.Insert_WithoutBalancing(root, new RedBlackTreeNode<int, string>(70, "str6", Color.Red));
            root = tree.Insert_WithoutBalancing(root, new RedBlackTreeNode<int, string>(50, "str4", Color.Red));
            root = tree.Insert_WithoutBalancing(root, new RedBlackTreeNode<int, string>(80, "str7", Color.Red));
            root = tree.Insert_WithoutBalancing(root, new RedBlackTreeNode<int, string>(30, "str2", Color.Red));
            root = tree.Insert_WithoutBalancing(root, new RedBlackTreeNode<int, string>(60, "str5", Color.Red));

            HasBinarySearchTreeOrderProperty(root);

            List<RedBlackTreeNode<int, string>> nodes = new List<RedBlackTreeNode<int, string>>();
            tree.InOrderTraversal(root, nodes);
            Assert.AreEqual(7, nodes.Count);
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                Assert.IsTrue(nodes[i].Key < nodes[i + 1].Key);
            }

            Assert.AreEqual(40, root.Key);
            Assert.AreEqual("str3", root.Value, ignoreCase: false);

        }

        [TestMethod]
        public void RedBlackTree_RotateLeft_Test()
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

            HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();
            tree.RotateLeft(B);
            HasBinarySearchTreeOrderProperty(A);

            Assert.IsTrue(A.Parent == null);
            Assert.IsTrue(A.LeftChild.Equals(D));
            Assert.IsTrue(A.RightChild == null);
            Assert.IsTrue(B.Parent.Equals(D));
            Assert.IsTrue(B.LeftChild.Equals(C));
            Assert.IsTrue(B.RightChild.Equals(E));
            Assert.IsTrue(C.Parent.Equals(B));
            Assert.IsTrue(C.LeftChild == null);
            Assert.IsTrue(C.RightChild == null);
            Assert.IsTrue(D.Parent.Equals(A));
            Assert.IsTrue(D.LeftChild.Equals(B));
            Assert.IsTrue(D.RightChild.Equals(F));
            Assert.IsTrue(E.Parent.Equals(B));
            Assert.IsTrue(E.LeftChild == null);
            Assert.IsTrue(E.RightChild == null);
            Assert.IsTrue(F.Parent.Equals(D));
            Assert.IsTrue(F.LeftChild == null);
            Assert.IsTrue(F.RightChild.Equals(G));
            Assert.IsTrue(G.Parent.Equals(F));
            Assert.IsTrue(G.LeftChild == null);
            Assert.IsTrue(G.RightChild == null);
        }

        [TestMethod]
        public void RedBlackTree_RotateRight_Test()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(30, "A");
            RedBlackTreeNode<int, string> B = new RedBlackTreeNode<int, string>(70, "B");
            RedBlackTreeNode<int, string> C = new RedBlackTreeNode<int, string>(50, "C");
            RedBlackTreeNode<int, string> D = new RedBlackTreeNode<int, string>(80, "D");
            RedBlackTreeNode<int, string> E = new RedBlackTreeNode<int, string>(40, "E");
            RedBlackTreeNode<int, string> F = new RedBlackTreeNode<int, string>(60, "F");
            RedBlackTreeNode<int, string> G = new RedBlackTreeNode<int, string>(35, "G");

            A.Parent = null;
            A.LeftChild = null;
            A.RightChild = B;

            B.Parent = A;
            B.LeftChild = C;
            B.RightChild = D;

            C.Parent = B;
            C.LeftChild = E;
            C.RightChild = F;

            D.Parent = B;
            D.LeftChild = null;
            D.RightChild = null;

            E.Parent = C;
            E.LeftChild = G;
            E.RightChild = null;

            F.Parent = C;
            F.LeftChild = null;
            F.RightChild = null;

            G.Parent = E;
            G.LeftChild = null;
            G.RightChild = null;

            HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();
            tree.RotateRight(B);
            HasBinarySearchTreeOrderProperty(A);

            Assert.IsTrue(A.Parent == null);
            Assert.IsTrue(A.LeftChild == null);
            Assert.IsTrue(A.RightChild.Equals(C));
            Assert.IsTrue(B.Parent.Equals(C));
            Assert.IsTrue(B.LeftChild.Equals(F));
            Assert.IsTrue(B.RightChild.Equals(D));
            Assert.IsTrue(C.Parent.Equals(A));
            Assert.IsTrue(C.LeftChild.Equals(E));
            Assert.IsTrue(C.RightChild.Equals(B));
            Assert.IsTrue(D.Parent.Equals(B));
            Assert.IsTrue(D.LeftChild == null);
            Assert.IsTrue(D.RightChild == null);
            Assert.IsTrue(E.Parent.Equals(C));
            Assert.IsTrue(E.LeftChild.Equals(G));
            Assert.IsTrue(E.RightChild == null);
            Assert.IsTrue(F.Parent.Equals(B));
            Assert.IsTrue(F.LeftChild == null);
            Assert.IsTrue(F.RightChild == null);
            Assert.IsTrue(G.Parent.Equals(E));
            Assert.IsTrue(G.LeftChild == null);
            Assert.IsTrue(G.RightChild == null);
        }

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

            HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();
            Assert.IsTrue(tree.GetUncle(A) == null);
            Assert.IsTrue(tree.GetUncle(B) == null);
            Assert.IsTrue(tree.GetUncle(C) == null);
            Assert.IsTrue(tree.GetUncle(D).Equals(B));
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

            HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();
            Assert.IsTrue(tree.GetGrandParent(A) == null);
            Assert.IsTrue(tree.GetGrandParent(B) == null);
            Assert.IsTrue(tree.GetGrandParent(C).Equals(A));
            Assert.IsTrue(tree.GetGrandParent(D).Equals(A));
            Assert.IsTrue(tree.GetGrandParent(E).Equals(B));
            Assert.IsTrue(tree.GetGrandParent(F).Equals(B));
            Assert.IsTrue(tree.GetGrandParent(G).Equals(D));
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

            HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();
            Assert.IsFalse(tree.IsLeftChild(A));
            Assert.IsFalse(tree.IsLeftChild(B));
            Assert.IsFalse(tree.IsLeftChild(C));
            Assert.IsFalse(tree.IsLeftChild(null));
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

            HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsTrue(tree.IsLeftChild(B));
            Assert.IsTrue(tree.IsLeftChild(C));
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

            HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsTrue(tree.IsRightChild(B));
            Assert.IsTrue(tree.IsRightChild(C));
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

            HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsFalse(tree.IsRightChild(A));
            Assert.IsFalse(tree.IsRightChild(B));
            Assert.IsFalse(tree.IsRightChild(C));
            Assert.IsFalse(tree.IsRightChild(null));
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

            HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsTrue(tree.IsRoot(A));
            Assert.IsFalse(tree.IsRoot(B));
            Assert.IsFalse(tree.IsRoot(C));
            Assert.IsFalse(tree.IsRoot(null));
        }

        [TestMethod]
        public void RedBlackTree_FlipColor_Test()
        {
            RedBlackTreeNode<int, string> A = new RedBlackTreeNode<int, string>(2, "A", Color.Red);
            Assert.AreEqual(Color.Red, A.Color);

            var tree = new RedBlackTree<int, string>();

            tree.FlipColor(A);
            Assert.AreEqual(Color.Black, A.Color);
            tree.FlipColor(A);
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

            HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsFalse(tree.FormsLine(A));
            Assert.IsFalse(tree.FormsLine(B));
            Assert.IsTrue(tree.FormsLine(C));
            Assert.IsFalse(tree.FormsLine(D));
            Assert.IsFalse(tree.FormsLine(E));
            Assert.IsTrue(tree.FormsLine(F));
            Assert.IsTrue(tree.FormsLine(G));
            Assert.IsFalse(tree.FormsLine(H));
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

            HasBinarySearchTreeOrderProperty(A);
            var tree = new RedBlackTree<int, string>();

            Assert.IsFalse(tree.FormsTriangle(A));
            Assert.IsFalse(tree.FormsTriangle(B));
            Assert.IsFalse(tree.FormsTriangle(C));
            Assert.IsTrue(tree.FormsTriangle(D));
            Assert.IsTrue(tree.FormsTriangle(E));
            Assert.IsFalse(tree.FormsTriangle(F));
            Assert.IsFalse(tree.FormsTriangle(G));
            Assert.IsTrue(tree.FormsTriangle(H));
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

            HasBinarySearchTreeOrderProperty(A);

            var tree = new RedBlackTree<int, string>();

            Assert.IsTrue(tree.GetSibling(A) == null);
            Assert.IsTrue(tree.GetSibling(B).Equals(C));
            Assert.IsTrue(tree.GetSibling(C).Equals(B));
            Assert.IsTrue(tree.GetSibling(D) == null);

        }

        //TODO: This code is repeated between here and binary search tree: remove duplicates
        /// <summary>
        /// Given the root of a binary search tree, checks whether the binary search tree properties hold.
        /// </summary>
        /// <typeparam name="T1">Specifies the type of the keys in tree. </typeparam>
        /// <typeparam name="T2">Specifies the type of the values in tree nodes. </typeparam>
        /// <param name="root">Is the root of a binary search tree. </param>
        private void HasBinarySearchTreeOrderProperty<T1, T2>(RedBlackTreeNode<T1, T2> root) where T1 : IComparable<T1>, IEquatable<T1>
        {
            if (root != null)
            {
                if (root.LeftChild != null)
                {
                    Assert.IsTrue(root.Key.CompareTo(root.LeftChild.Key) > 0);
                    HasBinarySearchTreeOrderProperty(root.LeftChild);
                }
                if (root.RightChild != null)
                {
                    Assert.IsTrue(root.Key.CompareTo(root.RightChild.Key) < 0);
                    HasBinarySearchTreeOrderProperty(root.RightChild);
                }
            }
        }

        private void HasRedBlackTreeProperties(RedBlackTreeNode<int, string> root, List<RedBlackTreeNode<int, string>> inOrderTraversal, int expectedNodeCount)
        {
            // Check order properties.
            HasBinarySearchTreeOrderProperty(root);

            //Check to make sure nodes are not orphaned in the insertion or deletion process. 
            Assert.AreEqual(expectedNodeCount, inOrderTraversal.Count);

            // Check color properties.
            Assert.IsTrue(root.Color == Color.Black);
            foreach (RedBlackTreeNode<int, string> node in inOrderTraversal)
            {
                Assert.IsTrue(node.Color == Color.Red || node.Color == Color.Black);

                if (node.Color == Color.Red)
                {
                    if (node.LeftChild != null)
                    {
                        Assert.AreEqual(Color.Black, node.LeftChild.Color);
                    }
                    if (node.RightChild != null)
                    {
                        Assert.AreEqual(Color.Black, node.RightChild.Color);
                    }

                    /* If node N is red, then its parent must be black. As otherwise its parent is red, and the children of a red parent should all be black, in our case node N, which we assumed is red. */
                    Assert.IsTrue(node.Parent.Color == Color.Black);
                }
            }
            // TODO 4- all paths from a node to its null (leaf) descendants contain the same number of black nodes. 
            // TODO 5- get the longest path, get the shortest path, assert is not more than twice.. shortest path might be all black nodes, and longest path would be alternating between red and black nodes
        }
    }
}
