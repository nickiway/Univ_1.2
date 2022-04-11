using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_ASD_Shkitak_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The lab. no. 1 of ASD, done by Nikita Shkitak IPZ-11-1, FIT, KNU");
            OutputInput.SetValues(out var array, out var list, out var key);
            OutputInput.BoldLine();
            OutputInput.Menu();
            OutputInput.BoldLine();
            while(true)
            {
                Console.WriteLine("Enter the menu point : ");
                Int32.TryParse(Console.ReadLine(), out int menu);
                switch (menu)
                {
                    case 1:
                        LinearSearch.ShowResult(key, array, list);
                        break;
                    case 2:
                        BarrierSearch.ShowResult(key, array, list);
                        break;
                    case 3:
                        BinarySearch.ShowResult(key, array, false);
                        break;
                    case 4:
                        BinarySearch.ShowResult(key, array, true);
                        break;
                    case 5:
                        Console.WriteLine("Please, enter the way of creating the array : ");
                        Int32.TryParse(Console.ReadLine(), out int choise);
                        OutputInput.BoldLine();
                        if (choise == 1)
                            OutputInput.ChangeArray(out array, out list);
                        else
                            OutputInput.ChangeArrayRandom(out array, out list);
                        OutputInput.BoldLine();
                        break;
                    case 6:
                        OutputInput.BoldLine();
                        key = OutputInput.ChangeKey();
                        OutputInput.BoldLine();
                        break;
                    case 7:
                        OutputInput.BoldLine();
                        OutputInput.PrintArray(array);
                        OutputInput.BoldLine();
                        break;
                    case 8:
                        OutputInput.BoldLine();
                        OutputInput.Menu();
                        OutputInput.BoldLine();
                        break;
                    case 9:
                        return;
                    default:
                        OutputInput.BoldLine();
                        Console.WriteLine("You've entered a wrong command");
                        OutputInput.BoldLine();
                        break;
                }
            }
        }
    }
}
