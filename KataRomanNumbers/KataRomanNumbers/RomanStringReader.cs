using System;
using System.IO;

namespace KataRomanNumbers
{
    public class RomanStringReader : StringReader
    {
        private RomanCharConverter converter;

        public RomanStringReader(string romanString) : base(romanString)
        {
            this.converter = new RomanCharConverter();
        }

        public bool EndOfString
        {
            get
            {
                return base.Peek() == -1;
            }
        }

        public override int Read()
        {
            if (EndOfString)
                throw new InvalidOperationException("Attempt to read when EndOfString");
            return converter.Convert((char) base.Read());
        }

        public override int Peek()
        {
            return EndOfString ? 0 : converter.Convert((char) base.Peek());
        }

        public void Skip()
        {
            base.Read();
        }
    }
}