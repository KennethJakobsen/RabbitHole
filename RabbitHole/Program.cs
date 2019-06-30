using System;
using System.IO;
using System.Linq;
using System.Text;
using RabbitHole.Collections;

namespace RabbitHole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var collection = new CharCountCollection("poultry outwits ants");
            var list = new RegexFilterList(collection, File.ReadAllText("wordlist"));

            var sb = new StringBuilder();
           var collBuilder = new CombinationBuilder();
            var lst = collBuilder.GetPossibleMatches(list, collection);
        }
    }
}
