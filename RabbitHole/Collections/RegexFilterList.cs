using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RabbitHole.Collections
{
    public class RegexFilterList : IEnumerable<string>
    {
        private readonly List<string> _list;
        private readonly string filter;

        public RegexFilterList(string filter, string wordlist)
        {
            var regex = new Regex(filter);
            var matches = regex.Matches(wordlist);
            
            this.filter = filter;
            
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
