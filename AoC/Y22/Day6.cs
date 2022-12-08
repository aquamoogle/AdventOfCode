using AoC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y22
{
    public class Day6
    {
        public async Task<string> Part1()
        {
            var file = (await Downloader.GetInputAsync(2022, 6).ConfigureAwait(false)).First();
			var answer = Enumerable.Range(0, file.Length - 4)
				.Select(x => new { str = new string(file.Skip(x).Take(4).ToArray()), lastIndex = x + 4 })
				.Where(x => x.str.Distinct().Count() == 4)
				.First();
			return answer.lastIndex.ToString();
        }

        public async Task<string> Part2()
		{
			var file = (await Downloader.GetInputAsync(2022, 6).ConfigureAwait(false)).First();
			var answer = Enumerable.Range(0, file.Length - 14)
				.Select(x => new { str = new string(file.Skip(x).Take(14).ToArray()), firstIndex = x + 14 })
				.Where(x => x.str.Distinct().Count() == 14)
				.First();
			return answer.firstIndex.ToString();
		}
	}
}
