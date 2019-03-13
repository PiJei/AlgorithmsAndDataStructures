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

namespace CSFundamentals.DataStructures.Trees.API
{
    public abstract class BinarySearchTreeBase<T, T1, T2> where T : ITreeNode<T, T1, T2> where T1 : IEquatable<T1>, IComparable<T1>
    {
        /// <summary>
        /// Is the root of the binary search tree.
        /// </summary>
        protected T _root { get; set; } = default(T);

        /// <summary>
        /// Builds a binary search tree of the given list and returns the root of the tree.
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public abstract T Build(List<T> keyValues);

        public abstract T Insert(T root, T newNode);

        public abstract T Delete(T root, T1 key);

        // TODO: These bounds are no longer correct generally, depending on the Tree they change...
        /// <summary>
        /// Implements insert in a red black tree without the balancing step. The code is similar to the Insert operation for BinarySearchTree, except that it updates the parental relationship, and because of the balancing performed by the man insert method, it is guaranteed to be upper bounded by O(Log(n))
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [TimeComplexity(Case.Worst, "O(Log(n))")]
        internal T Insert_BST(T root, T newNode)
        {
            if (root == null) /* This is the case where there is no node in the tree, and newNode is the first one. */
            {
                root = newNode;
                root.Parent = default(T);
                return root;
            }

            if (root.Equals(newNode)) /* Turns to an Update. In this version, not allowing duplicate keys, and just updating the values, can make the values to be a list alternatively.*/
            {
                root.Value = newNode.Value;
                return root;
            }

            if (root.CompareTo(newNode) < 0)
            {
                if (root.RightChild == null) /* Treating this case separately as need to update the parent of the new node.*/
                {
                    root.RightChild = newNode;
                    newNode.Parent = root;
                }
                else
                {
                    root.RightChild = Insert_BST(root.RightChild, newNode); /* assignment because, in case right child is null, and in the recursive call it is instantiated, then parent will have the link to its right child, otherwise nothing changes. */
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
                    root.LeftChild = Insert_BST(root.LeftChild, newNode); /* assignment because, in case left child is null, and in the recursive call it is instantiated, then parent will have the link to its left child, otherwise nothing changes. */
                }
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
        public T Search(T root, T1 key)
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
        public bool Update(T root, T1 key, T2 value)
        {
            T node = Search(root, key); /* Since relies on Search, its time and space complexities are directly driven from Search() operation. */
            if (node != null)
            {
                node.Value = value;
                return true;
            }
            return false;
        }

        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(Log(n))")]
        [SpaceComplexity("O(1)")]
        public T FindMin(T root)
        {
            if (root == null) throw new ArgumentNullException();

            T node = root;
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
        public T FindMax(T root)
        {
            if (root == null) throw new ArgumentNullException();
            T node = root;
            while (node.RightChild != null)
            {
                node = node.RightChild;
            }
            return node;
        }

        /// <summary>
        /// Rotates the tree to left at the given node, meaning that the current right child of the given node will be its new parent.
        /// Also notice that in rotation, keys or values of a node never change, only the relations change.
        /// </summary>
        /// <param name="node"></param>
        [TimeComplexity(Case.Average, "O(1)")]
        public void RotateLeft(T node)
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
            }
            newNode.Parent = nodeParent;
        }

        /// <summary>
        /// Rotates the tree to right at the given node. Meaning that the current left child of the given node will be its new parent.
        /// Also notice that in rotation, keys or values of a node never change, only the relations change.
        /// </summary>
        /// <param name="node"></param>
        [TimeComplexity(Case.Average, "O(1)")]
        public void RotateRight(T node)
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
            }
            newNode.Parent = nodeParent;
        }

        [TimeComplexity(Case.Average, "")]
        [SpaceComplexity("")]
        public T DeleteMin(T root)
        {
            T minNode = FindMin(root);
            return Delete(root, minNode.Key);
        }

        [TimeComplexity(Case.Average, "")]
        [SpaceComplexity("")]
        public T DeleteMax(T root)
        {
            T maxNode = FindMax(root);
            return Delete(root, maxNode.Key);
        }
    }
}
