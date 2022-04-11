using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_ASD_Shkitak_1
{
    class BarrierSearch
    {
        public static void ShowResult(int key, int[] array, LinkedList head)
        {
            OutputInput.BoldLine();
            Console.WriteLine("\t Barrier Search: ");
            OutputInput.NextLine();

            Console.WriteLine("\t For the array: ");
            DateTime start = DateTime.Now;
            Console.Write("\t The position: ");
            Search(key, (int[])array.Clone());
            Console.WriteLine("\t Time: " + (DateTime.Now - start).TotalSeconds + " Seconds");
            OutputInput.NextLine();

            start = DateTime.Now;
            Console.WriteLine("\t For the linked list: ");
            Console.Write("\t The position: ");
            Search(key, head);
            Console.WriteLine("\t Time: " + (DateTime.Now - start).TotalSeconds + " Seconds");
            OutputInput.BoldLine();
        }

        public static void Search(int key, int[] array)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = key;
            int i = 0;
            while (array[i] != key )
                i++;
            if (i < array.Length - 1)
                Console.WriteLine(i);
            else
                Console.WriteLine("The object is not found");
        }

        public static void Search(int key, LinkedList list)
        {
            int i = 0;
            var iterator = list;
            var newLast = new LinkedList(key, null);
            while (iterator.Next != null)
                iterator = iterator.Next;
            iterator.Next = newLast;
            iterator = list;
            while (iterator.Data != key)
            {
                i++;
                iterator = iterator.Next;
            }
            if (iterator.Next != null)
                Console.WriteLine(i);
            else
                Console.WriteLine("The object is not found");
        }
    }
}
