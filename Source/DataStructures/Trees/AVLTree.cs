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
using System.Diagnostics.Contracts;
using CSFundamentals.DataStructures.Trees.API;
using CSFundamentals.Styling;

namespace CSFundamentals.DataStructures.Trees
{
    /// <summary>
    /// Implements an AVL tree. An AVL tree is a self balancing Binary Search Tree.
    /// Notice the differences in time complexity at worst case for various operations, compared to a basic binary search tree. 
    /// </summary>
    /// <typeparam name="T1">Specifies the type of the keys in the tree. </typeparam>
    /// <typeparam name="T2">Specifies the type of the values in the tree. </typeparam>
    public class AVLTree<T1, T2> : BinarySearchTreeBase<AVLTreeNode<T1, T2>, T1, T2> where T1 : IComparable<T1>
    {
        [TimeComplexity(Case.Best, "O(n)", When = "Every new node is inserted in the very first locations.")]
        [TimeComplexity(Case.Worst, "O(nLog(n))")]
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        [SpaceComplexity("O(n)")]
        public override AVLTreeNode<T1, T2> Build(List<AVLTreeNode<T1, T2>> nodes)
        {
            return Build_BST(nodes);
        }

        public override AVLTreeNode<T1, T2> Delete(AVLTreeNode<T1, T2> root, T1 key)
        {
            throw new NotImplementedException();
            //TODO
        }

        [TimeComplexity(Case.Best, "O(1)", When = "The tree is empty, and the first node is added.")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public override AVLTreeNode<T1, T2> Insert(AVLTreeNode<T1, T2> root, AVLTreeNode<T1, T2> newNode)
        {
            root = Insert_BST(root, newNode); /* First insert the node using normal BinarySearchInsert to preserve the ordering property. */
            var parent = newNode.Parent;
            var grandParent = newNode.GetGrandParent();

            while (grandParent != null && grandParent != null)
            {
                int grandParentBalance = ComputeBalanceFactor(grandParent);
                if (grandParentBalance > 1)
                {
                    if (newNode.FormsTriangle())
                    {
                        Contract.Assert(newNode.IsLeftChild());
                        RotateRight(parent);
                        RotateLeft(grandParent);
                    }
                    else if (newNode.FormsLine())
                    {
                        Contract.Assert(newNode.IsRightChild());
                        RotateLeft(grandParent);
                    }
                }
                else if (grandParentBalance < -1)
                {
                    if (newNode.FormsTriangle())
                    {
                        Contract.Assert(newNode.IsRightChild());
                        RotateLeft(parent);
                        RotateRight(grandParent);
                    }
                    else if (newNode.FormsLine())
                    {
                        Contract.Assert(newNode.IsLeftChild()); ;
                        RotateRight(grandParent);
                    }
                }
                else /* Expect this case be only repeated once, given the balance factor of any node that is kept controlled. */
                {
                    /* move one level upwards. */
                    newNode = parent;
                    parent = grandParent;
                    grandParent = grandParent.Parent;
                }
            }

            // Find the new root of the tree, as it might have changed during the operations. 
            root = newNode;
            while (root.Parent != null)
            {
                root = root.Parent;
            }
            return root;
        }

        /// <summary>
        /// Computes balance factor of a node. Which is the difference between the height of the left and right sub trees of the node.
        /// </summary>
        /// <param name="node">Is the node for which balance is computed.</param>
        /// <returns>the balance factor of the node. </returns>
        public int ComputeBalanceFactor(AVLTreeNode<T1, T2> node)
        {
            return (node.RightChild == null ? 0 : GetHeight(node.RightChild)) - (node.LeftChild == null ? 0 : GetHeight(node.LeftChild));
        }

        /// <summary>
        /// Computes the height of the tree rooted at the given node. The height of a node is the maximum path length to its leaf nodes.
        /// </summary>
        /// <param name="node">Is the node whose height is calculated.</param>
        /// <returns>The height of the tree rooted at the given node. </returns>
        public int GetHeight(AVLTreeNode<T1, T2> node)
        {
            List<List<AVLTreeNode<T1, T2>>> paths = GetAllPathToLeaves(node);
            int height = paths[0].Count;
            for (int i = 1; i < paths.Count; i++)
            {
                if (paths[i].Count > height)
                {
                    height = paths[i].Count;
                }
            }
            return height;
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public override AVLTreeNode<T1, T2> Search(AVLTreeNode<T1, T2> root, T1 key)
        {
            return Search_BST(root, key);
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public override bool Update(AVLTreeNode<T1, T2> root, T1 key, T2 value)
        {
            return Update_BST(root, key, value);
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public override AVLTreeNode<T1, T2> FindMin(AVLTreeNode<T1, T2> root)
        {
            return FindMin_BST(root);
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public override AVLTreeNode<T1, T2> FindMax(AVLTreeNode<T1, T2> root)
        {
            return FindMax_BST(root);
        }
    }
}
