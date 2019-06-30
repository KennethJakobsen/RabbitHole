using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitHole.Collections;

namespace RabbitHole
{
    public class CombinationBuilder
    {
        private readonly List<string> _combinations = new List<string>();
        public IEnumerable<string> GetPossibleMatches(RegexFilterList list, CharCountCollection collection)
        {
            Combine(list, collection, null);
            return _combinations;
        }

        private void Combine(RegexFilterList list, CharCountCollection collection, List<string> current)
        {

            
            if (current == null)
                current = new List<string>();

            var l = list.Copy();
            var c = collection.Copy();
            
            if(current.Any())
                c.MakeWord(current.Last());

            if (!l.Any()) return;


            foreach (var word in l)
            {
                if (current.Contains(word))
                    continue;
                if (c.Any())
                {
                    current.Add(word);
                    Combine(l, c, current);
                }
                else
                {
                    current.Add(word);
                    _combinations.Add(current.Aggregate((i, j) => i + " " + j));
                }
            }
        }
    }
}
