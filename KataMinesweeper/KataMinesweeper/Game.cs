using System;

namespace KataMinesweeper
{
    public class Game
    {
        private const string Header = "Field #{0}:";
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
                result += GetHeader(fieldCount++) +
                          GetFieldWithHints(reader).Rows + Environment.NewLine;
            }
            return RemoveNewline(result);
        }

        private Field GetFieldWithHints(FieldReader reader)
        {
            return (new HintsPopulator(reader.ReadField())).GetHints();
        }

        public static string GetHeader(int fieldCount)
        {
            return string.Format(Header, fieldCount) + Environment.NewLine;
        }

        private string RemoveNewline(string result)
        {
            return result.Substring(0, result.Length - Environment.NewLine.Length);
        }
    }
}
