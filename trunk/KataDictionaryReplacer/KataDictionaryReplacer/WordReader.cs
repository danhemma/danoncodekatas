using System;
using System.IO;

namespace KataDictionaryReplacer
{
    public class WordReader
    {
        private readonly TextReader reader;

        public WordReader(string input)
        {
            reader = new StringReader(input); 
        }

        public bool EOF()
        {
            return reader.Peek() == -1;
        }

        public string NextWord()
        {
            return NextPart(true);
        }

        public string NextSpace()
        {
            return NextPart(false);
        }

        private string NextPart(bool exitOnWhiteSpace)
        {
            string result = "";
            while (true)
            {
                if (EOF() || NextIsWhiteSpace() == exitOnWhiteSpace)
                    return result;
                result += (char)reader.Read();
            }
        }

        private bool NextIsWhiteSpace()
        {
            return Char.IsWhiteSpace((char)reader.Peek());
        }
    }
}