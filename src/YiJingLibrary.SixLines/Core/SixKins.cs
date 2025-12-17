using System.Collections.Generic;
using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.SixLines;

/// <summary>
/// 六亲
/// </summary>
/// <param name="value">六亲值。</param>
/// <param name="label">六亲标签。</param>
public sealed class SixKin(byte value, string label) : YiJingElement(value, label)
{
    /// <summary>
    /// 父母
    /// </summary>
    public static readonly SixKin Parent = new(1, nameof(Parent));
        
    /// <summary>
    /// 兄弟
    /// </summary>
    public static readonly SixKin Sibling = new(2, nameof(Sibling));
        
    /// <summary>
    /// 妻财
    /// </summary>
    public static readonly SixKin Wealth = new(3, nameof(Wealth));
        
    /// <summary>
    /// 官鬼
    /// </summary>
    public static readonly SixKin Officer = new(4, nameof(Officer));
        
    /// <summary>
    /// 子孙
    /// </summary>
    public static readonly SixKin Offspring = new(5, nameof(Officer));

    /// <summary>
    /// 所有六亲元素
    /// </summary>
    public static readonly IReadOnlyList<SixKin> All = [Parent, Sibling, Wealth, Officer, Offspring];
}