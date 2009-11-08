using System;

namespace KataMinesweeper
{
    public struct Field
    {
        public int ColumnCount;
        public FieldRows Rows;

        public int RowCount
        {
            get { return Rows.Count; }
        }

        public char CharAt(int row, int column)
        {
            return Rows[row][column];
        }

        public bool MineAt(int row, int column)
        {
            if (column < 0 || column >= ColumnCount)
                return false;
            if (row < 0 || row >= Rows.Count)
                return false;
            return CharAt(row, column) == '*';
        }
    }
}