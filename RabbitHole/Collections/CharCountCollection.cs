using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitHole.Entities;

namespace RabbitHole.Collections
{
    public class CharCountCollection : IEnumerable<CharCount>
    {
        private readonly List<CharCount> _list;

        private CharCountCollection(IEnumerable<CharCount> list)
        {
            _list = new List<CharCount>();
            _list.AddRange(list);
        }
        public CharCountCollection(string phrase)
        {
            var chars = phrase.Replace(" ", "").ToCharArray();
            var distinct = chars.Distinct();

            _list = new List<CharCount>();

            foreach (var dChar in distinct)
            {
                _list.Add(new CharCount(Empty, dChar, chars.Count(c => c == dChar)));
            }
        }

        private void Empty(CharCount obj)
        {
            _list.Remove(obj);
        }

        public CharCountCollection Copy()
        {
            return new CharCountCollection(_list);
        }

        public bool CanWordBeMade(string word)
        {
            var chars = word.Replace(" ", "").ToCharArray();
            var distinct = chars.Distinct();
            foreach (var dChar in distinct)
            {
                if (chars.Length > TotalLength())
                    return false;
                if (_list.FirstOrDefault(c => c.Character == dChar).Count < chars.Count(c => c == dChar))
                    return false;
            }

            return true;
        }

        public void MakeWord(string word)
        {
            if (!CanWordBeMade(word))
                throw new ArgumentOutOfRangeException();

            var chars = word.Replace(" ", "").ToCharArray();
            var distinct = chars.Distinct();
            foreach (var dChar in distinct)
            {
                _list.FirstOrDefault(c => c.Character == dChar).Use(chars.Count(c => c == dChar));
            }
        }

        public bool Any()
        {
            return _list.Any();
        }

        public void Add(CharCount cc)
        {
            _list.Add(cc);
        }

        public int TotalLength()
        {
            var total = 0;
            foreach (var cc in _list)
            {
                total += cc.Count;
            }

            return total;
        }

        public IEnumerator<CharCount> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}