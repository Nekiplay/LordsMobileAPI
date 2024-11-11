using LordsMobileAPI;
using System;

namespace Test // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var overlay = new SampleOverlay();
            overlay.Run();
        }
    }
}