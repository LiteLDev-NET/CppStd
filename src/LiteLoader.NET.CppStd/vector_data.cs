using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LiteLoader.NET.CppStd.Internal
{
    [StructLayout(LayoutKind.Explicit, Pack = 16, Size = 24)]
    public struct _Vector_data
    {
        [StructLayout(LayoutKind.Explicit, Pack = 16, Size = 24)]
        public struct _Compressed_pair
        {
            [StructLayout(LayoutKind.Explicit, Pack = 16, Size = 24)]
            public struct _Vector_val
            {
                [FieldOffset(0)]
                public unsafe byte* _Myfirst;

                [FieldOffset(8)]
                public unsafe byte* _Mylast;

                [FieldOffset(16)]
                public unsafe byte* _Myend;
            }

            [FieldOffset(0)]
            public _Vector_val _Myval2;
        }

        [FieldOffset(0)]
        public _Compressed_pair _Mypair;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 16, Size = 8)]
    public struct _Vector_iterator_data
    {
        [FieldOffset(0)]
        public unsafe byte* _Ptr;
    }

    public struct vector
    {
        public struct iterator
        {
            internal _Vector_iterator_data _Iter;

            internal ulong _Element_type_size;

            public unsafe iterator this[int index]
            {
                get
                {
                    //IL_002a: Expected I, but got I8
                    iterator result = this;
                    result._Iter._Ptr = (byte*)((long)result._Element_type_size * (long)index + (nint)result._Iter._Ptr);
                    return result;
                }
            }

            public iterator(_Vector_iterator_data data, ulong elementTypeSize)
            {
                _Iter = data;
                _Element_type_size = elementTypeSize;
            }

            public unsafe iterator(IntPtr stdVectorIteratorPtr, ulong elementTypeSize)
            {
                _Element_type_size = elementTypeSize;
                ref _Vector_iterator_data iter = ref _Iter;
                iter = *(_Vector_iterator_data*)(void*)stdVectorIteratorPtr;
            }

            public unsafe iterator(void* stdVectorIteratorPtr, ulong elementTypeSize)
            {
                _Element_type_size = elementTypeSize;
                ref _Vector_iterator_data iter = ref _Iter;
                iter = *(_Vector_iterator_data*)stdVectorIteratorPtr;
            }

            public unsafe static iterator operator ++(iterator val)
            {
                //IL_0022: Expected I, but got I8
                iterator result = val;
                result._Iter._Ptr = (byte*)((ulong)(nint)result._Iter._Ptr + result._Element_type_size);
                return result;
            }

            public unsafe static iterator operator --(iterator val)
            {
                //IL_0022: Expected I, but got I8
                iterator result = val;
                result._Iter._Ptr = (byte*)((ulong)(nint)result._Iter._Ptr - result._Element_type_size);
                return result;
            }

            public unsafe static iterator operator +(iterator a, int b)
            {
                //IL_0025: Expected I, but got I8
                iterator result = a;
                result._Iter._Ptr = (byte*)((long)result._Element_type_size * (long)b + (nint)result._Iter._Ptr);
                return result;
            }

            public unsafe static iterator operator -(iterator a, int b)
            {
                //IL_0025: Expected I, but got I8
                iterator result = a;
                result._Iter._Ptr = (byte*)((nint)result._Iter._Ptr - (long)result._Element_type_size * (long)b);
                return result;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public unsafe static bool operator >(iterator a, iterator b)
            {
                return a._Iter._Ptr > b._Iter._Ptr;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public unsafe static bool operator <(iterator a, iterator b)
            {
                return a._Iter._Ptr < b._Iter._Ptr;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public unsafe static bool operator >=(iterator a, iterator b)
            {
                return (byte)((a._Iter._Ptr >= b._Iter._Ptr) ? 1u : 0u) != 0;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public unsafe static bool operator <=(iterator a, iterator b)
            {
                return (byte)((a._Iter._Ptr <= b._Iter._Ptr) ? 1u : 0u) != 0;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public unsafe static bool operator ==(iterator a, iterator b)
            {
                return a._Iter._Ptr == b._Iter._Ptr;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public static bool operator !=(iterator a, iterator b)
            {
                return !(a == b);
            }

            public unsafe void* get()
            {
                return _Iter._Ptr;
            }
        }

        internal unsafe _Vector_data* _Data;

        internal ulong _Element_type_size;

        internal bool _Constructed_by_managed;

        public unsafe ref _Vector_data internal_data => ref *_Data;

        public unsafe vector(IntPtr stdVectorPtr, ulong elementTypeSize)
        {
            _Element_type_size = elementTypeSize;
            _Data = (_Vector_data*)(void*)stdVectorPtr;
        }

        public unsafe vector(void* stdVectorPtr, ulong elementTypeSize)
        {
            _Element_type_size = elementTypeSize;
            _Data = (_Vector_data*)stdVectorPtr;
        }

        public unsafe ulong size()
        {
            _Vector_data* ptr = _Data;
            return (ulong)(nint)(ptr->_Mypair._Myval2._Mylast - (nuint)ptr->_Mypair._Myval2._Myfirst) / _Element_type_size;
        }

        public unsafe iterator begin()
        {
            _Vector_iterator_data iter = default(_Vector_iterator_data);
            iter._Ptr = _Data->_Mypair._Myval2._Myfirst;
            Unsafe.SkipInit(out iterator result);
            _Vector_iterator_data vector_iterator_data = (result._Iter = iter);
            result._Element_type_size = _Element_type_size;
            return result;
        }

        public unsafe iterator end()
        {
            _Vector_iterator_data iter = default(_Vector_iterator_data);
            iter._Ptr = _Data->_Mypair._Myval2._Mylast;
            Unsafe.SkipInit(out iterator result);
            _Vector_iterator_data vector_iterator_data = (result._Iter = iter);
            result._Element_type_size = _Element_type_size;
            return result;
        }

        public unsafe iterator at(ulong pos)
        {
            //IL_0023: Expected I, but got I8
            _Vector_data* ptr = _Data;
            ulong element_type_size = _Element_type_size;
            byte* ptr2 = (byte*)(element_type_size * pos + (ulong)(nint)ptr->_Mypair._Myval2._Myfirst);
            if (ptr2 > ptr->_Mypair._Myval2._Mylast)
            {
                throw new IndexOutOfRangeException();
            }
            _Vector_iterator_data iter = default(_Vector_iterator_data);
            iter._Ptr = ptr2;
            Unsafe.SkipInit(out iterator result);
            _Vector_iterator_data vector_iterator_data = (result._Iter = iter);
            result._Element_type_size = element_type_size;
            return result;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe bool empty()
        {
            _Vector_data* ptr = _Data;
            return ptr->_Mypair._Myval2._Myfirst == ptr->_Mypair._Myval2._Mylast;
        }

        public unsafe ulong capacity()
        {
            _Vector_data* ptr = _Data;
            return (ulong)(nint)(ptr->_Mypair._Myval2._Myend - (nuint)ptr->_Mypair._Myval2._Myfirst) / _Element_type_size;
        }

        public unsafe void* data()
        {
            return _Data->_Mypair._Myval2._Myfirst;
        }
    }
}
