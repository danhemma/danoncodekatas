using System;
using System.IO;

namespace KataBankOCR
{
    public static class Extensions
    {
        public static bool EOF(this TextReader reader)
        {
            return reader.Peek() == -1;
        }
    }
}