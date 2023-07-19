using System;
using System.Runtime.CompilerServices;

namespace RPBUtilities
{
    public static class UConverter
    {
        /// <summary>
        /// Converts an Enum to and int in a faster way then normal cast
        /// </summary>
        /// <typeparam name="TEnum">Type of the Enum</typeparam>
        /// <param name="enumValue">An Enum with an int as base </param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int ToInt<TEnum>(TEnum enumValue)
            where TEnum : unmanaged, Enum
        {
            return *(int*)(&enumValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe TEnum ToEnum<TEnum>(int intValue)
            where TEnum : unmanaged, Enum
        {
            return *(TEnum*)(&intValue);
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static unsafe byte[] ToByteArray<TInput>(TInput value) where TInput : unmanaged
        //{
        //    var result = new byte[sizeof(TInput)];
        //    fixed (byte* b = &result[0])
        //    {
        //        Unsafe.Write(b, value);
        //        return result;
        //    }
        //}
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static unsafe TOutput ToStruct<TOutput>(byte[] bytes) where TOutput : unmanaged
        //{
        //    fixed (byte* b = &bytes[0])
        //    {
        //        return Unsafe.Read<TOutput>(b);
        //    }
        //}
    }

}
