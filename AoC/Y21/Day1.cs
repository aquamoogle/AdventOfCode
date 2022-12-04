using AoC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    public class Day1
    {
        public async Task<string> Part1()
        {
            var file = await Downloader.GetInputAsync(2021, 1);
            var last = (int?)null;
            var answer = 0;
            foreach(var ln in file)
            {
                int output;
                if (Int32.TryParse(ln, out output))
                {
                    var current = output;
                    if (last.HasValue && last.Value < current)
                        answer++;

                    last = current;
                }
            }

            return answer.ToString();
        }

        public async Task<string> Part2()
        {
            throw new NotImplementedException();
        }
    }
}
