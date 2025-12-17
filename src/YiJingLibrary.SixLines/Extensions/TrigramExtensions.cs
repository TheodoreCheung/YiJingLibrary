using System;
using YiJingLibrary.Core;

namespace YiJingLibrary.SixLines.Extensions;

internal static class TrigramExtensions
{
    extension(Trigram trigram)
    {
        /// <summary>
        /// 将<see cref="Trigram"/>转换为八纯卦的值。
        /// </summary>
        /// <returns></returns>
        public byte ToHexagramValue() => (byte)(trigram << 4 | trigram);
    }

    extension(Trigram)
    {
        /// <summary>
        /// 随机数取八卦。
        /// </summary>
        /// <param name="randomNumber"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Trigram GetByRandomNumber(int randomNumber)
        {
            var number = randomNumber % 8;

            return number switch
            {
                0 => Trigram.Kun,
                1 => Trigram.Qian,
                2 => Trigram.Dui,
                3 => Trigram.Li,
                4 => Trigram.Zhen,
                5 => Trigram.Xun,
                6 => Trigram.Kan,
                7 => Trigram.Gen,
                _ => throw new ArgumentException("Invalid random number.")
            };
        }
    }
}