using AoC.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Y22
{
    public class Day8
    {
        public bool IsVisibleCol(List<List<int>> grid, int x, int y)
        {
            var col = grid.Select(row => row[x]).ToList();

            var visible = true;
            for (var i = y + 1; i < col.Count(); i++)
            {
                if (col[y] <= col[i])
                    visible = false;
            }
            if (visible)
                return true;

            for (var i = y - 1; i >= 0; i--)
            {
                if (col[y] <= col[i])
                    return false;
            }

            return true;
        }

        public bool IsVisibleRow(List<List<int>> grid, int x, int y)
        {
            var row = grid[y];

            var visible = true;
            for(var i = x + 1; i < row.Count(); i++)
            {
                if (row[x] <= row[i])
                    visible = false;
            }
            if (visible)
                return true;

            for(var i = x - 1; i >= 0; i--)
            {
                if (row[x] <= row[i])
                    return false;
            }

            return true;
        }

        public async Task<string> Part1()
        {
            var file = (await Downloader.GetInputAsync(2022, 8).ConfigureAwait(false));
            var grid = file.Where(x => x.Any()).Select(x => x.Select(x => int.Parse(x.ToString())).ToList()).ToList();

            var visible = 0;
            for(var y = 0; y < grid.Count(); y++)
            {
                for(var x = 0; x < grid[y].Count(); x++)
                {
                    if (x == 0 || y == 0 || x == (grid[y].Count - 1) || y == (grid.Count - 1))
                        visible++;
                    else if (IsVisibleRow(grid, x, y) || IsVisibleCol(grid, x, y))
                        visible++;
                }
            }

            return visible.ToString();
        }

        public int ColScore(List<List<int>> grid, int x, int y)
        {
            var col = grid.Select(row => row[x]).ToList();

            int visible = 0;
            for (var i = y + 1; i < col.Count(); i++)
            {
                if (col[y] > col[i])
                    visible++;
                else
                {
                    visible++;
                    break;
                }
            }

            var visible2 = 0;
            for (var i = y - 1; i >= 0; i--)
            {
                if (col[y] > col[i])
                    visible2++;
                else
                {
                    visible2++;
                    break;
                }
            }

            return visible * visible2;
        }

        public int RowScore(List<List<int>> grid, int x, int y)
        {
            var row = grid[y];

            var visible = 0;
            for (var i = x + 1; i < row.Count(); i++)
            {
                if (row[x] > row[i])
                    visible++;
                else
                {
                    visible++;
                    break;
                }
            }

            var visible2 = 0;
            for (var i = x - 1; i >= 0; i--)
            {
                if (row[x] > row[i])
                    visible2++;
                else
                {
                    visible2++;
                    break;
                }
            }

            return visible * visible2;
        }

        public async Task<string> Part2()
		{
            var file = (await Downloader.GetInputAsync(2022, 8).ConfigureAwait(false));
            var grid = file.Where(x => x.Any()).Select(x => x.Select(x => int.Parse(x.ToString())).ToList()).ToList();

            var max = 0;
            for (var y = 0; y < grid.Count(); y++)
            {
                for (var x = 0; x < grid[y].Count(); x++)
                {
                    if (x == 0 || y == 0 || x == (grid[y].Count - 1) || y == (grid.Count - 1))
                        continue;

                    var score = RowScore(grid, x, y) * ColScore(grid, x, y);
                    if (score > max)
                        max = score;
                }
            }

            return max.ToString();
        }
	}
}
