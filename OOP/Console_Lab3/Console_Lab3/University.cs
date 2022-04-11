using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Console_Lab3
{
    partial class University
    {
        /* Constructor */
        public University()
        {
            name = "Taras Shevchenko Kyiv national university";
            adress = "Kyiv city";
            numberFaculties = 30;
            numberFaculties = 249;
            totalStudents = 26434;
            rate = 7;
        }
        public University(string name, string adress, int numberFaculties,int numberSpecialities, int totalStudents, double rate)
        {
            name = Name;
            adress = Adress;
            numberFaculties = NumberFaculties;
            numberSpecialities = NumberSpecialities;
            totalStudents = TotalStudents;
            rate = Rate;
        }
        /* Variables */
        private string name;
        private string adress;
        private int numberFaculties;
        private int numberSpecialities;
        private int totalStudents;
        private int rate;
        /* Properties */
        public string Name 
        {
            get => name;
            set => name = value;
        }
        public string Adress
        {
            get => adress; 
            set => adress = value; 
        }
        public int NumberFaculties
        {
            get => numberFaculties; 
            set => numberFaculties = value;
        }
        public int NumberSpecialities
        {
            get => numberSpecialities; 
            set => numberSpecialities = value;
        }
        public int TotalStudents
        {
            get => totalStudents; 
            set => totalStudents = value;
        }
        public int Rate
        {
            get => rate; 
            set => rate = value;
        }
        /* Public methods */
        static public int GetInt(string message)
        {
            int element;
            Console.WriteLine(message);
            while (!Int32.TryParse(Console.ReadLine().Split(' ')[0], out element))
            {
                Console.WriteLine("Enter the number, please! ");
            }
            return element;

        }
        public void SetValues(ref University university)
        {
            Console.WriteLine("Enter university's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter university's adress: ");
            string adress = Console.ReadLine();
            int numberFaculties = GetInt("Enter number of faculties: ");
            int numberSpecialities = GetInt("Enter number of specialities: ");
            int totalStudents = GetInt("Enter number of students: ");
            int rate = GetInt("Enter the university's rate (from 1 - 5): ");
            while (rate > 5 | rate < 1)
            {
                rate = GetInt("Enter the rate (FROM 1 - TO 5): ");
            }
            university.Name = name;
            university.Adress = adress;
            university.NumberFaculties = numberFaculties;
            university.NumberSpecialities = numberSpecialities;
            university.TotalStudents = totalStudents;
            university.Rate = rate;
        }
        public void PrintClass(University university)
        {
            Console.WriteLine($"The university name: {university.Name}\nIts adress: {university.Adress}\nNumber of faculties: {university.NumberFaculties}\nNumber of specialities: {university.NumberSpecialities}\nTotal number of students: {university.TotalStudents}\nIts rate: {university.Rate}");
        }
        public void WriteFile(University university)
        {
            string path = @"d:\OP\OOP\Console_Lab3\university.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                string text = $" The university name: {university.Name}\n Its adress: {university.Adress}\n Nomber of faculties: {university.NumberFaculties}\n Number of specialities: {university.NumberSpecialities}\n Total number of students: {university.TotalStudents}\n Its rate: {university.Rate}";
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
            }
        }
        static public void Rating(Random random)
        {
            int quantity = GetInt("Enter the number of universities: ");
            University university = new University();
            University[] universities = new University[quantity];
            List<Tuple<string, int>> tupleArray = new List<Tuple<string, int>>();
            for (int index = 0; index < universities.Length; index++)
            {
                universities[index] = new University();
                university.SetValues(ref universities[index]);
                Program.DrawLine();
            }
            for (int index = 0; index < universities.Length; index++)
            {
                int temp, summary = 0;
                Console.WriteLine($"The SCOPUS rating mark: {temp = random.Next(0, 201)}");
                summary += temp;
                Console.WriteLine($"The \"ТОП200 Україна\" rating mark: {temp = random.Next(0, 201)}");
                summary += temp;
                Console.WriteLine($"The \"Бал ЗНО на контракт\" rating mark: {temp = random.Next(0, 201)}");
                summary += temp;
                Console.WriteLine($"The the summary mark of {universities[index].Name} is:  {summary}");
                Program.DrawLine();
                tupleArray.Add(Tuple.Create(universities[index].Name, summary));
            }
            tupleArray = tupleArray.OrderByDescending(t => t.Item2).ToList();
            for (int index = 0; index < tupleArray.Count(); index++)
            {
                Console.WriteLine($"The top #{index + 1} : {tupleArray[index].Item1} what's summary marks: {tupleArray[index].Item2}");
            }
        }
    }
}
