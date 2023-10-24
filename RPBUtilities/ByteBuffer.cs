using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace RPBUtilities
{
    /// <summary>
    ///     A buffer class that reads and writes data to a byte array in a very fast way.
    ///     Useful for performance critical applications.
    /// </summary>
    public unsafe class ByteBuffer
    {
        private int _head;

        /// <summary>
        ///     Constructor used if you want to write data to the buffer.
        /// </summary>
        /// <param name="size">The FIXED size of the Data byte array</param>
        public ByteBuffer(int size)
        {
            Data = new byte[size];
        }

        /// <summary>
        ///     Constructor used if you want to read data from the buffer.
        /// </summary>
        /// <param name="data">The data that needs to be read</param>
        public ByteBuffer(byte[] data)
        {
            Data = data;
        }

        /// <summary>
        ///     The byte array that stores the data
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        ///     Writes data to the buffer.
        /// </summary>
        /// <typeparam name="T">The type of the data that needs to be written. Only unmanaged types are allowed</typeparam>
        /// <param name="o"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Write<T>(T o) where T : unmanaged
        {
            fixed (byte* b = &Data[_head])
            {
                Unsafe.Write(b, o);
            }

            _head += sizeof(T);
        }

        /// <summary>
        ///     Reads data from the buffer
        /// </summary>
        /// <typeparam name="T">The type of the data that needs to be read. Only unmanaged types are allowed</typeparam>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Read<T>() where T : unmanaged
        {
            fixed (byte* b = &Data[_head])
            {
                _head += sizeof(T);
                return Unsafe.Read<T>(b);
            }
        }


        /// <summary>
        ///     Reads a string from the buffer.
        /// </summary>
        /// <returns></returns>
        public void Write(string s)
        {
            Write(s.Length);

            Buffer.BlockCopy(Encoding.ASCII.GetBytes(s), 0, Data, _head, s.Length);

            _head += s.Length;
        }

        public void Write(string[] strings)
        {
            Write(strings.Length);
            for (var i = 0; i < strings.Length; i++)
            {
                Write(strings[i]);
            }
        }
        
        /// <summary>
        ///     Writes a byte[] to the buffer.
        /// </summary>
        /// <returns></returns>
        public void Write(byte[] bytes)
        {
            Write(bytes.Length);
            Buffer.BlockCopy(bytes, 0, Data, _head, bytes.Length);
            _head += bytes.Length;
        }


        public void Write<T>(T[] array) where T : unmanaged
        {
            Write(array.Length);
            
            fixed (byte* b = &Data[_head])
            {
                Unsafe.WriteUnaligned(b, array);
            }

            _head += array.Length * sizeof(T);
        }

        public T[] ReadArray<T>() where T : unmanaged
        {
            var size = Read<int>();
            var result = new T[size];

            fixed (byte* b = &Data[_head])
            {
                _head += size* sizeof(T);
                return Unsafe.ReadUnaligned<T[]>(b);
            }
        }

        /// <summary>
        ///     Reads a byte[] from the buffer.
        /// </summary>
        /// <returns></returns>
        public byte[] ReadBytes()
        {
            var size = Read<int>();
            var result = new byte[size];
            Buffer.BlockCopy(Data, _head, result, 0, size);
            _head += size;
            return result;
        }

        /// <summary>
        ///     Writes a string to the buffer.
        /// </summary>
        /// <returns></returns>
        public string ReadString()
        {
            var size = Read<int>();
            var bytes = new byte[size];

            Buffer.BlockCopy(Data, _head, bytes, 0, size);
            _head += size;
            return Encoding.UTF8.GetString(bytes);
        }


        public string[] ReadStringArray()
        {
            var size = Read<int>();
            var result = new string[size];
            for (var i = 0; i < size; i++)
            {
                result[i] = ReadString();
            }
            return result;
        }
        /// <summary>
        ///     A method to check weather there is data left to read.
        /// </summary>
        /// <returns>True if there is no data left to read</returns>
        public bool DoneReading()
        {
            return _head == Data.Length;
        }

        /// <summary>
        ///     A method to check weather there is space left on the buffer.
        /// </summary>
        /// <returns>True if there is no space left on the buffer</returns>
        public bool IsFull()
        {
            return _head == Data.Length;
        }

        /// <summary>
        ///     Resets the head of the buffer to 0
        /// </summary>
        public void ResetHead()
        {
            _head = 0;
        }
    }
}