﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCarnivalV2.Source.CarnivalGames.AllCarnivalGames
{
    class HorseyRaces : CarnivalGame
    {
        public override string getName()
        {
            return "Horsey Races";
        }

        public override void play()
        {
            int Money = 1000;
            while (Money > 0)
            {
                clear();
                showTitle("Horsey Races");
                writeLine("$" + Money);
                writeLine("1 [Horse 1], 2 [Horse 2], 3 [Horse 3], Q [Quit]");
                write("Select a horse to bet on: ");

                string choice = getOption("1", "2", "3", "q");
                if (choice == "q")
                {
                    clear();
                    break;
                }

                write("How much to bet? $");
                int Bet = Convert.ToInt32(getInput());
                if (Bet > Money)
                {
                    writeLine("Cheater!");
                    break;
                }

                Money -= Bet;
                

                string RaceTrack1 = "-_-_-_-_-$-_";
                string RaceTrack01 = "-_-_-_-_-$-_";
                string RaceTrack2 = "-_-_-_-_-$-_";
                string RaceTrack02 = "-_-_-_-_-$-_";
                string RaceTrack3 = "-_-_-_-_-$-_";
                string RaceTrack03 = "-_-_-_-_-$-_";

                Random Moves = new Random();

                int H1 = 0, H2 = 0, H3 = 0;

                int Max = 0;
                while (Max < 10)
                {
                    clear();

                    for (int i = 1; i <= 3; i++)
                    {
                        if (i == 1)
                        {
                            RaceTrack1 = RaceTrack01;
                            H1 += Moves.Next(0, 3) + 1;
                            RaceTrack1 = RaceTrack1.Insert(H1, "1");

                        }
                        if (i == 2)
                        {
                            RaceTrack2 = RaceTrack02;
                            H2 += Moves.Next(0, 3) + 1;
                            RaceTrack2 = RaceTrack2.Insert(H2, "2");
                        }
                        if (i == 2)
                        {
                            RaceTrack3 = RaceTrack03;
                            H3 += Moves.Next(0, 3) + 1;
                            RaceTrack3 = RaceTrack3.Insert(H3, "3");
                        }
                    }

                    Max = Math.Max(H1, Math.Max(H2, H3));
                    writeOut(RaceTrack1 + "\n" + RaceTrack2 + "\n" + RaceTrack3);
                    wait(3);
                }

                string winner = "";

                if (Max == H1)
                    winner = "1";
                if (Max == H2)
                    winner = "2";
                if (Max == H3)
                    winner = "3";

                if (choice == winner)
                {
                    write("Y O U  W I N !");
                    Money += Bet * 2;
                }
                else
                    write("Y O U  L O S E !");

                wait(3);
                clear();
            }
        }
    }
}
