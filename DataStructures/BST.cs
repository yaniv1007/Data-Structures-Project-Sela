using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class BST<T> where T : IComparable<T>, IComparer<T>
    {
        Node root = null;

        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node(value);
                return;
            }

            Node tmp = root;

            while (true)
            {
                if (value.CompareTo(tmp.value) < 0)
                {
                    if (tmp.left == null)
                    {
                        tmp.left = new Node(value);
                        break;
                    }
                    else tmp = tmp.left;
                }
                else
                {
                    if (tmp.right == null)
                    {
                        tmp.right = new Node(value);
                        break;
                    }
                    else tmp = tmp.right;
                }
            }
        }
        public bool IsEmpty()
        {
            if (root == null)
                return true;
            else
                return false;

        }
        public bool Search(T itemToFind)
        {
            if (IsEmpty())
            {
                return false;
            }
            else
            {
                Node tmp = root;

                while (itemToFind.CompareTo(tmp.value) != 0)
                {
                    if (itemToFind.CompareTo(tmp.value) < 0)
                    {
                        if (tmp.left != null)
                        {
                            tmp = tmp.left;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (tmp.right != null)
                        {
                            tmp = tmp.right;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }
        public bool FindClosest(T itemToFind, out T closestItem)
        {
            closestItem = default;

            if (IsEmpty())
            {
                return false;
            }

            closestItem = root.value;
            Node tmp = root;

            if (IsEmpty()) return false;

            while (itemToFind.CompareTo(tmp.value) != 0)
            {
                if (itemToFind.CompareTo(tmp.value) < 0)
                {
                    if (tmp.left != null)
                    {
                        if (itemToFind.Compare(itemToFind, closestItem)
                            > itemToFind.Compare(itemToFind, tmp.left.value))
                        {
                            closestItem = tmp.left.value;
                        }

                        tmp = tmp.left;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if (tmp.right != null)
                    {
                        if (itemToFind.Compare(itemToFind, closestItem)
                            > itemToFind.Compare(itemToFind, tmp.right.value))
                        {
                            closestItem = tmp.right.value;
                        }

                        tmp = tmp.right;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return true;
        }

        public void PrintInOrder()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No Distribution Points Added");
            }
            else
            {
                PrintInOrder(root);
            }

            Console.WriteLine();
        }
        private void PrintInOrder(Node tmp)
        {
            if (tmp.left != null)
            {
                PrintInOrder(tmp.left);
            }

            Console.WriteLine(tmp.value);

            if (tmp.right != null)
            {
                PrintInOrder(tmp.right);
            }

        }

        class Node
        {
            public T value;
            public Node left;
            public Node right;

            public Node(T value)
            {
                this.value = value;
            }
        }
    }
}

