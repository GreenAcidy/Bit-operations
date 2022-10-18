// <copyright file="NumbersExtension.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BitOperations
{
    using System;

    /// <summary>
    /// Class NumberExtensions contains two methods: algorithm of inserting bytes of one number into another; algorithm that check if number is palindrom.
    /// </summary>
    internal class NumbersExtension
    {
        /// <summary >
        /// Algorithm of inserting bits of one number into another.
        /// </summary >
        /// <param  name = " numberSource " > Number for inserting bits. </param >
        /// <param  name = " numberIn " > Number from which will get bits. </param >
        /// <param  name = " firstBit " > First position of inserting bits in number. </param >
        /// <param  name = " lastBit " > Last position of inserting bits in number. </param >
        /// <exception cref="ArgumentOutOfRangeException">Throw when index more than 32 or negative.</exception>
        /// <exception cref="ArgumentException">Throw when firstBit more than lastBit.</exception>
        /// <returns>Number with inserted bits.  </returns>
        private static int InsertNumberIntoAnother(int numberSource, int numberIn, int firstBit, int lastBit)
        {
            if (firstBit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(firstBit), "must be positive");
            }

            if (lastBit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lastBit), "must be positive");
            }

            if (lastBit >= 32)
            {
                throw new ArgumentOutOfRangeException(nameof(lastBit), "must be less than 32");
            }

            if (firstBit >= 32)
            {
                throw new ArgumentOutOfRangeException(nameof(firstBit), "must be less than 32");
            }

            if (firstBit > lastBit)
            {
                throw new ArgumentException("firstBit must be less than lastBit");
            }

            int count = lastBit - firstBit;
            int mask1 = 0;
            for (int k = count; k >= 0; k--)
            {
                mask1 += 1 << k;
            }

            int temp = mask1 & numberIn;
            temp <<= firstBit;
            int mask2 = ~(mask1 << firstBit);
            numberSource &= mask2;
            int result = numberSource | temp;
            return result;
        }
    }
}
