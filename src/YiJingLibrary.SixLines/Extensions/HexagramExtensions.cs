using System;
using System.Linq;
using YiJingLibrary.Core;

namespace YiJingLibrary.SixLines.Extensions;

/// <summary>
/// 六十四卦扩展类。
/// </summary>
public static class HexagramExtensions
{
    /// <summary>
    /// 扩展六十四卦的属性、方法。
    /// </summary>
    /// <param name="hexagram"></param>
    extension(Hexagram hexagram)
    {
        /// <summary>
        /// 是否本宫卦
        /// </summary>
        /// <returns></returns>
        public bool IsPalace() => hexagram.Upper.Equals(hexagram.Palace) &&
                                  hexagram.Lower.Equals(hexagram.Palace);

        /// <summary>
        /// 是否六冲卦
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool IsClashing()
        {
            for (byte i = 1; i <= 3; i++)
            {
                var thisStemBranch = hexagram[i].StemBranch;
                var thatStemBranch = hexagram[(byte)(i + 3)].StemBranch;

                if (thisStemBranch is null || thatStemBranch is null)
                    throw new InvalidOperationException("Hexagram has no stem branch.");

                if (!thisStemBranch.EarthlyBranch.IsClashing(thatStemBranch.EarthlyBranch))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 是否六合卦
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public bool IsCombining()
        {
            for (byte i = 1; i <= 3; i++)
            {
                var thisStemBranch = hexagram[i].StemBranch;
                var thatStemBranch = hexagram[(byte)(i + 3)].StemBranch;

                if (thisStemBranch is null || thatStemBranch is null)
                    throw new InvalidOperationException("Hexagram has no stem branch.");

                if (!thisStemBranch.EarthlyBranch.IsCombining(thatStemBranch.EarthlyBranch))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 是否游魂卦
        /// </summary>
        /// <returns></returns>
        public bool IsWanderingSoul()
        {
            var palace = hexagram.Palace.ToHexagramValue();

            // 从初爻到五爻变
            palace ^= 0b0011_0111;
            // 再变四爻
            palace ^= 0b0001_0000;

            return (byte)hexagram == palace;
        }

        /// <summary>
        /// 是否归魂卦
        /// </summary>
        /// <returns></returns>
        public bool IsReturningSoul()
        {
            var palace = hexagram.Palace.ToHexagramValue();

            // 从初爻到五爻变
            palace ^= 0b0011_0111;
            // 再从四爻到初爻变
            palace ^= 0b0001_0111;

            return (byte)hexagram == palace;
        }

        /// <summary>
        /// 获取卦的特征。
        /// </summary>
        public HexagramFeature Feature
        {
            get
            {
                if (hexagram.IsClashing())
                    return HexagramFeature.Clashing;
                if (hexagram.IsCombining())
                    return HexagramFeature.Combining;
                if (hexagram.IsWanderingSoul())
                    return HexagramFeature.WanderingSoul;
                if (hexagram.IsReturningSoul())
                    return HexagramFeature.ReturningSoul;
                return HexagramFeature.None;
            }
        }

        /// <summary>
        /// 找卦身。
        /// </summary>
        public EarthlyBranch Body
        {
            get
            {
                var worldly =
                    hexagram.Lines.First(l => l.Position is { } position && position == Position.Worldly);
                var beginBranch = worldly.YinYang.Equals(YinYang.Yang) ? EarthlyBranch.Zi : EarthlyBranch.Wu;
                return EarthlyBranch.FromValue((byte)(beginBranch + worldly));
            }
        }

        /// <summary>
        /// 转换为互卦。
        /// </summary>
        /// <remarks>由主卦中间四爻交互组成的新卦，揭示事物内在的、隐藏的联系与过程。</remarks>
        /// <returns></returns>
        public Hexagram ConvertToInterlockingHexagram()
        {
            var newUpper = (((hexagram.Upper & 0b0000_0011) << 1) | (hexagram.Lower >> 2 & 0b0000_0001)) << 4;
            var newLower = ((hexagram.Upper & 0b0000_0001) << 2) | (hexagram.Lower >> 1 & 0b0000_0011);
            return Hexagram.FromValue((byte)(newUpper | newLower));
        }

        /// <summary>
        /// 转换为错卦。
        /// </summary>
        /// <remarks>将主卦的每一爻阴阳互变得到的新卦，代表事物的对立面、阴阳颠倒的状态。</remarks>
        /// <returns></returns>
        public Hexagram ConvertToLaterallyChangedHexagram()
        {
            return Hexagram.FromValue((byte)(hexagram ^ 0b0111_0111));
        }

        /// <summary>
        /// 转换为综卦。
        /// </summary>
        /// <remarks>将主卦整体颠倒（旋转180度） 得到的新卦，代表事物的反面、不同视角或过程的反转。</remarks>
        /// <returns></returns>
        public Hexagram ConvertToInverselyChangedHexagram()
        {
            return Hexagram.FromValue(
                (byte)((hexagram & 0b0000_0001) << 6 |
                       (hexagram & 0b0000_0010) << 4 |
                       (hexagram & 0b0000_0100) << 2 |
                       (hexagram & 0b0001_0000) >> 2 |
                       (hexagram & 0b0010_0000) >> 4 |
                       (hexagram & 0b0100_0000) >> 6)
            );
        }
    }
}