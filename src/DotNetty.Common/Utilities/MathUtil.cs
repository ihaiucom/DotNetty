﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace DotNetty.Common.Utilities
{
    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;

    public static class MathUtil
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOutOfBounds(int index, int length, int capacity) =>
            (index | length | (index + length) | (capacity - (index + length))) < 0;

        public static int FindNextPositivePowerOfTwo(int value)
        {
            Contract.Assert(value > int.MinValue && value < 0x40000000);
            return 1 << (32 - NumberOfLeadingZeros(value - 1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int NumberOfLeadingZeros(int i)
        {
            i |= i >> 1;
            i |= i >> 2;
            i |= i >> 4;
            i |= i >> 8;
            i |= i >> 16;

            return BitCount(~i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BitCount(int i)
        {
            i -= ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            i = (((i >> 4) + i) & 0x0F0F0F0F);
            i += (i >> 8);
            i += (i >> 16);

            return (i & 0x0000003F);
        }
    }
}