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

using CSFundamentals.DataStructures.Trees.API;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

//TODO: Shall inherit from BinarySearchTree

namespace CSFundamentals.DataStructures.Trees
{
    public class AVLTree<T1, T2> : BinarySearchTreeBase<AVLTreeNode<T1, T2>, T1, T2> where T1 : IComparable<T1>
    {
        public override AVLTreeNode<T1, T2> Build(List<AVLTreeNode<T1, T2>> nodes)
        {
            return Build_BST(nodes);
        }

        public override AVLTreeNode<T1, T2> Delete(AVLTreeNode<T1, T2> root, T1 key)
        {
            throw new NotImplementedException();
            //TODO
        }

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

        public int ComputeBalanceFactor(AVLTreeNode<T1,T2> node)
        {
            return  (node.RightChild == null ? 0 : GetHeight(node.RightChild)) - (node.LeftChild == null ? 0 : GetHeight(node.LeftChild));
        }

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
    }
}
