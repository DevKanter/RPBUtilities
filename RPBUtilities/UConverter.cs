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
    }

}
