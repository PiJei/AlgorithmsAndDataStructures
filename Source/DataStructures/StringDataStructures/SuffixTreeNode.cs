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
using System.Collections.Generic;

// TODO: Can the class be modified to be usable by DFS and BFS?

namespace CSFundamentalAlgorithms.DataStructures.StringDataStructures
{
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
