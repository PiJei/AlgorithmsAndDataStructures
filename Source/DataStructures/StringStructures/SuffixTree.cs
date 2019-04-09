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

// TODO: As an alternative implement UKKONEN's algorithm as well, which is on line. 
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using CSFundamentals.Decoration;

namespace CSFundamentals.DataStructures.StringStructures
{
    /// <summary>
    /// Implements a SuffixTree also known as a PAT. A DFS search of the tree should give the collection of all the suffixes of the string. 
    /// This implementation is Naive: not optimized. 
    /// </summary>
    [DataStructure("SuffixTree(aka. PAT)")]
    public class SuffixTree
    {
        /// <summary>
        /// Given a string, builds its suffix tree. 
        /// </summary>
        /// <param name="text">Specifies the string for which the suffix tree is being built. </param>
        /// <returns>The root of the suffix tree. </returns>
        public static SuffixTreeNode Build(string text)
        {
            /*Assuming text does not contain $, appending $. Without this, some suffixes will be implicit in the tree.  */
            string extendedText = text + "$";
            int n = extendedText.Length;

            SuffixTreeNode root = null;
            for (int i = n - 2; i >= 0; i--) /* Start building the Suffix tree by the shortest suffix. For example in string 'data$', the shortest suffix is 'a$'.  */
            {
                string suffix = extendedText.Substring(i);
                if (root == null) /* If root is null, create a root node, and make the current suffix its only child. */
                {
                    root = new SuffixTreeNode { IsRoot = true };
                    root.Children.Add(new SuffixTreeNode { IsLeaf = true, StringValue = suffix, StartIndex = i });
                }
                else /* Otherwise traverse the tree starting from root to find the right position for the current suffix. */
                {
                    Insert(root, suffix, i);
                }
            }

            return root;
        }

        /// <summary>
        /// Inserts the given suffix in the tree. Notice that the suffix is not necessarily inserted as a while. On the traversal of the tree, the intermediate nodes that have common prefixes with these suffix, make the suffix to break down. 
        /// </summary>
        /// <param name="root">Specifies the root node of a suffix tree. </param>
        /// <param name="suffix">Specifies the suffix string that should be inserted in the suffix tree. </param>
        /// <param name="startIndex">Specifies the start index of the suffix in its container string. </param>
        public static void Insert(SuffixTreeNode root, string suffix, int startIndex)
        {
            SuffixTreeNode node = null;
            var nodes = root.Children.Where(c => c.StringValue.StartsWith(suffix[0])); /* Before creating a new branch in the tree, look for a branch of the root that has a common starting character with the current suffix. */
            if (!nodes.Any()) /* If no child of the root has a common starting character with suffix, create a new child. */
            {
                root.Children.Add(new SuffixTreeNode { IsLeaf = true, StringValue = suffix, StartIndex = startIndex });
                return;
            }

            Contract.Assert(nodes.ToList().Count == 1); /* It is expected that all the branches (children) of a node start with distinct characters. */
            node = nodes.ToList()?[0]; /* Take the only child that has the same starting character as the suffix and continue traversing down its children.  */
            int indexOverSuffix = 1;
            while (true)
            {
                int j = 1;
                while (j < node.StringValue.Length && indexOverSuffix < suffix.Length && node.StringValue[j] == suffix[indexOverSuffix])
                {
                    j++;
                    indexOverSuffix++;
                }
                if (j <= node.StringValue.Length - 1) /* This means node should be converted to a intermediate node, with two children, and new suffix string */
                {
                    var child1 = new SuffixTreeNode { IsLeaf = true, StringValue = node.StringValue.Substring(j), StartIndex = node.StartIndex };
                    var child2 = new SuffixTreeNode { IsLeaf = true, StringValue = suffix.Substring(indexOverSuffix), StartIndex = startIndex };
                    node.IsLeaf = false;
                    node.IsRoot = false;
                    node.IsIntermediate = true;
                    node.StartIndex = -1;
                    node.StringValue = node.StringValue.Substring(0, node.StringValue.Length - 1);
                    node.Children.Add(child1);
                    node.Children.Add(child2);
                    break;
                }
                else if (j == node.StringValue.Length && indexOverSuffix < suffix.Length)
                {
                    nodes = node.Children.Where(c => c.StringValue.StartsWith(suffix[indexOverSuffix]));
                    if (!nodes.Any())
                    {
                        node.Children.Add(new SuffixTreeNode { IsLeaf = true, StringValue = suffix.Substring(indexOverSuffix), StartIndex = startIndex });
                        break;
                    }

                    Contract.Assert(nodes.ToList().Count == 1); /* It is expected that all the branches (children) of a node start with distinct characters. */
                    node = nodes.ToList()[0];
                    indexOverSuffix++;
                }
            }
        }
    }


    // TODO: Can the class be modified to be usable by DFS and BFS?
    // Contract: All the nodes except the root node contain a value for Suffix String. That value is the edge value from the parent of the node to this node. 
    // Contract: Intermediate nodes' startIndex is set to -1
    public class SuffixTreeNode
    {
        /// <summary>
        /// Is the substring - Also considered an edge. 
        /// </summary>
        public string StringValue { get; set; } = string.Empty;

        /// <summary>
        /// Is the startIndex of the suffix
        /// </summary>
        public int StartIndex { get; set; } = -1;

        /// <summary>
        /// True if the suffix is a leaf node.
        /// </summary>
        public bool IsLeaf { get; set; } = false;

        /// <summary>
        /// True if the suffix is a root node. 
        /// If Root, then suffix string is empty. 
        /// </summary>
        public bool IsRoot { get; set; } = false;

        /// <summary>
        /// True if the node is an intermediate node. 
        /// Intermediate nodes' startIndex is set to -1
        /// </summary>
        public bool IsIntermediate { get; set; } = false;

        /// <summary>
        /// Is the list if the suffix Nodes that can be reached from the current node. 
        /// </summary>
        public List<SuffixTreeNode> Children { get; set; } = new List<SuffixTreeNode>();
    }
}
