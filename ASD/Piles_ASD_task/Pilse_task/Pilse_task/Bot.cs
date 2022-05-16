using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilse_task
{
    class Bot
    {
        // easy bot mod
        public static void BotEasyMod(List<int> stone)
        {
            // obj of rand class
            Random random = new Random();
            // setting vars
            int pile = random.Next(0, stone.Count);
            int stones = random.Next(1, stone[pile] + 1);
            stone[pile] -= stones;
            Console.WriteLine("\tI'm taking {0} stone(s) from the pile # {1}", stones, pile);
        }

        // hard bot mod 
        public static void BotHardMod(List<int> stone)
        {
            int nim = nimSum(stone);
            int index = 0;
            if (nim == 0)
            {
                Console.WriteLine("\tI'm taking 1 stone from the pile # {0}", index + 1);
                stone[index]--;
            }
            else
            {
                while ((stone[index] ^ nim) >= stone[index])
                {
                    index++;
                }
                Console.WriteLine("\tI'm taking {0} stones from the pile # {1}", stone[index] - (stone[index] ^ nim), index + 1);
                stone[index] = (stone[index] ^ nim);
            }
            
        }
        // nim summary for hard bot
        public static int nimSum(List<int> stones)
        {
            int nim = 0;
            for(int index = 0; index < stones.Count; index++)
            {
                nim = nim ^ stones[index];
            }
            return nim;
        }
    }
}
