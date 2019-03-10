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

using System;
using System.Collections.Generic;
using CSFundamentals.Styling;

namespace CSFundamentals.DataStructures.Trees
{
    public class TreesUtils
    {
        // TODO: Move this method to Algorithms/ graph traversal, and also make it more general node wise... 
        public static List<List<RedBlackTreeNode<int, string>>> GetAllPathToNullLeaves(RedBlackTreeNode<int, string> startNode)
        {
            if (startNode == null)
            {
                return new List<List<RedBlackTreeNode<int, string>>>();
            }

            List<List<RedBlackTreeNode<int, string>>> paths = new List<List<RedBlackTreeNode<int, string>>>();
            List<List<RedBlackTreeNode<int, string>>> leftPaths = GetAllPathToNullLeaves(startNode.LeftChild);
            List<List<RedBlackTreeNode<int, string>>> rightPaths = GetAllPathToNullLeaves(startNode.RightChild);

            for (int i = 0; i < leftPaths.Count; i++)
            {
                var newPath = new List<RedBlackTreeNode<int, string>>();
                newPath.Add(startNode);
                newPath.AddRange(leftPaths[i]);
                paths.Add(newPath);
            }
            for (int i = 0; i < rightPaths.Count; i++)
            {
                var newPath = new List<RedBlackTreeNode<int, string>>();
                newPath.Add(startNode);
                newPath.AddRange(rightPaths[i]);
                paths.Add(newPath);
            }

            if (paths.Count == 0)
            {
                paths.Add(new List<RedBlackTreeNode<int, string>> { startNode });
            }

            return paths;
        }
    }
}
