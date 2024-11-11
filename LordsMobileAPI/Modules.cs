using Process.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsMobileAPI
{
    public class Modules
    {
        public nint GameAssembly = -1;
        public Modules(ProcessSharp processSharp)
        {
            GameAssembly = processSharp.ModuleFactory["GameAssembly.dll"].BaseAddress;
        }
    }
}
