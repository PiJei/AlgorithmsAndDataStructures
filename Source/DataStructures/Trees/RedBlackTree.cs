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

[assembly: InternalsVisibleTo("CSFundamentalsTests.DataStructures")]

// TODO: Make to inherit from BinarySearchTree and no implementations for search/update/insert-normal
namespace CSFundamentals.DataStructures.Trees
{
    /// <summary>
    /// Implements a red black tree and its operations. A red-black tree is a self-balancing binary search tree.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class RedBlackTree<T1, T2> where T1 : IComparable<T1>, IEquatable<T1>
    {
        public RedBlackTreeNode<T1, T2> Build(Dictionary<T1, T2> keyValues)
        {
            throw new NotImplementedException();
        }

        [TimeComplexity(Case.Worst, "O(Log(n))")]
        public RedBlackTreeNode<T1, T2> Delete(RedBlackTreeNode<T1, T2> root, T1 key)
        {
            throw new NotImplementedException();
        }

        [TimeComplexity(Case.Worst, "O(Log(n))")]
        public RedBlackTreeNode<T1, T2> Insert(RedBlackTreeNode<T1, T2> root, T1 key, T2 value)
        {
            root = Insert_WithoutBalancing(root, key, value);
            throw new NotImplementedException();

            // 1- insert node and color as red.
            // 2-  recolor and rotate to fix balance
            // a) if node is root color it black
            // b) if node's uncle is red, flip colors of parent, grandparent, and uncle. 
            // c) if uncle. black, and triangle is formed, rotate parent
            // d ) if uncle is black, and line formed, rotate grandparent (but to which directions? opposite of z?)
        }

        /// <summary>
        /// Implements insert in a red black tree without the balancing step. The code is the same as the Insert operation for BinarySearchTree, except that because of the balancing performed by the man insert method, it is guaranteed to be upper bounded by O(Log(n))
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        internal RedBlackTreeNode<T1, T2> Insert_WithoutBalancing(RedBlackTreeNode<T1, T2> root, T1 key, T2 value)
        {
            if (root == null)
            {
                root = new RedBlackTreeNode<T1, T2>(key, value, Color.Red);
                return root;
            }

            if (root.Key.CompareTo(key) == 0) /* Turns to an Update. */
            {
                root.Value = value;
                return root;
            }

            if (root.Key.CompareTo(key) < 0)
            {
                root.RightChild = Insert_WithoutBalancing(root.RightChild, key, value);
            }
            else
            {
                root.LeftChild = Insert_WithoutBalancing(root.LeftChild, key, value);
            }

            return root;
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

        /// <summary>
        /// Rotates the tree to left at the given node, meaning that the current right child of the given node will be its new parent.
        /// Also notice that in rotation, keys or values of a node never change, only the relations change.
        /// </summary>
        /// <param name="node"></param>
        [TimeComplexity(Case.Average, "O(1)")]
        public void RotateLeft(RedBlackTreeNode<T1, T2> node)
        {
            if (node == null) throw new ArgumentNullException();
            if (node.RightChild == null) throw new Exception("While rotating left, the new parent can not be null.");

            var nodeParent = node.Parent;
            var newNode = node.RightChild; /* This will be node's new parent. */

            /* Since the node is losing its right child, we need to select a new right child. The left child of node's right child is a perfect candidate for this position to preserve tree's order properties.*/
            node.RightChild = newNode.LeftChild;
            if (node.RightChild != null)
                node.RightChild.Parent = node;

            newNode.LeftChild = node; /* Meaning new node is becoming node's parent. */
            node.Parent = newNode;

            /* Next need to update the links of the parent node, since one of its children is replaced by a new node. */
            if (nodeParent != null)
            {
                if (nodeParent.LeftChild != null && nodeParent.LeftChild.Key.CompareTo(node.Key) == 0)
                {
                    nodeParent.LeftChild = newNode;
                }
                else if (nodeParent.RightChild != null && nodeParent.RightChild.Key.CompareTo(node.Key) == 0)
                {
                    nodeParent.RightChild = newNode;
                }
                newNode.Parent = nodeParent;
            }
        }

        /// <summary>
        /// Rotates the tree to right at the given node. Meaning that the current left child of the given node will be its new parent.
        /// Also notice that in rotation, keys or values of a node never change, only the relations change.
        /// </summary>
        /// <param name="node"></param>
        [TimeComplexity(Case.Average, "O(1)")]
        public void RotateRight(RedBlackTreeNode<T1, T2> node)
        {
            if (node == null) throw new ArgumentNullException();
            if (node.LeftChild == null) throw new Exception("While rotating right, the new parent can not be null.");

            var nodeParent = node.Parent;
            var newNode = node.LeftChild; /* This will be node's new parent. */

            /* Since node is losing its left child, we need to select a new left child. The right child of node's left child is the perfect candidate for this position to preserve tree's order properties.*/
            node.LeftChild = newNode.RightChild;
            if (node.LeftChild != null)
                node.LeftChild.Parent = node;

            newNode.RightChild = node; /* Meaning that newNode is becoming node's parent. */
            node.Parent = newNode;

            if (nodeParent != null)
            {
                if (nodeParent.LeftChild != null && nodeParent.LeftChild.Key.CompareTo(node.Key) == 0)
                {
                    nodeParent.LeftChild = newNode;
                }
                else if (nodeParent.RightChild != null && nodeParent.RightChild.Key.CompareTo(node.Key) == 0)
                {
                    nodeParent.RightChild = newNode;
                }
                newNode.Parent = nodeParent;
            }
        }

        public RedBlackTreeNode<T1, T2> GetUncle(RedBlackTreeNode<T1, T2> node)
        {
            if (node == null) return null;
            if (node.Parent == null) return null;
            if (node.Parent.Parent == null) return null;
            if (node.Parent.Parent.LeftChild.Key.CompareTo(node.Parent.Key) == 0)
            {
                return node.Parent.Parent.RightChild;
            }
            else if (node.Parent.Parent.RightChild.Key.CompareTo(node.Parent.Key) == 0)
            {
                return node.Parent.Parent.LeftChild;
            }
            return null;
        }

        public RedBlackTreeNode<T1, T2> GetGrandParent(RedBlackTreeNode<T1, T2> node)
        {
            if (node == null) return null;
            if (node.Parent == null) return null;
            if (node.Parent.Parent == null) return null;
            return node.Parent.Parent;
        }

        /// <summary>
        /// Checks to see if the given node is the left child of its parent.
        /// </summary>
        /// <param name="node"></param>
        /// <returns>True in case the given node is the left child of its parent, and false otherwise.</returns>
        public bool IsLeftChild(RedBlackTreeNode<T1, T2> node)
        {
            if (node == null) return false;
            if (IsRoot(node)) return false;
            if (node.Parent.LeftChild == null) return false;
            if (node.Parent.LeftChild.Key.CompareTo(node.Key) == 0) return true;
            return false;
        }

        /// <summary>
        /// Checks to see if the given node is the right child of its parent. 
        /// Notice that we can not simply use !IsLeftChild() as an answer to IsRightChild(), because the keys could be smaller or larger when not equal. 
        /// </summary>
        /// <param name="node"></param>
        /// <returns>True in case the given node is the right child of its parent, and false if it is not.</returns>
        public bool IsRightChild(RedBlackTreeNode<T1, T2> node)
        {
            if (node == null) return false;
            if (IsRoot(node)) return false;
            if (node.Parent.RightChild == null) return false;
            if (node.Parent.RightChild.Key.CompareTo(node.Key) == 0) return true;
            return false;
        }


        public bool IsRoot(RedBlackTreeNode<T1, T2> node)
        {
            if (node == null) throw new ArgumentNullException();
            if (node.Parent == null) return true;
            return false;
        }

        public void FlipColor(RedBlackTreeNode<T1, T2> node)
        {
            if (node.Color == Color.Red)
            {
                node.Color = Color.Black;
            }
            if (node.Color == Color.Black)
            {
                node.Color = Color.Red;
            }
        }

        /// <summary>
        /// Checks whether the node forms a line with its parent and grandparent. 
        /// </summary>
        /// <param name="node"></param>
        public bool FormsLine(RedBlackTreeNode<T1, T2> node)
        {
            if (IsLeftChild(node) && IsLeftChild(node.Parent)) return true;
            if (IsRightChild(node) && IsRightChild(node.Parent)) return true;
            return false;
        }

        /// <summary>
        /// Checks whether the node forms a triangle with its parent and grandparent.
        /// </summary>
        /// <param name="node"></param>
        public bool FormsTriangle(RedBlackTreeNode<T1, T2> node)
        {
            if (IsLeftChild(node) && IsRightChild(node.Parent)) return true;
            if (IsRightChild(node) && IsLeftChild(node.Parent)) return true;
            return false;
        }
    }
}
