using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Lab4
{
    /// <summary>
    /// Basic class for tasks 1 - 6
    /// </summary>
    class Enterprise
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
        public int WorkersNumber 
        {
            get => workersNum; 
            set => workersNum = value; 
        }
        public int GetInt(string message)
        {
            Console.WriteLine(message);
            int temporary;
            while(!Int32.TryParse(Console.ReadLine(), out temporary))
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
        public Enterprise()
        {
            Name = "Nasha Ryaba";
            Adress = "Kyiv, Khreshtik 22";
            Sphere = "Trade";
            Rate = 5;
            WorkersNumber = 2000;
        }
        public Enterprise(string name, string adress, string sphere, int rate, int workersNumber) 
        {
            Name = name;
            Adress = adress;
            Sphere = sphere;
            Rate = rate;
            WorkersNumber = workersNum;
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
    class Ensurance_Company : Enterprise
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
        public Ensurance_Company()
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
    class OilAndGas_Company : Enterprise
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
        public OilAndGas_Company()
        {
            Product = "Oil and Gas";
            ProductNum = 3000;
            Profit = 100000;
            WorkersNum = 400;
        }
        public override void PritAllFields()
        {
            Console.WriteLine($"The product: {Product}\nThe number of products: {ProductNum}\nThe profit of company: {Profit}\nThe number of workers: {WorkersNum}");
        }
    }
    class Factory : Enterprise 
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
        public Factory()
        {
            Product = "Cartoon boxes";
            ProductNum = 3000;
            Profit = 100000;
            WorkersNum = 400;
        }
        public override void PritAllFields()
        {
            Console.WriteLine($"The product: {Product}\nThe number of products: {ProductNum}\nThe profit of company: {Profit}\nThe number of workers: {WorkersNum}");
        }
    }
}
