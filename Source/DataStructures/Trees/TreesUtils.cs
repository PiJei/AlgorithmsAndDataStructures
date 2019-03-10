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

namespace CSFundamentals.DataStructures.Trees
{
    public class TreesUtils
    {
        // TODO: Move this method to Algorithms/ graph traversal, and also make it more general node wise... 
        public static List<List<RedBlackTreeNode<T1, T2>>> GetAllPathToNullLeaves<T1, T2>(RedBlackTreeNode<T1, T2> startNode) where T1:IComparable<T1>,IEquatable<T1>
        {
            if (startNode == null)
            {
                return new List<List<RedBlackTreeNode<T1, T2>>>();
            }

            List<List<RedBlackTreeNode<T1, T2>>> paths = new List<List<RedBlackTreeNode<T1, T2>>>();
            List<List<RedBlackTreeNode<T1, T2>>> leftPaths = GetAllPathToNullLeaves(startNode.LeftChild);
            List<List<RedBlackTreeNode<T1, T2>>> rightPaths = GetAllPathToNullLeaves(startNode.RightChild);

            for (int i = 0; i < leftPaths.Count; i++)
            {
                var newPath = new List<RedBlackTreeNode<T1, T2>>();
                newPath.Add(startNode);
                newPath.AddRange(leftPaths[i]);
                paths.Add(newPath);
            }
            for (int i = 0; i < rightPaths.Count; i++)
            {
                var newPath = new List<RedBlackTreeNode<T1, T2>>();
                newPath.Add(startNode);
                newPath.AddRange(rightPaths[i]);
                paths.Add(newPath);
            }

            if (paths.Count == 0)
            {
                paths.Add(new List<RedBlackTreeNode<T1, T2>> { startNode });
            }

            return paths;
        }
    }
}
