using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_ASD_Shkitak_1
{
    class LinearSearch
    {
        public static void ShowResult(int key, int[] array, LinkedList list)
        {
            OutputInput.BoldLine();
            Console.WriteLine("\t Linear Search: ");
            OutputInput.NextLine();

            Console.WriteLine("\t For the array: ");
            DateTime start = DateTime.Now;
            Console.Write("\t The position: ");
            Search(key, array);
            Console.WriteLine("\t Time: " + (DateTime.Now - start).TotalSeconds + " Seconds");
            OutputInput.NextLine();
            
            start = DateTime.Now;
            Console.WriteLine("\t For the linked list: ");
            Console.Write("\t The position: ");
            Search(key, list);
            Console.WriteLine("\t Time: " +  (DateTime.Now - start).TotalSeconds + " Seconds");
            OutputInput.BoldLine();
        }
        public static void Search(int key, int[] array)
        {
            bool Found = false;
            int i = 0, size = array.Length, position = 0;
            while (i < size && !Found)
            {
                if (array[i] == key)
                {
                    position = i;
                    Found = true;
                }
                i++;
            }
            if (Found)
                 Console.WriteLine(position.ToString());
            else
                Console.WriteLine("The object is not found");
        }
        public static void Search(int key, LinkedList list)
        {
            bool Found = false;
            int i = 0, position = 0;
            var iterator = list;
            while (iterator != null && !Found)
            {
                if (iterator.Data == key)
                {
                    position = i;
                    Found = true;
                }
                i++;
                iterator = iterator.Next;
            }
            if (Found)
                Console.WriteLine(position.ToString());
            else
                Console.WriteLine("The object is not found" );
        }
    }
}
