using AoC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y22
{
    public class Range {
        public int Start;
        public int End;
        public Range(string input1)
        {
            var data = input1.Split("-");
            Start = Int32.Parse(data[0]);
            End = Int32.Parse(data[1]);
        }

        public bool Contains(Range input)
        {
            return (Start <= input.Start && End >= input.End) ;
        }

        public bool AnyOverlap(Range input)
        {
            return (Start <= input.Start && End >= input.End) || (Start <= input.End && End >= input.End);
        }
    }
    public class Day4
    {
        public async Task<string> Part1()
        {
            var file = await Downloader.GetInputAsync(2022, 4).ConfigureAwait(false);
            return file.Where(x => x.Contains(","))
                .Select(x => x.Split(",").Select(y => new Range(y)).ToList())
                .Where(x => x[0].Contains(x[1]) || x[1].Contains(x[0]))
                .Count().ToString();
        }

        public async Task<string> Part2()
        {
			var file = await Downloader.GetInputAsync(2022, 4).ConfigureAwait(false);
			return file.Where(x => x.Contains(","))
				.Select(x => x.Split(",").Select(y => new Range(y)).ToList())
				.Where(x => x[0].AnyOverlap(x[1]) || x[1].AnyOverlap(x[0]))
				.Count().ToString();
		}
    }
}
