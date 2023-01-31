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
    public class vector<T>
        : _Vector_base<T, allocator<T>>
        , IList<T>
        , ICppClassHelper<T>
        , IConstructableCppClass<vector<T>>
        , ICopyable<vector<T>>
        , IMoveable<vector<T>>
        , IDisposable
        where T : new()
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

        public vector<T> ConstructInstanceByCopy(vector<T> _Right)
        {
            return new(_Right);
        }

        public vector<T> ConstructInstanceByMove(move<vector<T>> _Right)
        {
            return new(_Right);
        }

        vector<T> IPointerConstructable<vector<T>>.ConstructInstance(nint ptr, bool ownsInstance)
        {
            return new(ptr, ownsInstance);
        }
    }

    public class vector<T, TAlloc>
        : _Vector_base<T, TAlloc>
        , IList<T>
        , ICppClassHelper<T>
        , IConstructableCppClass<vector<T, TAlloc>>
        , ICopyable<vector<T, TAlloc>>
        , IMoveable<vector<T, TAlloc>>
        , IDisposable
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

        public vector<T, TAlloc> ConstructInstanceByCopy(vector<T, TAlloc> _Right)
        {
            return new(_Right);
        }

        public vector<T, TAlloc> ConstructInstanceByMove(move<vector<T, TAlloc>> _Right)
        {
            return new(_Right);
        }

        vector<T, TAlloc> IPointerConstructable<vector<T, TAlloc>>.ConstructInstance(nint ptr, bool ownsInstance)
        {
            return new(ptr, ownsInstance);
        }
    }
}
