using System;
namespace Console_Lab1
{
    class Program
    {
        /*Drawing the line-separator*/
        static void DrawBoldLine()
        {
            for(int index = 0; index < Console.WindowWidth; index++)
            {
                Console.Write("-");
            }
            Console.Write("\n");
        }
        /* Outputting the task condtition*/
        static void WriteTask(string task)
        {
            DrawBoldLine();
            Console.WriteLine("The task:");
            Console.WriteLine(task);
            DrawBoldLine();

        }
        /*Task 1*/
        static void Task1()
        {
            Double[] sides = new double[2];
            Console.WriteLine("Name: Nikita\nSurname: Shkitak\nAge: 17 years\nEmail: shkitak@dlit.dp.ua\nGroup: IPZ-11-1\nCourse: 1 ");
            DrawBoldLine();
            Console.WriteLine("Enter enter first rec side: ");
            Double.TryParse(Console.ReadLine(), out sides[0]);
            Console.WriteLine("Enter enter second rec side: ");
            Double.TryParse(Console.ReadLine(), out sides[1]);
            double result = sides[0] * sides[1];
            Console.WriteLine("{0:f3}", $"The square of rec: {result}");
        }
        /*Task 2*/
        static void Task2()
        {
            Double[] variables = new double [2];
            Console.WriteLine("Enter A: ");
            Double.TryParse(Console.ReadLine(), out variables[0]);
            Console.WriteLine("Enter B: ");
            Double.TryParse(Console.ReadLine(), out variables[1]);
            Console.WriteLine("x=(1-a)*(a+b)/(a-b)+∛(sin⁡〖a^2 〗 )");
            double result = ((1 - variables[0]) * (variables[0] + variables[1]) / (variables[0] - variables[1]) + (double)Math.Pow(Math.Sin(variables[0]), 2 / 3));
            Console.WriteLine($"The result: {string.Format("{0:f3}", result)}");
        }
        /*Task 3*/
        static void Task3()
        {
            Double[] variables = new double[2];
            Console.WriteLine("Enter enter A: ");
            Double.TryParse(Console.ReadLine(), out variables[0]);
            Console.WriteLine("Enter enter B: ");
            Double.TryParse(Console.ReadLine(), out variables[1]);
            Console.WriteLine("The result :");
            if (variables[1] == 0)
            {
                Console.WriteLine(0);
            }
            else if (variables[0] > variables[1])
            {
                Console.WriteLine("{0:f3}", Math.Pow(variables[0], 2) / Math.Pow(variables[1], 2));
            }
            else if (variables[0] < variables[1])
            {
                Console.WriteLine("{0:f3}", Math.Pow(variables[1], 2) - Math.Pow(variables[0], 2));
            }
            else
            {
                Console.WriteLine(1);
            }
        }
        /*Task 4*/
        static void Task4()
        {
            Int32 colorNumber = 0;
            Console.WriteLine("Enter enter color (if you enter string type, it will automatically set red): ");
            Int32.TryParse(Console.ReadLine(), out colorNumber);
            String [] colors = { "Red", "Orange", "Yellow", "Green", "Light Blue", "Blue", "Purple" };
            String[] rgbaColors = { "rgb(255, 0, 0)", "rgb(255,0,255)", "rgb(255,255,0)", "rgb(0,128,0)", "rgb(0,0,255)", "rgb(0,0,128)", "rgb(128,0,128)" };
            Console.WriteLine($"The number {colorNumber} color is {colors[colorNumber - 1]}, its rgb code: {rgbaColors[colorNumber - 1]}");
        }
        /*Task 5*/
        static void Task5()
        {
            Console.WriteLine("Enter the row with marks : ");
            string marks = Console.ReadLine();
            double avarage = 0.00;
            short counter = 0;
            string tempString = "";
            Int32 max = Int32.MinValue, min = Int32.MaxValue, summary = 0;
            for(int index = 0; index < marks.Length; index++)
            {
                if (marks[index] != ' ')
                {
                    tempString += marks[index];
                }
                if (marks[index] == ' ' | index + 1 == marks.Length)
                {
                    if (int.TryParse(tempString, out _))
                    {
                        int temp = Convert.ToInt32(tempString);
                        counter++;
                        if (max < temp)
                        {
                            max = temp;
                        }
                        if (min > temp)
                        {
                            min = temp;
                        }
                        summary += temp;
                    }
                    tempString = "";
                }
            }
            if (marks.Length > 2)
            {
                avarage = (summary - max - min) / (counter - 2);
            }
            else
            {
                avarage = 0;
            }
            Console.WriteLine("{0:f3}", $"The avarage: {avarage}, the minimal: {min}, the maximal: {max}, the summ: {summary}"); 
        }
        static void Main(string[] args)
        {
            /*Setting Cyrillic*/
            Console.OutputEncoding = System.Text.Encoding.GetEncoding("Cyrillic");
            Console.InputEncoding = System.Text.Encoding.GetEncoding("Cyrillic");
            int menu;
            /*Condition task*/
            string[] tasks = { "1.Вивести на консоль власні анкетні дані: прізвище, ім'я, вік, група, курс, e=mail. Обчислити площу прямокутника за заданими сторонами. Результат вивести на консоль. " ,
            "2.За даними, що введені з консолі, визначити значення виразу, використовуючи математичні функції, і вивести результат на консоль. x=(1-a)*(a+b)/(a-b)+∛(sin⁡〖a^2 〗 )",
            "3.За даними a, b, x, значення яких ввести з консолі, обчислити значення функції:\nif b == 0 -> 0\nif a > b -> a^2 / b^2\nif a < b -> b^2 - a^2\nif a = b -> 1",
            "4.Написати функцію, яка в залежності від порядкового номера кольору у спектрі (1,2,...7) виводить його назву (червоний, помаранчевий, жовтий, зелений, блакитний, синій, фіолетовий) і код RGB.",
            "5.N суддів поставили різні оцінки одному спортсмену. Обчислити середній бал спортсмена, видаливши найменшу та найвищу суддівські оцінки. Оцінки вводити з клавіатури, Не використовуючи масиви, обраховувати суму введених значень, найменше та найбільші значення."};
            Console.WriteLine("Lab. no. 1, created by Nikita Shkitak IPZ_11 (VAR_5)\nEnter the number of task you want to complete (1 - 6): ");
            while(!Int32.TryParse(Console.ReadLine(), out menu))
            {
                Console.WriteLine("Enter number, not a string!");
            }
            /* Menu */
            while(true)
            {
                switch (menu) 
                {
                    case 1 :
                        WriteTask(tasks[0]);
                        DrawBoldLine();
                        Task1();
                        DrawBoldLine();
                        break;
                    case 2:
                        WriteTask(tasks[1]);
                        DrawBoldLine();
                        Task2();
                        DrawBoldLine();
                        break;
                    case 3:
                        WriteTask(tasks[2]);
                        DrawBoldLine();
                        Task3();
                        DrawBoldLine();
                        break;
                    case 4:
                        WriteTask(tasks[3]);
                        DrawBoldLine();
                        Task4();
                        DrawBoldLine();
                        break;
                    case 5:
                        WriteTask(tasks[4]);
                        DrawBoldLine();
                        Task5();
                        DrawBoldLine();
                        break;
                    default:
                        WriteTask(tasks[0]);
                        Task1();
                        DrawBoldLine();
                        break;
                }
                /*Loop for continue*/
                Console.WriteLine("Do you wanna finish? (if yes - enter q, else enter other symbol) ");
                char exit = Convert.ToChar(Console.ReadLine());
                if (exit == 'Q' | exit == 'q')
                {
                    break;
                } 
                else
                {
                    Console.WriteLine("Enter the number of task you want to complete: ");
                    while (!Int32.TryParse(Console.ReadLine(), out menu))
                    {
                        Console.WriteLine("Enter number, not a string!");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
