using YiJingLibrary.Core;
using YiJingLibrary.Core.Internationalization;

namespace YiJingLibrary.ChineseLunarCalendar;

/// <summary>
/// 农历日期。
/// </summary>
public readonly struct LunarStemBranch(StemBranch year, StemBranch month, StemBranch day, StemBranch hour)
{
    /// <summary>
    /// 年干支
    /// </summary>
    public StemBranch Year { get; } = year;

    /// <summary>
    /// 月干支
    /// </summary>
    public StemBranch Month { get; } = month;

    /// <summary>
    /// 日干支
    /// </summary>
    public StemBranch Day { get; } = day;

    /// <summary>
    /// 时干支
    /// </summary>
    public StemBranch Hour { get; } = hour;

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{Year}{L.GetText("LSB_Year")}{Month}{L.GetText("LSB_Month")}{Day}{L.GetText("LSB_Day")}{Hour}{L.GetText("LSB_Hour")}";
    }
}