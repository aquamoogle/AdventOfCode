using AoC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y22
{
	public enum NodeType
	{
		File,
		Directory
	}

	public class Node
	{
		public NodeType Type { get; set; }
		public string Name { get; set; }
		public Dictionary<string, Node> Children { get; set; }
		public Node Parent { get; set; }
		public long Size { get; set; }


		public Node()
		{
			Children = new Dictionary<string, Node>();
		}
	}

    public class Day7
    {
		public Node Root { get; set; }
		public Node Location { get; set; }
		public List<Node> Directories { get; set; } = new List<Node>();
		public void ls(int idx, string[] file)
		{
			string[] data;
			do
			{
				data = file[idx].Split(' ');
				if (data == null || data[0] == String.Empty || data[0] == "$")
					return;
				var n = new Node();
				n.Type = (data[0] == "dir" ? NodeType.Directory : NodeType.File);
				n.Name = data[1];
				n.Parent = Location;

				if (n.Type == NodeType.File)
				{
					n.Size = int.Parse(data[0]);
					var p = n.Parent;
					while (p != null)
					{
						p.Size += n.Size;
						p = p.Parent;
					}
				}
				else
				{
					Directories.Add(n);
				}

				Location.Children.Add(n.Name, n);
				idx++;
			} while (idx < file.Length && data[0] != "$");
		}

		public void cd(string path)
		{
			if (path == "..")
			{
				Location = Location.Parent;
			}
			else
			{
				Location = Location.Children[path];
			}
		}

        public async Task<string> Part1()
        {
            var file = (await Downloader.GetInputAsync(2022, 7).ConfigureAwait(false));
			Root = Location = new Node() { Type = NodeType.Directory, Name = "/" };
			for (var i = 1; i < file.Length; i++)
			{
				var data = file[i].Split(' ');
				if (data[0] == "$")
				{
					if (data[1] == "cd")
						cd(data[2]);
					else
						ls(i + 1, file);
				}
			}

			return Directories.Where(x => x.Type == NodeType.Directory && x.Size <= 100000).Sum(x => x.Size).ToString();
        }

        public async Task<string> Part2()
		{
			var file = (await Downloader.GetInputAsync(2022, 7).ConfigureAwait(false));
			Root = Location = new Node() { Type = NodeType.Directory, Name = "/" };
			for (var i = 1; i < file.Length; i++)
			{
				var data = file[i].Split(' ');
				if (data[0] == "$")
				{
					if (data[1] == "cd")
						cd(data[2]);
					else
						ls(i + 1, file);
				}
			}

			var free = 70000000 - Root.Size;
			var needed = 30000000 - free;

			var target = Directories.OrderBy(x => x.Size).SkipWhile(x => x.Size < needed).First();
			return target.Size.ToString();
		}
	}
}
