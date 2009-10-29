using System;

namespace KataDictionaryReplacer
{
    public class WordWithSpace 
    {
        private string _word;
        public string Word
        {
            get
            {
                return IsReplaceable() ? WithoutFirstAndLast() : _word;
            }
            set 
            { 
                _word = value; 
            }
        }

        public string Space { get; set; }
        
        public WordWithSpace() {}

        public WordWithSpace(string word, string space)
        {
            Word = word;
            Space = space;
        }

        public override bool Equals(object obj)
        {
            var other = obj as WordWithSpace;
            return 
                other != null && 
                other._word == _word && 
                other.Space == Space;
        }

        public override int GetHashCode()
        {
            return _word.GetHashCode() | Space.GetHashCode();
        }

        public override string ToString()
        {
            return Word + Space;
        }

        public bool IsReplaceable()
        {
            return _word.StartsWith("$") && _word.EndsWith("$");
        }

        private string WithoutFirstAndLast()
        {
            return _word.Substring(1, _word.Length - 2);
        }

    }
}