using System;
using System.IO;

#pragma warning disable CA1062

namespace WorkingWithStreams
{
    public static class ReadingFromString
    {
        public static string ReadAllStreamContent(StringReader stringReader)
        {
            return stringReader.ReadToEnd();
        }

        public static string ReadCurrentLine(StringReader stringReader)
        {
            return stringReader.ReadLine();
        }

        public static bool ReadNextCharacter(StringReader stringReader, out char currentChar)
        {
            if (stringReader.Peek() > -1)
            {
                currentChar = Convert.ToChar(stringReader.Read());
                return true;
            }
            else
            {
                currentChar = ' ';
                return false;
            }
        }

        public static bool PeekNextCharacter(StringReader stringReader, out char currentChar)
        {
            if (stringReader.Peek() > -1)
            {
                currentChar = (char)stringReader.Peek();
                return true;
            }
            else
            {
                currentChar = ' ';
                return false;
            }
        }

        public static char[] ReadCharactersToBuffer(StringReader stringReader, int count)
        {
            char[] buffer = new char[count];
            int lengthResult = stringReader.Read(buffer, 0, count);
            char[] result = new char[lengthResult];
            Array.Copy(buffer, result, count);
            return result;
        }
    }
}
