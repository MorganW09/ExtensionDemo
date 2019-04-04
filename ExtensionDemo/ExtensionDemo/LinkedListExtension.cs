using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static ExtensionDemo.LinkedListExtension;

namespace ExtensionDemo
{
    public class LinkedListExtension
    {
        internal Node root { get; set; }
        internal Node tail { get; set; }
        internal int count { get; set; }

        internal class Node
        {
            public int value { get; set; }
            public Node next { get; set; }

            public Node(int value)
            {
                this.value = value;
                next = null;
            }
        }
    }

    public static class LinkedListExtensions
    {
        public static void AddAfter(this LinkedListExtension linkedList, int num, int newNum)
        {
            if (linkedList == null)
            {
                return;
            }

            var currentNode = linkedList.root;
            while (currentNode != null)
            {
                if (currentNode.value == num)
                {
                    break;
                }

                currentNode = currentNode.next;
            }

            if (currentNode == null)
            {
                throw new InvalidOperationException("num is not in the current LinkedList");
            }

            var newNode = new Node(newNum);

            if (currentNode.next == null)
            {
                linkedList.tail = newNode;
            }
            else
            {
                newNode.next = currentNode.next;
            }

            currentNode.next = newNode;
            linkedList.count++;
        }

        /// <summary>
        /// Adds newNum before the first occurrence of num in list
        /// </summary>
        /// <param name="num"></param>
        /// <param name="newNum"></param>
        public static void AddBefore(this LinkedListExtension linkedList, int num, int newNum)
        {
            if (linkedList == null)
            {
                return;
            }

            var currentNode = linkedList.root;
            Node previousNode = null;
            while (currentNode != null && currentNode.value != num)
            {
                previousNode = currentNode;
                currentNode = currentNode.next;
            }

            if (currentNode == null)
            {
                throw new InvalidOperationException("num is not in the current LinkedList");
            }

            var newNode = new Node(newNum);

            if (previousNode == null)
            {
                newNode.next = currentNode;
                linkedList.root = newNode;
            }
            else
            {
                newNode.next = previousNode.next;
                previousNode.next = newNode;
            }

            linkedList.count++;
        }

        /// <summary>
        /// Add num to LinkedList in the root position
        /// </summary>
        /// <param name="num"></param>
        public static void AddFirst(this LinkedListExtension linkedList, int num)
        {
            if (linkedList == null)
            {
                return;
            }

            if (linkedList.root == null)
            {
                linkedList.root = new Node(num);
                linkedList.tail = linkedList.root;
            }
            else
            {
                var newNode = new Node(num);
                newNode.next = linkedList.root;
                linkedList.root = newNode;
            }

            linkedList.count++;
        }

        /// <summary>
        /// Add num to LinkedList in the tail position
        /// </summary>
        /// <param name="num"></param>
        public static void AddLast(this LinkedListExtension linkedList, int num)
        {
            if (linkedList == null)
            {
                return;
            }

            if (linkedList.root == null)
            {
                linkedList.root = new Node(num);
                linkedList.tail = linkedList.root;
            }
            else
            {
                linkedList.tail.next = new Node(num);
                linkedList.tail = linkedList.tail.next;
            }

            linkedList.count++;
        }

        /// <summary>
        /// Drops all elements of LinkedList
        /// </summary>
        public static void Clear(this LinkedListExtension linkedList)
        {
            if (linkedList == null)
            {
                return;
            }

            var currentNode = linkedList.root;
            while (currentNode != null)
            {
                var previousNode = currentNode;
                currentNode = currentNode.next;
                previousNode.next = null;
            }

            linkedList.root = null;
            linkedList.tail = null;
            linkedList.count = 0;
        }

        /// <summary>
        /// Checks to see whether num is contained in list
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool? Contains(this LinkedListExtension linkedList, int num)
        {
            if (linkedList == null)
            {
                return null;
            }

            var currentNode = linkedList.root;

            while (currentNode != null && currentNode.value != num)
            {
                currentNode = currentNode.next;
            }

            if (currentNode != null)
            {
                return currentNode.value == num;
            }

            return false;
        }

        /// <summary>
        /// Attempt to remove num from LinkedList.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool? Remove(this LinkedListExtension linkedList, int num)
        {
            if (linkedList == null)
            {
                return null;
            }

            var removed = false;
            var currentNode = linkedList.root;

            if (currentNode.value == num)
            {
                var firstNode = linkedList.root;

                linkedList.root = linkedList.root.next;
                firstNode.next = null;

                if (linkedList.count == 1)
                {
                    linkedList.tail = null;
                }
                removed = true;
            }
            else
            {
                Node previousNode = null;
                while (currentNode != null && currentNode.value != num)
                {
                    previousNode = currentNode;
                    currentNode = currentNode.next;
                }

                if (currentNode != null)
                {
                    previousNode.next = currentNode.next;

                    if (currentNode.next == null && currentNode.value == linkedList.tail.value)
                    {
                        linkedList.tail = previousNode;
                    }
                    currentNode.next = null;

                    removed = true;
                }
            }

            if (removed)
            {
                linkedList.count--;
            }
            return removed;
        }
    }
}
