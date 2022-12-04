using AoC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y22
{
    public class Day1
    {
        public async Task<string> Part1()
        {
            var file = await Downloader.GetInputAsync(2022, 1);
            var answer = (string)null;

            var vals = new List<int>();
            var elf = 0;
            foreach(var ln in file)
            {
                int current;
                if(Int32.TryParse(ln, out current))
                {
                    elf += current;
                }
                else
                {
                    vals.Add(elf);
                    elf = 0;
                }
            }

            if(elf != 0)
                vals.Add(elf);

            answer = vals.Max().ToString();

            return answer.ToString();
        }

        public async Task<string> Part2()
        {
            var file = await Downloader.GetInputAsync(2022, 1);
            var answer = (string)null;

            var vals = new List<int>();
            var elf = 0;
            foreach (var ln in file)
            {
                int current;
                if (Int32.TryParse(ln, out current))
                {
                    elf += current;
                }
                else
                {
                    vals.Add(elf);
                    elf = 0;
                }
            }

            if (elf != 0)
                vals.Add(elf);

            answer = vals.OrderByDescending(x => x).Take(3).Sum().ToString();

            return answer.ToString();
        }
    }
}
