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
 * along with CSFundamentalAlgorithms.  If not, see <http://www.gnu.org/licenses/>.
 */

// TODO: Implement UKKONEN's algorithm as well, which is on line. 
using System.Linq;

namespace CSFundamentalAlgorithms.StringDataStructures
{
    /// <summary>
    /// Implements a SuffixTree also known as a PAT. A DFS search of the tree should give the collection of all the suffixes of the string. 
    /// This implementation is Naive: not optimized. 
    /// </summary>
    [DataStructure("SuffixTree(aka. PAT)")]
    public class SuffixTree
    {
        public static SuffixTreeNode Build(string text)
        {
            /*Assuming text does not contain $, appending $. Without this, some suffixes will be implicit in the tree.  */
            string extendedText = text + "$";
            int n = extendedText.Length;

            SuffixTreeNode root = null;
            for (int i = n - 2; i >= 0; i--)
            {
                string suffix = extendedText.Substring(i);
                if (root == null)
                {
                    root = new SuffixTreeNode { IsRoot = true };
                    root.Children.Add(new SuffixTreeNode { IsLeaf = true, StringValue = suffix, StartIndex = i });
                }
                else
                {
                    Insert(root, suffix, i);
                }
            }

            return root;
        }

        public static void Insert(SuffixTreeNode root, string suffix, int startIndex)
        {
            SuffixTreeNode node = null;
            if (root.Children.Any(c => c.StringValue.StartsWith(suffix[0])))
            {
                node = root.Children.Where(c => c.StringValue.StartsWith(suffix[0]))?.ToList()?[0];
            }
            
            if (node == null)
            {
                var newNode = new SuffixTreeNode { IsLeaf = true, StringValue = suffix, StartIndex = startIndex };
                root.Children.Add(newNode);
                return;
            }

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
                    if (!node.Children.Any(c => c.StringValue.StartsWith(suffix[indexOverSuffix])))
                    {
                        var child = new SuffixTreeNode { IsLeaf = true, StringValue = suffix.Substring(indexOverSuffix), StartIndex = startIndex };
                        node.Children.Add(child);
                        break;
                    }
                    node = node.Children.Where(c => c.StringValue.StartsWith(suffix[indexOverSuffix]))?.ToList()[0];
                    indexOverSuffix++;
                }
            }
        }
    }
}
