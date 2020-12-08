using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Bot
{
    public class Functions
    {
        private const int YellFunctionOffset = 0x10E1;

        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void YellDelegate();

        YellDelegate YellFunction;

        public Functions()
        {
            var processModule = Process.GetCurrentProcess().MainModule;
            if (processModule != null)
                YellFunction = Marshal.GetDelegateForFunctionPointer(
                    processModule.BaseAddress + YellFunctionOffset,
                    typeof(YellDelegate)) as YellDelegate;
        }
        
        internal void Yell() => YellFunction();
    }
}
