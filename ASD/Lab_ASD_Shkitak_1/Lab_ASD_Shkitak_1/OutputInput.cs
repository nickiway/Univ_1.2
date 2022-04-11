using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_ASD_Shkitak_1
{
    public static class OutputInput
    {
        public static void NextLine()
        {
            Console.Write('\n');
        }
        public static void BoldLine()
        {
            NextLine();
            int windowWidth = Console.WindowWidth;
            for (int index = 0; index < windowWidth; index++)
            {
                Console.Write("=");
            }
            NextLine();
        }
        public static void Menu()
        {
            Console.WriteLine("1. To run the Linear search");
            Console.WriteLine("2. To run the Barrier search");
            Console.WriteLine("3. To run the Binary search");
            Console.WriteLine("4. To run the Binary search with golden cut");
            Console.WriteLine("5. To change the input array");
            Console.WriteLine("6. To change the key");
            Console.WriteLine("7. To print the array");
            Console.WriteLine("8. Menu output");
            Console.WriteLine("9. Exit");
        }
      
        public static List<int> Generate(int startPostion, int endPostion, int quatnity)
        {
            List<int> result = new List<int>(); 
            Random random = new Random();
            if(startPostion > endPostion)
            {
                int temp = startPostion;
                startPostion = endPostion;
                endPostion = temp;
            }
            for(int index = 0; index <= quatnity; index++)
                result.Add(random.Next(startPostion, endPostion));
            return result;
        }
        public static void SetValues(out int[] array, out LinkedList list, out int key)
        {
            OutputInput.BoldLine();
            Console.WriteLine("Do you want to enter the value by yourself of automatically? ");
            Console.WriteLine("Enter 1, if you want to enter value by yourself");
            Console.WriteLine("Enter other number, if you want to enter value automatically");
            BoldLine();
            Console.WriteLine("Please, enter the way of creating the array : ");
            Int32.TryParse(Console.ReadLine(), out int choise);
            OutputInput.BoldLine(); 
            if (choise == 1)
                ChangeArray(out array, out list);
            else
                ChangeArrayRandom(out array, out list);
            BoldLine();
            Console.WriteLine("The array : ");
            PrintArray(array);
            BoldLine();
            key = ChangeKey();
        }

        public static void ChangeArray(out int[] array, out LinkedList list)
        {
            Console.WriteLine("Please, enter an integer array to search in");
            array = GetArray();
            list = LinkedList.GetList(array);
        }
        public static void GenerateCondition(out int startPostion, out int endPostion, out int quatnity)
        {
            Console.WriteLine("Enter the startPostion (the smallest possible value) :");
            Int32.TryParse(Console.ReadLine(), out startPostion);
            Console.WriteLine("Enter the endPostion (the largest possible value) :");
            Int32.TryParse(Console.ReadLine(), out endPostion);
            Console.WriteLine("Enter the quantity :");
            Int32.TryParse(Console.ReadLine(), out quatnity);
        }
        public static void ChangeArrayRandom(out int[] array, out LinkedList list)
        {
            int startPostion,  endPostion,  quatnity;
            GenerateCondition(out startPostion, out endPostion, out quatnity);
            array = Generate(startPostion, endPostion, quatnity).ToArray();
            list = LinkedList.GetList(array);
        }
        public static void PrintArray(int[] array)
        {
            int size = array.Length;
            for (int i = 0; i < size - 1; i++) Console.Write(array[i] + " ");
            NextLine();
        }
        public static int ChangeKey()
        {
            Console.WriteLine("Please, enter a key to search for");
            int.TryParse(Console.ReadLine(), out var result);
            return result;
        }

        private static int[] GetArray()
        {
            var result = new List<int>();
            var line = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int temp;
            foreach (string element in line)
            {
                int.TryParse(element, out temp);
                result.Add(temp);
            }

            return result.ToArray();
        }
    }
}
