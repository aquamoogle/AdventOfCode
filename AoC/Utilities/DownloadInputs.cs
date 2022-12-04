using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Utilities
{
    public static class Downloader
    {
        //Where would you like to store input files?
        const string InputFolderAbsolutePath = "C:\\AoC\\2022\\";
        //Get this from being logged in and using developer tools
        //Network -> Cookies -> SessionId from the Cookie
        const string SessionId = "53616c7465645f5f644b7493f573d3a21ae011bf53598418e50ec8e87b15a17da1d79b44d2cc69228e3c6f4350a4900035eb1242ca93c67f1856245ae6e2139f";

        public static async Task<string[]> GetInputAsync(int year, int day)
        {
            var path = Path.Combine(InputFolderAbsolutePath, $"{day}.txt");
            if (File.Exists(path))
            {
                return await File.ReadAllLinesAsync(path);
            }
            else
            {
                if (!Directory.Exists(InputFolderAbsolutePath))
                {
                    Directory.CreateDirectory(InputFolderAbsolutePath);
                }

                var uri = new Uri("https://adventofcode.com");
                var cookies = new CookieContainer();
                cookies.Add(new Uri("https://adventofcode.com"), new Cookie("session", SessionId));

                using (var handler = new HttpClientHandler { CookieContainer = cookies }) 
                using(var client = new HttpClient(handler) {  BaseAddress = uri })
                {
                    var response = await client.GetAsync($"/{year}/day/{day}/input");
                    var tmp = await response.Content.ReadAsStringAsync();
                    var lines = tmp.Split("\n");

                    await File.WriteAllLinesAsync(path, lines);

                    return lines;
                }
            }
        }
    }
}
