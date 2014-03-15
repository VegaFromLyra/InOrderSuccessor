using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write an algorithm to find next node of a given node (in-order succesor) in a binary search tree.
//Assume that each node has link to its parent


//     8
// 4      10
//     9     14
//        12    15
//           13 

//4 - 8 - 9 - 10 - 12 - 13 - 14 - 15

//Input: 10
//Output: 12

//Input:13
//Output: 14

//Input:9
//Output: 10

//if n has a right subtree
//  result = left most node of right subtree
//else
//  while (n is a right child of parent AND n is not null)
//  {
//     n = n.parent
//  }

//   if (n is null)
//      return null
//
//  result = n.Parent;
//return result; 

namespace InOrderSuccessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(8);
            root.Left = new Node(4);
            root.Right = new Node(10);
            root.Left.Parent = root;
            root.Right.Parent = root;

            root.Right.Left = new Node(9);
            root.Right.Right = new Node(14);
            root.Right.Left.Parent = root.Right;
            root.Right.Right.Parent = root.Right;

            root.Right.Right.Left = new Node(12);
            root.Right.Right.Right = new Node(15);
            root.Right.Right.Left.Parent = root.Right.Right;
            root.Right.Right.Right.Parent = root.Right.Right;

            root.Right.Right.Left.Right = new Node(13);
            root.Right.Right.Left.Right.Parent = root.Right.Right.Left;

            Console.WriteLine("InOrder successor of 10 is");
            Node result = GetInOrderSuccessor(root.Right);

            if (result != null)
            {
                Console.WriteLine(result.Data);
            }
            else
            {
                Console.WriteLine("null");
            }

            Console.WriteLine("InOrder successor of 13 is");
            result = GetInOrderSuccessor(root.Right.Right.Left.Right);

            if (result != null)
            {
                Console.WriteLine(result.Data);
            }
            else
            {
                Console.WriteLine("null");
            }

            Console.WriteLine("InOrder successor of 15 is");
            result = GetInOrderSuccessor(root.Right.Right.Right);

            if (result != null)
            {
                Console.WriteLine(result.Data);
            }
            else
            {
                Console.WriteLine("null");
            }

        }

        static Node GetInOrderSuccessor(Node n)
        {
            if (n == null)
            {
                return null;
            }

            if (n.Right != null)
            {
                return LeftMostChild(n.Right);
            }

            while (n != null && n.Parent != null && n.Data >= n.Parent.Data)
            {
                n = n.Parent;
            }

            if (n == null)
            {
                return null;
            }

            return n.Parent;
        }

        static Node LeftMostChild(Node n)
        {
            while (n.Left != null)
            {
                n = n.Left;
            }

            return n;
        }
    }

    class Node
    {
        public Node(int data)
        {
            Data = data;
        }

        public int Data { get; private set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node Parent { get; set; }
    }
}
