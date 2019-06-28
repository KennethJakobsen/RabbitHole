using System;
using System.IO;
using RabbitHole.Collections;

namespace RabbitHole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var list = new RegexFilterList("^[pultryouwians]{1,18}$", File.ReadAllText("wordlist"));
        }
    }
}
