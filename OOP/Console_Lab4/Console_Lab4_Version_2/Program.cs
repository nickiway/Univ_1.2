using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Task 9 new console project
/// </summary>
namespace Console_Lab4_Version_2
{
    /// <summary>
    /// IComparable
    /// </summary>
    public class Enterprise : IComparable
    {
        /* Main class variables */
        private string name;
        private string adress;
        private string sphere;
        private int rate;
        private int workersNum;
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Sphere { get; set; }
        public int Rate { get; set; }
        public int WorkersNum { get; set; }
        static public string GetString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        static public int GetInt(string message)
        {
            Console.WriteLine(message);
            int temporary;
            while (!Int32.TryParse(Console.ReadLine(), out temporary))
            {
                Console.WriteLine("Enter the number (integer): ");
            }
            return temporary;
        }
        static public double GetDouble(string message)
        {
            Console.WriteLine(message);
            double temporary;
            while (Double.TryParse(Console.ReadLine(), out temporary))
            {
                Console.WriteLine("Enter the number (integer): ");
            }
            return temporary;
        }
        public Enterprise()
        {
            Name = "Nasha Ryaba";
            Adress = "Kyiv, Khreshtik 22";
            Sphere = "Trade";
            Rate = 5;
            WorkersNum = 10;
        }
        public Enterprise(string name, string adress, string sphere, int rate, int workersNum)
        {
            Name = name;
            Adress = adress;
            Sphere = sphere;
            Rate = rate;
            WorkersNum = workersNum;
        }
        public virtual void PritAllFields()
        {
            Console.WriteLine($"The name: {Name}\nThe adress: {Adress}\nThe sphere: {Sphere}\nIts rate: {Rate}\nThe number of workers: {WorkersNum}");
        }
        static public void DrawLine() => Console.WriteLine(new string('=', Console.WindowWidth));
        public int CompareTo(object obj)
        {
            Enterprise enterprise = obj as Enterprise;
            if(enterprise != null)
            {
                if(this.WorkersNum > enterprise.WorkersNum)
                {
                    return 1;
                }
                else if (this.WorkersNum < enterprise.WorkersNum)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new Exception("The object class is not appropriate to the comparer.");        
            }
        }
    }
    /// <summary>
    /// Task 9.3 IEnumerator and IEnumerable
    /// </summary>
    public class Enterprises : IEnumerable
    {
        private Enterprise[] _enterprises;
        public Enterprises(Enterprise[] enterprises)
        {
            _enterprises = new Enterprise[enterprises.Length];
            for (int index = 0; index < enterprises.Length; index++)
            {
                _enterprises[index] = enterprises[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }
        public EnterpriseEnum GetEnumerator()
        {
            return new EnterpriseEnum(_enterprises);
        }
    }
    public class EnterpriseEnum : IEnumerator 
    {
        public Enterprise[] enterprises;
        int position = -1;
        public EnterpriseEnum(Enterprise[] list)
        {
            enterprises = list;
        }
        public bool MoveNext()
        {
            position++;
            return (position < enterprises.Length);
        }
        public void Reset()
        {
            position -= 1;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public Enterprise Current
        {
            get
            {
                try
                {
                    return enterprises[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    class Program
    {
        static public void FillEnterprises(ref Enterprise [] enterprises)
        {
            for (int index = 0; index < enterprises.Length; index++)
            {
                string name, adress, sphere;
                int rate, workersNumber;
                name = Enterprise.GetString("Enter the name of enterprice: ");
                adress = Enterprise.GetString("Enter the adress of enterprice: ");
                sphere = Enterprise.GetString("Enter the sphere of enterprice: ");
                rate = Enterprise.GetInt("Enter the rate [1 - 5]: ");
                while (rate < 1 | rate > 5)
                {
                    rate = Enterprise.GetInt("Enter the rate [1 - 5]: ");
                }
                workersNumber = Enterprise.GetInt("Enter the number of workers: ");
                enterprises[index] = new Enterprise(name, adress, sphere, rate, workersNumber);
                Enterprise.DrawLine();
            }
        }
        static public int GetMenu()
        {
            int menu = Enterprise.GetInt("Enter the menu [1 - 3]");
            while (menu < 1 | menu > 3)
            {
                menu = Enterprise.GetInt("Enter the menu [1 - 3]");
            }
            return menu;
        }
        static public void Task1()
        {
            Console.WriteLine("The task 1 (9.1)");
            int length = Enterprise.GetInt("Enter the number of objects: ");
            Enterprise[] enterprises = new Enterprise[length];
            FillEnterprises(ref enterprises);
            Array.Sort(enterprises);
            Console.WriteLine("The sorted Array: ");
            for (int index = 0; index < enterprises.Length; index++)
            {
                enterprises[index].PritAllFields();
                Enterprise.DrawLine();
            }
        }
        static public void Task2()
        {
            Console.WriteLine("The task 2 (9.2)");
            int length = Enterprise.GetInt("Enter the number of objects: ");
            Enterprise[] enterprises = new Enterprise[length];
            FillEnterprises(ref enterprises);
            Array.Sort(enterprises, new Rate());
            Console.WriteLine("The sorted Array (by Rate): ");
            Enterprise.DrawLine();
            for (int index = 0; index < enterprises.Length; index++)
            {
                enterprises[index].PritAllFields();
                Enterprise.DrawLine();
            }
            Array.Sort(enterprises, new Workers());
            Console.WriteLine("The sorted Array (by number of workers): ");
            Enterprise.DrawLine();
            for (int index = 0; index < enterprises.Length; index++)
            {
                enterprises[index].PritAllFields();
                Enterprise.DrawLine();
            }
        }
        static public void Task3()
        {
            Console.WriteLine("The task 3 (9.3)");
            int length = Enterprise.GetInt("Enter the number of objects: ");
            Enterprise[] enterprises = new Enterprise[length];
            FillEnterprises(ref enterprises);
            Array.Sort(enterprises, new Rate());
            Enterprises enterpriceList = new Enterprises(enterprises);
            Enterprise.DrawLine();
            foreach(Enterprise obj in enterpriceList)
            {
                Console.WriteLine($"{obj.Name} its rate: {obj.Rate}");
                Enterprise.DrawLine();
            }
        }
        static void Main(string[] args)
        {
            int menu = GetMenu();
            while (true)
            {
                switch (menu) 
                {
                    case 1:
                        Enterprise.DrawLine();
                        Task1();
                        break;
                    case 2:
                        Enterprise.DrawLine();
                        Task2();
                        break;
                    case 3:
                        Enterprise.DrawLine();
                        Task3();
                        break;
                    default:
                        Enterprise.DrawLine();
                        Task1();
                        break;
                }
                Console.WriteLine("Do you want  to finish? if yes - enter 'y' ");
                char exit = Console.ReadLine()[0];
                if(exit == 'y' | exit == 'Y')
                {
                    break;
                }
                else
                {
                    menu = GetMenu();
                }
            }
        }
    }
}
