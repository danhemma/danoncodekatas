using System;
using System.Collections.Specialized;

namespace KataDictionaryReplacer
{
    public class Replacer
    {
        private readonly ReplacingWordAssembler wordAssembler;

        public Replacer(StringDictionary dictionary)
        {
            wordAssembler = new ReplacingWordAssembler(dictionary);
        }

        public string Replace(string input)
        {
            var splitter = new StringSplitter();
            foreach (var word in splitter.Split(input))
                wordAssembler.Append(word);
            return wordAssembler.GetResult();
        }
    }
}