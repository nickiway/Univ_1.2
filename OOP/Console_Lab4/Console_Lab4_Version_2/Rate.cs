using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Lab4_Version_2
{
    /// <summary>
    /// Class for IComparer
    /// </summary>
    class Rate : IComparer<Enterprise>
    {
        public int Compare(Enterprise x, Enterprise y)
        {
            if (x.Rate > y.Rate)
                return 1;
            else if (x.Rate < y.Rate)
                return -1;
            else
                return 0;
        }
    }
}
