using System;

namespace KataMinesweeper
{
    public class Game
    {
        public const string Header = "Field #{0}:";
        private readonly string input;

        public Game(string input)
        {
            this.input = input;
        }

        public string ShowHints()
        {
            var reader = new FieldReader(input);
            var result = "";

            int fieldCount = 1;
            while (reader.HasMoreFields())
                result += string.Format(Header, fieldCount++) + Environment.NewLine +
                    (new HintsPopulator(reader.ReadField())).GetHints().Content;
            return result;
        }
    }
}
