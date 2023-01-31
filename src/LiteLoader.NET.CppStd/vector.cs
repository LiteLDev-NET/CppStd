using LiteLoader.NET.CppStd.Internal;
using LiteLoader.NET.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LiteLoader.NET.CppStd
{
    public class vector<T> : _Vector_base<T, allocator<T>> where T : new()
    {
        public vector() : base()
        {
        }

        public vector(nint ptr) : base(ptr)
        {
        }

        public vector(vector<T> vec) : base(vec)
        {
        }

        public vector(move<vector<T>> vec) : base(vec)
        {
        }

        public vector(nint ptr, [MarshalAs(UnmanagedType.U1)] bool ownsInstance) : base(ptr, ownsInstance)
        {
        }
    }

    public class vector<T, TAlloc> : _Vector_base<T, TAlloc>
        where T : new()
        where TAlloc : ICppStdAllocator, new()
    {
        public vector() : base()
        {
        }

        public vector(nint ptr) : base(ptr)
        {
        }

        public vector(vector<T, TAlloc> vec) : base(vec)
        {
        }

        public vector(move<vector<T, TAlloc>> vec) : base(vec)
        {
        }

        public vector(nint ptr, [MarshalAs(UnmanagedType.U1)] bool ownsInstance) : base(ptr, ownsInstance)
        {
        }
    }
}
