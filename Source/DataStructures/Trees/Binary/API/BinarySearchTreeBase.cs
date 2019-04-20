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
using CSFundamentals.Decoration;

[assembly: InternalsVisibleTo("CSFundamentalTests")]

namespace CSFundamentals.DataStructures.Trees.Binary.API
{
    public abstract class BinarySearchTreeBase<TNode, TKey, TValue>
        where TNode : IBinaryTreeNode<TNode, TKey, TValue>, new()
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Is the root of the binary search tree.
        /// </summary>
        protected TNode _root { get; set; } = default(TNode);

        /// <summary>
        /// Builds the tree to include the given nodes.
        /// </summary>
        /// <param name="nodes">Is a list of nodes to be inserted in the tree.</param>
        /// <returns>Root of the tree.</returns>
        public abstract TNode Build(List<TNode> nodes);

        /// <summary>
        /// Inserts a new node in the tree
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which insert operation should be started.</param>
        /// <param name="newNode">New node to be inserted in the tree. </param>
        /// <returns>New root of the tree (might or might not change during operation).</returns>
        public abstract TNode Insert(TNode root, TNode newNode);

        /// <summary>
        /// Deletes a node with the given key from th tree.
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which delete operation should be started. </param>
        /// <param name="key">Specifies the key of the node to be deleted. </param>
        /// <returns>New root of the tree (might or might not change during the operation).</returns>
        public abstract TNode Delete(TNode root, TKey key);

        /// <summary>
        /// Searches for the given key in the tree. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which search operation should be started. </param>
        /// <param name="key">Specifies the key to be searched. </param>
        /// <returns>Returns the tree node that contains key. </returns>
        public abstract TNode Search(TNode root, TKey key);

        /// <summary>
        /// Updates the tree node of the specified key with the new given value. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which update operation should be started.</param>
        /// <param name="key">Specifies the key of the node whose value should be updated.</param>
        /// <param name="value">Specifies the new value. </param>
        /// <returns>true in case of success and false otherwise.</returns>
        public abstract bool Update(TNode root, TKey key, TValue value);

        public abstract TNode FindMin(TNode root);

        public abstract TNode FindMax(TNode root);

        /// <summary>
        /// Implements a binary search tree insert. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which insert operation should be started.</param>
        /// <param name="newNode">New node to be inserted in the tree. </param>
        /// <returns>New root of the tree (might or might not change during operation).</returns>
        internal TNode Insert_BST(TNode root, TNode newNode)
        {
            if (root == null) /* This is the case where there is no node in the tree, and newNode is the first one. */
            {
                root = newNode;
                root.Parent = default(TNode);
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
        /// Builds a binary search tree to include the given nodes.
        /// </summary>
        /// <param name="nodes">Is a list of nodes to be inserted in the tree.</param>
        /// <returns>Root of the tree.</returns>
        internal TNode Build_BST(List<TNode> nodes)
        {
            foreach (TNode node in nodes)
            {
                _root = Insert(_root, node);
            }
            return _root;
        }

        /// <summary>
        /// Searches for the given key in a binary search tree. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which search operation should be started. </param>
        /// <param name="key">Specifies the key to be searched. </param>
        /// <returns>Returns the tree node that contains key. </returns>
        internal TNode Search_BST(TNode root, TKey key)
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
                return Search_BST(root.RightChild, key);
            }

            return Search_BST(root.LeftChild, key);
        }

        /// <summary>
        /// Updates the tree node of the specified key with the new given value. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which insert operation should be started.</param>
        /// <param name="key">Specifies the key to be updated.</param>
        /// <param name="value">Specifies the new value of the key.</param>
        /// <returns>True in case the operation was successful, and false otherwise. </returns>
        internal bool Update_BST(TNode root, TKey key, TValue value)
        {
            TNode node = Search(root, key); /* Since relies on Search, its time and space complexities are directly driven from Search() operation. */
            if (node != null)
            {
                node.Value = value;
                return true;
            }
            return false;
        }

        internal TNode Delete_BST(TNode root, TKey key)
        {
            if (root == null)
            {
                return root;
            }

            if (root.Key.CompareTo(key) < 0)
            {
                root.RightChild = Delete_BST(root.RightChild, key);
            }
            else if (root.Key.CompareTo(key) > 0)
            {
                root.LeftChild = Delete_BST(root.LeftChild, key);
            }
            else if (root.Key.CompareTo(key) == 0) // The key is found
            {
                if (root.RightChild == null && root.LeftChild == null)
                {
                    return default(TNode);
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
                /* From definition of FindMin() it is obvious that the replacement node [rightChildMin] has less than 2 children. */
                TNode rightChildMin = FindMin_BST(root.RightChild);
                root.Key = rightChildMin.Key;
                root.Value = rightChildMin.Value;
                root.RightChild = Delete_BST(root.RightChild, rightChildMin.Key); /* at this point both node, and rightChildMin have the same keys, but calling delete on the same key, will only result in the removal  of rightChildMin, because pf the root that is passed to Delete.*/
            }
            return root;
        }

        /// <summary>
        /// Finds the node with the smallest key in a binary search tree.
        /// </summary>
        /// <param name="root">Is the node at which the search starts. </param>
        /// <returns>The tree node with the smallest key. </returns>
        internal TNode FindMin_BST(TNode root)
        {
            if (root == null)
            {
                throw new ArgumentNullException();
            }

            TNode node = root;
            while (node.LeftChild != null)
            {
                node = node.LeftChild;
            }
            return node;
        }

        /// <summary>
        /// Finds the node with the largest key in a binary search tree.
        /// </summary>
        /// <param name="root">Is the node at which the search starts. </param>
        /// <returns>The tree node with the largest key.</returns>
        internal TNode FindMax_BST(TNode root)
        {
            if (root == null)
            {
                throw new ArgumentNullException();
            }

            TNode node = root;
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
        /// <param name="node">Is the node at which rotation happens.</param>
        [TimeComplexity(Case.Average, "O(1)")]
        public TNode RotateLeft(TNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            if (node.RightChild == null)
            {
                throw new Exception("While rotating left, the new parent can not be null.");
            }

            var nodeParent = node.Parent;
            var newNode = node.RightChild; /* This will be node's new parent. */

            /* Since the node is losing its right child, we need to select a new right child. The left child of node's right child is a perfect candidate for this position to preserve tree's order properties.*/
            node.RightChild = newNode.LeftChild;
            if (node.RightChild != null)
            {
                node.RightChild.Parent = node;
            }

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
            return newNode;
        }

        /// <summary>
        /// Rotates the tree to right at the given node. Meaning that the current left child of the given node will be its new parent.
        /// Also notice that in rotation, keys or values of a node never change, only the relations change.
        /// </summary>
        /// <param name="node">Is the node at which rotation happens.</param>
        [TimeComplexity(Case.Average, "O(1)")]
        public TNode RotateRight(TNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            if (node.LeftChild == null)
            {
                throw new Exception("While rotating right, the new parent can not be null.");
            }

            var nodeParent = node.Parent;
            var newNode = node.LeftChild; /* This will be node's new parent. */

            /* Since node is losing its left child, we need to select a new left child. The right child of node's left child is the perfect candidate for this position to preserve tree's order properties.*/
            node.LeftChild = newNode.RightChild;
            if (node.LeftChild != null)
            {
                node.LeftChild.Parent = node;
            }

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
            return newNode;
        }

        public TNode DeleteMin(TNode root)
        {
            TNode minNode = FindMin(root);
            return Delete(root, minNode.Key);
        }

        public TNode DeleteMax(TNode root)
        {
            TNode maxNode = FindMax(root);
            return Delete(root, maxNode.Key);
        }

        /// <summary>
        /// Computes all the paths from the given node to all of its leaves. A node is a leaf if it has no children.
        /// </summary>
        /// <param name="startNode">Is the node at which computing all routes/paths to leaf nodes starts.</param>
        /// <returns>List of all the paths.</returns>
        public virtual List<List<TNode>> GetAllPathToLeaves(TNode startNode)
        {
            if (startNode == null)
            {
                return new List<List<TNode>>();
            }

            var paths = new List<List<TNode>>();
            List<List<TNode>> leftPaths = GetAllPathToLeaves(startNode.LeftChild);
            List<List<TNode>> rightPaths = GetAllPathToLeaves(startNode.RightChild);

            for (int i = 0; i < leftPaths.Count; i++)
            {
                var newPath = new List<TNode> { startNode };
                newPath.AddRange(leftPaths[i]);
                paths.Add(newPath);
            }
            for (int i = 0; i < rightPaths.Count; i++)
            {
                var newPath = new List<TNode> { startNode };
                newPath.AddRange(rightPaths[i]);
                paths.Add(newPath);
            }

            if (paths.Count == 0)
            {
                paths.Add(new List<TNode> { startNode });
            }

            return paths;
        }

        /// <summary>
        /// Traverses tree in order, and since this is a binary search tree, in order traversal returns a sorted list of keys.
        /// </summary>
        /// <param name="root">Is the node at which in order traversal starts. </param>
        /// <param name="inOrderSetOfNodes">Is the sorted list of nodes.</param>
        public void InOrderTraversal(TNode root, List<TNode> inOrderSetOfNodes)
        {
            if (root != null)
            {
                InOrderTraversal(root.LeftChild, inOrderSetOfNodes);
                inOrderSetOfNodes.Add(root);
                InOrderTraversal(root.RightChild, inOrderSetOfNodes);
            }
        }
    }
}
