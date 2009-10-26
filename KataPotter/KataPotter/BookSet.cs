using System;
using System.Collections;
using System.Collections.Generic;

namespace KataPotter
{
    public class BookSet
    {
        private const int TYPESOFBOOKS = 5;
        private readonly Hashtable hash = new Hashtable();

        private BookSet(Hashtable hash)
        {
            this.hash = hash;   
        }

        public BookSet(params int[] books)
        {
            Array.ForEach(books, IncreaseCountFor);
        }

        public bool IsEmpty()
        {
            for (int i = 0; i <= 5; i++)
            {
                if (CountFor(i) > 0)
                    return false;
            }
            return true;
        }

        private void IncreaseCountFor(int book)
        {
            hash[book] = hash.ContainsKey(book) ? ((int)hash[book] + 1) : 1;
        }

        public int[] PopCart(int includeAtMost)
        {
            var result = new List<int>(TYPESOFBOOKS);
            for (int book = 1; book <= TYPESOFBOOKS; book++)
            {
                if (result.Count == includeAtMost)
                    break;
                if (CountFor(book) == 0)
                    continue;
                result.Add(book);
                ReduceCountFor(book);
            }
            return result.ToArray();
        }

        private void ReduceCountFor(int value)
        {
            hash[value] = (int)hash[value] - 1;
        }

        public int CountFor(int book)
        {
            return hash.ContainsKey(book) ? (int)hash[book] : 0;
        }

        public BookSet Clone()
        {
            return new BookSet((Hashtable)hash.Clone());
        }
    }
}