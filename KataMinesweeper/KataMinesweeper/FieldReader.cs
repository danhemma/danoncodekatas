using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KataMinesweeper
{
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
            var NxM = header.Split();
            int n;
            int.TryParse(NxM[0], out n);
            int m;
            int.TryParse(NxM[1], out m);
            List<string> rows = new List<string>();
            for (int i = 0; i < n; i++)
                rows.Add(reader.ReadLine());
            
            return new Field() {Rows = new FieldRows(rows.ToArray()), ColumnCount = m };
        }
    }
}