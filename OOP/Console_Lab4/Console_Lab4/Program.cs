using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Lab4
{
    /// <summary>
    /// tak 8, using abstract class
    /// </summary>
    abstract class EnterpriseV3
    {
        /* Main class variables */
        private string name;
        private string adress;
        private string sphere;
        private int rate;
        /* Child class variables */
        protected string product;
        protected int productNum;
        protected int profit;
        protected int workersNum;
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
        public string Sphere
        {
            get => sphere;
            set => sphere = value;
        }
        public int Rate
        {
            get => rate;
            set => rate = value;

        }
        public int GetInt(string message)
        {
            Console.WriteLine(message);
            int temporary;
            while (!Int32.TryParse(Console.ReadLine(), out temporary))
            {
                Console.WriteLine("Enter the number (integer): ");
            }
            return temporary;
        }
        public double GetDouble(string message)
        {
            Console.WriteLine(message);
            double temporary;
            while (!Double.TryParse(Console.ReadLine(), out temporary))
            {
                Console.WriteLine("Enter the number (integer): ");
            }
            return temporary;
        }
        public virtual void PritAllFields()
        {
            Console.WriteLine($"The name: {Name}\nThe adress: {Adress}\nThe sphere: {Sphere}\nIts rate: {Rate}");
        }
        public double GetProfit()
        {
            int productCost = GetInt("Enter the product cost: ");
            double percentage = GetDouble("Enter the percent to find profit: ");
            return (double)productCost * percentage;
        }
        public int NumberOfWorkers(Random random)
        {
            int avarageSalary = GetInt("Enter the avarage salary: ");
            int summarySalary = random.Next(10000, 50000);
            return summarySalary / avarageSalary;
        }
        static public void DrawLine() => Console.WriteLine(new string('=', Console.WindowWidth));
    }
    class Ensurance_CompanyV3 : EnterpriseV3
    {
        public string Product
        {
            get => product;
            set => product = value;
        }
        public int ProductNum
        {
            get => productNum;
            set => productNum = value;
        }
        public int Profit
        {
            get => profit;
            set => profit = value;
        }
        public int WorkersNum
        {
            get => workersNum;
            set => workersNum = value;

        }
        public Ensurance_CompanyV3()
        {
            Product = "Car Ensurance";
            ProductNum = 3000;
            Profit = 100000;
            WorkersNum = 400;
        }
        public override void PritAllFields()
        {
            Console.WriteLine($"The product: {Product}\nThe number of products: {ProductNum}\nThe profit of company: {Profit}\nThe number of workers: {WorkersNum}");
        }
    }
    class OilAndGas_CompanyV3 : EnterpriseV3
    {
        public string Product
        {
            get => product;
            set => product = value;
        }
        public int ProductNum
        {
            get => productNum;
            set => productNum = value;
        }
        public int Profit
        {
            get => profit;
            set => profit = value;
        }
        public int WorkersNum
        {
            get => workersNum;
            set => workersNum = value;

        }
        public OilAndGas_CompanyV3()
        {
            Product = "Oil and Gas";
            ProductNum = 3000;
            Profit = 100000;
            WorkersNum = 400;
        }
        public override void PritAllFields()
        {
            this.PritAllFields();
        }
    }
    class FactoryV3 : EnterpriseV3
    {
        public string Product
        {
            get => product;
            set => product = value;
        }
        public int ProductNum
        {
            get => productNum;
            set => productNum = value;
        }
        public int Profit
        {
            get => profit;
            set => profit = value;
        }
        public int WorkersNum
        {
            get => workersNum;
            set => workersNum = value;

        }
        public FactoryV3()
        {
            Product = "Cartoon boxes";
            ProductNum = 3000;
            Profit = 100000;
            WorkersNum = 400;
        }
        public override void PritAllFields()
        {
            this.PritAllFields();
        }
    }
    /// <summary>
    /// task 7, using interface 
    /// </summary>
    interface Business
    {
        int GetInt(string message);
        double GetDouble(string message);
        double GetProfit();
        int NumberOfWorkers(Random random);
        void PritAllFields();

    }
    class EnterpriseV2 : Business
    {
        /* Main class variables */
        private string name;
        private string adress;
        private string sphere;
        private int rate;
        /* Child class variables */
        protected string product;
        protected int productNum;
        protected int profit;
        protected int workersNum;
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
        public string Sphere
        {
            get => sphere;
            set => sphere = value;
        }
        public int Rate
        {
            get => rate;
            set => rate = value;

        }
        public int GetInt(string message)
        {
            Console.WriteLine(message);
            int temporary;
            while (!Int32.TryParse(Console.ReadLine(), out temporary))
            {
                Console.WriteLine("Enter the number (integer): ");
            }
            return temporary;
        }
        public double GetDouble(string message)
        {
            Console.WriteLine(message);
            double temporary;
            while (!Double.TryParse(Console.ReadLine(), out temporary))
            {
                Console.WriteLine("Enter the number (integer): ");
            }
            return temporary;
        }
        public EnterpriseV2()
        {
            Name = "Nasha Ryaba";
            Adress = "Kyiv, Khreshtik 22";
            Sphere = "Trade";
            Rate = 5;
        }
        public EnterpriseV2(string name, string adress, string sphere, int rate)
        {
            Name = name;
            Adress = adress;
            Sphere = sphere;
            Rate = rate;
        }
        public virtual void PritAllFields()
        {
            Console.WriteLine($"The name: {Name}\nThe adress: {Adress}\nThe sphere: {Sphere}\nIts rate: {Rate}");
        }
        public double GetProfit()
        {
            int productCost = GetInt("Enter the product cost: ");
            double percentage = GetDouble("Enter the percent to find profit: ");
            return (double)productCost * percentage;
        }
        public int NumberOfWorkers(Random random)
        {
            int avarageSalary = GetInt("Enter the avarage salary: ");
            int summarySalary = random.Next(10000, 50000);
            return summarySalary / avarageSalary;
        }

    }
    class Ensurance_CompanyV2 : EnterpriseV2
    {
        public string Product
        {
            get => product;
            set => product = value;
        }
        public int ProductNum
        {
            get => productNum;
            set => productNum = value;
        }
        public int Profit
        {
            get => profit;
            set => profit = value;
        }
        public int WorkersNum
        {
            get => workersNum;
            set => workersNum = value;

        }
        public Ensurance_CompanyV2()
        {
            Product = "Car Ensurance";
            ProductNum = 3000;
            Profit = 100000;
            WorkersNum = 400;
        }
        public override void PritAllFields()
        {
            Console.WriteLine($"The product: {Product}\nThe number of products: {ProductNum}\nThe profit of company: {Profit}\nThe number of workers: {WorkersNum}");
        }
    }
    class OilAndGas_CompanyV2 : EnterpriseV2
    {
        public string Product
        {
            get => product;
            set => product = value;
        }
        public int ProductNum
        {
            get => productNum;
            set => productNum = value;
        }
        public int Profit
        {
            get => profit;
            set => profit = value;
        }
        public int WorkersNum
        {
            get => workersNum;
            set => workersNum = value;

        }
        public OilAndGas_CompanyV2()
        {
            Product = "Oil and Gas";
            ProductNum = 3000;
            Profit = 100000;
            WorkersNum = 400;
        }
        public override void PritAllFields()
        {
            this.PritAllFields();
        }
    }
    class FactoryV2 : EnterpriseV2
    {
        public string Product
        {
            get => product;
            set => product = value;
        }
        public int ProductNum
        {
            get => productNum;
            set => productNum = value;
        }
        public int Profit
        {
            get => profit;
            set => profit = value;
        }
        public int WorkersNum
        {
            get => workersNum;
            set => workersNum = value;

        }
        public FactoryV2()
        {
            Product = "Cartoon boxes";
            ProductNum = 3000;
            Profit = 100000;
            WorkersNum = 400;
        }
        public override void PritAllFields()
        {
            this.PritAllFields();
        }
    }
    /// <summary>
    /// Main
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            /* Objects */
            Random random = new Random();
            Enterprise enterpriseBasic = new Ensurance_Company();
            EnterpriseV3 enterprise = new Ensurance_CompanyV3();
            Business business = new Ensurance_CompanyV2();
            /* Basic class */
            Console.WriteLine("Lab. no. 4 , created by Shkitak Nikita IPZ-11-1");
            EnterpriseV3.DrawLine();
            Console.WriteLine("Task 1 - 6 demonstration (3 methods ): ");
            Console.WriteLine($"The number of workers: {enterpriseBasic.NumberOfWorkers(random)}");
            EnterpriseV3.DrawLine();
            Console.WriteLine($"The profit: { enterpriseBasic.GetProfit()}");
            EnterpriseV3.DrawLine();
            enterpriseBasic.PritAllFields();
            EnterpriseV3.DrawLine();
            /* Interface */
            Console.WriteLine("Using interface: ");
            business.PritAllFields();
            EnterpriseV3.DrawLine();
            /* Abstract class */
            Console.WriteLine("Using abstract class: ");
            enterprise.PritAllFields();
            EnterpriseV3.DrawLine();
            /* Consclusion */
            Console.WriteLine("The main defenition is we can set method's body's in abstract class, while in interface we can only announce methods and properties");
            Console.ReadKey();
        }
    }
}
