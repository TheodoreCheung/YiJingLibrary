using System;
using Lunar;
using YiJingLibrary.Core;

namespace YiJingLibrary.ChineseLunarCalendar;

/// <summary>
/// Lunar类库适配器
/// </summary>
internal static class LunarAdapter
{
    /// <summary>
    /// 将DateTimeOffset转换为农历干支。
    /// </summary>
    /// <param name="dt">要转换的DateTimeOffset时间。</param>
    /// <returns>返回转换后的农历干支。</returns>
    public static LunarStemBranch AdaptToStemBranch(DateTimeOffset dt)
    {
        var solar = new Solar(dt.LocalDateTime);
        var lunar = solar.Lunar;

        return new LunarStemBranch(
            new StemBranch(HeavenlyStem.FromValue((byte)(lunar.YearGanIndex + 1)),
                EarthlyBranch.FromValue((byte)(lunar.YearZhiIndex + 1))),
            new StemBranch(HeavenlyStem.FromValue((byte)(lunar.MonthGanIndex + 1)),
                EarthlyBranch.FromValue((byte)(lunar.MonthZhiIndex + 1))),
            new StemBranch(HeavenlyStem.FromValue((byte)(lunar.DayGanIndex + 1)),
                EarthlyBranch.FromValue((byte)(lunar.DayZhiIndex + 1))),
            new StemBranch(HeavenlyStem.FromValue((byte)(lunar.TimeGanIndex + 1)), 
                EarthlyBranch.FromValue((byte)(lunar.TimeZhiIndex+ 1)))
        );
    }

    /// <summary>
    /// 将DateTimeOffset转换为农历DateTime。
    /// </summary>
    /// <param name="dt">要转换的DateTimeOffset时间。</param>
    /// <returns>返回转换后的农历DateTime。</returns>
    public static DateTime AdaptToDateTime(DateTimeOffset dt)
    {
        var solar = new Solar(dt.LocalDateTime);
        return new DateTime(solar.Lunar.Year, solar.Lunar.Month, solar.Lunar.Day, solar.Lunar.Hour, solar.Lunar.Minute,
            solar.Lunar.Second);
    }
}