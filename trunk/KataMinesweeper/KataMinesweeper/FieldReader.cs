using System.Collections.Generic;
using System.IO;

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
            var header = ReadHeader();
            var rowCount = GetRowCount(header);
            var columnCount = GetColumnCount(header);
            return ReadField(rowCount, columnCount);
        }

        private Field ReadField(int rowCount, int columnCount)
        {
            var rows = new List<string>();
            ReadRows(rowCount, rows);            
            return CreateResult(rows, columnCount);
        }

        private void ReadRows(int rowCount, List<string> rows)
        {
            for (int i = 0; i < rowCount; i++)
                rows.Add(reader.ReadLine());
        }

        private Field CreateResult(List<string> rows, int m)
        {
            return new Field() {Rows = new FieldRows(rows.ToArray()), ColumnCount = m };
        }

        private int GetColumnCount(string[] header)
        {
            return GetDimensionFromHeader(header, 1);
        }

        private int GetRowCount(string[] header)
        {
            return GetDimensionFromHeader(header, 0);
        }

        private int GetDimensionFromHeader(string[] header, int index)
        {
            int dimension;
            int.TryParse(header[index], out dimension);
            return dimension;
        }

        private string[] ReadHeader()
        {
            var header = reader.ReadLine();
            return header.Split();
        }
    }
}