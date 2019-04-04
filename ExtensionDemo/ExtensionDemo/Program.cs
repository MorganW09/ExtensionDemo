using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace ExtensionDemo
{
    [MemoryDiagnoser]
    [CsvExporter]
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = null;
            //LinkedListExtension extension = null;
            linkedList.AddFirst(1);
            Console.WriteLine("No Null Pointer Exception");
            Console.ReadKey();
        }

        [Benchmark]
        public void BenchmarkLinkedListDotNet()
        {
            var linkedListDotNet = new LinkedList<int>();
            for (int i = 0; i < 1_000_000; i++)
            {
                if (i % 2 == 0)
                {
                    linkedListDotNet.AddLast(i);
                }
                else
                {
                    linkedListDotNet.AddFirst(i);
                }
            }

            for (int i = 0; i < 1_000_000; i++)
            {
                linkedListDotNet.Remove(i);
            }
        }

        [Benchmark]
        public void BenchmarkLinkedListNormal()
        {
            var linkedListNormal = new LinkedListNormal();
            for (int i = 0; i < 1_000_000; i++)
            {
                if (i % 2 == 0)
                {
                    linkedListNormal.AddLast(i);
                }
                else
                {
                    linkedListNormal.AddFirst(i);
                }
            }

            for (int i = 0; i < 1_000_000; i++)
            {
                linkedListNormal.Remove(i);
            }
        }

        [Benchmark]
        public void BenchmarkLinkedListExtension()
        {
            var linkedListExtension = new LinkedListExtension();
            for (int i = 0; i < 1_000_000; i++)
            {
                if (i % 2 == 0)
                {
                    linkedListExtension.AddLast(i);
                }
                else
                {
                    linkedListExtension.AddFirst(i);
                }
            }

            for (int i = 0; i < 1_000_000; i++)
            {
                linkedListExtension.Remove(i);
            }
        }
    }
}
