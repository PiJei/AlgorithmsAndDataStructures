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
using System.Runtime.CompilerServices;
using CSFundamentals.Styling;
using System.Diagnostics.Contracts;

[assembly: InternalsVisibleTo("CSFundamentalsTests")]

// TODO: Make to inherit from BinarySearchTree and no implementations for search/update/insert-normal

namespace CSFundamentals.DataStructures.Trees
{
    /// <summary>
    /// Implements a red black tree and its operations. A red-black tree is a self-balancing binary search tree.
    /// In this implementation, leaf nodes are treated as nulls and are not explicit. 
    /// A red black tree can also be used as a key-value store.
    /// </summary>
    /// <typeparam name="T1">Specifies the type of the keys in red black tree.</typeparam>
    /// <typeparam name="T2">Specifies the type of the values in red black tree. </typeparam>
    public class RedBlackTree<T1, T2> where T1 : IComparable<T1>, IEquatable<T1>
    {
        private RedBlackTreeNode<T1, T2> _root = null;

        public RedBlackTreeNode<T1, T2> Build(Dictionary<T1, T2> keyValues)
        {
            foreach (KeyValuePair<T1, T2> keyVal in keyValues)
            {
                _root = Insert(_root, keyVal.Key, keyVal.Value);
            }
            return _root;
        }

        [TimeComplexity(Case.Worst, "O(Log(n))")]
        public RedBlackTreeNode<T1, T2> Insert(RedBlackTreeNode<T1, T2> root, T1 key, T2 value)
        {
            var newNode = new RedBlackTreeNode<T1, T2>(key, value, Color.Red);
            root = Insert_WithoutBalancing(root, newNode);
            Insert_Repair(root, newNode);

            /* After rotation the root could have easily changed. Need to find the root. */
            root = newNode;
            while (root.Parent != null)
            {
                root = root.Parent;
            }
            return root;
        }

        [SpaceComplexity("O(1)", InPlace = true)]
        public void Insert_Repair(RedBlackTreeNode<T1, T2> root, RedBlackTreeNode<T1, T2> newNode)
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
        /// Implements insert in a red black tree without the balancing step. The code is similar to the Insert operation for BinarySearchTree, except that it updates the parental relationship, and because of the balancing performed by the man insert method, it is guaranteed to be upper bounded by O(Log(n))
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        internal RedBlackTreeNode<T1, T2> Insert_WithoutBalancing(RedBlackTreeNode<T1, T2> root, RedBlackTreeNode<T1, T2> newNode)
        {
            if (root == null)
            {
                root = newNode;
                return root;
            }

            if (root.Equals(newNode)) /* Turns to an Update. */
            {
                root.Value = newNode.Value;
                return root;
            }

            if (root.Key.CompareTo(newNode.Key) < 0)
            {
                if (root.RightChild == null)
                {
                    root.RightChild = newNode;
                    newNode.Parent = root;
                }
                else
                {
                    root.RightChild = Insert_WithoutBalancing(root.RightChild, newNode);
                }
            }
            else
            {
                if (root.LeftChild == null)
                {
                    root.LeftChild = newNode;
                    newNode.Parent = root;
                }
                else
                {
                    root.LeftChild = Insert_WithoutBalancing(root.LeftChild, newNode);
                }
            }

            return root;
        }

        public RedBlackTreeNode<T1, T2> Delete(RedBlackTreeNode<T1, T2> root, T1 key)
        {
            var node = Search(root, key);
            if (node == null)
            {
                return root;
            }
            var newRoot = node;

            if (node.LeftChild != null && node.RightChild != null) /* The root has exactly 2 non-null children. */
            {
                RedBlackTreeNode<T1, T2> rightChildMin = FindMin(node.RightChild);
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

        [TimeComplexity(Case.Worst, "O(Log(n))")]
        internal RedBlackTreeNode<T1, T2> Delete(RedBlackTreeNode<T1, T2> nodeToBeDeleted)
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

        public void UpdateParentWithNullingChild(RedBlackTreeNode<T1, T2> parent, RedBlackTreeNode<T1, T2> child)
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

        public RedBlackTreeNode<T1, T2> DeleteBlackLeafNode(RedBlackTreeNode<T1, T2> node)
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

        public bool IsRed(RedBlackTreeNode<T1, T2> node)
        {
            if (node != null && node.Color == Color.Red)
                return true;
            return false;
        }

        public bool IsBlack(RedBlackTreeNode<T1, T2> node)
        {
            if (node == null || (node != null && node.Color == Color.Black)) return true;
            return false;
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public RedBlackTreeNode<T1, T2> FindMin(RedBlackTreeNode<T1, T2> root)
        {
            if (root == null) throw new ArgumentNullException();

            RedBlackTreeNode<T1, T2> node = root;
            while (node.LeftChild != null)
            {
                node = node.LeftChild;
            }
            return node;
        }

        /// <summary>
        /// Implements search for RedBlackTree- the code is exactly the same as Search for BinarySearchTree, however because of its self-balancing properties it is guaranteed to be upper bounded by O(Log(n)).
        /// </summary>
        /// <param name="root">Specifies the root of the tree.</param>
        /// <param name="key">Specifies the key the method should look for. </param>
        /// <returns></returns>
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        public RedBlackTreeNode<T1, T2> Search(RedBlackTreeNode<T1, T2> root, T1 key)
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

        [TimeComplexity(Case.Worst, "O(Log(n))")]
        public bool Update(RedBlackTreeNode<T1, T2> root, T1 key, T2 value)
        {
            throw new NotImplementedException();
        }

        public int GetBlackHeight(RedBlackTreeNode<T1, T2> root)
        {
            throw new NotImplementedException();
        }
    }
}
