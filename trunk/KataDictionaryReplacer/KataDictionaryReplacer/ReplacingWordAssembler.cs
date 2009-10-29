using System;
using System.Collections.Specialized;
using System.Text;

namespace KataDictionaryReplacer
{
    public class ReplacingWordAssembler
    {
        private readonly StringDictionary replacements;
        private readonly StringBuilder result;

        public ReplacingWordAssembler(StringDictionary replacements)
        {
            this.replacements = replacements;
            result = new StringBuilder();
        }

        public void Append(WordWithSpace word)
        {
            if (word.IsReplaceable() && replacements.ContainsKey(word.Word))
                Append(replacements[word.Word], word.Space);
            else
                Append(word.Word, word.Space);
        }

        private void Append(string word, string space) 
        {
            result.Append(word);
            result.Append(space);
        }

        public string GetResult()
        {
            return result.ToString();
        }
    }
}