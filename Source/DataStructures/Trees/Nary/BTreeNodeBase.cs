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

namespace CSFundamentals.DataStructures.Trees.Nary
{
    public abstract class BTreeNodeBase
    {
        /// <summary>
        /// Is the minimum number of keys in a B-tree internal/leaf node. (Notice that a root has no lower bound on the number of keys. Intuitively when the tree is just being built it might start with 1, and grow afterwards.)
        /// </summary>
        public int MinKeys { get; protected set; }

        /// <summary>
        /// Is the maximum number of keys in a B-tree internal/leaf/root node. This is often 2 times the MinKeys.
        /// </summary>
        public int MaxKeys { get; protected set; }

        /// <summary>
        /// Is the minimum number of branches/children a B-tree internal node can have. 
        /// </summary>
        public int MinBranchingDegree { get; protected set; }

        /// <summary>
        /// Is the maximum number of branches/children a B-tree internal or root node can have. Leaf nodes contain 0 children. 
        /// </summary>
        public int MaxBranchingDegree { get; protected set; }

        public BTreeNodeBase(int maxBranchingDegree)
        {
            Init(maxBranchingDegree);
        }

        /// <summary>
        /// Initializes the node.
        /// </summary>
        /// <param name="maxBranchingDegree">Is the maximum number of children the node can have. </param>
        private void Init(int maxBranchingDegree)
        {
            MaxBranchingDegree = maxBranchingDegree;
            MinBranchingDegree = Convert.ToInt32(Math.Ceiling(Math.Round(MaxBranchingDegree / (double)2, MidpointRounding.AwayFromZero)));
            MinKeys = MinBranchingDegree - 1;
            MaxKeys = MaxBranchingDegree - 1;
        }
    }
}
