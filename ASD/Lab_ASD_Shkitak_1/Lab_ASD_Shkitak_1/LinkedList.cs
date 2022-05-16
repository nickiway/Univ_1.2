using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_ASD_Shkitak_1
{
    public class LinkedList
    {
        public LinkedList Next;
        public int Data;
        public LinkedList(int data, LinkedList next)
        {
            Data = data;
            Next = next;
        }
        public static LinkedList SetList(int[] array)
        {
            int i = array.Length - 1;
            var last = new LinkedList(array[i], null);
            while (i > 0)
            {
                i--;
                var temp = new LinkedList(array[i], last);
                last = temp;
            }
            return last;
        }
        public static LinkedList GetItem(LinkedList list, int position)
        {
            for (int i = 0; i < position; i++)
                list = list.Next;
            return list;
        }

        public static int GetLength(LinkedList list)
        {
            int i = 0;
            while (list.Next != null)
            {
                i++;
                list = list.Next;
            }
            return i;
        }
    }
}
