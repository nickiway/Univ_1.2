using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Lab2
{
    static class Task
    {
        static double Function(double x)
        { 
            return Math.Pow(x, 4) - 10 * Math.Pow(x, 3) + 38 * Math.Pow(x,2) - 65 * x + 43;
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
        static public void Anouncement(string task, string condition)
        {
            Console.WriteLine($"The task number: {task}");
            Console.WriteLine($"The task: \n{condition}");
        }
        public static object BinarySearchIterative(List<int> inputArray, int key)
        {
            int min = 0;
            int max = inputArray.Count() - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return "The element wasn't found";
        }
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
        static public double GetDouble(string message)
        {
            double item;
            Console.WriteLine(message);
            while (!Double.TryParse(Console.ReadLine().Split(' ')[0], out item))
            {
                Console.WriteLine("Enter the number, please! ");
            }
            return item;

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
        static public void Task3(ref List<int> elements_to_sort, Random random)
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
            foreach(int item in elements_to_sort)
            {
                Console.Write($"{item} ");
            }

        }
        static public void Task4(ref List<int> array, Random random)
        {
            Anouncement("FOUR", "4.	Знайти найбільший серед від’ємних та найменший серед додатних елементів масиву, застосувавши алгоритм лінійного пошуку. Вивести значення знайдених елементів та їх індекси.");
            DrawBoldLine();
            if (array.Count() == 0)
            {
                array = GenerateList(random);
            }
            int negativeMax = int.MinValue, negativeMaxIndex = 0, positiveMin = int.MaxValue, positiveMinIndex = 0;
            foreach(int temp in array) 
            { 
                if (temp < 0)
                {
                    if (temp > negativeMax)
                    {
                        negativeMax = temp;
                        negativeMaxIndex = array.IndexOf(temp);
                    }
                }
                else
                {
                    if (temp < positiveMin)
                    {
                        positiveMin = temp;
                        positiveMinIndex = array.IndexOf(temp);
                    }
                }
            }
            if (positiveMin == int.MaxValue)
            {
                Console.WriteLine("There is not positive numbers");
            }
            else
            {
                Console.WriteLine($"The minimal positive number: {positiveMin} and its index: {positiveMinIndex}");
            }
            if (negativeMax == int.MinValue)
            {
                Console.WriteLine("There is not negative numbers");
            }
            else
            {
                Console.WriteLine($"The maximal negative number: {negativeMax} and its index: {negativeMaxIndex}");
            }
        }
        static public void Task5(ref List<int> elementsToSearchInt, Random random) 
        {
            Anouncement("FIVE", "5.	Визначити кількість і значення елементів масиву, що належать заданому з консолі діапазону, застосувавши метод бінарного пошуку. У разі їх відсутності вивести відповідне повідомлення. Модифікувати функцію бінарного пошуку у масиві, використавши метод  BinarySearch класу Array");
            DrawBoldLine();
            if (elementsToSearchInt.Count() == 0)
            {
                elementsToSearchInt = GenerateList(random);
            }
            int min = GetInt("Enter the minimal of the range: ");
            int max = GetInt("Enter the maximal of the range: ");
            elementsToSearchInt.Sort();
            foreach(int item in elementsToSearchInt)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            for(int index = min; index < max + 1; index++) 
            {
                Console.WriteLine($"The element that was searched is {index} and its index in searched array (sorted) is: {BinarySearchIterative(elementsToSearchInt, index)}");
            }
        }
        static public int[,] Task6(Random random)
        {
            Anouncement("SIX", "6.	Згенерувати елементи матриці, задавши її вимірність та діапазон значень з консолі. На перетині i-го рядка та j-го стовпчика матриці записаний прибуток за j-й місяць від продажу i-го товару в магазині. Вивести матрицю на консоль. Визначити загальний прибуток від кожного товару, загальний прибуток магазину від продажу усіх  товарів за усі місяці, індекс товару, який приносить найбільший прибуток. Вивести результати на консоль.");
            DrawBoldLine();
            int[] range = new int[2];
            int[] lengthMatricx = new int[2];
            range[0] = Math.Abs(GetInt("Enter the minimal value of element:"));
            range[1] = Math.Abs(GetInt("Enter the maximal value of element:"));
            if(range[0] > range[1])
            {
                int temp = range[0];
                range[0] = range[1];
                range[1] = temp;
            }
            lengthMatricx[0] = GetInt("Enter i: ");
            lengthMatricx[1] = GetInt("Enter j: ");
            int[,] matrix = new int[lengthMatricx[0], lengthMatricx[1]];
            int[] summary = new int[lengthMatricx[0]];
            DrawBoldLine();
            Console.WriteLine("The generated matrix: ");
            for (int index = 0; index < lengthMatricx[0];index++)
            {
                for(int indexJ = 0; indexJ < lengthMatricx[1]; indexJ++)
                {
                    matrix[index, indexJ] = random.Next(range[0], range[1] + 1);
                    Console.Write($"{matrix[index, indexJ]} \t");
                    summary[index] += matrix[index, indexJ];
                }
                Console.Write("\n\n");
            }
            DrawBoldLine();
            int totalSummary = 0;
            int max = int.MinValue, maxIndex = 0;
            for(int index = 0; index < lengthMatricx[0]; index++)
            {
                Console.WriteLine($"The profit of product num #{index + 1}: {summary[index]}");
                totalSummary += summary[index];
                if(max < summary[index])
                {
                    max = summary[index];
                    maxIndex = index;
                }
            }
            DrawBoldLine();
            Console.WriteLine($"The most profitable good is good undex index: {maxIndex}, it brought sum: {max}");
            Console.WriteLine($"The total profit for selling all goods: {totalSummary}");
            return matrix;
        }
        static public int [,] Task7(Random random, int [,] matrix)
        {
            Anouncement("SEVEN", "7.	У створеній матриці визначити та вивести на консоль значення та індекси мінімального елемента. Видалити рядок та стовпчик з мінімальним елементом матриці. Вивести на консоль отриману після перетворення матрицю.");
            DrawBoldLine();
            if (matrix == null)
            {
                int[] range = new int[2];
                int[] lengthMatricx = new int[2];
                range[0] = GetInt("Enter the minimal value of element:");
                range[1] = GetInt("Enter the maximal value of element:");
                lengthMatricx[0] = GetInt("Enter i: ");
                lengthMatricx[1] = GetInt("Enter j: ");
                matrix = new int[lengthMatricx[0], lengthMatricx[1]];
                DrawBoldLine();
                Console.WriteLine("The generated matrix: ");
                for (int index = 0; index < lengthMatricx[0]; index++)
                {
                    for (int indexJ = 0; indexJ < lengthMatricx[1]; indexJ++)
                    {
                        matrix[index, indexJ] = random.Next(range[0], range[1] + 1);
                        Console.Write($"{matrix[index, indexJ]} \t");
                    }
                    Console.Write("\n");
                }
                DrawBoldLine();
            }
            int min = int.MaxValue; int[] minIndex = new int [2];
            for(int index = 0; index < matrix.GetLength(0); index++)
            {
                for(int indexJ = 0; indexJ < matrix.GetLength(1); indexJ++)
                {
                    if (min > matrix[index,indexJ])
                    {
                        min = matrix[index, indexJ];
                        minIndex[0] = index;
                        minIndex[1] = indexJ;
                    }
                }
            }
            Console.WriteLine($"The minimal element is: {min}, its indexes: I = {minIndex[0]} and J = {minIndex[1]}");
            int[,] resizedMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int resizeIndexI = 0, resizeIndexJ = 0;
            for (int index = 0; index < matrix.GetLength(0); index++)
            {
                if(index != minIndex[0])
                {
                    for (int indexJ = 0; indexJ < matrix.GetLength(1); indexJ++)
                    {
                        if (indexJ != minIndex[1])
                        {
                            resizedMatrix[resizeIndexI, resizeIndexJ] = matrix[index, indexJ];
                            Console.Write($"{resizedMatrix[resizeIndexI, resizeIndexJ]} \t");
                            resizeIndexJ += 1;
                        }
                    }
                    Console.Write("\n\n");
                    resizeIndexJ = 0;
                    resizeIndexI += 1;
                }
            }
            return resizedMatrix;
        }
        static public void Task8()
        {
            Anouncement("EIGHT", "8.	Знайти корені нелінійного рівняння (x^25*x+7)^2(x2)(x3)=0, застосувавши метод половинного ділення (метод бісекції). Вивести результати на консоль. Здійснити перевірку правильності рішення, підставивши знайдені значення коренів в нелінійне рівняння.");
            double intervalBegin;
            double intervalEnd;
            double middle;
            double precision;
            intervalBegin = GetDouble("Enter begining of interval: ");
            intervalEnd = GetDouble("Enter end of interval: ");
            precision = GetDouble("Enter precision of method: ");
            if (Function(intervalBegin) * Function(intervalEnd) > 0.0D)
            {
                Console.Write("Function has same signs at ends of interval (or no roots)");
                return;
            }
            while (Math.Abs(intervalBegin - intervalEnd) > precision)
            {
                middle = (intervalBegin + intervalEnd) / 2.0D;
                Console.WriteLine("X: " + middle);
                if (Function(intervalBegin) * Function(middle) < 0.0D)
                {
                    intervalEnd = middle;
                }
                else
                {
                    intervalBegin = middle;
                }
            }
        }
        static public void Task9 ()
        {
            Anouncement("NINE", "9.	Увести з консолі рядок символів (тип string), що містить круглі, квадратні та фігурні дужки. Визначити, чи є послідовність дужок правильною, тобто кількість дужок, що відкривається, дорівнює кількості дужок, що закриваються. Результати вивести на консоль.");
            DrawBoldLine();
            Console.WriteLine("Enter the string you want to work with: ");
            List<string> elements = new List<string>();
            string temp = Console.ReadLine();
            for(int index = 0; index < temp.Length; index++)
            {
                elements.Add(temp[index].ToString());
            }
            char[] symbolsToCheck = { '(', ')', '{', '}', '[', ']' };
            short[] symbolsToCheckCounter = new short [6];
            int length = elements.Count();
            for(int index = 0; index < length; index++)
            {
                for(int indexJ = 0; indexJ < symbolsToCheck.Length; indexJ++)
                { 
                    if(elements.IndexOf(symbolsToCheck[indexJ].ToString()) != -1)
                    {
                        symbolsToCheckCounter[indexJ] += 1;
                        elements.RemoveAt(elements.IndexOf(symbolsToCheck[indexJ].ToString()));
                    }
                }
            }
            if(symbolsToCheckCounter[0] == symbolsToCheckCounter[1] 
                & symbolsToCheckCounter[2] == symbolsToCheckCounter[3] 
                & symbolsToCheckCounter[4] == symbolsToCheckCounter[5])
            {
                Console.WriteLine("The Sequence IS CORRECT");
            }
            else
            {
                Console.WriteLine("The Sequence IS NOT CORRECT");
            }
        }
    }
}
