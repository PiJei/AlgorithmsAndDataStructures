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
using System.Runtime.CompilerServices;
using CSFundamentals.DataStructures.Trees.Binary.API;
using CSFundamentals.Decoration;

[assembly: InternalsVisibleTo("CSFundamentalsTests")]

namespace CSFundamentals.DataStructures.Trees.Binary
{
    /// <summary>
    /// Implements a red black tree and its operations. A red-black tree is a self-balancing binary search tree.
    /// In this implementation, nulls are treated as black nodes. 
    /// A red black tree can also be used as a key-value store.
    /// </summary>
    /// <typeparam name="TKey">Specifies the type of the keys in red black tree.</typeparam>
    /// <typeparam name="TValue">Specifies the type of the values in red black tree. </typeparam>
    [DataStructure("RedBlackTree")]
    public class RedBlackTree<TKey, TValue> : BinarySearchTreeBase<RedBlackTreeNode<TKey, TValue>, TKey, TValue> where TKey : IComparable<TKey>
    {
        [TimeComplexity(Case.Best, "O(n)", When = "Every new node is inserted in the very first locations.")]
        [TimeComplexity(Case.Worst, "O(nLog(n))")]
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        [SpaceComplexity("O(n)")]
        public override RedBlackTreeNode<TKey, TValue> Build(List<RedBlackTreeNode<TKey, TValue>> nodes)
        {
            return Build_BST(nodes);
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        public override RedBlackTreeNode<TKey, TValue> Insert(RedBlackTreeNode<TKey, TValue> root, RedBlackTreeNode<TKey, TValue> newNode)
        {
            root = Insert_BST(root, newNode);
            Insert_Repair(root, newNode);

            /* After rotation the root could have easily changed. Need to find the root. */
            root = newNode;
            while (root.Parent != null)
            {
                root = root.Parent;
            }
            return root;
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(nLog(n))")]
        public override RedBlackTreeNode<TKey, TValue> Delete(RedBlackTreeNode<TKey, TValue> root, TKey key)
        {
            var node = Search(root, key);
            if (node == null)
            {
                return root;
            }
            var newRoot = node;

            if (node.LeftChild != null && node.RightChild != null) /* The root has exactly 2 non-null children. */
            {
                RedBlackTreeNode<TKey, TValue> rightChildMin = FindMin(node.RightChild);
                node.Key = rightChildMin.Key;
                node.Value = rightChildMin.Value;
                var parent = rightChildMin.Parent;
                newRoot = Delete(rightChildMin); ;
                UpdateParentWithNullingChild(parent, rightChildMin);
                rightChildMin = null;
            }
            else
            {
                newRoot = Delete(node);
                node = null;
            }

            // Find the root of the tree.
            if (newRoot == null) return null;
            while (newRoot.Parent != null)
            {
                newRoot = newRoot.Parent;
            }
            return newRoot;
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public override RedBlackTreeNode<TKey, TValue> Search(RedBlackTreeNode<TKey, TValue> root, TKey key)
        {
            return Search_BST(root, key);
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)", InPlace = true)]
        public override bool Update(RedBlackTreeNode<TKey, TValue> root, TKey key, TValue value)
        {
            return Update_BST(root, key, value);
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public override RedBlackTreeNode<TKey, TValue> FindMin(RedBlackTreeNode<TKey, TValue> root)
        {
            return FindMin_BST(root);
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public override RedBlackTreeNode<TKey, TValue> FindMax(RedBlackTreeNode<TKey, TValue> root)
        {
            return FindMax_BST(root);
        }

        //TODO: Test
        internal RedBlackTreeNode<TKey, TValue> Delete(RedBlackTreeNode<TKey, TValue> nodeToBeDeleted)
        {
            /* The nodeToBeDeleted has at most 1 non-null child. */
            var parent = nodeToBeDeleted.Parent;

            if (nodeToBeDeleted.IsLeaf() && nodeToBeDeleted.Color == Color.Red) // case 1 
            {
                UpdateParentWithNullingChild(parent, nodeToBeDeleted);
                return parent;
            }
            else if (nodeToBeDeleted.IsLeaf() && nodeToBeDeleted.Color == Color.Black) //Case2: nodeToBeDeleted is black, and has 2 null children. Or in other words: Deleting a black node with 2 null children. /* This case is tricky, because removing one black node from the tree will violate red-black property of: all the paths from a node to all of its leaf (null) children have exactly the same number of black nodes. */
            {
                var node = DeleteBlackLeafNode(nodeToBeDeleted);
                UpdateParentWithNullingChild(parent, nodeToBeDeleted);
                return node;
            }
            else if (!nodeToBeDeleted.IsLeaf() && nodeToBeDeleted.Color == Color.Black) // Case3: nodeToBeDeleted is black, and its the only not null child is red
            {
                if (nodeToBeDeleted.LeftChild != null) /* Then replace nodeToBeDeleted with nodeToBeDeleted.LeftChild*/
                {
                    Contract.Assert(nodeToBeDeleted.LeftChild.Color == Color.Red);
                    nodeToBeDeleted.LeftChild.Parent = nodeToBeDeleted.Parent;
                    if (nodeToBeDeleted.Parent != null)
                        nodeToBeDeleted.Parent.LeftChild = nodeToBeDeleted.LeftChild;
                    nodeToBeDeleted = nodeToBeDeleted.LeftChild;
                    nodeToBeDeleted.Color = Color.Black; /* This is to keep the number of black nodes the same, as we have just dropped a non-leaf black node.*/
                }
                else if (nodeToBeDeleted.RightChild != null) /* Then replace nodeToBeDeleted with nodeToBeDeleted.rightChild*/
                {
                    Contract.Assert(nodeToBeDeleted.RightChild.Color == Color.Red);
                    nodeToBeDeleted.RightChild.Parent = nodeToBeDeleted.Parent;
                    if (nodeToBeDeleted.Parent != null)
                        nodeToBeDeleted.Parent.RightChild = nodeToBeDeleted.RightChild;
                    nodeToBeDeleted = nodeToBeDeleted.RightChild;
                    nodeToBeDeleted.Color = Color.Black; /* This is to keep the number of black nodes the same, as we have just dropped a non-leaf black node.*/
                }
                return nodeToBeDeleted;
            } // Case 4: Notice that by properties of RedBlackTree case 4 can not exist (case 4: !IsLeaf(nodeToBeDeleted) && nodeToBeDeleted.Color == Color.Red)
            return null;
        }

        //TODO: Test
        internal RedBlackTreeNode<TKey, TValue> DeleteBlackLeafNode(RedBlackTreeNode<TKey, TValue> node)
        {
            if (node.Parent == null) return null;

            var sibling = node.GetSibling();
            if (sibling == null) return null;

            if (IsRed(sibling)) /* Implies that parent is black, following RedBlack tree properties.*/
            {
                node.Parent.Color = Color.Red;
                sibling.Color = Color.Black;
                if (node.IsLeftChild())
                {
                    RotateLeft(node.Parent);
                }
                if (node.IsRightChild())
                {
                    RotateRight(node.Parent);
                }
                sibling = node.GetSibling();
            }

            if (IsBlack(node.Parent) && IsBlack(sibling) && IsBlack(sibling.LeftChild) && IsBlack(sibling.RightChild))
            {
                sibling.Color = Color.Red;
                DeleteBlackLeafNode(node.Parent);
            }
            else if (IsRed(node.Parent) && IsBlack(sibling) && IsBlack(sibling.LeftChild) && IsBlack(sibling.RightChild))
            {
                sibling.Color = Color.Red;
                node.Parent.Color = Color.Black;
            }
            else if (IsBlack(sibling))
            {
                if (IsRed(sibling.LeftChild) && IsBlack(sibling.RightChild) && node.IsLeftChild())
                {
                    sibling.Color = Color.Red;
                    if (sibling.LeftChild != null)
                        sibling.LeftChild.Color = Color.Black;
                    RotateRight(sibling);
                    sibling = node.GetSibling();
                }
                else if (IsBlack(sibling.LeftChild) && IsRed(sibling.RightChild) && node.IsRightChild())
                {
                    sibling.Color = Color.Red;
                    if (sibling.RightChild != null)
                        sibling.RightChild.Color = Color.Black;
                    RotateLeft(sibling);
                    sibling = node.GetSibling();
                }

                if (IsBlack(sibling) && IsRed(sibling.RightChild))
                {
                    sibling.Color = node.Parent.Color;
                    node.Parent.Color = Color.Black;
                    if (node.IsLeftChild())
                    {
                        sibling.RightChild.Color = Color.Black;
                        RotateLeft(node.Parent);
                    }
                    else if (node.IsRightChild())
                    {
                        sibling.LeftChild.Color = Color.Black;
                        RotateRight(node.Parent);
                    }
                }
            }
            return sibling;
        }

        [SpaceComplexity("O(1)", InPlace = true)]
        internal void Insert_Repair(RedBlackTreeNode<TKey, TValue> root, RedBlackTreeNode<TKey, TValue> newNode)
        {
            if (newNode.Parent == null && newNode.Color == Color.Red) /* Property: the root is black. */
            {
                newNode.FlipColor();
            }
            else if (newNode.Parent != null && newNode.Parent.Color == Color.Red) /* If this holds it means that both the new node and its parent are red, and in a red-black tree this is not allowed. Children of a red node should be black.*/
            {
                var uncle = newNode.GetUncle();

                if (uncle != null && uncle.Color == Color.Red) /* Both the parent and uncle of the new node are red. Note that a null uncle is considered black. */
                {
                    newNode.Parent.Color = Color.Black;
                    uncle.Color = Color.Black;
                    newNode.GetGrandParent().Color = Color.Red;
                    Insert_Repair(root, newNode.GetGrandParent()); /* Repeat repair on the grandparent, as by the re-coloring the previous layers could have been messed up. */
                }
                else if (uncle == null || uncle.Color == Color.Black)
                {
                    if (newNode.FormsTriangle() && newNode.IsLeftChild())
                    {
                        RotateRight(newNode.Parent);
                        newNode = newNode.RightChild; /* After rotation new node has become the parent of its former parent.*/
                        /* Triangle is transformed to a line.*/
                    }
                    else if (newNode.FormsTriangle() && newNode.IsRightChild())
                    {
                        RotateLeft(newNode.Parent);
                        newNode = newNode.LeftChild; /* After rotation new node has become the parent of its former parent.*/
                        /* Triangle is transformed to a line.*/
                    }

                    /* When reaching at this point, we might or might not have gone through above two triangle forms, as the alignment could have already been a line.*/
                    var grandParent = newNode.GetGrandParent();
                    if (newNode.IsRightChild())
                    {
                        RotateLeft(grandParent);
                    }
                    else if (newNode.IsLeftChild())
                    {
                        RotateRight(grandParent);
                    }
                    newNode.Parent.Color = Color.Black;
                    if (grandParent != null)
                        grandParent.Color = Color.Red;
                }
            }
        }

        /// <summary>
        /// Checks whether the given node is red. 
        /// </summary>
        /// <param name="node">Is a node in a red black tree. </param>
        /// <returns>True in case node is red, and false otherwise. </returns>
        internal bool IsRed(RedBlackTreeNode<TKey, TValue> node)
        {
            if (node != null && node.Color == Color.Red)
                return true;
            return false;
        }

        /// <summary>
        /// Checks whether the given node is black. 
        /// </summary>
        /// <param name="node">Is a node in a red black tree. </param>
        /// <returns>True in case node is black, and false otherwise. </returns>
        internal bool IsBlack(RedBlackTreeNode<TKey, TValue> node)
        {
            if (node == null || (node != null && node.Color == Color.Black)) return true;
            return false;
        }

        /// <summary>
        /// Finds the given child node in the parent node, and if in fact a child of the parent replaces it with null. 
        /// </summary>
        /// <param name="parent">Is a parent node. </param>
        /// <param name="child">Is a child node of the given parent node. </param>
        internal void UpdateParentWithNullingChild(RedBlackTreeNode<TKey, TValue> parent, RedBlackTreeNode<TKey, TValue> child)
        {
            if (parent != null)
            {
                if (child.IsLeftChild())
                {
                    parent.LeftChild = null;
                }
                else if (child.IsRightChild())
                {
                    parent.RightChild = null;
                }
            }
        }
    }
}
