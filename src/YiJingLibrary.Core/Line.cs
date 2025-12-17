using System;
using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.Core;

/// <summary>
/// 爻。
/// </summary>
public class Line : YiJingElement
{
    /// <summary>
    /// 爻的扩展属性。
    /// </summary>
    public readonly ExtensibleAttribute Attributes = new();

    /// <summary>
    /// 阴阳。
    /// </summary>
    public YinYang YinYang { get; } 

    /// <inheritdoc />
    private Line(byte value, string label, YinYang yinYang) : base(value, label)
    {
        YinYang = yinYang;
    }

    /// <summary>
    /// 爻工厂类。
    /// </summary>
    /// <remarks>
    /// <see cref="Line"/>实例不希望被外部初始化。
    /// 静态属性构建实例时无法确定爻的阴阳，通过工厂类强制初始化爻时同时指定爻的阴阳属性。
    /// </remarks>
    /// <param name="value">爻的值。</param>
    /// <param name="label">爻的标签。</param>
    private class LineFactory(byte value, string label): ILine
    {
        /// <inheritdoc />
        public Line WithYinYang(YinYang yinYang) => new(value, label, yinYang);
    }

    /// <summary>
    /// 初爻
    /// </summary>
    public static ILine First => new LineFactory(1, nameof(First));

    /// <summary>
    /// 二爻
    /// </summary>
    public static ILine Second => new LineFactory(2, nameof(Second));

    /// <summary>
    /// 三爻
    /// </summary>
    public static ILine Third => new LineFactory(3, nameof(Third));

    /// <summary>
    /// 四爻
    /// </summary>
    public static ILine Fourth => new LineFactory(4, nameof(Fourth));

    /// <summary>
    /// 五爻
    /// </summary>
    public static ILine Fifth => new LineFactory(5, nameof(Fifth));

    /// <summary>
    /// 上爻
    /// </summary>
    public static ILine Top => new LineFactory(6, nameof(Top));

    /// <summary>
    /// 获取指定值对应的爻。
    /// </summary>
    /// <param name="value">爻的值（1~6）。</param>
    /// <returns>返回指定值对应的爻。</returns>
    /// <exception cref="ArgumentOutOfRangeException">当值不在1到6范围内时抛出此异常。</exception>
    public static ILine FromValue(byte value) => value switch
    {
        1 => First,
        2 => Second,
        3 => Third,
        4 => Fourth,
        5 => Fifth,
        6 => Top,
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Invalid value of line.")
    };
}