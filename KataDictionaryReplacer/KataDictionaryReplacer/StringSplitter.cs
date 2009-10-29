using System.Collections.Generic;

namespace KataDictionaryReplacer
{
    public class StringSplitter
    {
        public IEnumerable<WordWithSpace> Split(string input)
        {
            var reader = new WordReader(input);
            while (!reader.EOF())
                yield return NextWordWithSpace(reader);
        }

        private WordWithSpace NextWordWithSpace(WordReader reader)
        {
            return (new WordWithSpace
                       {
                           Word = reader.NextWord(), 
                           Space = reader.NextSpace()
                       });
        }
    }
}