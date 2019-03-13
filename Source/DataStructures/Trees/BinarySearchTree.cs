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
using CSFundamentals.DataStructures.Trees.API;
using CSFundamentals.Styling;

namespace CSFundamentals.DataStructures.Trees
{
    /// <summary>
    /// Implements a binary search tree, and its operations. In a binary search tree, each node's key is larger than its left child's key, and smaller than its right child's key.
    /// A binary Search Tree can be used as a key-value store. 
    /// </summary>
    /// <typeparam name="T1">Specifies the type of the key in tree nodes.</typeparam>
    /// <typeparam name="T2">Specifies the type of the value in tree nodes. </typeparam>
    [DataStructure("BinarySearchTree (aka BST)")]
    public class BinarySearchTreeBase<T1, T2> : BinarySearchTreeBase<BinarySearchTreeNode<T1, T2>, T1, T2> where T1 : IComparable<T1>, IEquatable<T1>
    {
        //TODO Compute best and worst case for build operation. 
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        [SpaceComplexity("O(n)")]
        public override BinarySearchTreeNode<T1, T2> Build(List<BinarySearchTreeNode<T1, T2>> nodes)
        {
            foreach (BinarySearchTreeNode<T1, T2> node in nodes)
            {
                _root = Insert(_root, node);
            }
            return _root;
        }

        [TimeComplexity(Case.Best, "O(1)", When = "The tree is empty, and the first node is added.")]
        [TimeComplexity(Case.Worst, "O(n)", When = "Tree is imbalanced such that it is like one sequential branch (linked list), every node except the leaf having exactly one child.")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)] /* Notice that a new node is allocated for a new key, thus can be considered as O(Size(TreeNode))*/
        public override BinarySearchTreeNode<T1, T2> Insert(BinarySearchTreeNode<T1, T2> root, BinarySearchTreeNode<T1, T2> newNode)
        {
            return Insert_BST(root, newNode);
        }

        [TimeComplexity(Case.Average, "")] // TODO
        [SpaceComplexity("O(1)")]
        public override BinarySearchTreeNode<T1, T2> Delete(BinarySearchTreeNode<T1, T2> root, T1 key)
        {
            if (root == null) return root;

            if (root.Key.CompareTo(key) < 0)
            {
                root.RightChild = Delete(root.RightChild, key);
            }
            else if (root.Key.CompareTo(key) > 0)
            {
                root.LeftChild = Delete(root.LeftChild, key);
            }
            else
            {
                if (root.RightChild == null && root.LeftChild == null)
                {
                    return null;
                }

                if (root.RightChild == null)
                {
                    return root.LeftChild;
                }

                if (root.LeftChild == null)
                {
                    return root.RightChild;
                }

                /* Else replacing the node that has 2 non-null children with its in-order successor, or could alternatively replace it with its in-order predecessor. */
                /* From these definitions it is obvious that the replacement node has less than 2 children. */
                BinarySearchTreeNode<T1, T2> rightChildMin = FindMin(root.RightChild);
                root.Key = rightChildMin.Key;
                root.Value = rightChildMin.Value;
                root.RightChild = Delete(root.RightChild, rightChildMin.Key); /* at this point both node, and rightChildMin have the same keys, but calling delete on the same key, will only result in the removal  of rightChildMin, because pf the root that is passed to Delete.*/
            }
            return root;
        }
    }
}
