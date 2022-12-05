using AoC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y22
{
    public class Day5
    {

        /*    
[S] [C]         [Z]            
[F] [J] [P]         [T]     [N]    
[G] [H] [G] [Q]     [G]     [D]    
[V] [V] [D] [G] [F] [D]     [V]    
[R] [B] [F] [N] [N] [Q] [L] [S]    
[J] [M] [M] [P] [H] [V] [B] [B] [D]
[L] [P] [H] [D] [L] [F] [D] [J] [L]
[D] [T] [V] [M] [J] [N] [F] [M] [G]
 1   2   3   4   5   6   7   8   9 

move 3 from 4 to 6*/

        public void Print(List<Stack<char>> stacks)
        {
            var board = stacks.Select(x => new Stack<char>(x)).ToList();
            do
            {
                for (var i = 0; i < board.Count; i++)
                {
                    char c;
                    if (board[i].Any())
                    {
                        c = board[i].Pop();
                    }
                    else
                    {
                        c = ' ';
                    }
                    Console.Write($"[{c}] ");
                }
                Console.WriteLine();
            } while (board.Any(x => x.Any()));
        }

        public async Task<string> Part1()
        {
            var file = await Downloader.GetInputAsync(2022, 5).ConfigureAwait(false);
            var stacks = new List<Stack<char>>
            {
                new Stack<char>("FGVRJLD".Reverse()),
                new Stack<char>("SJHVBMPT".Reverse()),
                new Stack<char>("CPGDFMHV".Reverse()),
				new Stack<char>("QGNPDM".Reverse()),
				new Stack<char>("FNHLJ".Reverse()),
				new Stack<char>("ZTGDQVFN".Reverse()),
				new Stack<char>("LBDF".Reverse()),
				new Stack<char>("NDVSBJM".Reverse()),
				new Stack<char>("DLG".Reverse())
			};

            Print(stacks);

            foreach (var item in file)
            {
                if (item.StartsWith("move"))
                {
                    Console.WriteLine(item);

                    var args = item.Split(" ");
                    var count = Int32.Parse(args[1]);
                    var source = Int32.Parse(args[3]) - 1;
                    var dest = Int32.Parse(args[5]) - 1;

                    for (var i = 0; i < count; i++)
                    {
                        var sourceStack = stacks[source];
                        var destStack = stacks[dest];

						if (!stacks[source].Any())
							continue;

						destStack.Push(sourceStack.Pop());
                    }

                    Print(stacks);
                }
            }

            return new string(stacks.Where(x => x.Any()).Select(x => x.Pop()).ToArray());
        }

        public async Task<string> Part2()
		{
			var file = await Downloader.GetInputAsync(2022, 5).ConfigureAwait(false);
			var stacks = new List<Stack<char>>
			{
				new Stack<char>("FGVRJLD".Reverse()),
				new Stack<char>("SJHVBMPT".Reverse()),
				new Stack<char>("CPGDFMHV".Reverse()),
				new Stack<char>("QGNPDM".Reverse()),
				new Stack<char>("FNHLJ".Reverse()),
				new Stack<char>("ZTGDQVFN".Reverse()),
				new Stack<char>("LBDF".Reverse()),
				new Stack<char>("NDVSBJM".Reverse()),
				new Stack<char>("DLG".Reverse())
			};

			Print(stacks);

			foreach (var item in file)
			{
				if (item.StartsWith("move"))
				{
					//Console.WriteLine(item);

					var args = item.Split(" ");
					var count = Int32.Parse(args[1]);
					var source = Int32.Parse(args[3]) - 1;
					var dest = Int32.Parse(args[5]) - 1;

                    var elems = new List<char>();
					for (var i = 0; i < count; i++)
					{
						var sourceStack = stacks[source];

						if (!stacks[source].Any())
							continue;

                        elems.Add(sourceStack.Pop());
					}

                    elems.Reverse();
                    elems.ToList().ForEach(x => stacks[dest].Push(x));

					//Print(stacks);
				}
			}

			return new string(stacks.Where(x => x.Any()).Select(x => x.Pop()).ToArray());
		}
	}
}
