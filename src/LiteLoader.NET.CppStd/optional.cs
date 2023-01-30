using LiteLoader.NET.CppStd;
using LiteLoader.NET.InteropServices;
using LiteLoader.NET.InteropServices.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LiteLoader.NET.CppStd
{
    public class optional<T> : ICppClassHelper<T>, IConstructableCppClass<optional<T>>, ICopyable<optional<T>>, IMoveable<optional<T>>, IDisposable where T : new()
    {
        private unsafe byte* ptr;

        private bool ownsNativeInstance;
        private bool disposedValue;

        public virtual bool OwnsNativeInstance
        {
            [return: MarshalAs(UnmanagedType.U1)]
            get
            {
                return ownsNativeInstance;
            }
            [param: MarshalAs(UnmanagedType.U1)]
            set
            {
                ownsNativeInstance = value;
            }
        }

        public unsafe virtual IntPtr NativePointer
        {
            get
            {
                IntPtr result = new IntPtr(ptr);
                GC.KeepAlive(this);
                return result;
            }
            set
            {
                ptr = (byte*)value.ToPointer();
                GC.KeepAlive(this);
            }
        }

        public unsafe optional()
        {
            ptr = (byte*)MemoryAPI.operator_new(ICppClassHelper<T>.type_size + 8);
            *(sbyte*)(ICppClassHelper<T>.type_size + (ulong)(nint)ptr) = 0;
            ownsNativeInstance = true;
        }

        public unsafe optional(IntPtr ptr)
        {
            this.ptr = (byte*)ptr.ToPointer();
            ownsNativeInstance = false;
        }

        public unsafe optional(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool ownsInstance)
        {
            this.ptr = (byte*)ptr.ToPointer();
            ownsNativeInstance = ownsInstance;
        }

        public unsafe optional(optional<T> val)
        {
            if (ICppClassHelper<T>.isCopyable)
            {
                T val2;
                if (ICppClassHelper<T>.isValueType)
                {
                    val2 = default!;
                    delegate*<ref T, IntPtr, bool, void> set_native_pointer = ICppClassHelper<T>._Value_type_funcptr_def.set_native_pointer;
                    IntPtr intPtr = new IntPtr(val.ptr);
                    set_native_pointer(ref val2, intPtr, false);
                    val2 = ICppClassHelper<T>._Value_type_funcptr_def.ctor_copy(ref *(T*)null, val2);
                    ptr = (byte*)MemoryAPI.operator_new(ICppClassHelper<T>.type_size + 8);
                    Unsafe.CopyBlock(ptr, &val2, (uint)(ICppClassHelper<T>.type_size + 1));
                }
                else
                {
                    val2 = new T();
                    delegate*<T, IntPtr, bool, void> set_native_pointer2 = ICppClassHelper<T>._Ref_type_funcptr_def.set_native_pointer;
                    IntPtr intPtr2 = new IntPtr(val.ptr);
                    set_native_pointer2(val2, intPtr2, false);
                    val2 = ICppClassHelper<T>._Ref_type_funcptr_def.ctor_copy(new T(), val2);
                    ptr = (byte*)MemoryAPI.operator_new(ICppClassHelper<T>.type_size + 8);
                    IntPtr intPtr3 = ICppClassHelper<T>._Ref_type_funcptr_def.get_intptr(val2);
                    uint byteCount = (uint)(ICppClassHelper<T>.type_size + 1);
                    void* source = intPtr3.ToPointer();
                    Unsafe.CopyBlock(ptr, source, byteCount);
                    ICppClassHelper<T>._Ref_type_funcptr_def.set_own_instance(val2, false);
                    if (val2 is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                }
                ownsNativeInstance = true;
                GC.KeepAlive(this);
                return;
            }
            string text = " is not a copyable type.";
            throw new InvalidTypeException(typeof(T)!.FullName + text);
        }

        public unsafe optional(move<optional<T>> val)
        {
            if (ICppClassHelper<T>.isMoveable)
            {
                T val2;
                if (ICppClassHelper<T>.isValueType)
                {
                    val2 = default!;
                    delegate*<ref T, IntPtr, bool, void> set_native_pointer = ICppClassHelper<T>._Value_type_funcptr_def.set_native_pointer;
                    IntPtr intPtr = new IntPtr(val.instance.ptr);
                    set_native_pointer(ref val2, intPtr, false);
                    delegate*<ref T, move<T>, T> ctor_move = ICppClassHelper<T>._Value_type_funcptr_def.ctor_move;
                    Unsafe.SkipInit(out move<T> move2);
                    move2.instance = val2;
                    val2 = ctor_move(ref *(T*)null, move2);
                    ptr = (byte*)MemoryAPI.operator_new(ICppClassHelper<T>.type_size + 8);
                    Unsafe.CopyBlock(ptr, &val2, (uint)(ICppClassHelper<T>.type_size + 1));
                }
                else
                {
                    val2 = new T();
                    delegate*<T, IntPtr, bool, void> set_native_pointer2 = ICppClassHelper<T>._Ref_type_funcptr_def.set_native_pointer;
                    IntPtr intPtr2 = new IntPtr(val.instance.ptr);
                    set_native_pointer2(val2, intPtr2, false);
                    delegate*<T, move<T>, T> ctor_move2 = ICppClassHelper<T>._Ref_type_funcptr_def.ctor_move;
                    Unsafe.SkipInit(out move<T> move3);
                    move3.instance = val2;
                    val2 = ctor_move2(new T(), move3);
                    ptr = (byte*)MemoryAPI.operator_new(ICppClassHelper<T>.type_size + 8);
                    IntPtr intPtr3 = ICppClassHelper<T>._Ref_type_funcptr_def.get_intptr(val2);
                    uint byteCount = (uint)(ICppClassHelper<T>.type_size + 1);
                    void* source = intPtr3.ToPointer();
                    Unsafe.CopyBlock(ptr, source, byteCount);
                    ICppClassHelper<T>._Ref_type_funcptr_def.set_own_instance(val2, false);
                    if (val2 is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                }
                GC.KeepAlive(this);
                return;
            }
            string text = " is not a moveable type.";
            throw new InvalidTypeException(typeof(T)!.FullName + text);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe bool has_value()
        {
            return *(bool*)(*(byte*)((ulong)(nint)ptr + ICppClassHelper<T>.type_size));
        }

        public unsafe T value()
        {
            if (*(byte*)(*(byte*)((ulong)(nint)ptr + ICppClassHelper<T>.type_size)) == 0)
            {
                throw new InvalidOperationException();
            }
            if (ICppClassHelper<T>.isValueType)
            {
                if (ICppClassHelper<T>.isPointer)
                {
                    T result = default!;
                    IntPtr intPtr = (IntPtr)ptr;
                    ICppClassHelper<T>._Value_type_funcptr_def.set_native_pointer(ref result, intPtr, false);
                    GC.KeepAlive(this);
                    return result;
                }
                T result2 = Unsafe.Read<T>(ptr);
                GC.KeepAlive(this);
                return result2;
            }
            T val = new T();
            IntPtr intPtr2 = (IntPtr)ptr;
            ICppClassHelper<T>._Ref_type_funcptr_def.set_native_pointer(val, intPtr2, false);
            GC.KeepAlive(this);
            return val;
        }

        public unsafe T value_or(T val)
        {
            if (*(bool*)(*(byte*)((ulong)(nint)ptr + ICppClassHelper<T>.type_size)))
            {
                return value();
            }
            return val;
        }

        public unsafe virtual void Destruct()
        {
            if (*(bool*)(*(byte*)((ulong)(nint)ptr + ICppClassHelper<T>.type_size)))
            {
                T val;
                if (ICppClassHelper<T>.isValueType)
                {
                    if (ICppClassHelper<T>.isICppClass)
                    {
                        val = default!;
                        delegate*<ref T, IntPtr, bool, void> set_native_pointer = ICppClassHelper<T>._Value_type_funcptr_def.set_native_pointer;
                        IntPtr intPtr = new IntPtr(ptr);
                        set_native_pointer(ref val, intPtr, false);
                        ICppClassHelper<T>._Value_type_funcptr_def.dtor(ref val);
                        GC.KeepAlive(this);
                        return;
                    }
                }
                else
                {
                    val = new T();
                    delegate*<T, IntPtr, bool, void> set_native_pointer2 = ICppClassHelper<T>._Ref_type_funcptr_def.set_native_pointer;
                    IntPtr intPtr2 = new IntPtr(ptr);
                    set_native_pointer2(val, intPtr2, false);
                    ICppClassHelper<T>._Ref_type_funcptr_def.dtor(val);
                    if ((object)val is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                }
            }
            GC.KeepAlive(this);
        }

        public virtual ulong GetClassSize()
        {
            var add = ICppClassHelper<T>.type_size % 4;
            return ICppClassHelper<T>.type_size + add == 0 ? 4 : add;
        }

        public unsafe virtual void SetNativePointer(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool ownsInstance)
        {
            this.ptr = (byte*)ptr.ToPointer();
            ownsNativeInstance = ownsInstance;
        }

        public unsafe virtual optional<T> ConstructInstance(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool ownsInstance)
        {
            return new(ptr, ownsNativeInstance);
        }

        public virtual optional<T> ConstructInstanceByCopy(optional<T> _Right)
        {
            return new optional<T>(_Right);
        }

        public virtual optional<T> ConstructInstanceByMove(move<optional<T>> _Right)
        {
            return new optional<T>(_Right);
        }

        protected unsafe virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (ownsNativeInstance)
                {
                    Destruct();

                    MemoryAPI.operator_delete(ptr);
                    GC.KeepAlive(this);
                }

                disposedValue = true;
            }
        }

        ~optional()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
