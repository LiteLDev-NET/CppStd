using LiteLoader.NET.InteropServices.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LiteLoader.NET.CppStd.Internal
{
    [StructLayout(LayoutKind.Explicit, Pack = 16, Size = 1)]
    public struct _Allocator_data
    {
    }

    public struct allocator
    {
        internal _Allocator_data _Data;

        internal ulong _Element_type_size;

        public unsafe allocator(IntPtr stdAllocatorPtr, ulong elementTypeSize)
        {
            _Element_type_size = elementTypeSize;
            ref _Allocator_data data = ref _Data;
            data = *(_Allocator_data*)(void*)stdAllocatorPtr;
        }

        public unsafe allocator(void* stdAllocatorPtr, ulong elementTypeSize)
        {
            _Element_type_size = elementTypeSize;
            ref _Allocator_data data = ref _Data;
            data = *(_Allocator_data*)stdAllocatorPtr;
        }

        public unsafe void* allocate(ulong count)
        {
            if (count > 4611686018427387903L)
            {
                throw new OutOfMemoryException();
            }
            ulong num = count * _Element_type_size;
            if (num >= 4096)
            {
                return std_Allocate_manually_vector_aligned_struct_std__Default_allocate_traits_(num);
            }
            if (num != 0L)
            {
                return MemoryAPI.operator_new(count);
            }
            return null;
        }

        public unsafe void deallocate(void* ptr, ulong count)
        {
            if (ptr == null || count == 0)
                throw new ArgumentException("null pointer cannot point to a block of non-zero size");

            MemoryAPI.operator_delete(ptr, count);
        }

        internal unsafe static void* std_Allocate_manually_vector_aligned_struct_std__Default_allocate_traits_(ulong _Bytes)
        {
            ulong num = _Bytes + 39;
            if (num <= _Bytes)
            {
                throw new OutOfMemoryException();
            }
            ulong num2 = (ulong)MemoryAPI.operator_new(num);
            if (num2 != 0L)
            {
                void* ptr = (void*)((num2 + 39) & 0xFFFFFFFFFFFFFFE0uL);
                *(ulong*)((ulong)ptr - 8uL) = num2;
                return ptr;
            }
            return (void*)0uL;
        }
    }

}
