using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#pragma warning disable CA1062

namespace WorkingWithStreams
{
    public static class ReadingFromStream
    {
        public static string ReadAllStreamContent(StreamReader streamReader)
        {
            return streamReader.ReadToEnd();
        }

        public static string[] ReadLineByLine(StreamReader streamReader)
        {
            List<string> result = new List<string>();
            while (!streamReader.EndOfStream)
            {
                result.Add(streamReader.ReadLine());
            }

            return result.ToArray();
        }

        public static StringBuilder ReadOnlyLettersAndNumbers(StreamReader streamReader)
        {
            StringBuilder result = new StringBuilder();
            while (streamReader.Peek() > -1 && char.IsLetterOrDigit((char)streamReader.Peek()))
            {
                char temp = (char)streamReader.Read();
                result.Append(temp);
            }

            return result;
        }

        public static char[][] ReadAsCharArrays(StreamReader streamReader, int arraySize)
        {
            // to Get Length try to use BaseStream, another variants doesn't work
            long length = streamReader.BaseStream.Length / arraySize;
            if (streamReader.BaseStream.Length % arraySize != 0)
            {
                length += 1;
            }

            char[][] result = new char[length][];
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                List<char> temp = new List<char>();
                for (int j = 0; j < arraySize && count < streamReader.BaseStream.Length; j++)
                {
                    temp.Add((char)streamReader.Read());
                    count++;
                }

                result[i] = temp.ToArray();
            }

            return result;
        }
    }
}
