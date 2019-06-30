using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using RabbitHole.Entities;
using RabbitHole.Extensions;

namespace RabbitHole.Collections
{
    public class RegexFilterList : IEnumerable<string>
    {
        private readonly string _wordlist;
        private List<string> _list;

        private RegexFilterList(IEnumerable<string> list)
        {
            _list = new List<string>();
            _list.AddRange(list);
        }
        public RegexFilterList(CharCountCollection collection, string wordlist)
        {
            _wordlist = wordlist;
            Filter(collection);
        }

        public void Filter(CharCountCollection collection)
        {
            var regex = new Regex(collection.ToRegex(), RegexOptions.Multiline | RegexOptions.Compiled);
            var matches = regex.Matches(_wordlist);
            _list = matches
                .Select(m => m.Groups["word"].Value)
                .Distinct()
                .Where(collection.CanWordBeMade)
                .OrderByDescending(c => c.Length)
                .ToList();
        }

        public RegexFilterList Copy()
        {
            return new RegexFilterList(_list);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}