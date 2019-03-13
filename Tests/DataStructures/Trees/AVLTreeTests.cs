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
using CSFundamentals.DataStructures.Trees.API;
using System;
using System.Collections.Generic;
using CSFundamentalsTests.DataStructures.Trees.API;

namespace CSFundamentalsTests.DataStructures.Trees
{
    [TestClass]
    public class AVLTreeTests
    {
        private AVLTreeNode<int, string> _root = null;
        private AVLTree<int, string> _tree = null;

        [TestInitialize]
        public void Init()
        {
            _tree = new AVLTree<int, string>();
        }

        [TestMethod]
        public void AVLTree_Insert_Test()
        {
            AVLTreeNode<int, string> E = new AVLTreeNode<int, string>(40, "E");
            _root = _tree.Insert(_root, E);
            HasAVLTreeProperties(_root);

            AVLTreeNode<int, string> C = new AVLTreeNode<int, string>(50, "C");
            _root = _tree.Insert(_root, C);
            HasAVLTreeProperties(_root);

            AVLTreeNode<int, string> A = new AVLTreeNode<int, string>(47, "A");
            _root = _tree.Insert(_root, A);
            HasAVLTreeProperties(_root);

            AVLTreeNode<int, string> G = new AVLTreeNode<int, string>(45, "G");
            _root = _tree.Insert(_root, G);
            HasAVLTreeProperties(_root);

            AVLTreeNode<int, string> D = new AVLTreeNode<int, string>(20, "D");
            _root = _tree.Insert(_root, D);
            HasAVLTreeProperties(_root);

            AVLTreeNode<int, string> F = new AVLTreeNode<int, string>(35, "F");
            _root = _tree.Insert(_root, F);
            HasAVLTreeProperties(_root);

            AVLTreeNode<int, string> B = new AVLTreeNode<int, string>(30, "B");
            _root = _tree.Insert(_root, B);
            HasAVLTreeProperties(_root);

            AVLTreeNode<int, string> H = new AVLTreeNode<int, string>(10, "H");
            _root = _tree.Insert(_root, H);
            HasAVLTreeProperties(_root);

            AVLTreeNode<int, string> I = new AVLTreeNode<int, string>(80, "I");
            _root = _tree.Insert(_root, I);
            HasAVLTreeProperties(_root);
        }

        [TestMethod]
        public void AVLTree_Build_Test()
        {
            List<AVLTreeNode<int, string>> nodes = new List<AVLTreeNode<int, string>>
            {
                new AVLTreeNode<int, string>(40, "E"),
                new AVLTreeNode<int, string>(50, "C"),
                new AVLTreeNode<int, string>(47, "A"),
                new AVLTreeNode<int, string>(45, "G"),
                new AVLTreeNode<int, string>(20, "D"),
                new AVLTreeNode<int, string>(35, "F"),
                new AVLTreeNode<int, string>(30, "B"),
                new AVLTreeNode<int, string>(10, "H"),
                new AVLTreeNode<int, string>(80, "I")
            };

            _root = _tree.Build(nodes);
            HasAVLTreeProperties(_root);
        }

        //TODO; Drop iequatable from all the tree stuff, and just use icomparable, ... 
        public void HasAVLTreeProperties<T1, T2>(AVLTreeNode<T1, T2> root) where T1 : IComparable<T1>, IEquatable<T1>
        {
            BinarySearchTreeBaseTests.HasBinarySearchTreeOrderProperty<AVLTreeNode<T1, T2>, T1, T2>(root);

            List<AVLTreeNode<T1, T2>> inOrderTraversal = new List<AVLTreeNode<T1, T2>>();
            BinarySearchTreeBase<AVLTreeNode<T1, T2>, T1, T2>.InOrderTraversal(root, inOrderTraversal);
            HasExpectedBalanceFactor(inOrderTraversal);
        }

        public void HasExpectedBalanceFactor<T1, T2>(List<AVLTreeNode<T1, T2>> nodes) where T1 : IComparable<T1>, IEquatable<T1>
        {
            foreach (AVLTreeNode<T1, T2> node in nodes)
            {
                int balanceFactor = node.ComputeBalanceFactor();
                Assert.IsTrue(balanceFactor >= -1 && balanceFactor <= 1);
            }
        }
    }
}
