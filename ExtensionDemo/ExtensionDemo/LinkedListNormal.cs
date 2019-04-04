using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExtensionDemo
{
    public class LinkedListNormal
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

        /// <summary>
        /// Adds the newNum after the first occurrence of num in list
        /// </summary>
        /// <param name="num"></param>
        /// <param name="newNum"></param>
        public void AddAfter(int num, int newNum)
        {
            var currentNode = root;
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
                tail = newNode;
            }
            else
            {
                newNode.next = currentNode.next;
            }

            currentNode.next = newNode;
            count++;
        }

        /// <summary>
        /// Adds newNum before the first occurrence of num in list
        /// </summary>
        /// <param name="num"></param>
        /// <param name="newNum"></param>
        public void AddBefore(int num, int newNum)
        {
            var currentNode = root;
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
                root = newNode;
            }
            else
            {
                newNode.next = previousNode.next;
                previousNode.next = newNode;
            }

            count++;
        }

        /// <summary>
        /// Add num to LinkedList in the root position
        /// </summary>
        /// <param name="num"></param>
        public void AddFirst(int num)
        {
            if (root == null)
            {
                root = new Node(num);
                tail = root;
            }
            else
            {
                var newNode = new Node(num);
                newNode.next = root;
                root = newNode;
            }

            count++;
        }

        /// <summary>
        /// Add num to LinkedList in the tail position
        /// </summary>
        /// <param name="num"></param>
        public void AddLast(int num)
        {
            if (root == null)
            {
                root = new Node(num);
                tail = root;
            }
            else
            {
                tail.next = new Node(num);
                tail = tail.next;
            }

            count++;
        }

        /// <summary>
        /// Drops all elements of LinkedList
        /// </summary>
        public void Clear()
        {
            var currentNode = root;
            while (currentNode != null)
            {
                var previousNode = currentNode;
                currentNode = currentNode.next;
                previousNode.next = null;
            }

            root = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// Checks to see whether num is contained in list
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Contains(int num)
        {
            var currentNode = root;

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
        public bool Remove(int num)
        {
            var removed = false;
            var currentNode = root;

            if (currentNode.value == num)
            {
                removed = removeFirstNode();
            }
            else
            {
                removed = removeMiddleOrLastElement(num);
            }

            if (removed)
            {
                count--;
            }
            return removed;
        }

        internal bool removeFirstNode()
        {
            var firstNode = root;

            root = root.next;
            firstNode.next = null;

            if (count == 1)
            {
                tail = null;
            }

            return true;
        }

        internal bool removeMiddleOrLastElement(int num)
        {
            var removed = false;
            var currentNode = root;
            Node previousNode = null;
            while (currentNode != null && currentNode.value != num)
            {
                previousNode = currentNode;
                currentNode = currentNode.next;
            }

            if (currentNode != null)
            {
                previousNode.next = currentNode.next;

                if (currentNode.next == null && currentNode.value == tail.value)
                {
                    tail = previousNode;
                }
                currentNode.next = null;

                removed = true;
            }

            return removed;
        }
    }
}
