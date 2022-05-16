using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pilse_task
{
    class Program : DrawItems
    {

        private static int GetInt(string message, int biggerThan, int lowerThan)
        {
            int pile;
            do
            {
                Console.WriteLine(message);
            }
            while (!Int32.TryParse(Console.ReadLine(), out pile) | pile > biggerThan | pile < lowerThan);
            return pile;
        }
        // if the user wants to restart
        private static bool _isRestart()
        {
            Console.WriteLine("\tDo you wish to restart? Enter r(R) to restart.");
            char _isContinue = Console.ReadLine()[0];

            if (_isContinue != 'r' & _isContinue != 'R')
            {
                return false;
            }
            return true;
        }
        
        // if the list of stones is empty
        private static bool _isListEmpty(List<int> stones)
        {
            int temp = 0;
            for (int index = 0; index < stones.Count; index++)
            {
                temp += stones[index];
            }
            if (temp == 0)
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            // settings 
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            // program's start
            bool restart = true;
           
            // untill user finishes the game will continue
            while (restart)
            {
                Console.WriteLine("\tEnter the numbers of stones for each pile:");
                
                string sentenceString = Console.ReadLine().Trim();
                string[] sentence = sentenceString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> stones = new List<int>();

                foreach (string items in sentence)
                {
                    if (Int32.TryParse(items, out int temp) && temp != 0)
                    {
                        stones.Add(temp);
                    }
                }

                // output items (piles and stones)
                DrawItem(stones);
                DrawEnter();

                Console.WriteLine("\tDo you want play with bot? Enter 'y' if yes");

                // bot vars 
                int queNum = 1;
                bool bot = Console.ReadLine()[0] == 'y' ? true : false;
                bool easyMod = true;

                // player vars
                var players = new List<Tuple<int, string>>();
                short queue = 1;

                // checking if we play with bot
                if (!bot)
                {
                    for (int index = 1; index <= 2; index++)
                    {
                        Console.WriteLine("\tEnter the name of player {0}: ", index);
                        players.Add(Tuple.Create(index, Console.ReadLine()));
                    }
                }
                
                // getting if the player wants to become first or second
                else
                {
                    // setting the mod of bot
                    Console.WriteLine("\tChose the mod of bot : easy or hard (enter 1 or 2) ");
                    easyMod = Console.ReadLine()[0] == '1' ? true : false;

                    // setting the queue
                    Console.WriteLine("\tDo you want to start first or second (bot will be first), enter 1 or 2 - your queue");
                    do
                    {
                        Console.WriteLine("\tEnter the number of your queue (1 - 2) ");
                    }
                    while (!Int32.TryParse(Console.ReadLine(), out queNum) | queNum > 2 | queNum < 1);

                    // setting the values of a bot and a user
                    Console.WriteLine("\tEnter the name of the player: ");
                    players.Add(Tuple.Create(0, Console.ReadLine()));
                    players.Add(Tuple.Create(1, "BOT"));
                }
                
                // chaning the postions if the user is the second
                if(bot & queNum == 2) 
                {
                    (players[0], players[1]) = (players[1], players[0]);
                }

                // the game start : 
                while (!_isListEmpty(stones))
                {
                    // setting vars
                    int pile = 1, changeNumber;

                    // case it is a player
                    if (!players[queue - 1].Item2.Equals("BOT"))
                    {
                        Console.WriteLine("\tIt's {0}'s turn! (player #{1}) ", players[queue - 1].Item2, players[queue - 1].Item1);

                        pile = GetInt("\tEnter the number of pile from what you want to take stones (starts from 1): ", stones.Count, 1);
                        changeNumber = GetInt($"\tEnter the number of stones you want to take out from the pile #{pile}: ", stones[pile - 1], 1);
                        stones[pile - 1] -= changeNumber;
                    }
                    else
                    {
                        // queue of the bot
                        Console.WriteLine("\tIt's bot's turn now :");

                        // time out for a bot 
                        if (easyMod)
                        {
                            Bot.BotEasyMod(stones);
                        }
                        else
                        {
                            Bot.BotHardMod(stones);
                        }
                        Thread.Sleep(3000);
                    }
                    // case if we are deleting the pile
                    if (stones[pile - 1] == 0)
                    {
                        stones.RemoveAt(pile - 1);
                    }

                    // queue changing
                    if (queue == 1)
                    {
                        queue = 2;
                    }
                    else queue = 1;
                    
                    // checking if the game isn't finished yet
                    if (!_isListEmpty(stones))
                    {
                        DrawItem(stones);
                        DrawEnter();
                    }
                }

                // output the winner
                Console.WriteLine("\tPlayer #{0} (it's {1}), LOSES!", players[queue - 1].Item1, players[queue - 1].Item2);
                
                // restart command
                restart = _isRestart();
            }
        } 
    }
}
