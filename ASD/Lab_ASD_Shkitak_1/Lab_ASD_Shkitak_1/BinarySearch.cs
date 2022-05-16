using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_ASD_Shkitak_1
{
    class BinarySearch
    {
        private static void BubbleSort(ref int[] array)
        {
            for(int index = 0; index < array.Length; index++)
            {
                for (int indexJ = 0; indexJ < array.Length - 1; indexJ++)
                {
                    if(array[indexJ] > array[indexJ + 1])
                    {
                        int temp = array[indexJ];
                        array[indexJ] = array[indexJ + 1];
                        array[indexJ + 1] = temp;
                    }
                }
            }
        }
        public static void ShowResult(int key, int[] array, bool isGoldenRatio)
        {
            Console.WriteLine("WARNING! The array will be sorted in order to use the binnary search method!");
            var sortedArray = (int[])array.Clone();
            BubbleSort(ref sortedArray);
            var sortedListHead = LinkedList.SetList(sortedArray);
            Console.WriteLine("The sorted array:");
            OutputInput.PrintArray(sortedArray);

            OutputInput.BoldLine();
            Console.WriteLine("\t Binary Search: ");
            OutputInput.NextLine();

            Console.WriteLine("\t For the array: ");
            DateTime start = DateTime.Now;
            Console.Write("\t The position: ");
            Search(key, sortedArray, isGoldenRatio);
            Console.WriteLine("\t Time: " + (DateTime.Now - start).TotalSeconds + " Seconds");
            OutputInput.NextLine();

            start = DateTime.Now;
            Console.WriteLine("\t For the linked list: ");
            Console.Write("\t The position: ");
            Search(key, sortedListHead, isGoldenRatio);
            Console.WriteLine("\t Time: " + (DateTime.Now - start).TotalSeconds + " Seconds");
            OutputInput.BoldLine();
        }
        public static void Search(int key, int[] array, bool ratio)
        {
            int min = 0, max = array.Length - 1, mid;
            double adder = (Math.Sqrt(5) + 1) / 2;
            double devider = ratio ? 1 + adder : 2;
            double multiplayer = ratio ? adder : 1;
            while (min <= max)
            {
                mid = (int)((min + multiplayer * max) / devider);
                if (key < array[mid])
                    max = mid - 1;
                else
                    min = mid + 1;
            }
            if(array[max] == key)
                Console.WriteLine(max);
            else
                Console.WriteLine("The object is not found");
        }


        public static void Search(int key, LinkedList head, bool isGoldenRatio)
        {
            int indexLeft = 0, indexRight = LinkedList.GetLength(head), indexMiddle = 0;
            LinkedList nodeLeft = head, nodeRight = null, nodeMiddle = null;
            double goldenration = (Math.Sqrt(5) + 1) / 2;
            double lambda;
            if (isGoldenRatio)
            {
                lambda = goldenration;
            }
            else
            {
                lambda = 1;
            }
            while (nodeRight == null || nodeLeft.Data != nodeRight.Data)
            {
                indexMiddle = (int)((indexLeft + lambda * indexRight) / (1 + lambda));
                nodeMiddle = LinkedList.GetItem(nodeLeft, indexMiddle - indexLeft);
                if (key > nodeMiddle.Data)
                {
                    indexLeft = indexMiddle + 1;
                    nodeLeft = nodeMiddle.Next;
                }
                else
                {
                    indexRight = indexMiddle;
                    nodeRight = nodeMiddle;
                }
            }
            if (key == nodeRight.Data)
            {
                Console.WriteLine(indexRight + 1);
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    }
}
