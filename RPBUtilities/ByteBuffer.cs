using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace RPBUtilities
{

    public unsafe class ByteBuffer
    {
        public byte[] Data { get; }

        private int _head;
        public ByteBuffer(int size)
        {
            Data = new byte[size];
        }
        public ByteBuffer(byte[] data)
        {
            Data = data;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write<T>(T o) where T : unmanaged
        {
            fixed (byte* b = &Data[_head])
            {
                Unsafe.Write(b, o);
            }

            _head += sizeof(T);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Read<T>() where T : unmanaged
        {
            fixed (byte* b = &Data[_head])
            {
                _head += sizeof(T);
                return Unsafe.Read<T>(b);
            }

        }

        public void Write(string s)
        {
            var size = (ushort)s.Length;
            var bytes = Encoding.UTF8.GetBytes(s);

            Write(size);

            fixed (byte* b = &Data[_head])
            {
                Unsafe.Write(b, bytes);
            }

            _head += size;
        }

        public string ReadString()
        {
            var size = Read<ushort>();
            var bytes = new byte[size];
            Array.Copy(Data, _head, bytes, 0, size);
            return Encoding.UTF8.GetString(bytes);
        }

        public bool DoneReading()
        {
            return _head >= Data.Length - 1;
        }
        public void ResetHead()
        {
            _head = 0;
        }
    }

}