using System;
using System.Collections.Generic;
using System.Text;

namespace TestLib
{
    public class ConsolePrinter
    {
        private string _prefix;

        public ConsolePrinter(string prefix) => _prefix = prefix;
         
        public void Print(string message)
        {
            Console.WriteLine("{0}{1}", _prefix, message);
        }

        private int GetPrefixLength(int offset, string str) => _prefix?.Length ?? -1 + offset + str?.Length ?? 0;
    }

    internal class PrivatePrinter
    {
        private int _data;

        private PrivatePrinter(int data) { _data = data; }

        public void Print(string message) => Console.WriteLine("{0} - {1}", message, _data);
    }
}
