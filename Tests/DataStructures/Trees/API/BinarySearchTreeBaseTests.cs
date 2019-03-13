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

using CSFundamentals.DataStructures.Trees.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CSFundamentalsTests.DataStructures.Trees.API
{
    [TestClass]
    public class BinarySearchTreeBaseTests
    {
        private MockTreeNode<int, string> _root;
        private MockBinarySearchTreeBase<int, string> _tree;

        [TestInitialize]
        public void Init()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(40, "str3");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(20, "str1");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(70, "str6");
            MockTreeNode<int, string> D = new MockTreeNode<int, string>(50, "str4");
            MockTreeNode<int, string> E = new MockTreeNode<int, string>(80, "str7");
            MockTreeNode<int, string> F = new MockTreeNode<int, string>(30, "str2");
            MockTreeNode<int, string> G = new MockTreeNode<int, string>(60, "str5");

            A.Parent = null;
            A.LeftChild = B;
            A.RightChild = C;

            B.Parent = A;
            B.LeftChild = null;
            B.RightChild = F;

            C.Parent = A;
            C.LeftChild = D;
            C.RightChild = E;

            D.Parent = C;
            D.LeftChild = null;
            D.RightChild = G;

            E.Parent = C;
            E.LeftChild = null;
            E.RightChild = null;

            F.Parent = B;
            F.LeftChild = null;
            F.RightChild = null;

            G.Parent = D;
            G.LeftChild = null;
            G.RightChild = null;

            _tree = new MockBinarySearchTreeBase<int, string>();
            _root = A;
        }

        [TestMethod]
        public void BinarySearchTreeBase_RotateLeft_Test()
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

            HasBinarySearchTreeOrderProperty<MockTreeNode<int, string>, int, string>(A);
            var tree = new MockBinarySearchTreeBase<int, string>();
            tree.RotateLeft(B);
            HasBinarySearchTreeOrderProperty<MockTreeNode<int, string>, int, string>(A);

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
        public void BinarySearchTreeBase_RotateRight_Test()
        {
            MockTreeNode<int, string> A = new MockTreeNode<int, string>(30, "A");
            MockTreeNode<int, string> B = new MockTreeNode<int, string>(70, "B");
            MockTreeNode<int, string> C = new MockTreeNode<int, string>(50, "C");
            MockTreeNode<int, string> D = new MockTreeNode<int, string>(80, "D");
            MockTreeNode<int, string> E = new MockTreeNode<int, string>(40, "E");
            MockTreeNode<int, string> F = new MockTreeNode<int, string>(60, "F");
            MockTreeNode<int, string> G = new MockTreeNode<int, string>(35, "G");

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

            HasBinarySearchTreeOrderProperty<MockTreeNode<int, string>, int, string>(A);
            var tree = new MockBinarySearchTreeBase<int, string>();
            tree.RotateRight(B);
            HasBinarySearchTreeOrderProperty<MockTreeNode<int, string>, int, string>(A);

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
        public void BinarySearchTreeBase_Search_Test_Success()
        {
            Assert.AreEqual("str5", _tree.Search(_root, 60).Value, ignoreCase: false);
            Assert.AreEqual("str2", _tree.Search(_root, 30).Value, ignoreCase: false);
            Assert.AreEqual("str7", _tree.Search(_root, 80).Value, ignoreCase: false);
            Assert.AreEqual("str4", _tree.Search(_root, 50).Value, ignoreCase: false);
            Assert.AreEqual("str6", _tree.Search(_root, 70).Value, ignoreCase: false);
            Assert.AreEqual("str1", _tree.Search(_root, 20).Value, ignoreCase: false);
            Assert.AreEqual("str3", _tree.Search(_root, 40).Value, ignoreCase: false);
        }

        [TestMethod]
        public void BinarySearchTreeBase_Search_Test_Failure()
        {
            Assert.IsNull(_tree.Search(_root, 45));
            Assert.IsNull(_tree.Search(null, 30));
        }

        [TestMethod]
        public void BinarySearchTreeBase_Update_Test_Success()
        {
            Assert.IsTrue(_tree.Update(_root, 40, "string3"));

            Assert.IsTrue(_tree.Update(_root, 70, "string6"));
        }

        [TestMethod]
        public void BinarySearchTreeBase_Update_Test_Failue()
        {
            /* Testing the case where root is null. */
            Assert.IsFalse(_tree.Update(null, 40, "string3"));

            /* Testing the case where key does not exist in tree. */
            Assert.IsFalse(_tree.Update(_root, 45, "string3"));
        }

        [TestMethod]
        public void BinarySearchTreeBase_FindMin_Test_Success()
        {
            Assert.AreEqual("str1", _tree.FindMin(_root).Value);
            Assert.AreEqual("str1", _tree.FindMin(_root.LeftChild).Value);
            Assert.AreEqual("str2", _tree.FindMin(_root.LeftChild.RightChild).Value);
            Assert.AreEqual("str4", _tree.FindMin(_root.RightChild).Value);
            Assert.AreEqual("str4", _tree.FindMin(_root.RightChild.LeftChild).Value);
            Assert.AreEqual("str7", _tree.FindMin(_root.RightChild.RightChild).Value);
            Assert.AreEqual("str5", _tree.FindMin(_root.RightChild.LeftChild.RightChild).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchTreeBase_FindMin_Test_Failure()
        {
            _tree.FindMin(null);
        }

        [TestMethod]
        public void BinarySearchTreeBase_FindMax_Test_Success()
        {
            Assert.AreEqual("str7", _tree.FindMax(_root).Value);
            Assert.AreEqual("str2", _tree.FindMax(_root.LeftChild).Value);
            Assert.AreEqual("str2", _tree.FindMax(_root.LeftChild.RightChild).Value);
            Assert.AreEqual("str7", _tree.FindMax(_root.RightChild).Value);
            Assert.AreEqual("str5", _tree.FindMax(_root.RightChild.LeftChild).Value);
            Assert.AreEqual("str7", _tree.FindMax(_root.RightChild.RightChild).Value);
            Assert.AreEqual("str5", _tree.FindMax(_root.RightChild.LeftChild.RightChild).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchTreeBase_FindMax_Test_Failure()
        {
            _tree.FindMax(null);
        }

        [TestMethod]
        public void BinarySearchTreeBase_Insert_WithoutBalancing_Test()
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

            var tree = new MockBinarySearchTreeBase<int, string>();
            MockTreeNode<int, string> root = null;

            root = tree.Insert_BST(root, new MockTreeNode<int, string>(40, "str3"));
            root = tree.Insert_BST(root, new MockTreeNode<int, string>(20, "str1"));
            root = tree.Insert_BST(root, new MockTreeNode<int, string>(70, "str6"));
            root = tree.Insert_BST(root, new MockTreeNode<int, string>(50, "str4"));
            root = tree.Insert_BST(root, new MockTreeNode<int, string>(80, "str7"));
            root = tree.Insert_BST(root, new MockTreeNode<int, string>(30, "str2"));
            root = tree.Insert_BST(root, new MockTreeNode<int, string>(60, "str5"));

            HasBinarySearchTreeOrderProperty<MockTreeNode<int, string>, int, string>(root);

            List<MockTreeNode<int, string>> nodes = new List<MockTreeNode<int, string>>();
            _tree.InOrderTraversal(root, nodes);
            Assert.AreEqual(7, nodes.Count);
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                Assert.IsTrue(nodes[i].Key < nodes[i + 1].Key);
            }

            Assert.AreEqual(40, root.Key);
            Assert.AreEqual("str3", root.Value, ignoreCase: false);
        }

        [TestMethod]
        public void BinarySearchTreeBase_InOrderTraversal_Test()
        {
            var inOrderTraversal = new List<MockTreeNode<int, string>>();
            _tree.InOrderTraversal(_root, inOrderTraversal);
            Assert.AreEqual(7, inOrderTraversal.Count);
            for (int i = 0; i < inOrderTraversal.Count - 1; i++)
            {
                Assert.IsTrue(inOrderTraversal[i].Key < inOrderTraversal[i + 1].Key);
            }
        }

        [TestMethod]
        public void BinarySearchTreeBase_GetAllPathToNullLeaves_Test()
        {
            List<List<MockTreeNode<int, string>>> pathsFromRoot = _tree.GetAllPathToNullLeaves(_root);
            Assert.AreEqual(3, pathsFromRoot.Count);
            Assert.AreEqual(3, pathsFromRoot[0].Count);
            Assert.AreEqual(4, pathsFromRoot[1].Count);
            Assert.AreEqual(3, pathsFromRoot[2].Count);
        }

        // TODO: This code is repeated between here and binary search tree: remove duplicates
        /// <summary>
        /// Given the root of a binary search tree, checks whether the binary search tree properties hold.
        /// </summary>
        /// <typeparam name="T1">Specifies the type of the keys in tree. </typeparam>
        /// <typeparam name="T2">Specifies the type of the values in tree nodes. </typeparam>
        /// <param name="root">Is the root of a binary search tree. </param>
        public static void HasBinarySearchTreeOrderProperty<T, T1, T2>(T root) where T : ITreeNode<T, T1, T2> where T1 : IComparable<T1>, IEquatable<T1>
        {
            if (root != null)
            {
                if (root.LeftChild != null)
                {
                    Assert.IsTrue(root.Key.CompareTo(root.LeftChild.Key) > 0);
                    HasBinarySearchTreeOrderProperty<T, T1, T2>(root.LeftChild);
                }
                if (root.RightChild != null)
                {
                    Assert.IsTrue(root.Key.CompareTo(root.RightChild.Key) < 0);
                    HasBinarySearchTreeOrderProperty<T, T1, T2>(root.RightChild);
                }
            }
        }
    }
}
