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
using CSFundamentals.DataStructures.Trees.Nary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.DataStructures.Trees.Nary
{
    [TestClass]
    public class _2_3_BPlusTreeTests
    {
        [TestMethod]
        public void Insert_SeveralKeys_ExpectsTreeToIncreaseInLevelsAfewTimes()
        {
            BPlusTree<int, string> tree = new BPlusTree<int, string>(3);
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 0, 0));

            tree.Insert(new KeyValuePair<int, string>(50, "A"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 1, 1));

            tree.Insert(new KeyValuePair<int, string>(10, "B"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 2, 1));

            tree.Insert(new KeyValuePair<int, string>(100, "C"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 3, 3));

            tree.Insert(new KeyValuePair<int, string>(200, "D"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 4, 3));

            tree.Insert(new KeyValuePair<int, string>(20, "E"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 5, 3));

            tree.Insert(new KeyValuePair<int, string>(300, "F"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 6, 4));

            tree.Insert(new KeyValuePair<int, string>(30, "G"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 7, 7));

            tree.Insert(new KeyValuePair<int, string>(500, "H"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 8, 7));

            tree.Insert(new KeyValuePair<int, string>(250, "I"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 9, 8));

            tree.Insert(new KeyValuePair<int, string>(400, "J"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 10, 8));

            tree.Insert(new KeyValuePair<int, string>(270, "K"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 11, 8));

            tree.Insert(new KeyValuePair<int, string>(600, "L"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 12, 10));

            tree.Insert(new KeyValuePair<int, string>(150, "M"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 13, 10));

            tree.Insert(new KeyValuePair<int, string>(80, "N"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 14, 11));

            tree.Insert(new KeyValuePair<int, string>(60, "O"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 15, 11));

            tree.Insert(new KeyValuePair<int, string>(90, "P"));
            Assert.IsTrue(BTreeTestsUtils<BPlusTreeNode<int, string>, int, string>.HasBPlusTreeProperties(tree, 16, 15));

            Assert.AreEqual(1, tree.Root.KeyCount);
            Assert.AreEqual(100, tree.Root.GetKeyValue(0).Key);
            Assert.AreEqual("C", tree.Root.GetKeyValue(0).Value, ignoreCase: true);
        }
    }
}
