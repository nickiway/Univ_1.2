using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Lab3
{
    static class StartupProject
    {
        static public void DrawBoldLine()
        {
            int width = Console.WindowWidth;
            Console.Write("\n");
            for (int index = 0; index < width; index++)
            {
                Console.Write("-");
            }
            Console.Write("\n");
        }

        static public void Anouncement(string task, string condition)
        {
            Console.WriteLine($"The task number: {task}");
            Console.WriteLine($"The task: \n{condition}");
        }
        static public int GetInt(string message)
        {
            int item;
            Console.WriteLine(message);
            while (!Int32.TryParse(Console.ReadLine().Split(' ')[0], out item))
            {
                Console.WriteLine("Enter the number, please! ");
            }
            return item;

        }
        static public List<int> GenerateList(Random random)
        {
            List<int> list = new List<int>();
            int lengthArray = GetInt("Enter the length of array you want to generate: ");
            int min = GetInt("Enter the minimal number from the range of generated numbers: ");
            int max = GetInt("Enter the maximal number from the range of generated numbers: ");
            lengthArray = Math.Abs(lengthArray);
            Console.WriteLine("Generated array: ");
            for (int index = 0; index < lengthArray; index++)
            {
                list.Add(random.Next(min, max + 1));
                Console.WriteLine($" {list[index]}");
            }
            return list;
        }
        static public void Task1(Random random, ref List<int> array)
        {
            Anouncement("ONE", "Згенерувати цілочислові додатні та від’ємні елементи одновимірного масиву, задавши їх кількість та діапазон значень з консолі. Відсортувати згенерований масив за зростанням значень його елементів алгоритмом сортування Шелла. Вивести на консоль масив до та після сортування. ");
            DrawBoldLine();
            array = GenerateList(random);
            int d = array.Count() / 2;
            while (d >= 1)
            {
                for (int index = d; index < array.Count(); index++)
                {
                    int j = index;
                    while ((j >= d) && array[j - d] > array[j])
                    {
                        int temp = array[j];
                        array[j] = array[j - d];
                        array[j - d] = temp;
                        j -= d;
                    }
                }
                d /= 2;
            }
            Console.WriteLine("Sorted array :");
            for (int index = 0; index < array.Count(); index++)
            {
                Console.WriteLine($" {array[index]}");
            }
        }
        static public void Task2(Random random, ref List<int> array)
        {
            Anouncement("TWO", "2.	У згенерованому масиві визначити прості числа із заданого з консолі діапазону додатних цілих значень, використавши алгоритм Ератосфена, та вивести їх на консоль. Якщо в згенерованому масиві відсутні прості числа, то вивести на консоль відповідне повідомлення");
            DrawBoldLine();
            if (array.Count() == 0)
            {
                array = GenerateList(random);
            }
            int min = GetInt("Enter the minimal: ");
            int max = GetInt("Enter the maximum: ");
            short counter = 1;
            min = Math.Abs(min);
            max = Math.Abs(max);
            List<int> simples = new List<int>();
            for (int index = min > array.Min() ? min : array.Min(); index <= (max < array.Max() ? max : array.Max()); index++)
            {
                simples.Add(index);
                counter++;
            }
            counter = 2;
            while (true)
            {
                for (int index = 0; index < simples.Count(); index++)
                {
                    if (simples[index] % counter == 0 && simples[index] != counter || simples[index] == 1)
                    {
                        simples.Remove(simples[index]);
                        index -= 1;
                    }
                }
                if (counter == max)
                {
                    break;
                }
                counter++;
            }
            DrawBoldLine();
            if (simples.Count == 0)
            {
                Console.WriteLine("All the elements were non-simple.");
            }
            else
            {
                Console.WriteLine("Simple elements : ");
                foreach (int element in simples)
                {
                    Console.WriteLine(element);
                }
            }
        }
        static public void Task3(Random random, ref List<int> elements_to_sort)
        {
            Anouncement("THREE", "3.	Переставити елементи масиву так, щоб їх значення чергувалися в порядку: від’ємний, додатний, нульовий, від’ємний, додатний, нульовий і т.д, Надрукувати масив після переставлення елементів.");
            DrawBoldLine();
            if (elements_to_sort.Count() == 0)
            {
                elements_to_sort = GenerateList(random);
            }
            List<int> positive_numbers = new List<int>();
            List<int> negative_numbers = new List<int>();
            int index = 0;
            Int32 zero_counter = 0;
            foreach (int element in elements_to_sort)
            {
                if (element > 0)
                {
                    positive_numbers.Add(element);
                }
                else if (element < 0)
                {
                    negative_numbers.Add(element);
                }
                else
                {
                    zero_counter += 1;
                }
            }
            elements_to_sort.Clear();
            Console.WriteLine("The sorted array (negative - positive  - zero)");
            while (positive_numbers.Count() + negative_numbers.Count() + zero_counter != 0)
            {
                if (negative_numbers.Count() != 0)
                {
                    elements_to_sort.Add(negative_numbers[index]);
                    negative_numbers.Remove(negative_numbers[index]);
                }
                if (positive_numbers.Count() != 0)
                {
                    elements_to_sort.Add(positive_numbers[index]);
                    positive_numbers.Remove(positive_numbers[index]);
                }
                if (zero_counter != 0)
                {
                    elements_to_sort.Add(0);
                    zero_counter -= 1;
                }
            }
            foreach (int item in elements_to_sort)
            {
                Console.Write($"{item} ");
            }

        }
    }
}
