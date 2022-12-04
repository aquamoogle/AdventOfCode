using AoC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y22
{
    public class RPS
    {
        public int PlayerOne { get; set; }
        public int PlayerTwo { get; set; }
        public int Outcome { get; set; }
        public int PointsAwarded { get; set; }
        public string Input { get; set; }
    }

    public class Day2
    {

        protected int GetValue(string x)
        {
            switch (x)
            {
                case "A":
                case "X":
                    return 1;
                    break;
                case "B":
                case "Y":
                    return 2;
                    break;
                case "C":
                case "Z":
                    return 3;
                    break;
            }
            return 0;
        }

        //(1 for Rock,
        //2 for Paper, and
        //3 for Scissors)
        //plus the score for the outcome of the round(
        //  0 if you lost,
        //  3 if the round was a draw, and
        //  6 if you won)
        public async Task<string> Part1()
        {
            var file = await Downloader.GetInputAsync(2022, 2);
            var games = new List<RPS>();
            foreach (var ln in file)
            {
                var splits = ln.Split(' ');

                try
                {
                    var g = new RPS();
                    g.Input = ln;
                    g.PlayerOne = GetValue(splits[0].Trim());
                    g.PlayerTwo = GetValue(splits[1].Trim());
                    if (
                        (g.PlayerOne == 1 && g.PlayerTwo == 2)
                        || (g.PlayerOne == 2 && g.PlayerTwo == 3)
                        || (g.PlayerOne == 3 && g.PlayerTwo == 1)
                    )
                        g.Outcome = 6;
                    else if (g.PlayerOne == g.PlayerTwo)
                        g.Outcome = 3;
                    else
                        g.Outcome = 0;

                    g.PointsAwarded = g.PlayerTwo + g.Outcome;

                    games.Add(g);
                }
                catch (Exception ex)
                {

                }
            }

            return games.Sum(x => x.PointsAwarded).ToString();
        }

        public int GetPlay(string x, int opponent)
        {
            switch (x)
            {
                case "X": //Lose
                    if (opponent == 1)
                        return 3;
                    else if (opponent == 2)
                        return 1;
                    else
                        return 2;
                        break;
                case "Y": //Draw
                    return opponent;
                    break;
                case "Z": //Win
                    if (opponent == 1)
                        return 2;
                    else if (opponent == 2)
                        return 3;
                    else
                        return 1;
                    break;
            }

            return 0;
        }

        public async Task<string> Part2()
        {
            var file = await Downloader.GetInputAsync(2022, 2);
            var last = (int?)null;
            var answer = 0;
            var games = new List<RPS>();
            foreach (var ln in file)
            {
                var splits = ln.Split(' ');

                try
                {
                    //X means you need to lose,
                    //Y means you need to end the round in a draw, and
                    //Z means you need to win. Good luck!"
                    var g = new RPS();
                    g.Input = ln;
                    g.PlayerOne = GetValue(splits[0].Trim());
                    g.PlayerTwo = GetPlay(splits[1].Trim(), g.PlayerOne);
                    if (
                        (g.PlayerOne == 1 && g.PlayerTwo == 2)
                        || (g.PlayerOne == 2 && g.PlayerTwo == 3)
                        || (g.PlayerOne == 3 && g.PlayerTwo == 1)
                    )
                        g.Outcome = 6;
                    else if (g.PlayerOne == g.PlayerTwo)
                        g.Outcome = 3;
                    else
                        g.Outcome = 0;

                    g.PointsAwarded = g.PlayerTwo + g.Outcome;

                    games.Add(g);
                }
                catch (Exception ex)
                {

                }
            }

            return games.Sum(x => x.PointsAwarded).ToString();
        }
    }
}
