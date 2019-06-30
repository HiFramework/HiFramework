using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HiFramework.Core;

namespace HiFramework.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var binder = new HiFramework.Binder();
            Center.SetBinder(binder);
            Center.Init();

            //Center.Get<>();
        }
    }
}
