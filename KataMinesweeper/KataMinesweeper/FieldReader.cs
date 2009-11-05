using System.IO;
using System.Text;

namespace KataMinesweeper
{
    public struct Field
    {
        public int Rows;
        public int Columns;
        public string Content;
    }

    public class FieldReader
    {
        private TextReader reader;

        public FieldReader(string input)
        {
            reader = new StringReader(input);
        }

        public bool HasMoreFields()
        {
            return reader.Peek() != -1;
        }

        public Field ReadField()
        {
            var header = reader.ReadLine();
            var sb = new StringBuilder();
            var NxM = header.Split();
            int n;
            int.TryParse(NxM[0], out n);
            int m;
            int.TryParse(NxM[1], out m);
            for (int i = 0; i < n; i++)
                sb.AppendLine(reader.ReadLine());
            return new Field() {Rows = n, Columns = m, Content = sb.ToString()};
        }
    }
}