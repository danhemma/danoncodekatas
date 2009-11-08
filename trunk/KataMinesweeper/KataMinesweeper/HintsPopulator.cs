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
            for (int row = 0; row < field.RowCount; row++)
            {
                string resultRow = "";
                for (int column = 0; column < field.ColumnCount; column++)
                    resultRow += GetHintAt(row, column);
                result.Add(resultRow);    
            }
            return CreateResult(result);
        }

        private char GetHintAt(int row, int column)
        {
            if (field.MineAt(row, column))
                return field.CharAt(row, column);
            return '1';
        }

        private Field CreateResult(List<string> result)
        {
            return new Field {ColumnCount = field.ColumnCount, Rows = new FieldRows(result.ToArray())};
        }
    }
}