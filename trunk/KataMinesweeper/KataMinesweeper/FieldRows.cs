using System;
using System.Collections;
using System.Collections.Generic;

namespace KataMinesweeper
{
    public struct FieldRows : IEnumerable<string>
    {
        private readonly List<string> rows;
        public FieldRows(IEnumerable<string> rows)
        {
            this.rows = new List<string>(rows);
        }

        public string this[int index]
        {
            get { return rows[index]; }
            set { rows[index] = value; }
        }

        public int Count
        {
            get { return rows.Count; }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return rows.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, rows.ToArray());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}