using OSRS.HiScores;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            foreach(var p in PlayerScores.GetAll(0))
            {
                Console.WriteLine(p.ToJson());
            }
        }
    }
}
