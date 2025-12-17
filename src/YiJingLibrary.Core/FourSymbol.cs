using System;
using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.Core;

/// <summary>
/// 四象
/// </summary>
public sealed class FourSymbol : YiJingElement
{
    /// <inheritdoc />
    private FourSymbol(byte value, string label) : base(value, label)
    {
    }
    
    /// <summary>
    /// 老阳。
    /// </summary>
    public static readonly FourSymbol OldYin = new(6, nameof(OldYin));
    
    /// <summary>
    /// 少阳。
    /// </summary>
    public static readonly FourSymbol YoungYang = new(7, nameof(YoungYang));
    
    /// <summary>
    /// 少阴。
    /// </summary>
    public static readonly FourSymbol YoungYin = new(8, nameof(YoungYin));
    
    /// <summary>
    /// 老阳。
    /// </summary>
    public static readonly FourSymbol OldYang = new (9, nameof(OldYang));

    /// <summary>
    /// 获取指定值所对应的四象。
    /// </summary>
    /// <param name="value">四象对应的值（6~9）.</param>
    /// <returns>返回指定值对应的四象。</returns>
    /// <exception cref="ArgumentOutOfRangeException">当值不在6到9范围内时抛出此异常。</exception>
    public static FourSymbol FromValue(byte value) => value switch
    {
        6 => OldYin,
        7 => YoungYang,
        8 => YoungYin,
        9 => OldYang,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "The value must be between 6 and 9.")
    };
}