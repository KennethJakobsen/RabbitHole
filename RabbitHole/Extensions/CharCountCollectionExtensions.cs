using System;
using System.Collections.Generic;
using System.Text;
using RabbitHole.Collections;

namespace RabbitHole.Extensions
{
    public static class CharCountCollectionExtensions
    {
        public static string ToRegex(this CharCountCollection collection)
        {
            var sb = new StringBuilder();
            foreach (var charCount in collection)
            {
                sb.Append(charCount.Character);
            }
            return $@"\n(?<word>[{sb.ToString()}]{{1,{collection.TotalLength()}}})\r";
        }
    }
}
