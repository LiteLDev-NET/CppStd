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
    public interface ICppStdAllocator
    {
        unsafe void* allocate(ulong count);

        unsafe void deallocate(void* ptr, ulong count);

        ulong max_size();
    }

    public class allocator<T> : ICppClassHelper<T>, ICppStdAllocator, IConstructableCppClass<allocator<T>> where T : new()
    {
        private static ulong type_size = ICppClassHelper<T>.type_size;

        private static ulong isValueType = (ICppClassHelper<T>.isValueType ? 1uL : 0uL);

        private allocator _this;

        public const ulong NativeClassSize = 1uL;

        public virtual bool OwnsNativeInstance
        {
            [return: MarshalAs(UnmanagedType.U1)]
            get
            {
                return true;
            }
            [param: MarshalAs(UnmanagedType.U1)]
            set
            {
            }
        }

        public unsafe virtual IntPtr NativePointer
        {
            get
            {
                fixed (allocator* value = &_this)
                {
                    IntPtr result = new(value);
                    GC.KeepAlive(this);
                    return result;
                }
            }
            set
            {
                ref allocator @this = ref _this;
                @this = *(allocator*)value.ToPointer();
            }
        }

        public allocator()
        {
            _this = new allocator
            {
                _Data = default,
                _Element_type_size = type_size
            };
        }

        public allocator(IntPtr ptr, bool ownsInstance)
        {
            ref allocator @this = ref _this;
            @this = new allocator(ptr, type_size);
        }

        public unsafe virtual void* allocate(ulong count)
        {
            void* result = _this.allocate(count);
            GC.KeepAlive(this);
            return result;
        }

        public unsafe virtual void deallocate(void* ptr, ulong count)
        {
            _this.deallocate(ptr, count);
        }

        public virtual ulong max_size()
        {
            ulong result = ulong.MaxValue / type_size;
            GC.KeepAlive(this);
            return result;
        }

        public virtual void Destruct()
        {
        }

        public unsafe virtual void SetNativePointer(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool ownsInstance)
        {
            ref allocator @this = ref _this;
            @this = *(allocator*)ptr.ToPointer();
        }

        public unsafe virtual allocator<T> ConstructInstance(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool ownsInstance)
        {
            return new(ptr, ownsInstance);
        }

        public virtual ulong GetClassSize()
        {
            return 1uL;
        }
    }
}
