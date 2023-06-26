using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#pragma warning disable CA1062 // Validate arguments of public methods

namespace WorkingWithStreams
{
    public static class WritingToStream
    {
        public static void ReadAndWriteIntegers(StreamReader streamReader, StreamWriter outputWriter)
        {
            while (streamReader.Peek() > -1)
            {
                outputWriter.Write(streamReader.Read());
            }
        }

        public static void ReadAndWriteChars(StreamReader streamReader, StreamWriter outputWriter)
        {
            char[] result = streamReader.ReadToEnd().ToCharArray();

            for (int i = 0; i < result.Length; i++)
            {
                outputWriter.Write(result[i]);
            }

            outputWriter.Flush();
        }

        public static void TransformBytesToHex(StreamReader contentReader, StreamWriter outputWriter)
        {
            while (contentReader.Peek() > -1)
            {
                outputWriter.Write(contentReader.Read().ToString("X2", System.Globalization.CultureInfo.CurrentCulture));
            }
        }

        public static void WriteLinesWithNumbers(StreamReader contentReader, StreamWriter outputWriter)
        {
            int count = 1;
            StringBuilder resultString = new StringBuilder();

            while (!contentReader.EndOfStream)
            {
                resultString.Append(count.ToString("D3", System.Globalization.CultureInfo.InvariantCulture) + " ").Append(contentReader.ReadLine() + "\r\n");
                count++;
            }

            outputWriter.Write(resultString.ToString());
            outputWriter.Flush();
        }

        public static void RemoveWordsFromContentAndWrite(StreamReader contentReader, StreamReader wordsReader, StreamWriter outputWriter)
        {
            StringBuilder result = new StringBuilder();
            result.Append(contentReader.ReadToEnd());
            StringBuilder words = new StringBuilder();

            while (wordsReader.Peek() > -1)
            {
                words.Append((char)wordsReader.Read());
            }

            string[] wordsStrings = words.ToString().Split('\n');

            foreach (string item in wordsStrings)
            {
                result.Replace(item, string.Empty);
            }

            outputWriter.Write(result);
        }
    }
}
