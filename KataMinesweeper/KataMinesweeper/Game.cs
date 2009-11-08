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
            {
                var fieldWithHints = (new HintsPopulator(reader.ReadField())).GetHints();
                result += string.Format(Header, fieldCount++) + Environment.NewLine +
                          fieldWithHints.Rows + Environment.NewLine;
            }
            return RemoveNewline(result);
        }

        private string RemoveNewline(string result)
        {
            return result.Substring(0, result.Length - Environment.NewLine.Length);
        }
    }
}
