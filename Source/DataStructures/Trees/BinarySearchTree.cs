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
    /// <summary>
    /// Implements a binary search tree, and its operations. In a binary search tree, each node's key is larger than its left child's key, and smaller than its right child's key.
    /// A binary Search Tree can be used as a key-value store. 
    /// </summary>
    /// <typeparam name="T1">Specifies the type of the key in tree nodes.</typeparam>
    /// <typeparam name="T2">Specifies the type of the value in tree nodes. </typeparam>
    [DataStructure("BinarySearchTree (aka BST)")]
    public class BinarySearchTree<T1, T2> where T1 : IComparable<T1>, IEquatable<T1>
    {
        /// <summary>
        /// Is the root of the binary search tree.
        /// </summary>
        private BinaryTreeNode<T1, T2> _root = null;

        //TODO Compute best and worst case for build operation. 
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        [SpaceComplexity("O(n)")]
        public BinaryTreeNode<T1, T2> Build(Dictionary<T1, T2> keyValues)
        {
            foreach (KeyValuePair<T1, T2> item in keyValues)
            {
                _root = Insert(_root, item.Key, item.Value);
            }
            return _root;
        }

        [TimeComplexity(Case.Best, "O(1)", When = "The tree is empty, and the first node is added.")]
        [TimeComplexity(Case.Worst, "O(n)", When = "Tree is imbalanced such that it is like one sequential branch (linked list), every node except the leaf having exactly one child.")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)] /* Notice that a new node is allocated for a new key, thus can be considered as O(Size(TreeNode))*/
        public BinaryTreeNode<T1, T2> Insert(BinaryTreeNode<T1, T2> root, T1 key, T2 value)
        {
            if (root == null)
            {
                root = new BinaryTreeNode<T1, T2>(key, value);
                return root;
            }

            if (root.Key.CompareTo(key) == 0) /* In this version, not allowing duplicate keys, and just updating the values, can make the values to be a list alternatively.*/
            {
                root.Value = value;
            }
            else if (root.Key.CompareTo(key) < 0)
            {
                root.RightChild = Insert(root.RightChild, key, value); /* assignment because, in case right child is null, and in the recursive call it is instantiated, then parent will have the link to its right child, otherwise nothing changes. */
            }
            else
            {
                root.LeftChild = Insert(root.LeftChild, key, value); /* assignment because, in case left child is null, and in the recursive call it is instantiated, then parent will have the link to its left child, otherwise nothing changes. */
            }

            return root;
        }

        /// <summary>
        /// Implements Search/Lookup/Find operation for a BinarySearchTree. 
        /// </summary>
        /// <param name="root">Specifies the root of the tree.</param>
        /// <param name="key">Specifies the key, the method should look for. </param>
        /// <returns>The tree node that has the key. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)", When = "Tree is imbalanced such that it is like one sequential branch (linked list), every node except the leaf having exactly one child.")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public BinaryTreeNode<T1, T2> Search(BinaryTreeNode<T1, T2> root, T1 key)
        {
            if (root == null)
            {
                return root;
            }

            if (root.Key.CompareTo(key) == 0)
            {
                return root;
            }

            if (root.Key.CompareTo(key) < 0)
            {
                return Search(root.RightChild, key);
            }

            return Search(root.LeftChild, key);
        }

        /// <summary>
        /// Implements Update operation for a BinarySearchTree.
        /// </summary>
        /// <param name="root">Specifies the root of the tree.</param>
        /// <param name="key">Specifies the key of the node for which the value should be updated. </param>
        /// <param name="value">Specifies the new value for the given key. </param>
        /// <returns>True in case of success, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "o(n)")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public bool Update(BinaryTreeNode<T1, T2> root, T1 key, T2 value)
        {
            BinaryTreeNode<T1, T2> node = Search(root, key); /* Since relies on Search, its time and space complexities are directly driven from Search() operation. */
            if (node != null)
            {
                node.Value = value;
                return true;
            }
            return false;
        }

        [TimeComplexity(Case.Average, "O(n)")]
        [SpaceComplexity("O(n)")]
        public void InOrderTraversal(BinaryTreeNode<T1, T2> root, List<BinaryTreeNode<T1, T2>> inOrder)
        {
            if (root != null)
            {
                InOrderTraversal(root.LeftChild, inOrder);
                inOrder.Add(root);
                InOrderTraversal(root.RightChild, inOrder);
            }
        }

        [TimeComplexity(Case.Average, "")] // TODO
        [SpaceComplexity("O(1)")]
        public BinaryTreeNode<T1, T2> Delete(BinaryTreeNode<T1, T2> root, T1 key)
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
                BinaryTreeNode<T1, T2> rightChildMin = FindMin(root.RightChild);
                root.Key = rightChildMin.Key;
                root.Value = rightChildMin.Value;
                root.RightChild = Delete(root.RightChild, rightChildMin.Key); /* at this point both node, and rightChildMin have the same keys, but calling delete on the same key, will only result in the removal  of rightChildMin, because pf the root that is passed to Delete.*/
            }
            return root;
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public BinaryTreeNode<T1, T2> FindMin(BinaryTreeNode<T1, T2> root)
        {
            if (root == null) throw new ArgumentNullException();

            BinaryTreeNode<T1, T2> node = root;
            while (node.LeftChild != null)
            {
                node = node.LeftChild;
            }
            return node;
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public BinaryTreeNode<T1, T2> FindMax(BinaryTreeNode<T1, T2> root)
        {
            if (root == null) throw new ArgumentNullException();
            BinaryTreeNode<T1, T2> node = root;
            while (node.RightChild != null)
            {
                node = node.RightChild;
            }
            return node;
        }

        [TimeComplexity(Case.Average, "")]
        [SpaceComplexity("")]
        public BinaryTreeNode<T1, T2> DeleteMin(BinaryTreeNode<T1, T2> root)
        {
            BinaryTreeNode<T1, T2> minNode = FindMin(root);
            return Delete(root, minNode.Key);
        }

        [TimeComplexity(Case.Average, "")]
        [SpaceComplexity("")]
        public BinaryTreeNode<T1, T2> DeleteMax(BinaryTreeNode<T1, T2> root)
        {
            BinaryTreeNode<T1, T2> maxNode = FindMax(root);
            return Delete(root, maxNode.Key);
        }
    }
}
