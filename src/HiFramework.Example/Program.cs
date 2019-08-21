using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiFramework.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var io = Center.Get<IIO>();
            var bytes = io.ReadFile("path");
        }
    }
}
