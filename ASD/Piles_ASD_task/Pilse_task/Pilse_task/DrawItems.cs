using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilse_task
{
    class DrawItems
    {
        // drawing space
        public static string DrawSpace(string output)
        {
            output = output.Insert(0, "       ");
            return output;
        }

        // getting to another line with message
        public static string DrawEnter(string output)
        {
            output = output.Insert(0, "\n");
            return output;
        }

        // getting to another line 
        public static void DrawEnter()
        {
            Console.WriteLine("\n");
        }

        // drawing the side top side 
        public static void DrawTopSide(List<int> stones, ref string output)
        {
            for (int indexJ = stones.Count() - 1; indexJ >= 0; indexJ--)
            {
                if (stones[indexJ] == 0)
                {
                    for (int indexP = 0; indexP < 2; indexP++)
                    {
                        output = DrawSpace(output);
                    }
                }
                else
                {
                    string item = "*******";
                    output = output.Insert(0, item);
                    output = DrawSpace(output);
                }
            }
            output = DrawEnter(output);
        }

        // setting the column number
        public static string SetColumnNumber(string output, List<int> column)
        {
            for (int index = column.Count - 1; index >= 0; index--)
            {
                if (column[index] < 10)
                {
                    output = output.Insert(0, $"  ({column[index]})  ");
                }
                else
                {
                    output = output.Insert(0, $" ({column[index]})  ");
                }
                output = DrawSpace(output);
            }

            output = DrawEnter(output);

            for (int index = column.Count; index >= 1; index--)
            {
                if (index < 10)
                {
                    output = output.Insert(0, $"   {index}   ");
                }
                else
                {
                    output = output.Insert(0, $"  {index}   ");
                }
                output = DrawSpace(output);
            }

            output = DrawEnter(output);
            return output;
        }

        // drawing the side 
        public static void DrawSide(List<int> stones, ref string output)
        {
            for (int indexJ = stones.Count() - 1; indexJ >= 0; indexJ--)
            {
                if (stones[indexJ] == 0)
                {
                    for (int indexP = 0; indexP < 2; indexP++)
                    {
                        output = DrawSpace(output);
                    }
                }
                else
                {
                    string item = "**   **";
                    output = output.Insert(0, item);
                    output = DrawSpace(output);
                }
            }
            output = DrawEnter(output);
        }

        // drawing the items
        public static void DrawItem(List<int> stones)
        {
            string output = "";
            List<int> stonesNew = new List<int>(stones);
            int max = stones.Max();

            output = SetColumnNumber(output, stonesNew);

            for (int index = 0; index < max; index++)
            {

                DrawTopSide(stonesNew, ref output);
                DrawSide(stonesNew, ref output);
                DrawSide(stonesNew, ref output);
                DrawTopSide(stonesNew, ref output);

                for (int indexJ = 0; indexJ < stonesNew.Count; indexJ++)
                {
                    if (stonesNew[indexJ] > 0)
                    {
                        stonesNew[indexJ] -= 1;
                    }
                }
                output = DrawEnter(output);

            }
            Console.WriteLine(output);
        }

    }
}
