using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Lab2
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random random = new Random();
            int[,] matrix = null;
            Console.WriteLine("Lab. no. 2, created by Nikita Shkitak IPZ_11");
            int menu = Task.GetInt("Enter the number of task you want to complete [1 - 9]: ");
            Task.DrawBoldLine();
            List<int> list = new List<int>();
            while (true)
            {
                switch (menu)
                {
                    case 1:
                        Task.Task1(random, ref list);
                        Task.DrawBoldLine();
                        break;
                    case 2:
                        Task.Task2(random, ref list);
                        Task.DrawBoldLine();
                        break;
                    case 3:
                        Task.Task3(ref list, random);
                        Task.DrawBoldLine();
                        break;
                    case 4:
                        Task.Task4(ref list, random);
                        Task.DrawBoldLine();
                        break;
                    case 5:
                        Task.Task5(ref list, random);
                        Task.DrawBoldLine();
                        break;
                    case 6:
                        matrix = Task.Task6(random);
                        Task.DrawBoldLine();
                        break;
                    case 7:
                        Task.Task7(random, matrix);
                        Task.DrawBoldLine();
                        break;
                    case 8:
                        Task.Task8();
                        Task.DrawBoldLine();
                        break;
                    case 9:
                        Task.Task9();
                        Task.DrawBoldLine();
                        break;
                    default:
                        Task.Task1(random, ref list);
                        Task.DrawBoldLine();
                        break;
                }
                Console.WriteLine("If you want to stop the program, enter q(Q), if you want to continue - enter other key");
                char exit = Convert.ToChar(Console.ReadLine());
                if(exit == 'q' || exit == 'Q')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter the menu point [1 - 9]");
                    menu = Task.GetInt("");
                }
                Task.DrawBoldLine();
            }
        }
    }
}
