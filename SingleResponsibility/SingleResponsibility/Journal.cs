using System;
using System.Collections.Generic;
using System.IO;

namespace SingleResponsibility
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; //memento pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        //public static Journal Load(string filename)
        //{

        //}


        //public static Journal Load(string uri)
        //{
        //}
    }
}
