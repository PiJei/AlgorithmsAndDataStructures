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
    public abstract class BinarySearchTreeBase<T, T1, T2> where T : ITreeNode<T, T1, T2> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Is the root of the binary search tree.
        /// </summary>
        protected T _root { get; set; } = default(T);

        /// <summary>
        /// Builds the tree to include the given nodes.
        /// </summary>
        /// <param name="nodes">Is a list of nodes to be inserted in the tree.</param>
        /// <returns>Root of the tree.</returns>
        public abstract T Build(List<T> nodes);

        /// <summary>
        /// Inserts a new node in the tree
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which insert operation should be started.</param>
        /// <param name="newNode">New node to be inserted in the tree. </param>
        /// <returns>New root of the tree (might or might not change during operation).</returns>
        public abstract T Insert(T root, T newNode);

        /// <summary>
        /// Deletes a node with the given key from th tree.
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which delete operation should be started. </param>
        /// <param name="key">Specifies the key of the node to be deleted. </param>
        /// <returns>New root of the tree (might or might not change during the operation).</returns>
        public abstract T Delete(T root, T1 key);

        /// <summary>
        /// Searches for the given key in the tree. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which search operation should be started. </param>
        /// <param name="key">Specifies the key to be searched. </param>
        /// <returns>Returns the tree node that contains key. </returns>
        public abstract T Search(T root, T1 key);

        /// <summary>
        /// Updates the tree node of the specified key with the new given value. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which update operation should be started.</param>
        /// <param name="key">Specifies the key of the node whose value should be updated.</param>
        /// <param name="value">Specifies the new value. </param>
        /// <returns>true in case of success and false otherwise.</returns>
        public abstract bool Update(T root, T1 key, T2 value);

        public abstract T FindMin(T root);

        public abstract T FindMax(T root);

        /// <summary>
        /// Implements a binary search tree insert. 
        /// </summary>
        /// <param name="root">Current root of the tree, or the node at which insert operation should be started.</param>
        /// <param name="newNode">New node to be inserted in the tree. </param>
        /// <returns>New root of the tree (might or might not change during operation).</returns>
        protected T Insert_BST(T root, T newNode)
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
        /// Builds a binary search tree to include the given nodes.
        /// </summary>
        /// <param name="nodes">Is a list of nodes to be inserted in the tree.</param>
        /// <returns>Root of the tree.</returns>
        protected T Build_BST(List<T> nodes)
        {
            foreach(T node in nodes)
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
        protected T Search_BST(T root, T1 key)
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
        internal bool Update_BST(T root, T1 key, T2 value)
        {
            T node = Search(root, key); /* Since relies on Search, its time and space complexities are directly driven from Search() operation. */
            if (node != null)
            {
                node.Value = value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Finds the node with the smallest key in a binary search tree.
        /// </summary>
        /// <param name="root">Is the node at which the search starts. </param>
        /// <returns>The tree node with the smallest key. </returns>
        public T FindMin_BST(T root)
        {
            if (root == null) throw new ArgumentNullException();

            T node = root;
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
        public T FindMax_BST(T root)
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
        /// <param name="node">Is the node at which rotation happens.</param>
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
        /// <param name="node">Is the node at which rotation happens.</param>
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

        public T DeleteMin(T root)
        {
            T minNode = FindMin(root);
            return Delete(root, minNode.Key);
        }

        public T DeleteMax(T root)
        {
            T maxNode = FindMax(root);
            return Delete(root, maxNode.Key);
        }

        /// <summary>
        /// Computes all the paths from the given node to all of its leaves. A node is a leaf if it has no children.
        /// </summary>
        /// <param name="startNode">Is the node at which computing all routes/paths to leaf nodes starts.</param>
        /// <returns>List of all the paths.</returns>
        public List<List<T>> GetAllPathToLeaves(T startNode)
        {
            if (startNode == null)
            {
                return new List<List<T>>();
            }

            List<List<T>> paths = new List<List<T>>();
            List<List<T>> leftPaths = GetAllPathToLeaves(startNode.LeftChild);
            List<List<T>> rightPaths = GetAllPathToLeaves(startNode.RightChild);

            for (int i = 0; i < leftPaths.Count; i++)
            {
                var newPath = new List<T>();
                newPath.Add(startNode);
                newPath.AddRange(leftPaths[i]);
                paths.Add(newPath);
            }
            for (int i = 0; i < rightPaths.Count; i++)
            {
                var newPath = new List<T>();
                newPath.Add(startNode);
                newPath.AddRange(rightPaths[i]);
                paths.Add(newPath);
            }

            if (paths.Count == 0)
            {
                paths.Add(new List<T> { startNode });
            }

            return paths;
        }

        /// <summary>
        /// Traverses tree in order, and since this is a binary search tree, in order traversal returns a sorted list of keys.
        /// </summary>
        /// <param name="root">Is the node at which in order traversal starts. </param>
        /// <param name="inOrderSetOfNodes">Is the sorted list of nodes.</param>
        public void InOrderTraversal(T root, List<T> inOrderSetOfNodes)
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
