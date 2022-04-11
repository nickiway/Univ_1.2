using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_Lab3
{
    class Program
    {
       static public void DrawLine()
        {
            Console.Write("\n");
            int width = Console.WindowWidth;
            for(int index = 0; index < width; index++) 
            {
                Console.Write("-");
            }
            Console.Write("\n");
        }
        
        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> list = new List<int>();
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Lab. no. 2, created by Nikita Shkitak IPZ_11");
            int menu = University.GetInt("Enter the menu point of task 1 - 5");
            while (true)
            {
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("The task #1 :");
                        DrawLine();
                        Console.WriteLine("Розрахунок рейтингу університету за версією Osvita.ua: загальний бал університету визначається як сума балів за рейтингами «SCОPUS», «ТОП200 Україна», «Бал ЗНО на контракт». Рейтинг визначається як порядковий номер університету в масиві відсортованих за зростанням загальних балів. Бали за різні номінації отримати в результаті генерації псевдовипадкових цілих чисел в діапазоні від 0 до 200 методами класу Random.");
                        DrawLine();
                        University.Rating(random);
                        DrawLine();
                        break;
                    case 2:
                        Console.WriteLine("The task #2 :");
                        DrawLine();
                        Console.WriteLine("Розрахунок розміру річного фінансування університету відповідно до його рейтингу, розміру, місця розташування та кількості студентів, враховуючи, що підготовка одного бюджетного студента в рік коштує від $2000 до $6000. Значення показників задати самостійно. ");
                        DrawLine();
                        University.Finance(random);
                        DrawLine();
                        break;
                    case 3:
                        Console.WriteLine("The task #3 :");
                        DrawLine();
                        Console.WriteLine("Запис у текстовий файл значень полів класу (назва факультету, кількість кафедр, кількість спеціальностей, кількість студентів факультету); ");
                        DrawLine();
                        Faculty faculty = new Faculty();
                        faculty.PrintClass(faculty);
                        faculty.WriteFile(faculty);
                        if (File.Exists(@"d:\OP\OOP\Console_Lab3\faculty.txt"))
                        {
                            Console.WriteLine("The information was written to the file");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, something went wrong :(");
                        }
                        DrawLine();
                        break;
                    case 4:
                        Console.WriteLine("The task #4 :");
                        DrawLine();
                        Console.WriteLine("Збільшення (зменшення) кількості кафедр в залежності від збільшення (зменшення) кількості спеціальностей (з розрахунку одна спеціальність відповідає одній кафедри), та кількості студентів (на спеціальності має навчатися не менше, ніж 200 студентів). ");
                        DrawLine();
                        int resize = University.GetInt("Enter the number of cafedras you want to increase (if you want to decrease : enter negative value , e.x : -10): ");
                        faculty = new Faculty();
                        Console.WriteLine("Do you want to set values of object by yourself? Enter y if 'yes': ");
                        char yorself = Console.ReadLine()[0];
                        if (yorself == 'y' | yorself == 'Y')
                        {
                            faculty.SetValues(ref faculty);
                        }
                        DrawLine();
                        Console.WriteLine("Before resizing: ");
                        faculty.PrintClass(faculty);
                        faculty = faculty.ResizeCafedras(faculty, resize);
                        DrawLine();
                        Console.WriteLine("After resizing: ");
                        faculty.PrintClass(faculty);
                        DrawLine();
                        break;
                    case 5:
                        Console.WriteLine("The task #5 :");
                        DrawLine();
                        Console.WriteLine("Вибір найкращого стартап проекту. Алгоритм метода такий. Вважатимемо, що є 10 проектів і 5 експертів, кожний з яких ставить проекту оцінку. В якості оцінок проекту виступають псевдовипадкові числа, що отримані  за допомогою класу Random в діапазоні від 1 до 10. В результаті отримаємо матрицю вимірністю 5*10 (кількість експертів*кількість проектів).  Для кожного проекту знаходимо суму балів (сума елементів по стовпчиках), потім розраховуємо середнє арифметичний бал для проекту, поділивши сумарний бал проекту на кількість експертів. Сортуємо середні бали за зростанням. Проект, який має найменший середній бал, вважатимемо найкращим.   ");
                        DrawLine();
                        Faculty.StartupIncubator.ChoseBest(random);
                        break;
                    case 6:
                        Console.WriteLine("The task #6 :");
                        DrawLine();
                        Console.WriteLine("Рейтинг результативності студентів в стартап Інкубаторе. Алгоритм метода такий. Для кожного студента визначаємо долю (значення від 0 до 1) його участі в кожному проекті за допомогою генератору псевдовипадкових чисел. Отриману долю участі множимо на обсяг інвестицій, сортуємо отримані значення за спаданням. Студент з найвищим показником є найрезультативнішим.");
                        DrawLine();
                        Faculty.StartupIncubator.MostProductiveStudent(random);
                        break;
                    case 7:
                        Console.WriteLine("The task #7 :");
                        DrawLine();
                        Console.WriteLine("9.	Додати до проекту новий статичний клас StartupProject (стартап проект), включивши в нього три функції (на вибір студента) з варіанта 5 лабораторної роботи 2. ");
                        DrawLine();
                        StartupProject.Task1(random, ref list);
                        DrawLine();
                        StartupProject.Task2(random, ref list);
                        DrawLine();
                        StartupProject.Task3(random, ref list);
                        DrawLine();
                        break;
                    default:
                        Console.WriteLine("The task #1 :");
                        DrawLine();
                        Console.WriteLine("Розрахунок рейтингу університету за версією Osvita.ua: загальний бал університету визначається як сума балів за рейтингами «SCОPUS», «ТОП200 Україна», «Бал ЗНО на контракт». Рейтинг визначається як порядковий номер університету в масиві відсортованих за зростанням загальних балів. Бали за різні номінації отримати в результаті генерації псевдовипадкових цілих чисел в діапазоні від 0 до 200 методами класу Random.");
                        DrawLine();
                        University.Rating(random);
                        DrawLine();
                        break;
                }
                Console.WriteLine("If you want to finish : enter \"q\", else enter other symbol");
                char exit = Console.ReadLine()[0];
                if (exit == 'q' | exit == 'Q')
                {
                    break;
                }
            }
        }
    }
}
