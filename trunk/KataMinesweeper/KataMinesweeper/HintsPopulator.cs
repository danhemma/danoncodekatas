using System;
using System.Collections.Generic;

namespace KataMinesweeper
{
    public class HintsPopulator
    {
        private readonly Field field;

        public HintsPopulator(Field field)
        {
            this.field = field;
        }

        public Field GetHints()
        {
            var result = new List<string>();
            AddRowsWithHints(result);
            return CreateResultFieldWith(result);
        }

        private void AddRowsWithHints(ICollection<string> result)
        {
            for (int row = 0; row < field.RowCount; row++)
                AddRowWithHints(row, result);
        }

        private void AddRowWithHints(int row, ICollection<string> result)
        {
            string resultRow = "";
            for (int column = 0; column < field.ColumnCount; column++)
                resultRow += GetHintAt(row, column);
            result.Add(resultRow);
        }

        private char GetHintAt(int row, int column)
        {
            return field.MineAt(row, column) ? '*' :
                IntToChar(CountMinesAround(row, column));
        }

        private char IntToChar(int value)
        {
            return Char.ConvertFromUtf32(value + 48)[0];
        }

        private int CountMinesAround(int row, int column)
        {
            int minesAround = 0;
            foreach (var rowOffset in new [] {-1, 0, 1})
                foreach (var columnOffset in new[] { -1, 0, 1})
                   minesAround += field.MineAt(row + rowOffset, column + columnOffset) ? 1 : 0;
            return minesAround;
        }

        private Field CreateResultFieldWith(List<string> result)
        {
            return new Field {ColumnCount = field.ColumnCount, Rows = new FieldRows(result.ToArray())};
        }
    }
}