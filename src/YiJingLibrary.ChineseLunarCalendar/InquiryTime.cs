using System;

namespace YiJingLibrary.ChineseLunarCalendar;

/// <summary>
/// 起卦时间
/// </summary>
public struct InquiryTime
{
    /// <summary>
    /// 阳历
    /// </summary>
    public DateTimeOffset Solar { get; }
        
    /// <summary>
    /// 阴历
    /// </summary>
    public LunarStemBranch Lunar { get; }

    /// <summary>
    /// 构造函数。通过阳历计算阴历。
    /// </summary>
    /// <param name="solar">阳历时间。</param>
    public InquiryTime(DateTimeOffset solar)
    {
        Solar = solar;
        Lunar = solar.ToLunarStemBranch();
    }
}