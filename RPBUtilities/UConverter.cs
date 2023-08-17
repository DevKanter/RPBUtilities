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

        /// <summary>
        /// Converts an Enum to another Enum in a faster way then normal cast
        /// </summary>
        /// <typeparam name="TEnum1">Type of the first Enum</typeparam>
        /// <typeparam name="TEnum2">Type of the second Enum</typeparam>
        /// <param name="enumValue">An Enum with an int as base </param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe TEnum2 ToInt<TEnum1,TEnum2>(TEnum1 enumValue)
            where TEnum1 : unmanaged, Enum where TEnum2 : unmanaged
        {
            return *(TEnum2*)(&enumValue);
        }

    }

}
