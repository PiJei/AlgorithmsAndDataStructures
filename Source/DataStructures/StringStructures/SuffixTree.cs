#region copyright
/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of AlgorithmsAndDataStructures project.
 *
 * AlgorithmsAndDataStructures is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AlgorithmsAndDataStructures is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion

using System.Diagnostics.Contracts;
using System.Linq;
using AlgorithmsAndDataStructures.Decoration;

namespace AlgorithmsAndDataStructures.DataStructures.StringStructures
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
        /// <param name="text">The string for which the suffix tree is being built. </param>
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
        /// <param name="root">The root node of a suffix tree. </param>
        /// <param name="suffix">The suffix string that should be inserted in the suffix tree. </param>
        /// <param name="startIndex">The start index of the suffix in its container string. </param>
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
}
