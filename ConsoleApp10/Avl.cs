using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Avl
    {
        public class AVLNode
        {
            public int Key;
            public AVLNode Left;
            public AVLNode Right;
            public int Height;
            public AVLNode(int key)
            {
                Key = key;
                Left = null;
                Right = null;
                Height = 1;
            }
        }
        public class AVLTree
        {
            private AVLNode root;
            public AVLTree()
            {
                root = null;
            }
            public void Insert(int key)
            {
                root = InsertHelper(root, key);
            }
            private AVLNode InsertHelper(AVLNode node, int key)
            {
                if (node == null)
                    return new AVLNode(key);
                if (key < node.Key)
                    node.Left = InsertHelper(node.Left, key);
                else
                    node.Right = InsertHelper(node.Right, key);
                node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
                int balanceFactor = GetBalanceFactor(node);
                if (balanceFactor > 1)
                {
                    if (key < node.Left.Key)
                        return RotateRight(node);
                    else
                    {
                        node.Left = RotateLeft(node.Left);
                        return RotateRight(node);
                    }
                }
                if (balanceFactor < -1)
                {
                    if (key > node.Right.Key)
                        return RotateLeft(node);
                    else
                    {
                        node.Right = RotateRight(node.Right);
                        return RotateLeft(node);
                    }
                }
                return node;
            }
            private int GetHeight(AVLNode node)
            {
                if (node == null)
                    return 0;
                return node.Height;
            }
            private int GetBalanceFactor(AVLNode node)
            {
                if (node == null)
                    return 0;
                return GetHeight(node.Left) - GetHeight(node.Right)  ;
            }
            private AVLNode RotateLeft(AVLNode z)
            {
                AVLNode y = z.Right;
                AVLNode T3 = y.Left;
                y.Left = z;
                z.Right = T3;
                z.Height = 1 + Math.Max(GetHeight(z.Left), GetHeight(z.Right));
                y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));
                return y;
            }
            private AVLNode RotateRight(AVLNode z)
            {
                AVLNode y = z.Left;
                AVLNode T2 = y.Right;
                y.Right = z;
                z.Left = T2;
                z.Height = 1 + Math.Max(GetHeight(z.Left), GetHeight(z.Right));
                y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));
                return y;
            }
        }

    }
}
