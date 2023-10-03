using System;
using System.Collections.Generic;

namespace ConsoleApp10
{



    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class BinarySearchTree
    {
        public Node Root;

        public BinarySearchTree()
        {
            Root = null;
        }

        public void Insert(int value)
        {
            Root = InsertHelper(Root, value);
        }

        private Node InsertHelper(Node root, int value)
        {
            if (root == null)
            {
                return new Node(value);
            }
            else if (value < root.Value)
            {
                root.Left = InsertHelper(root.Left, value);
            }
            else
            {
                root.Right = InsertHelper(root.Right, value);
            }
            return root;
        }

        public Node Search(int value)
        {
            return SearchHelper(Root, value);
        }

        private Node SearchHelper(Node root, int value)
        {
            if (root == null || root.Value == value)
            {
                return root;
            }
            if (value < root.Value)
            {
                return SearchHelper(root.Left, value);
            }
            return SearchHelper(root.Right, value);
        }

        public void Delete(int value)
        {
            Root = DeleteRecursive(Root, value);
        }


        private Node DeleteRecursive(Node current, int value)
        {
            if (current == null)
            {
                return null;
            }
            if (value == current.Value)
            {
                // Case 1: no children
                if (current.Left == null && current.Right == null)
                {
                    return null;
                }
                // Case 2: only 1 child; 5 -- 7 -- 6 ==> 5 -- 6
                if (current.Right == null)
                {
                    return current.Left;
                }
                if (current.Left == null)
                {
                    return current.Right;
                }
                // Case 3: 2 children; 5 -- 7 -- 8     5 -- 8 -- 7     5 -- 8
                //                        |      ==>      |      ==>      |
                //                        6               6               6
                int smallestValue = findSmallestValue(current.Right);
                current.Value = smallestValue;
                current.Right = DeleteRecursive(current.Right, smallestValue);
                return current;
            }
            if (value < current.Value)
            {
                current.Left = DeleteRecursive(current.Left, value);
                return current;
            }
            current.Right = DeleteRecursive(current.Right, value);
            return current;
        }

        private int findSmallestValue(Node root)
        { return root.Left == null ? root.Value : findSmallestValue(root.Left);
        }
        private int FindMinValue(Node node)
        {
            int minValue = node.Value;
            while (node.Left != null)
            {
                minValue = node.Left.Value;
                node = node.Left;
            }
            return minValue;
        }

        public void Balance()
        {
            List<int> values = new List<int>();
            InOrderTraversal(Root, values);
            Root = BalanceHelper(values, 0, values.Count - 1);
        }

        private void InOrderTraversal(Node root, List<int> values)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left, values);
                values.Add(root.Value);
                InOrderTraversal(root.Right, values);
            }
        }

        private Node BalanceHelper(List<int> values, int low, int high)
        {
            if (low > high)
            {
                return null;
            }
            int mid = (low + high) / 2;
            Node newNode = new Node(values[mid]);
            newNode.Left = BalanceHelper(values, low, mid - 1);
            newNode.Right = BalanceHelper(values, mid + 1, high);
            return newNode;
        }

        public void Plot()
        {
            PlotHelper(Root, 0);
        }

        private void PlotHelper(Node node, int level)
        {
            if (node != null)
            {
                PlotHelper(node.Right, level + 1);
                Console.WriteLine(new string(' ', level * 4) + node.Value);
                PlotHelper(node.Left, level + 1);
            }
        }
        public void Sort()
        {
            List<int> sortedValues = new List<int>();
            InOrderTraversal(Root, sortedValues);
            Console.WriteLine("Sorted values: " + string.Join(", ", sortedValues));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
           // int[] bstValues = { 5, 3, 7, 2, 4, 6, 8,9 };
           int[] bstValues = { 17, 6, 5, 20, 19, 18, 11, 14, 12, 13, 2, 4, 10 };  
            Console.WriteLine("Добавление ");
            foreach (int value in bstValues)
            {
                bst.Insert(value);
           
            }
            Console.WriteLine("BINARY"+bst);
            bst.Plot();
            Console.WriteLine("Балансировка");
            bst.Balance();
            bst.Plot();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Удаление 5");
            bst.Delete(5);
            bst.Plot();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Удаление 8");
            bst.Delete(8);
            bst.Plot();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Вывод");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Удаление 9");
            bst.Delete(9);
            bst.Plot();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Удаление 6");
            bst.Delete(6);
            bst.Plot();
            Console.WriteLine("Балансировка");
            bst.Balance();
            bst.Plot();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Вывод");
            bst.Plot();
            Console.WriteLine("Добавление AVLTree");

            AVLTree avl = new AVLTree();
             int[] bstValuesы = { 17, 6, 5, 20, 19, 18, 11, 14, 12, 13, 2, 4, 10 };

            foreach (int value in bstValuesы)
            {
                avl.Insert(value);

            }
            Console.WriteLine("Вывод AVLTree");
            avl.Plot();
            Console.ReadLine();
        }
    }
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
            return GetHeight(node.Left) - GetHeight(node.Right);
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

        public void Plot()
        {
            PlotHelper(root, 0);
        }
        private void PlotHelper(AVLNode node, int level)
        {
            if (node != null)
            {
                PlotHelper(node.Right, level + 1);
                Console.WriteLine(new string(' ', level * 4) + node.Key);
                PlotHelper(node.Left, level + 1);
            }
        }
    }
}