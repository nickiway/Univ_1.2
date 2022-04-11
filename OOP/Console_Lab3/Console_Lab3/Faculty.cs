using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Console_Lab3
{
    class Faculty
    {
        /* Constructor */
        public Faculty()
        {
            name = "Faculty of Information Technologies";
            numberCafedras = 10;
            numberSpecialities = 10;
            numberStudents = 2330;
        }
        public Faculty(string name, int numberCafedras, int numberSpecialities, int numberStudents)
        {
            name = Name;
            numberCafedras = NumberCafedras;
            numberSpecialities = NumberSpecialities;
            numberStudents = NumberStudents;
        }
        /* Variables */
        private string name;
        private int numberCafedras;
        private int numberSpecialities;
        private int numberStudents;
        /* Properties */
        public string Name
        {
            get => name; 
            set => name = value; 
        }
        public int NumberCafedras
        {
            get => numberCafedras; 
            set => numberCafedras = value; 
        }
        public int NumberStudents
        {
            get => numberStudents; 
            set => numberStudents = value; 
        }
        public int NumberSpecialities
        {
            get => numberSpecialities; 
            set => numberSpecialities = value; 
        }
        /* Public methods */
        public int GetInt(string message)
        {
            int element;
            Console.WriteLine(message);
            while (!Int32.TryParse(Console.ReadLine().Split(' ')[0], out element))
            {
                Console.WriteLine("Enter the number, please! ");
            }
            return element;

        }
        public void SetValues(ref Faculty faculty)
        {
            Console.WriteLine("Enter faculty's name: ");
            string name = Console.ReadLine();
            int numberCafedras = GetInt("Enter number of cafedras: ");
            int numberSpecialities = GetInt("Enter number of specialities: ");
            int numberStudents = GetInt("Enter number of students: ");
            faculty.Name = name;
            faculty.NumberCafedras = numberCafedras;
            faculty.NumberSpecialities = numberSpecialities;
            faculty.NumberStudents = numberStudents;
        }
        public void PrintClass(Faculty faculty)
        {
            Console.WriteLine($"The faculty name: {faculty.Name}\nNumber of cafedras: {faculty.NumberCafedras}\nNumber of specialities: {faculty.NumberCafedras}\nNumber of students: {faculty.NumberStudents}");
        }
        public void WriteFile(Faculty faculty)
        {
            string path = @"d:\OP\OOP\Console_Lab3\faculty.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                string text = $" The faculty name: {faculty.Name}\n Number of cafedras: {faculty.NumberCafedras}\n Number of specialities: {faculty.NumberCafedras}\n Number of students: {faculty.NumberStudents}";
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
            }
        }
        public Faculty ResizeCafedras(Faculty faculty, int resizeCafedras)
        {
            faculty.NumberCafedras = faculty.NumberSpecialities + resizeCafedras;
            var studentsToCafedras = Math.Floor((decimal)(faculty.NumberStudents / 200));
            if(studentsToCafedras < faculty.NumberCafedras)
            {
                faculty.NumberCafedras = (int)studentsToCafedras;
            }
            return faculty;
        }

        /* StartupIncubator class : */
        public class StartupIncubator
        {
            public StartupIncubator()
            {
                NumberStartups = 10;
                NumberStudents = 5;
                Investitions = 1000;
            }
            public StartupIncubator(int numberStartups, int numberStudents, int investitions)
            {
                NumberStartups = numberStartups;
                NumberStudents = numberStudents;
                Investitions = investitions;
            }
            private int numberStartups;
            private int numberStudents;
            private int investitions;
            public int NumberStartups 
            {
                get => numberStartups;
                set => numberStartups = value;
            }
            public int NumberStudents
            {
                get => numberStudents;
                set => numberStudents = value;
            }
            public int Investitions
            {
                get => investitions;
                set => investitions = value;
            }
            static public void ChoseBest(Random random)
            {
                Faculty faculty = new Faculty();
                int experts = faculty.GetInt("Enter the number of experts, please: "), 
                    projects = faculty.GetInt("Enter the number of projects, please: "); ;
                int[,] matrix = new int[projects, experts];
                List<Tuple<double, int>> list = new List<Tuple<double, int>>();
                Program.DrawLine();
                for(int index = 0; index < matrix.GetLength(0); index++)
                {
                    for(int indexj = 0; indexj < matrix.GetLength(1); indexj++)
                    {
                        matrix[index,indexj] = random.Next(1, 11);
                        Console.Write($" \t {matrix[index, indexj]}");
                    }
                    Console.Write("\n\n");
                }
                Program.DrawLine();
                for (int index = 0; index < matrix.GetLength(1); index++)
                {
                    double summary = 0;
                    for (int indexj = 0; indexj < matrix.GetLength(0); indexj++)
                    {
                        summary += matrix[indexj, index];
                    }
                    Console.WriteLine($"Summary in column {index}: {summary}");
                    summary /= (double)experts;
                    Console.WriteLine($"For element under index {index} avarage mark is: {summary}");
                    list.Add(Tuple.Create(summary, index));
                }
                Program.DrawLine();
                list = list.OrderBy(t => t.Item1).ToList();
                Console.WriteLine($"The best project is project under index: {list[0].Item2} and its avarage mark is: {list[0].Item1}");
            }
            static public void MostProductiveStudent(Random random)
            {
                StartupIncubator startUp ;
                Faculty faculty = new Faculty();
                List<Tuple<int, double>> list = new List<Tuple<int, double>>();
                Console.WriteLine("Do you want fill the information by yourself or use standart information? if yes - enter 'y' ");
                char enter = Console.ReadLine()[0];
                if (enter == 'y' | enter == 'Y')
                {
                    startUp = new StartupIncubator(faculty.GetInt("Enter the number of startups: "), faculty.GetInt("Enter the number of students: "), faculty.GetInt("Enter the investitions: "));
                }
                else 
                {  
                    startUp = new StartupIncubator();
                }
                Program.DrawLine();
                for(int index = 0; index < startUp.NumberStudents; index++)
                {
                    double temp = random.NextDouble() * (double)startUp.Investitions;
                    Console.WriteLine($"Student {index} and its fraction: {temp}");
                    list.Add(Tuple.Create(index, temp));
                }
                Program.DrawLine();
                list = list.OrderByDescending(t => t.Item2).ToList();
                Console.WriteLine($"The {list[0].Item1} student is most resulting, his fraction: {list[0].Item2}");
            } 
        }
    }
}
