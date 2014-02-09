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
//else if n.Data < n.Parent.Data
//  result = n.Parent
//else
//  while (n is a righ child of parent)
//  {
//     n = n.parent
//  }
//  result = n.Parent;

//return result; 

namespace InOrderSuccessor
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        Node GetInOrderSuccessor(Node n)
        {
            if (n == null)
            {
                return null;
            }

            if (n.Right != null)
            {
                return LeftMostChild(n.Right);
            }

            if (n.Parent != null)
            {
                // n is left child so next node will be parent
                if (n.Data < n.Parent.Data)
                {
                    return n.Parent;
                }
                else
                {
                    // n is right child but with no right subtree
                    // so go up one level and get the parent's parent
                    // For example, in above diagram for 13, the inorder
                    // successor is 14 which is 2 levels up.
                    while (n.Data >= n.Parent.Data)
                    {
                        n = n.Parent;
                    }

                    return n.Parent;
                }
            }

            return null;
        }

        Node LeftMostChild(Node n)
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
        public int Data { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public Node Parent { get; set; }
    }
}
