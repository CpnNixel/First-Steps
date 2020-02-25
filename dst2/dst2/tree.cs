using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dst2
{
    class BinarySearchTree
    {
        public Node root;

        public BinarySearchTree()
        {
            root = null;
        }
        public void ContainsBBST(Node T, Node S)
        {
            Console.WriteLine("\nElements of the frist tree:");
            foreach (int lol in kekz(T))
            {
                Console.Write(lol+" ");
            }
            Console.WriteLine("\nElements of the second tree:");
            foreach(int lol in kekz(S))
            {
                Console.Write(lol+" ");
            }
            bool isSubset = !kekz(S).Except(kekz(T)).Any();
            Console.WriteLine("\nIf all keys of BBST2 are contained in BBST1. If so it returns true, otherwise false.");
            Console.WriteLine(isSubset);
        }

        //разность между нодами и  листьям
        /*
            считаем кол-во нодов;
            считаем кол-во листьев;

            разность = узлы - листья;
             
             */
        public void Doping(Node root)
        {
            int nodes = size(root);
            int leaves = leaf(root);
            
            Console.WriteLine(nodes-leaves);
        }
        public int size()
        {
            return size(root);
        }

        public static int size(Node node)
        {
            if (node == null) return 0;
            else return (size(node.left) + 1 + size(node.right));
        }
        public int LeafCount
        {
            get { return leaf(root); }   
        }
        public int leaf(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }
            else
            {
                return leaf(root.left) + leaf(root.right);
            }
        }
        /////////////////////////////
        
        
        //bst to sorted array
        public int[] kekz(Node root)
        {
            int[] array = new int[size(root)];
            int index = 0;
            //stores tree elements in created array
            void storeInOrder(Node root2)
            {
                if (root2 == null)
                    return;
                storeInOrder(root2.left);
                array[index++] = root2.data;
                storeInOrder(root2.right);
            }
            storeInOrder(root);
            return array;
        }



        public void Balance(Node root)
        {
            //////////////////////////////////
            Node sortedArrayToBST(int[] arr, int start, int end) 
            { 
                if (start > end) 
                { 
                    return null; 
                } 
            //Middle element - root
            int mid = (start + end) / 2; 
            Node node = new Node(arr[mid]);

             //construct left subtree == left child of root 
                node.left = sortedArrayToBST(arr, start, mid - 1); 
             //construct right subtree == right child of root 
                node.right = sortedArrayToBST(arr, mid + 1, end); 
            return node; 
            }
            ///////////////////////////////
            int len = kekz(root).Length - 1;

            Console.WriteLine("\nPreorder tree traversal:");
            PreO(sortedArrayToBST(kekz(root), 0, len));
            Console.WriteLine("\nIn-order tree traversal:");
            InO(sortedArrayToBST(kekz(root), 0, len));
            Console.WriteLine("\nPostorder tree traversal:");
            PoO(sortedArrayToBST(kekz(root), 0,len));
        }

        //preorder
        static void PreO(Node root)
        {
            Console.Write(root.data + " ");
            if (root.left != null)
            {
                PreO(root.left);
            }
            if (root.right != null)
            {
                PreO(root.right);
            }
        }
        //postorder
        static void PoO(Node root)
        {
            if (root != null)
            {
                PoO(root.left);
                PoO(root.right);

                Console.Write(root.data + " ");

            }
        }
        //inorder
        static void InO(Node root)
        {
            if (root != null)
            {
                InO(root.left);
                Console.Write(root.data + " ");
                InO(root.right);
            }
        }

        public bool IsEmpty(Node root)
        {
            if (root == null) return true;
            else return false;
        }
        public Node search(Node root, int x)
        {
            if (root.data == x)
            {
                return root;

            }
            if(root.data < x)
            {
                return search(root.right, x);
            }
           else return search(root.left, x);
            
        }
        public  bool isFull(Node root)
        {
            if ((root.left == null && root.right == null))
            {
                return true;
            }
            if ((root.left != null && root.right != null))
            {
                return isFull(root.left)&&isFull(root.right);
            }
            
                return false;
        }

        public int maxDepth(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                //calculating branch's height
                int lDepth = maxDepth(node.left);
                int rDepth = maxDepth(node.right);

                //return the larger one
                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }
        }
        public void deleteKey(int key)
        {
            root = deleteRec(root, key);
        }
        Node deleteRec(Node root, int key)
        {
            //if the tree is empty
            if (root == null) return root;

            //else finding element
            if (key < root.data)
                root.left = deleteRec(root.left, key);
            else if (key > root.data)
                root.right = deleteRec(root.right, key);

            // if key is
            else
            {
                // one child or no child  
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                // node with two children
                root.data = minValue(root.right);

                // Delete the inorder successor  
                root.right = deleteRec(root.right, root.data);
            }
            return root;
        }



        public int minValue(Node root)
        {
            int minv = root.data;
            while (root.left != null)
            {
                minv = root.left.data;
                root = root.left;
            }
            return minv;
        }


        
        public void insert(int key)
        {
            root = insertRec(root, key);
        }
        Node insertRec(Node root, int key)
        {

            //if tree is empty
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            
            if (key < root.data)
                root.left = insertRec(root.left, key);
            else if (key > root.data)
                root.right = insertRec(root.right, key);

            /* return the (unchanged) node pointer */
            return root;
        }
        ///////////////*POST-ORDER*/////////////////////////////
        public void postorder()
        {
            postorderRec(root);
        }
        void postorderRec(Node root)
        {
            if (root != null)
            {
                postorderRec(root.left);
                postorderRec(root.right);

                Console.Write(root.data + " ");

            }
        }
        ///////////////*PRE-ORDER*/////////////////////////////
        public void preorder()
        {
            preorderRec(root);
        }
        void preorderRec(Node root)
        {
            Console.Write(root.data + " ");
            if (root.left != null)
            {
                preorderRec(root.left);
            }
            if(root.right != null)
            {
                preorderRec(root.right);
            }

        }
        ///////////////*IN-ORDER*/////////////////////////////
        public void inorder()
        {
            inorderRec(root);
        }

        void inorderRec(Node root)
        {
            if (root != null)
            {
                inorderRec(root.left);
                Console.Write(root.data + " ");
                inorderRec(root.right);
            }
        }

    }
}
