using AoC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC.Y22
{
    public class Day3
    {
        public async Task<string> AltPart1()
        {
            var file = await Downloader.GetInputAsync(2022, 3).ConfigureAwait(false);
            var lower = new Regex("[a-z]");
            return file
                .Where(x => x.Length > 0)
                .Select(x => x.Chunk(x.Length / 2).ToList())
                .Select(x => x[0].Intersect(x[1]))
                .Sum(x => 
                    x.Where(y=>lower.IsMatch(y.ToString())).Sum(y => y - 'a' + 1)
                    + x.Where(y => !lower.IsMatch(y.ToString())).Sum(y => y - 'A' + 27)
                ).ToString();
        }

        public async Task<string> Part1()
        {
            var file = await Downloader.GetInputAsync(2022, 3);
            var lower = new Regex("[a-z]");
            var total = 0;
            foreach(var ln in file)
            {
                var half = ln.Count() / 2;
                var first = new string(ln.Take(half).ToArray());
                var second = new string(ln.Skip(half).ToArray());
                var found = new List<char>();
                foreach(var c in first)
                {
                    if (second.Contains(c) && !found.Contains(c))
                    {
                        if (lower.IsMatch(c.ToString()))
                            total += c - 'a' + 1;
                        else
                            total += c - 'A' + 27;

                        found.Add(c);
                    }
                }
            }

            return total.ToString();
        }

        public async Task<string> Part2()
        {
            var file = await Downloader.GetInputAsync(2022, 3);
            var lower = new Regex("[a-z]");
            var compare = new List<string>();
            var total = 0;
            foreach (var ln in file)
            {
                compare.Add(ln);
                if (compare.Count() != 3)
                    continue;

                var found = new List<char>();
                foreach (var c in compare[0])
                {
                    if (compare[1].Contains(c) && compare[2].Contains(c) && !found.Contains(c))
                    {
                        if (lower.IsMatch(c.ToString()))
                            total += c - 'a' + 1;
                        else
                            total += c - 'A' + 27;

                        found.Add(c);
                    }
                }
                compare.Clear();
            }

            return total.ToString();
        }
    }
}
