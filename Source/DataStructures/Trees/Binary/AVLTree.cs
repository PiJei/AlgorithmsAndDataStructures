#region copyright
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
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using CSFundamentals.DataStructures.Trees.Binary.API;
using CSFundamentals.Decoration;

namespace CSFundamentals.DataStructures.Trees.Binary
{
    /// <summary>
    /// Implements an AVL tree. An AVL tree is a self balancing Binary Search Tree.
    /// Notice the differences in time complexity at worst case for various operations, compared to a basic binary search tree. 
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the tree. </typeparam>
    /// <typeparam name="TValue">The type of the values in the tree. </typeparam>
    [DataStructure("AVLTree")]
    public class AVLTree<TKey, TValue> : BinarySearchTreeBase<AVLTreeNode<TKey, TValue>, TKey, TValue> where TKey : IComparable<TKey>
    {
        //TODO: Is o best true? I am suspicious, the input perhaps should be in a special order. 
        /// <summary>
        /// Builds the tree to include the given nodes.
        /// </summary>
        /// <param name="keyValues">A list of key-value pairs to be inserted in the tree.</param>
        /// <returns>Root of the tree.</returns>
        [TimeComplexity(Case.Best, "O(n)", When = "Every new node is inserted in the very first locations.")]
        [TimeComplexity(Case.Worst, "O(nLog(n))")]
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        [SpaceComplexity("O(n)")]
        public override AVLTreeNode<TKey, TValue> Build(List<KeyValuePair<TKey, TValue>> keyValues)
        {
            return Build_BST(keyValues);
        }

        /// <summary>
        /// Deletes a node with the given key from th tree.
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which delete operation should be started. </param>
        /// <param name="key">The key of the node to be deleted. </param>
        /// <returns>New root of the tree (might or might not change during the operation).</returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public override AVLTreeNode<TKey, TValue> Delete(AVLTreeNode<TKey, TValue> root, TKey key)
        {
            if (root == null)
            {
                return root;
            }

            if (root.Key.CompareTo(key) < 0)
            {
                root.RightChild = Delete(root.RightChild, key);
            }
            else if (root.Key.CompareTo(key) > 0)
            {
                root.LeftChild = Delete(root.LeftChild, key);
            }
            else if (root.Key.CompareTo(key) == 0) // The key is found
            {
                if (root.RightChild == null && root.LeftChild == null)
                {
                    root = null;
                }

                else if (root.RightChild == null)
                {
                    root = root.LeftChild;
                }

                else if (root.LeftChild == null)
                {
                    root = root.RightChild;
                }
                else
                {
                    /* Else replacing the node that has 2 non-null children with its in-order successor, or could alternatively replace it with its in-order predecessor. */
                    /* From definition of FindMin() it is obvious that the replacement node [rightChildMin] has less than 2 children. */
                    AVLTreeNode<TKey, TValue> rightChildMin = FindMin_BST(root.RightChild);
                    root.Key = rightChildMin.Key;
                    root.Value = rightChildMin.Value;
                    root.RightChild = Delete(root.RightChild, rightChildMin.Key); /* at this point both node, and rightChildMin have the same keys, but calling delete on the same key, will only result in the removal  of rightChildMin, because pf the root that is passed to Delete.*/
                }
            }

            if (root == null)
            {
                return root;
            }

            var grandChild = root?.GetGrandChildren()?.FirstOrDefault();
            var grandParent = root;
            var parent = grandChild?.Parent;
            if (grandParent != null && parent != null)
            {
                int grandParentBalance = ComputeBalanceFactor(grandParent);
                if (grandParentBalance > 1)
                {
                    if (grandChild.FormsTriangle())
                    {
                        Contract.Assert(grandChild.IsLeftChild());
                        RotateRight(parent);
                        return RotateLeft(grandParent);
                    }
                    else if (grandChild.FormsLine())
                    {
                        Contract.Assert(grandChild.IsRightChild());
                        return RotateLeft(grandParent);
                    }
                }
                else if (grandParentBalance < -1)
                {
                    if (grandChild.FormsTriangle())
                    {
                        Contract.Assert(grandChild.IsRightChild());
                        RotateLeft(parent);
                        return RotateRight(grandParent);
                    }
                    else if (grandChild.FormsLine())
                    {
                        Contract.Assert(grandChild.IsLeftChild());
                        return RotateRight(grandParent);
                    }
                }
            }
            return root;
        }

        /// <summary>
        /// Inserts a new node in the tree
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which insert operation should be started.</param>
        /// <param name="newNode">New node to be inserted in the tree. </param>
        /// <returns>New root of the tree (might or might not change during operation).</returns>
        [TimeComplexity(Case.Best, "O(1)", When = "The tree is empty, and the first node is added.")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public override AVLTreeNode<TKey, TValue> Insert(AVLTreeNode<TKey, TValue> root, AVLTreeNode<TKey, TValue> newNode)
        {
            root = Insert_BST(root, newNode); /* First insert the node using normal BinarySearchInsert to preserve the ordering property. */

            Balance(newNode);

            // Find the new root of the tree, as it might have changed during the operations. 
            root = newNode;
            while (root.Parent != null)
            {
                root = root.Parent;
            }
            return root;
        }

        /// <summary>
        /// Searches for the given key in the tree. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which search operation should be started. </param>
        /// <param name="key">The key to be searched. </param>
        /// <returns>Returns the tree node that contains key. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public override AVLTreeNode<TKey, TValue> Search(AVLTreeNode<TKey, TValue> root, TKey key)
        {
            return Search_BST(root, key);
        }

        /// <summary>
        /// Updates the tree node of the specified key with the new given value. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which update operation should be started.</param>
        /// <param name="key">The key of the node whose value should be updated.</param>
        /// <param name="value">The new value. </param>
        /// <returns>true in case of success and false otherwise.</returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public override bool Update(AVLTreeNode<TKey, TValue> root, TKey key, TValue value)
        {
            return Update_BST(root, key, value);
        }

        /// <summary>
        /// Finds the minimum key in the (sub)tree rooted at <paramref name="root"/> node. 
        /// </summary>
        /// <param name="root">The node at which (sub)tree is rooted. </param>
        /// <returns>The node containing the minimum key. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public override AVLTreeNode<TKey, TValue> FindMin(AVLTreeNode<TKey, TValue> root)
        {
            return FindMin_BST(root);
        }

        /// <summary>
        /// Finds the maximum key in the (sub)tree rooted at <paramref name="root"/> node. 
        /// </summary>
        /// <param name="root">The node at which (sub)tree is rooted. </param>
        /// <returns>The node containing the maximum key. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public override AVLTreeNode<TKey, TValue> FindMax(AVLTreeNode<TKey, TValue> root)
        {
            return FindMax_BST(root);
        }

        /// <summary>
        /// Balances a tree, starting at the given node and going upward. 
        /// </summary>
        /// <param name="node">The bottom most node, from which balance starts, based on its parent and grand parent. </param>
        internal void Balance(AVLTreeNode<TKey, TValue> node)
        {
            AVLTreeNode<TKey, TValue> parent = node?.Parent;
            AVLTreeNode<TKey, TValue> grandParent = node?.Parent?.Parent;

            while (grandParent != null && parent != null)
            {
                int grandParentBalance = ComputeBalanceFactor(grandParent);
                if (grandParentBalance > 1)
                {
                    if (node.FormsTriangle())
                    {
                        Contract.Assert(node.IsLeftChild());
                        RotateRight(parent);
                        RotateLeft(grandParent);
                    }
                    else if (node.FormsLine())
                    {
                        Contract.Assert(node.IsRightChild());
                        RotateLeft(grandParent);
                    }
                }
                else if (grandParentBalance < -1)
                {
                    if (node.FormsTriangle())
                    {
                        Contract.Assert(node.IsRightChild());
                        RotateLeft(parent);
                        RotateRight(grandParent);
                    }
                    else if (node.FormsLine())
                    {
                        Contract.Assert(node.IsLeftChild()); ;
                        RotateRight(grandParent);
                    }
                }
                else /* Expect this case be only repeated once, given the balance factor of any node that is kept controlled. */
                {
                    /* move one level upwards. */
                    node = parent;
                    parent = grandParent;
                    grandParent = grandParent.Parent;
                }
            }
        }

        /// <summary>
        /// Computes balance factor of a node. Which is the difference between the height of the left and right sub trees of the node.
        /// </summary>
        /// <param name="node">The node for which balance is computed.</param>
        /// <returns>the balance factor of the node. </returns>
        internal int ComputeBalanceFactor(AVLTreeNode<TKey, TValue> node)
        {
            return (node.RightChild == null ? 0 : GetHeight(node.RightChild)) - (node.LeftChild == null ? 0 : GetHeight(node.LeftChild));
        }

        /// <summary>
        /// Computes the height of the tree rooted at the given node. The height of a node is the maximum path length to its leaf nodes.
        /// </summary>
        /// <param name="node">The node whose height is calculated.</param>
        /// <returns>The height of the tree rooted at the given node. </returns>
        internal int GetHeight(AVLTreeNode<TKey, TValue> node)
        {
            List<List<AVLTreeNode<TKey, TValue>>> paths = GetAllPathToLeaves(node);

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
    }
}
