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
        private BPlusTree<int, string> _tree = null;

        [TestInitialize]
        public void Init()
        {
            _tree = new BPlusTree<int, string>(3);
            Dictionary<int, string> keyValues = new Dictionary<int, string>
            {
                [50] = "A",
                [10] = "B",
                [100] = "C",
                [200] = "D",
                [20] = "E",
                [300] = "F",
                [30] = "G",
                [500] = "H",
                [250] = "I",
                [400] = "J",
                [270] = "K",
                [600] = "L",
                [150] = "M",
                [80] = "N",
                [60] = "O",
                [90] = "P"
            };
            _tree.Build(keyValues);
        }

        [TestMethod]
        public void Build_ExpectsACorrectBPlusTree()
        {
            BTreeTestsUtils.HasBPlusTreeProperties(_tree, 25, 16, 17);
        }

        [TestMethod]
        public void Insert_SeveralKeys_ExpectsTreeToIncreaseInLevelsAfewTimes()
        {
            BPlusTree<int, string> tree = new BPlusTree<int, string>(3);
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 0, 0, 0);

            tree.Insert(new KeyValuePair<int, string>(50, "A"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 2, 1, 2);

            tree.Insert(new KeyValuePair<int, string>(10, "B"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 3, 2, 2);

            tree.Insert(new KeyValuePair<int, string>(100, "C"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 4, 3, 3);

            tree.Insert(new KeyValuePair<int, string>(200, "D"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 5, 4, 3);

            tree.Insert(new KeyValuePair<int, string>(20, "E"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 7, 5, 4);

            tree.Insert(new KeyValuePair<int, string>(300, "F"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 9, 6, 7);

            tree.Insert(new KeyValuePair<int, string>(30, "G"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 10, 7, 7);

            tree.Insert(new KeyValuePair<int, string>(500, "H"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 11, 8, 7);

            tree.Insert(new KeyValuePair<int, string>(250, "I"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 13, 9, 8);

            tree.Insert(new KeyValuePair<int, string>(400, "J"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 14, 10, 8);

            tree.Insert(new KeyValuePair<int, string>(270, "K"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 16, 11, 10);

            tree.Insert(new KeyValuePair<int, string>(600, "L"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 18, 12, 11);

            tree.Insert(new KeyValuePair<int, string>(150, "M"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 20, 13, 12);

            tree.Insert(new KeyValuePair<int, string>(80, "N"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 22, 14, 16);

            tree.Insert(new KeyValuePair<int, string>(60, "O"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 24, 15, 17);

            tree.Insert(new KeyValuePair<int, string>(90, "P"));
            BTreeTestsUtils.HasBPlusTreeProperties(tree, 25, 16, 17);

            Assert.AreEqual(1, tree.Root.KeyCount);
            Assert.AreEqual(150, tree.Root.GetKeyValue(0).Key);
            Assert.AreEqual(default(string), tree.Root.GetKeyValue(0).Value, ignoreCase: true);
        }
    }
}
