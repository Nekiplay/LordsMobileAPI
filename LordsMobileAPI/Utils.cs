using Process.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsMobileAPI
{
    public static class Utils
    {
        public static nint ReadOffset(nint baseAddres, int[] offsets, ProcessSharp processSharp)
        {
            for (int i = 0; i < offsets.Count() - 1; i++)
            {
                baseAddres = (nint)processSharp.Memory.Read<long>(IntPtr.Add((IntPtr)baseAddres, offsets[i]));
            }
            return baseAddres + offsets[offsets.Count() - 1];
        }
        public static IntPtr GetModuleAdress(string modulname, ProcessSharp processSharp)
        {
            return processSharp.ModuleFactory[modulname].BaseAddress;
        }
    }
}
