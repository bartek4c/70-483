using System;
using System.Runtime.InteropServices;

namespace ClassDemo
{
    class ResourceWrapper
    {
        int handle = 0;

        public ResourceWrapper()
        {
            handle = GetWindowsResource();
        }

        ~ResourceWrapper()
        {
            FreeWindowsResource(handle);
            handle = 0;
        }

        [DllImport("ASMechanics.Website.dll")]
        static extern int GetWindowsResource();

        [DllImport("ASMechanics.Website.dll")]
        static extern void FreeWindowsResource(int handle);
    }
}
