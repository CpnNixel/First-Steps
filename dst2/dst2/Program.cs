using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dst2
{
    //
    //10.	ContainsBBST(). It determines if all keys of BBST2 are contained in BBST1.If so it returns true, otherwise false.
    //
    //-	: isEmpty(), isFull(), size(), addItem(), deleteItem(), search(), rintTree_preorder(),printTree_inorder(),printTree_postorder().
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            BinarySearchTree tree2 = new BinarySearchTree();

            while (true)
            {
                Console.WriteLine();
                ShowMenu();
                Console.WriteLine();
                switch (Console.ReadKey(true).Key)
                {

                    case ConsoleKey.F1:
                        tree.Balance(tree.root);
                        break;
                    case ConsoleKey.F2:
                        Console.WriteLine("leaves:"+tree.LeafCount);
                        tree.Doping(tree.root);
                        break;


                    case ConsoleKey.D1:
                        Console.WriteLine("\n\n Enter the number of elements you want to insert");
                        int x = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nEnter {0} elements",x);
                        for(int i = 0; i < x; i++)
                        {
                            tree.insert(Convert.ToInt32(Console.ReadLine()));
                        }                        
                    break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Enter the element you want to remove");
                        tree.deleteKey(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("The number of all nodes: {0}", tree.size());
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Maximum in-height-depth of a tree is: " + tree.maxDepth(tree.root));
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("True - tree is empty, false - tree is filled");
                        Console.WriteLine(tree.IsEmpty(tree.root));
                        break;
                    case ConsoleKey.D6:
                        Console.WriteLine("The minimum data stored in a tree is: " + tree.minValue(tree.root));
                        break;
                    case ConsoleKey.D7:
                        Console.WriteLine("Enter the element you are looking for");
                        int y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("found node is:" + tree.search(tree.root, y).data);
                        break;
                    case ConsoleKey.D8:
                        ///////
                        Console.WriteLine("\nPreorder tree traversal:");
                        tree.preorder();
                        Console.WriteLine("\nIn-order tree traversal:");
                        tree.inorder();
                        Console.WriteLine("\nPostorder tree traversal:");
                        tree.postorder();
                        break;
                    case ConsoleKey.D9:
                        Console.WriteLine("\n10.	ContainsBBST(). It determines if all keys of BBST2 are contained in BBST1. " +
                            "\nIf so it returns true, otherwise false.");
                        Console.WriteLine("\nLets create a second custom BBST");
                        Console.WriteLine("Enter the number of elements you want to insert");
                        int xx = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nEnter {0} elements", xx);
                        for (int i = 0; i < xx; i++)
                        {
                            tree2.insert(Convert.ToInt32(Console.ReadLine()));
                        }
                        //tree.ContainsBBST(tree.root, tree2.root);
                        tree.ContainsBBST(tree.root, tree2.root);
                        break;
                    case ConsoleKey.Escape:
                        return;
                      
                }
            }
        

            Console.ReadKey();
        }
        public static void ShowMenu()
        {
            Console.WriteLine("\nPress 1 to insert to tree");
            Console.WriteLine("Press 2 to delete from tree");
            Console.WriteLine("Press 3 to get number of all nodes");
            Console.WriteLine("Press 4 to get height-depth of the tree");
            Console.WriteLine("Press 5 to isEmpty()");
            Console.WriteLine("Press 6 to get minimum stored data in a tree");
            Console.WriteLine("Press 7 to find a specified Node");
            Console.WriteLine("Press 8 to see all the Traversals");
            Console.WriteLine("Press 9 to ContainsBBST()");

        }
    }
}
