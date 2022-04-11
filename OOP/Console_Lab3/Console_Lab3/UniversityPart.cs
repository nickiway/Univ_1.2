using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Lab3
{
    partial class University
    {
        static public void Finance(Random random)
        {
            List<Tuple<University, int>> universities = new List<Tuple<University, int>>();
            int paymentsForStudent = random.Next(2000, 6001);
            int[] sizePayments = new int[] { 1000, 2000, 3000, 4000, 5000 };
            double[] ratePayments = new double[] { 1, 1.15, 1.3, 1.45, 1.5 };
            int objectsNumber = GetInt("Enter the number of universities: ");
            for (int index = 0; index < objectsNumber; index++)
            {
                University temp = new University();
                temp.SetValues(ref temp);
                int size = GetInt("Enter the university size-mark (from 1 - 5): ");
                while (size > 5 | size < 1)
                {
                    size = GetInt("Enter the rate (FROM 1 - TO 5): ");
                }
                universities.Add(Tuple.Create(temp, size));
                Program.DrawLine();
            }
            foreach (Tuple<University, int> temp in universities)
            {
                double summary;
                summary = (temp.Item1.TotalStudents * paymentsForStudent + sizePayments[temp.Item2 - 1]) * ratePayments[temp.Item1.Rate - 1];
                Console.WriteLine($"For the university {temp.Item1.Name} that is located at {temp.Item1.Adress} is required around {summary}$ of financiality");
            }
        }
    }
}
