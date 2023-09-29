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
            Root = DeleteHelper(Root, value);
        }

        private Node DeleteHelper(Node root, int value)
        {
            if (root == null)
            {
                return root;
            }
            if (value < root.Value)
            {
                root.Left = DeleteHelper(root.Left, value);
            }
            else if (value > root.Value)
            {
                root.Right = DeleteHelper(root.Right, value);
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }
                root.Value = FindMinValue(root.Right);
                root.Right = DeleteHelper(root.Right, root.Value);
            }
            return root;
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

    //public class BinaryHeap
    //{
    //    private List<int> heap;

    //    public BinaryHeap()
    //    {
    //        heap = new List<int>();
    //    }

    //    public void Insert(int value)
    //    {
    //        heap.Add(value);
    //        BubbleUp(heap.Count - 1);
    //    }

    //    private void BubbleUp(int index)
    //    {
    //        int parentIndex = (index - 1) / 2;
    //        if (index > 0 && heap[index] > heap[parentIndex])
    //        {
    //      //      Swap(index, parentIndex);
    //            BubbleUp(parentIndex);
    //        }
    //    }

    //}
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            int[] bstValues = { 5, 3, 7, 2, 4, 6, 8,9 };

            foreach (int value in bstValues)
            {
                bst.Insert(value);
            }

            bst.Plot();

            //bst.Delete(4);
            //bst.Balance();

          //  bst.Plot();

        //  BinaryHeap heap = new BinaryHeap();
            int[] heapValues = {  24,15,12,23,1,10,16,67};

            foreach (int value in heapValues)
            {
                
                bst.Insert(value);
            }

            bst.Balance();
          //  bst.Plot();
            bst.Delete(5);
            bst.Delete(8);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

         //   bst.Balance();
         //   bst.Sort();
            bst.Plot();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            bst.Delete(9);
            bst.Delete(6);
            //bst.Delete(2);
            //bst.Delete(1);
            bst.Balance();
           // bst.Sort();

            bst.Plot();
            //bst = heap;
            //heap.Plot();
            Console.ReadLine();
        }
    }
}