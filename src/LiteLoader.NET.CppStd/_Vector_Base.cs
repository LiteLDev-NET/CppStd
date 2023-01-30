using LiteLoader.NET.CppStd.Internal;
using LiteLoader.NET.InteropServices;
using LiteLoader.NET;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LiteLoader.NET.InteropServices.Native;

namespace LiteLoader.NET.CppStd.Internal
{

    unsafe public class _Vector_base<T, TAlloc>
        : IList<T>
        , ICppClassHelper<T>
        , IConstructableCppClass<_Vector_base<T, TAlloc>>
        , ICopyable<_Vector_base<T, TAlloc>>
        , IMoveable<_Vector_base<T, TAlloc>>
        , IDisposable where T : new() where TAlloc : ICppStdAllocator, new()
    {
        public struct iterator : IEnumerator<T>
        {
            public vector.iterator _this;

            public _Vector_base<T, TAlloc> instance;

            public bool isIterSet;

            public iterator this[int index]
            {
                get
                {
                    vector.iterator iter = _this[index];
                    return new iterator(iter, instance);
                }
            }

            public unsafe T Current
            {
                get
                {
                    if (_Vector_base<T, TAlloc>.isValueType)
                    {
                        if (ICppClassHelper<T>.isPointer)
                        {
                            T result = default!;
                            IntPtr intPtr = Unsafe.Read<IntPtr>(_this._Iter._Ptr);
                            ICppClassHelper<T>._Value_type_funcptr_def.set_native_pointer(ref result, intPtr, false);
                            return result;
                        }
                        return Unsafe.Read<T>(_this._Iter._Ptr);
                    }
                    T val = new();
                    IntPtr intPtr2 = (IntPtr)_this._Iter._Ptr;
                    ICppClassHelper<T>._Ref_type_funcptr_def.set_native_pointer(val, intPtr2, false);
                    return val;
                }
            }

            object IEnumerator.Current => Current!;

            public iterator(vector.iterator iter, _Vector_base<T, TAlloc> vec)
            {
                _this = iter;
                instance = vec;
                isIterSet = true;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public bool MoveNext()
            {
                if (isIterSet)
                {
                    ref vector.iterator @this = ref _this;
                    vector.iterator this2 = _this;
                    vector.iterator iterator = (@this = ++this2);
                    vector.iterator iterator2 = instance._this.end();
                    vector.iterator this3 = _this;
                    return !(this3 == iterator2);
                }
                vector.iterator iterator3 = (_this = instance._this.begin());
                vector.iterator iterator4 = instance._this.end();
                if (_this == iterator4)
                {
                    return false;
                }
                isIterSet = true;
                return true;
            }

            public void Reset()
            {
                isIterSet = false;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public static bool operator ==(iterator _Left, iterator _Right)
            {
                return _Left._this == _Right._this;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public static bool operator !=(iterator _Left, iterator _Right)
            {
                vector.iterator @this = _Right._this;
                vector.iterator this2 = _Left._this;
                return !(this2 == @this);
            }

            public static iterator operator ++(iterator _Val)
            {
                vector.iterator @this = _Val._this;
                ++@this;
                return new iterator(@this, _Val.instance);
            }

            public static iterator operator --(iterator _Val)
            {
                vector.iterator @this = _Val._this;
                --@this;
                return new iterator(@this, _Val.instance);
            }

            public static iterator operator +(iterator _Left, int _Val)
            {
                vector.iterator iter = _Left._this + _Val;
                return new iterator(iter, _Left.instance);
            }

            public static iterator operator -(iterator _Left, int _Val)
            {
                vector.iterator iter = _Left._this - _Val;
                return new iterator(iter, _Left.instance);
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public static bool operator >(iterator a, iterator b)
            {
                return a._this > b._this;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public static bool operator <(iterator a, iterator b)
            {
                return a._this < b._this;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public static bool operator >=(iterator a, iterator b)
            {
                return a._this >= b._this;
            }

            [return: MarshalAs(UnmanagedType.U1)]
            public static bool operator <=(iterator a, iterator b)
            {
                return a._this <= b._this;
            }

            [SpecialName]
            public static T op_PointerDereference(iterator _Val)
            {
                return _Val.Current;
            }

            public void Dispose()
            {
            }
        }

        private static ulong type_size = ICppClassHelper<T>.type_size;

        private static bool isValueType = ICppClassHelper<T>.isValueType;

        private vector _this;

        private bool ownsNativeInstance;

        private TAlloc _al;

        public ulong NativeClassSize = 24uL;
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
                IntPtr result = new IntPtr(_this._Data);
                GC.KeepAlive(this);
                return result;
            }
            set
            {
                _this._Data = (_Vector_data*)value.ToPointer();
                GC.KeepAlive(this);
            }
        }

        public virtual bool IsReadOnly
        {
            [return: MarshalAs(UnmanagedType.U1)]
            get
            {
                return false;
            }
        }

        public unsafe virtual T this[int index]
        {
            get
            {
                if (index >= 0)
                {
                    ulong num = _this.size();
                    GC.KeepAlive(this);
                    ulong num2 = (ulong)index;
                    if (num2 <= num)
                    {
                        T current = at(num2).Current;
                        GC.KeepAlive(this);
                        return current;
                    }
                }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (IsReadOnly)
                {
                    throw new NotSupportedException();
                }
                if (index < 0)
                {
                    ulong num = _this.size();
                    GC.KeepAlive(this);
                    if ((ulong)index > num)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                _Construct(at((ulong)index)._this._Iter._Ptr, ref value, byMove: false);
                GC.KeepAlive(this);
            }
        }

        public virtual int Count
        {
            get
            {
                int result = (int)_this.size();
                GC.KeepAlive(this);
                return result;
            }
        }

        internal unsafe static T _Copy_Instance(ref T val)
        {
            if (isValueType)
            {
                if (ICppClassHelper<T>.isCopyable)
                {
                    return ICppClassHelper<T>._Value_type_funcptr_def.ctor_copy(ref Unsafe.AsRef<T>(null), val);
                }
                return val;
            }
            if (ICppClassHelper<T>.isCopyable)
            {
                return ICppClassHelper<T>._Ref_type_funcptr_def.ctor_copy(new T(), val);
            }
            string text = " is not a copyable type.";
            throw new InvalidTypeException(typeof(T)!.FullName + text);
        }

        internal unsafe static T _Move_Instance(ref T val)
        {
            if (isValueType)
            {
                if (ICppClassHelper<T>.isMoveable)
                {
                    delegate*<ref T, move<T>, T> ctor_move = ICppClassHelper<T>._Value_type_funcptr_def.ctor_move;
                    Unsafe.SkipInit(out move<T> move);
                    T val2 = (move.instance = val);
                    return ctor_move(ref Unsafe.AsRef<T>(null), move);
                }
                return val;
            }
            if (ICppClassHelper<T>.isMoveable)
            {
                delegate*<T, move<T>, T> ctor_move2 = ICppClassHelper<T>._Ref_type_funcptr_def.ctor_move;
                Unsafe.SkipInit(out move<T> move2);
                T val3 = (move2.instance = val);
                return ctor_move2(new T(), move2);
            }
            string text = " is not a moveable type.";
            throw new InvalidTypeException(typeof(T)!.FullName + text);
        }

        internal unsafe static void _Destruct_Instance(ref T val)
        {
            if (isValueType)
            {
                if (ICppClassHelper<T>.isICppClass)
                {
                    ICppClassHelper<T>._Value_type_funcptr_def.dtor(ref val);
                }
            }
            else
            {
                ICppClassHelper<T>._Ref_type_funcptr_def.dtor(val);
            }
        }

        internal unsafe static void _Construct(byte* _Dest, ref T val, [MarshalAs(UnmanagedType.U1)] bool byMove)
        {
            T val2 = ((!byMove) ? _Copy_Instance(ref val) : _Move_Instance(ref val));
            T val3 = val2;
            IntPtr intPtr = default(IntPtr);
            if (isValueType)
            {
                if (!ICppClassHelper<T>.isICppClass)
                {
                    Unsafe.Write(_Dest, val);
                    return;
                }
                intPtr = ICppClassHelper<T>._Value_type_funcptr_def.get_intptr(ref val3);
            }
            else
            {
                intPtr = ICppClassHelper<T>._Ref_type_funcptr_def.get_intptr(val2);
            }
            uint byteCount = (uint)type_size;
            void* source = intPtr.ToPointer();
            Unsafe.CopyBlock(_Dest, source, byteCount);
            if (isValueType)
            {
                if (ICppClassHelper<T>.isICppClass)
                {
                    ICppClassHelper<T>._Value_type_funcptr_def.set_own_instance(ref val3, false);
                }
            }
            else
            {
                ICppClassHelper<T>._Ref_type_funcptr_def.set_own_instance(val3, false);
            }
        }

        internal unsafe static iterator _Make_iterator(byte* _Ptr)
        {
            iterator result = default(iterator);
            result._this._Iter._Ptr = _Ptr;
            return result;
        }

        internal TAlloc _Getal()
        {
            return _al;
        }

        internal unsafe void _Change_array(byte* _Newvec, ulong _Newsize, ulong _Newcapacity)
        {
            //IL_0044: Expected I, but got I8
            //IL_0044: Expected I, but got I8
            //IL_005f: Expected I, but got I8
            //IL_0062: Expected I8, but got I
            TAlloc al = _al;
            ref _Vector_data._Compressed_pair._Vector_val reference = ref _this._Data->_Mypair._Myval2;
            ref byte* myfirst = ref reference._Myfirst;
            ref byte* mylast = ref reference._Mylast;
            ref byte* myend = ref reference._Myend;

            if (myfirst != null)
            {
                _Destroy_range(myfirst, mylast);
                al.deallocate(myfirst, (ulong)(myend - myfirst) / type_size);
            }
            myfirst = _Newvec;
            mylast = _Newvec + _Newsize * type_size;
            myend = _Newvec + _Newcapacity * type_size;
        }

        internal ulong _Calculate_growth(ulong _Newsize)
        {
            ulong num = _this.capacity();
            GC.KeepAlive(this);
            ulong num2 = max_size();
            ulong num3 = num >> 1;
            if (num > num2 - num3)
            {
                return num2;
            }
            ulong num4 = num3 + num;
            return (num4 < _Newsize) ? _Newsize : num4;
        }

        internal unsafe byte* _Emplace_reallocate(byte* _Whereptr, [MarshalAs(UnmanagedType.U1)] bool byMove, ref T val)
        {
            ref byte* _Myfirst = ref _this._Data->_Mypair._Myval2._Myfirst;
            ref byte* _Mylast = ref _this._Data->_Mypair._Myval2._Mylast;

            var _Whereoff = (ulong)(_Whereptr - _Myfirst) / type_size;
            var _Oldsize = (ulong)(_Mylast - _Myfirst) / type_size;

            if (_Oldsize == max_size())
                throw new OutOfMemoryException("vector too long.");

            ulong _Newsize = _Oldsize + 1;
            ulong _Newcapacity = _Calculate_growth(_Newsize);

            byte* _Newvec = (byte*)(_al.allocate(_Newcapacity));
            byte* _Constructed_last = _Newvec + (_Whereoff + 1) * type_size;
            byte* _Constructed_first = _Constructed_last;

            try
            {
                _Construct(_Newvec + (_Whereoff) * type_size, ref val, byMove);
                _Constructed_first = _Newvec + _Whereoff * type_size;

                if (_Whereptr == _Mylast)
                {
                    if (ICppClassHelper<T>.isMoveable)
                        _Uninitialized_move(_Myfirst, _Mylast, _Newvec);
                    else
                        _Uninitialized_copy(_Myfirst, _Mylast, _Newvec);
                }
                else
                {
                    _Uninitialized_move(_Myfirst, _Whereptr, _Newvec);
                    _Constructed_first = _Newvec;
                    _Uninitialized_move(_Whereptr, _Mylast, _Newvec + (_Whereoff + 1) * type_size);
                }
            }
            catch
            {
                _Destroy_range(_Constructed_first, _Constructed_last);
                _al.deallocate(_Newvec, _Newcapacity);
                throw;
            }

            _Change_array(_Newvec, _Newsize, _Newcapacity);
            return _Newvec + _Whereoff * type_size;
        }

        internal unsafe void _Resize_reallocate(ulong _Newsize, ref T val)
        {
            if (_Newsize > max_size())
            {
                throw new OutOfMemoryException("vector too long.");
            }

            var _Al = _Getal();
            ref _Vector_data._Compressed_pair._Vector_val _My_data = ref _this._Data->_Mypair._Myval2;
            ref byte* _Myfirst = ref _My_data._Myfirst;
            ref byte* _Mylast = ref _My_data._Mylast;

            var _Oldsize = size();
            ulong _Newcapacity = _Calculate_growth(_Newsize);

            byte* _Newvec = (byte*)(_Al.allocate(_Newcapacity));
            byte* _Appended_first = _Newvec + _Oldsize * type_size;
            byte* _Appended_last = _Appended_first;

            try
            {
                _Appended_last = _Uninitialized_fill_n(_Appended_first, _Newsize - _Oldsize, ref val);

                if (ICppClassHelper<T>.isMoveable || !ICppClassHelper<T>.isCopyable)
                    _Uninitialized_move(_Myfirst, _Mylast, _Newvec);
                else
                    _Uninitialized_copy(_Myfirst, _Mylast, _Newvec);
            }
            catch
            {
                _Destroy_range(_Appended_first, _Appended_last);
                _Al.deallocate(_Newvec, _Newcapacity);
                throw;
            }
            _Change_array(_Newvec, _Newsize, _Newcapacity);
        }

        internal unsafe ref T _Emplace_back_with_unused_capacity([MarshalAs(UnmanagedType.U1)] bool byMove, ref T val)
        {
            byte* temp_ptr = _this._Data->_Mypair._Myval2._Mylast;

            var dval = (ulong)(_this._Data->_Mypair._Myval2._Myend) - (ulong)(_this._Data->_Mypair._Myval2._Mylast);

            if (dval <= 0 && dval % type_size != 0)
                throw new MemoryCorruptedException(
                    string.Format("Error internal vector data has been detected. _Myend:{0},_Mylast:{1}.",
                        (ulong)(_this._Data->_Mypair._Myval2._Myend),
                        (ulong)(_this._Data->_Mypair._Myval2._Mylast)));

            _Construct(temp_ptr, ref val, byMove);
            _this._Data->_Mypair._Myval2._Mylast += type_size;

            return ref val;
        }

        internal unsafe void _Destroy_range(byte* _First, byte* _Last)
        {
            //IL_0059: Expected I, but got I8
            //IL_00c7: Expected I, but got I8
            if (isValueType)
            {
                if (!ICppClassHelper<T>.isICppClass)
                {
                    return;
                }
                T val = default!;
                byte* ptr = _First;
                if (_First != _Last)
                {
                    do
                    {
                        delegate*<ref T, IntPtr, bool, void> set_native_pointer = ICppClassHelper<T>._Value_type_funcptr_def.set_native_pointer;
                        IntPtr intPtr = new IntPtr(ptr);
                        set_native_pointer(ref val!, intPtr, false);
                        ICppClassHelper<T>._Value_type_funcptr_def.dtor(ref val);
                        ptr = (byte*)(type_size + (ulong)(nint)ptr);
                    }
                    while (ptr != _Last);
                }
            }
            else
            {
                T val2 = new T();
                byte* ptr2 = _First;
                if (_First != _Last)
                {
                    do
                    {
                        delegate*<T, IntPtr, bool, void> set_native_pointer2 = ICppClassHelper<T>._Ref_type_funcptr_def.set_native_pointer;
                        IntPtr intPtr2 = new IntPtr(ptr2);
                        set_native_pointer2(val2, intPtr2, false);
                        ICppClassHelper<T>._Ref_type_funcptr_def.dtor(val2);
                        ptr2 = (byte*)(type_size + (ulong)(nint)ptr2);
                    }
                    while (ptr2 != _Last);
                }
                if ((object)val2 is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
            GC.KeepAlive(this);
        }

        internal unsafe void _Uninitialized_move(byte* _First, byte* _Last, byte* _Dest)
        {
            Unsafe.CopyBlock(_Dest, _First, (uint)(_Last - (nuint)_First));
            GC.KeepAlive(this);
        }

        internal unsafe void _Uninitialized_copy(byte* _First, byte* _Last, byte* _Dest)
        {
            Unsafe.CopyBlock(_Dest, _First, (uint)(_Last - (nuint)_First));
            GC.KeepAlive(this);
        }

        internal unsafe byte* _Uninitialized_fill_n(byte* _First, ulong _Count, ref T val)
        {
            //IL_005c: Expected I, but got I8
            //IL_0077: Expected I, but got I8
            //IL_008b: Expected I, but got I8
            //The blocks IL_0052, IL_0062, IL_007b are reachable both inside and outside the pinned region starting at IL_002a. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
            byte* source;
            byte* ptr2;
            byte* ptr3;
            if (isValueType)
            {
                if (!ICppClassHelper<T>.isICppClass)
                {
#pragma warning disable CS8500
                    fixed (T* ptr = &val)
                    {
                        source = (byte*)ptr;
                        ptr2 = (byte*)(type_size * _Count + (ulong)(nint)_First);
                        ptr3 = _First;
                        if (_First != ptr2)
                        {
                            do
                            {
                                Unsafe.CopyBlock(ptr3, source, (uint)type_size);
                                ptr3 = (byte*)(type_size + (ulong)(nint)ptr3);
                            }
                            while (ptr3 != ptr2);
                        }
                        GC.KeepAlive(this);
                        return (byte*)(type_size * _Count + (ulong)(nint)_First);
                    }
#pragma warning restore CS8500
                }
                source = (byte*)ICppClassHelper<T>._Value_type_funcptr_def.get_intptr(ref val).ToPointer();
            }
            else
            {
                source = (byte*)ICppClassHelper<T>._Ref_type_funcptr_def.get_intptr(val).ToPointer();
            }
            ptr2 = (byte*)(type_size * _Count + (ulong)(nint)_First);
            ptr3 = _First;
            if (_First != ptr2)
            {
                do
                {
                    Unsafe.CopyBlock(ptr3, source, (uint)type_size);
                    ptr3 = (byte*)(type_size + (ulong)(nint)ptr3);
                }
                while (ptr3 != ptr2);
            }
            GC.KeepAlive(this);
            return (byte*)(type_size * _Count + (ulong)(nint)_First);
        }

        internal unsafe byte* _Copy_backward_memmove(byte* _First, byte* _Last, byte* _Dest)
        {
            var _Count = (ulong)_Last - (ulong)_First;
            MemoryAPI.memmove(_Dest - _Count, _First, _Count);

            return _Dest - (_First - _Last);
        }

        internal unsafe byte* _Copy_memmove(byte* _First, byte* _Last, byte* _Dest)
        {
            MemoryAPI.memmove(_Dest, _First, (ulong)(_Last - _First));

            return _Dest + (_Last - _First);
        }

        internal unsafe byte* _Move_backward_unchecked(byte* _First, byte* _Last, byte* _Dest)
        {
            return _Copy_backward_memmove(_First, _Last, _Dest);
        }

        internal unsafe byte* _Move_unchecked(byte* _First, byte* _Last, byte* _Dest)
        {
            return _Copy_memmove(_First, _Last, _Dest);
        }

        public unsafe _Vector_base()
        {
            _al = new TAlloc();
            _this = default;
            _this._Element_type_size = type_size;
            _this._Constructed_by_managed = true;
            _this._Data = (_Vector_data*)MemoryAPI.operator_new((ulong)sizeof(_Vector_data));
            *_this._Data = default;
            _al = new TAlloc();
            ownsNativeInstance = true;
        }

        public _Vector_base(IntPtr ptr)
        {
            ref vector @this = ref _this;
            @this = new vector(ptr, type_size);
            ownsNativeInstance = false;
            _al = new TAlloc();
        }

        public _Vector_base(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool ownsInstance)
        {
            ref vector @this = ref _this;
            @this = new vector(ptr, type_size);
            ownsNativeInstance = ownsInstance;
            _al = new TAlloc();
        }

        public unsafe _Vector_base(_Vector_base<T, TAlloc> vec)
        {
            _al = new TAlloc();
            _this = default;
            _this._Element_type_size = type_size;
            _this._Constructed_by_managed = true;
            _this._Data = (_Vector_data*)MemoryAPI.operator_new((ulong)sizeof(_Vector_data));
            *_this._Data = default;
            _al = new TAlloc();
            ownsNativeInstance = true;

            var _Newsize = vec.size();
            var _Newcapacity = vec.size();
            var _Al = _Getal();

            var _Newvec = (byte*)(_Al.allocate(_Newsize));
            var _Newlast = _Newvec + _Newsize * type_size;
            var _Newend = _Newlast;

            var _Constructed_first = _Newvec;
            var _Constructed_last = _Constructed_first;

            try
            {
                foreach (var _var in vec)
                {
                    var temp = _var;
                    _Construct(_Constructed_last, ref temp, false);
                    _Constructed_last += type_size;
                }
            }
            catch
            {
                _Destroy_range(_Constructed_first, _Constructed_last);
                _Al.deallocate(_Newvec, _Newsize);
                throw;
            }

            _Change_array(_Newvec, _Newsize, _Newcapacity);
        }

        public _Vector_base(move<_Vector_base<T, TAlloc>> vec)
        {
            _al = new TAlloc();
            _Vector_base<T, TAlloc> instance = vec.instance;
            ref vector @this = ref _this;
            @this = instance._this;
            ownsNativeInstance = instance.ownsNativeInstance;
            _al = instance._al;
            _Vector_base<T, TAlloc> vector_base = new _Vector_base<T, TAlloc>();
            ref vector this2 = ref instance._this;
            this2 = vector_base._this;
            instance.ownsNativeInstance = vector_base.ownsNativeInstance;
            instance._al = vector_base._al;
        }

        public TAlloc get_allocator()
        {
            return _al;
        }

        public iterator at(ulong pos)
        {
            iterator result = default(iterator);
            vector.iterator iterator = (result._this = _this.at(pos));
            result.instance = this;
            result.isIterSet = true;
            return result;
        }

        public unsafe T front()
        {
            ref _Vector_data._Compressed_pair._Vector_val reference = ref _this._Data->_Mypair._Myval2;
            if (isValueType)
            {
                T result = Unsafe.AsRef<T>(reference._Myfirst);
                GC.KeepAlive(this);
                return result;
            }
            T val = new T();
            delegate*<T, IntPtr, bool, void> set_native_pointer = ICppClassHelper<T>._Ref_type_funcptr_def.set_native_pointer;
            IntPtr intPtr = new IntPtr(reference._Myfirst);
            set_native_pointer(val, intPtr, false);
            GC.KeepAlive(this);
            return val;
        }

        public unsafe T back()
        {
            //IL_002e: Expected I, but got I8
            //IL_0077: Expected I, but got I8
            ref _Vector_data._Compressed_pair._Vector_val reference = ref _this._Data->_Mypair._Myval2;
            if (isValueType)
            {
                T result = Unsafe.AsRef<T>((void*)((ulong)(nint)reference._Myfirst - type_size));
                GC.KeepAlive(this);
                return result;
            }
            T val = new T();
            delegate*<T, IntPtr, bool, void> set_native_pointer = ICppClassHelper<T>._Ref_type_funcptr_def.set_native_pointer;
            IntPtr intPtr = new IntPtr((void*)((ulong)(nint)reference._Myfirst - type_size));
            set_native_pointer(val, intPtr, false);
            GC.KeepAlive(this);
            return val;
        }

        public unsafe void* data()
        {
            void* result = _this.data();
            GC.KeepAlive(this);
            return result;
        }

        public iterator begin()
        {
            iterator result = default(iterator);
            vector.iterator iterator = (result._this = _this.begin());
            result.instance = this;
            result.isIterSet = true;
            return result;
        }

        public iterator end()
        {
            iterator result = default(iterator);
            vector.iterator iterator = (result._this = _this.end());
            result.instance = this;
            result.isIterSet = true;
            return result;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public bool empty()
        {
            bool result = _this.empty();
            GC.KeepAlive(this);
            return result;
        }

        public ulong size()
        {
            ulong result = _this.size();
            GC.KeepAlive(this);
            return result;
        }

        public ulong max_size()
        {
            ulong num = _al.max_size();
            ulong num2 = ulong.MaxValue;
            ref ulong reference = ref num < ulong.MaxValue ? ref num : ref num2;
            GC.KeepAlive(this);
            return reference;
        }

        public unsafe void reserve(ulong newCapacity)
        {
            var _Al = _Getal();
            ref _Vector_data._Compressed_pair._Vector_val _My_data = ref _this._Data->_Mypair._Myval2;
            ref byte* _Myfirst = ref _My_data._Myfirst;
            ref byte* _Mylast = ref _My_data._Mylast;

            var _Size = size();

            byte* _Newvec = (byte*)(_Al.allocate(newCapacity));

            try
            {
                if (ICppClassHelper<T>.isMoveable || !ICppClassHelper<T>.isCopyable)
                    _Uninitialized_move(_Myfirst, _Mylast, _Newvec);
                else
                    _Uninitialized_copy(_Myfirst, _Mylast, _Newvec);
            }
            catch
            {
                _Al.deallocate(_Newvec, newCapacity);
                throw;
            }
            _Change_array(_Newvec, _Size, newCapacity);
        }

        public ulong capacity()
        {
            ulong result = _this.capacity();
            GC.KeepAlive(this);
            return result;
        }

        public unsafe void clear()
        {
            ref _Vector_data._Compressed_pair._Vector_val reference = ref _this._Data->_Mypair._Myval2;
            ref byte* myfirst = ref reference._Myfirst;
            ref byte* mylast = ref reference._Mylast;

            if (myfirst != mylast)
            {
                _Destroy_range(myfirst, mylast);
                mylast = myfirst;
            }
        }

        public iterator insert(iterator where, T val)
        {
            return emplace(where, val);
        }

        public iterator insert(iterator where, move<T> val)
        {
            return emplace(where, val);
        }

        public unsafe iterator emplace(iterator where, T val)
        {
            //IL_008b: Expected I, but got I8
            //IL_009f: Expected I, but got I8
            if (!isValueType && !ICppClassHelper<T>.isCopyable)
            {
                string text = " is not copyable.";
                throw new InvalidTypeException(typeof(T)!.FullName + text);
            }
            byte* ptr = where._this._Iter._Ptr;
            ref _Vector_data._Compressed_pair._Vector_val reference = ref _this._Data->_Mypair._Myval2;
            byte* mylast = reference._Mylast;
            if (mylast != reference._Myend)
            {
                if (ptr == mylast)
                {
                    _ = ref _Emplace_back_with_unused_capacity(byMove: false, ref val);
                }
                else
                {
                    reference._Mylast = (byte*)(type_size + (ulong)(nint)reference._Mylast);
                    long num = (long)(nint)mylast - (long)type_size - (nint)ptr;

                    MemoryAPI.memmove((void*)((nint)mylast - num), ptr, (ulong)num);
                    _Construct(ptr, ref val, byMove: false);
                }
                iterator result = _Make_iterator(ptr);
                GC.KeepAlive(this);
                return result;
            }
            iterator result2 = _Make_iterator(_Emplace_reallocate(ptr, byMove: false, ref val));
            GC.KeepAlive(this);
            return result2;
        }

        public unsafe iterator emplace(iterator where, move<T> val)
        {
            //IL_0090: Expected I, but got I8
            //IL_00a4: Expected I, but got I8
            if (!isValueType && !ICppClassHelper<T>.isCopyable)
            {
                string text = " is not moveable.";
                throw new InvalidTypeException(typeof(T)!.FullName + text);
            }
            byte* ptr = where._this._Iter._Ptr;
            ref _Vector_data._Compressed_pair._Vector_val reference = ref _this._Data->_Mypair._Myval2;
            byte* mylast = reference._Mylast;
            if (mylast != reference._Myend)
            {
                if (ptr == mylast)
                {
                    _ = ref _Emplace_back_with_unused_capacity(byMove: true, ref val.instance);
                }
                else
                {
                    reference._Mylast = (byte*)(type_size + (ulong)(nint)reference._Mylast);
                    long num = (long)(nint)mylast - (long)type_size - (nint)ptr;

                    MemoryAPI.memmove((void*)((nint)mylast - num), ptr, (ulong)num);
                    _Construct(ptr, ref val.instance, byMove: true);
                }
                iterator result = _Make_iterator(ptr);
                GC.KeepAlive(this);
                return result;
            }
            iterator result2 = _Make_iterator(_Emplace_reallocate(ptr, byMove: true, ref val.instance));
            GC.KeepAlive(this);
            return result2;
        }

        public unsafe iterator erase(iterator where)
        {
            //IL_00e7: Expected I, but got I8
            //IL_00ef: Expected I, but got I8
            //IL_00fa: Expected I8, but got I
            byte* ptr = where._this._Iter._Ptr;
            ref byte* reference = ref _this._Data->_Mypair._Myval2._Mylast;
            if (ICppClassHelper<T>.isICppClass)
            {
                T val;
                if (isValueType)
                {
                    val = default!;
                    delegate*<ref T, IntPtr, bool, void> set_native_pointer = ICppClassHelper<T>._Value_type_funcptr_def.set_native_pointer;
                    IntPtr intPtr = new IntPtr(ptr);
                    set_native_pointer(ref val, intPtr, false);
                    ICppClassHelper<T>._Value_type_funcptr_def.dtor(ref val);
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
            byte* ptr2 = reference;
            byte* ptr3 = (byte*)(type_size + (ulong)(nint)ptr);

            MemoryAPI.memmove(ptr, ptr3, (ulong)(nint)(ptr2 - (nuint)ptr3));
            reference -= type_size;
            iterator result = _Make_iterator(ptr);
            GC.KeepAlive(this);
            return result;
        }

        public T push_back(T val)
        {
            return emplace_back(val);
        }

        public T push_back(move<T> val)
        {
            return emplace_back(val);
        }

        public unsafe T emplace_back(T val)
        {
            if (!isValueType && !ICppClassHelper<T>.isCopyable)
            {
                string text = " is not copyable.";
                throw new InvalidTypeException(typeof(T)!.FullName + text);
            }
            _Vector_data* ptr = _this._Data;
            ref _Vector_data._Compressed_pair._Vector_val reference = ref ptr->_Mypair._Myval2;
            if (reference._Mylast != reference._Myend)
            {
                return _Emplace_back_with_unused_capacity(byMove: false, ref val);
            }
            byte* ptr2 = _Emplace_reallocate(ptr->_Mypair._Myval2._Mylast, byMove: false, ref val);
            if (isValueType)
            {
                T result = Unsafe.AsRef<T>(ptr2);
                GC.KeepAlive(this);
                return result;
            }
            T val2 = new T();
            delegate*<T, IntPtr, bool, void> set_native_pointer = ICppClassHelper<T>._Ref_type_funcptr_def.set_native_pointer;
            IntPtr intPtr = new IntPtr(ptr2);
            set_native_pointer(val2, intPtr, false);
            GC.KeepAlive(this);
            return val2;
        }

        public unsafe T emplace_back(move<T> val)
        {
            if (!isValueType && !ICppClassHelper<T>.isMoveable)
            {
                string text = " is not moveable.";
                throw new InvalidTypeException(typeof(T)!.FullName + text);
            }
            _Vector_data* ptr = _this._Data;
            ref _Vector_data._Compressed_pair._Vector_val reference = ref ptr->_Mypair._Myval2;
            if (reference._Mylast != reference._Myend)
            {
                return _Emplace_back_with_unused_capacity(byMove: true, ref val.instance);
            }
            byte* ptr2 = _Emplace_reallocate(ptr->_Mypair._Myval2._Mylast, byMove: true, ref val.instance);
            if (isValueType)
            {
                T result = Unsafe.AsRef<T>(ptr2);
                GC.KeepAlive(this);
                return result;
            }
            T val2 = new T();
            delegate*<T, IntPtr, bool, void> set_native_pointer = ICppClassHelper<T>._Ref_type_funcptr_def.set_native_pointer;
            IntPtr intPtr = new IntPtr(ptr2);
            set_native_pointer(val2, intPtr, false);
            GC.KeepAlive(this);
            return val2;
        }

        public unsafe void resize(ulong newSize, T val)
        {
            //IL_004b: Expected I, but got I8
            //IL_0054: Expected I, but got I8
            //IL_0057: Expected I8, but got I
            //IL_0084: Expected I, but got I8
            //IL_0093: Expected I8, but got I
            ref _Vector_data._Compressed_pair._Vector_val reference = ref _this._Data->_Mypair._Myval2;
            ref byte* myfirst = ref reference._Myfirst;
            ref byte* mylast = ref reference._Mylast;
            ulong num = _this.size();
            GC.KeepAlive(this);
            if (newSize < num)
            {
                long num2 = (long)(type_size * newSize);
                byte* ptr = myfirst + num2;
                _Destroy_range(ptr, mylast);
                mylast = ptr;
            }
            else if (newSize > num)
            {
                ulong num3 = _this.capacity();
                GC.KeepAlive(this);
                if (newSize > num3)
                {
                    _Resize_reallocate(newSize, ref val);
                    return;
                }
                byte* first = mylast;
                mylast = _Uninitialized_fill_n(first, newSize - num, ref val);
            }
        }

        public void resize(ulong newSize)
        {
            T val = ((!isValueType) ? new T() : default!);
            resize(newSize, val);
            if ((object)val is IDisposable disposable)
            {
                disposable.Dispose();
            }
            GC.KeepAlive(this);
        }

        public void swap(_Vector_base<T, TAlloc> right)
        {
            if (!object.Equals(this, right))
            {
                TAlloc al = right._al;
                vector @this = right._this;
                bool flag = right.ownsNativeInstance;
                ref vector this2 = ref right._this;
                this2 = _this;
                right._al = _al;
                right.ownsNativeInstance = ownsNativeInstance;
                _this = @this;
                _al = al;
                ownsNativeInstance = flag;
            }
        }

        private IEnumerator GetEnumeratorNonGgeneric()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            //ILSpy generated this explicit interface implementation from .override directive in GetEnumeratorNonGgeneric
            return this.GetEnumeratorNonGgeneric();
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            iterator iterator = default(iterator);
            iterator.instance = this;
            return iterator;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public virtual bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public unsafe virtual int IndexOf(T item)
        {
            int check_contains_by_bytes(void* ptr)
            {
                var _Ptr = (byte*)ptr;
                ref _Vector_data._Compressed_pair._Vector_val _My_data = ref _this._Data->_Mypair._Myval2;
                ref byte* _Mylast = ref _My_data._Mylast;

                int index = 0;
                for (var _Iterptr = _My_data._Myfirst; _Iterptr != _Mylast; _Iterptr += type_size)
                {
                    bool _Isequals = true;
                    for (ulong i = 0; i < type_size; ++i)
                    {
                        if (*(_Ptr + i) != *(_Iterptr + i))
                        {
                            _Isequals = false;
                            break;
                        }
                    }
                    if (_Isequals)
                        return index;
                    else
                        ++index;
                }

                return -1;
            }

            if (isValueType)
            {
#pragma warning disable CS8500
                return check_contains_by_bytes(&item);
#pragma warning restore CS8500
            }
            else
            {
                var op_equality_fptr = ICppClassHelper<T>._Ref_type_funcptr_def.op_equality;
                if (op_equality_fptr == null)
                {
                    return check_contains_by_bytes(ICppClassHelper<T>._Ref_type_funcptr_def.get_intptr(item).ToPointer());
                }
                else
                {
                    int index = 0;
                    foreach (var _var in this)
                    {
                        if (op_equality_fptr(_var, item))
                            return index;
                        else
                            ++index;
                    }

                    return -1;
                }
            }
        }

        public virtual void Add(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }
            emplace_back(item);
        }

        public virtual void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }
            clear();
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            ulong num = _this.size();
            GC.KeepAlive(this);
            if (num > (ulong)(array.LongLength - arrayIndex))
            {
                throw new ArgumentException();
            }
            iterator iterator = end();
            iterator iterator2 = begin();
            if (iterator2 != iterator)
            {
                do
                {
                    T val = iterator.op_PointerDereference(iterator2);
                    if (ICppClassHelper<T>.isCopyable)
                    {
                        T val2 = (array[arrayIndex] = _Copy_Instance(ref val));
                    }
                    else
                    {
                        array[arrayIndex] = val;
                    }
                    arrayIndex++;
                    ++iterator2;
                }
                while (iterator2 != iterator);
            }
            GC.KeepAlive(this);
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public virtual bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }
            int num = IndexOf(item);
            if (num == -1)
            {
                return false;
            }
            iterator where = at((ulong)num);
            erase(where);
            return true;
        }

        public virtual void Insert(int index, T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }
            if (index >= 0)
            {
                ulong num = _this.size();
                GC.KeepAlive(this);
                ulong num2 = (ulong)index;
                if (num2 <= num)
                {
                    iterator where = at(num2);
                    emplace(where, item);
                    return;
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        public virtual void RemoveAt(int index)
        {
            if (index >= 0)
            {
                ulong num = _this.size();
                GC.KeepAlive(this);
                ulong num2 = (ulong)index;
                if (num2 <= num)
                {
                    iterator where = at(num2);
                    erase(where);
                    return;
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        public unsafe virtual void Destruct()
        {
            //IL_003a: Expected I, but got I8
            //IL_0055: Expected I, but got I8
            TAlloc al = _al;
            ref _Vector_data._Compressed_pair._Vector_val reference = ref _this._Data->_Mypair._Myval2;
            ref byte* myfirst = ref reference._Myfirst;
            ref byte* myend = ref reference._Myend;
            _Destroy_range(myfirst, reference._Mylast);
            al.deallocate(myfirst, (ulong)(myfirst - myend) / type_size);
            GC.KeepAlive(this);
        }

        public unsafe virtual void SetNativePointer(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool ownsInstance)
        {
            ref vector @this = ref _this;
            @this = *(vector*)ptr.ToPointer();
            ownsNativeInstance = ownsInstance;
        }

        public unsafe virtual _Vector_base<T, TAlloc> ConstructInstance(IntPtr ptr, [MarshalAs(UnmanagedType.U1)] bool ownsInstance)
        {
            return new(ptr, ownsInstance);
        }

        public virtual ulong GetClassSize()
        {
            return 24uL;
        }

        public virtual _Vector_base<T, TAlloc> ConstructInstanceByCopy(_Vector_base<T, TAlloc> _Right)
        {
            return new _Vector_base<T, TAlloc>(_Right);
        }

        public virtual _Vector_base<T, TAlloc> ConstructInstanceByMove(move<_Vector_base<T, TAlloc>> _Right)
        {
            return new _Vector_base<T, TAlloc>(_Right);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (ownsNativeInstance)
                {
                    Destruct();

                    MemoryAPI.operator_delete(_this._Data);
                    GC.KeepAlive(this);
                }

                disposedValue = true;
            }
        }

        ~_Vector_base()
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
