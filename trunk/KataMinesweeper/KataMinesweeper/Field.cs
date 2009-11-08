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
            return CharAt(row, column) == '*';
        }
    }
}