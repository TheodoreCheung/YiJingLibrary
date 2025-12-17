using System;
using System.Threading;
using YiJingLibrary.Core.Internationalization;
using YiJingLibrary.Core.Properties;

namespace YiJingLibrary.Core.Abstractions;

/// <summary>
/// 易经基础元素数据类型
/// </summary>
public abstract class YiJingElement : IEquatable<YiJingElement>
{
    /// <summary>
    /// 元素的值。
    /// </summary>
    protected readonly byte Value;

    /// <summary>
    /// 元素的国际化标签。
    /// </summary>
    protected readonly string Label;

    /// <summary>
    /// 元素的名称。
    /// </summary>
    public string ElementName => string.IsNullOrWhiteSpace(Label) 
        ? string.Empty 
        : Label.Contains('_') ? Label[(Label.IndexOf('_') + 1)..] : Label;

    /// <summary>
    /// 初始化<see cref="YiJingElement"/>类的新实例。
    /// </summary>
    /// <param name="value">元素的值。</param>
    /// <param name="label">元素的标签。</param>
    protected YiJingElement(byte value, string label)
    {
        Value = value;
        Label = $"{GetType().Name}_{label}";
    }
        
    /// <inheritdoc />
    public bool Equals(YiJingElement? other)
    {
        return other is not null && this.GetType() == other.GetType() && Value == other.Value;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        return obj is YiJingElement other && Equals(other);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        if (string.IsNullOrEmpty(Label)) return Label;

        return ToString(Label) ?? ElementName;
    }

    /// <summary>
    /// 根据自定义标签获取字符串表示。
    /// </summary>
    /// <param name="customLabel">自定义标签。</param>
    /// <returns>返回根据标签获取的字符串，如果找不到则返回null。</returns>
    protected static string? ToString(string customLabel) => L.GetText(customLabel);

    /// <summary>
    /// 将<see cref="YiJingElement"/>隐式转换为byte值。
    /// </summary>
    /// <param name="element">要转换的<see cref="YiJingElement"/>元素。</param>
    /// <returns>返回元素的byte值。</returns>
    public static implicit operator byte(YiJingElement element)
    {
        return element.Value;
    }

    /// <summary>
    /// 判断两个<see cref="YiJingElement"/>实例是否相等。
    /// </summary>
    /// <param name="left">左侧比较对象。</param>
    /// <param name="right">右侧比较对象。</param>
    /// <returns>如果两个对象相等则返回true，否则返回false。</returns>
    public static bool operator ==(YiJingElement left, YiJingElement right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 判断两个<see cref="YiJingElement"/>实例是否不相等。
    /// </summary>
    /// <param name="left">左侧比较对象。</param>
    /// <param name="right">右侧比较对象。</param>
    /// <returns>如果两个对象不相等则返回true，否则返回false。</returns>
    public static bool operator !=(YiJingElement left, YiJingElement right)
    {
        return !left.Equals(right);
    }

    /// <summary>
    /// 判断左侧<see cref="YiJingElement"/>是否小于右侧<see cref="YiJingElement"/>。
    /// </summary>
    /// <param name="left">左侧比较对象。</param>
    /// <param name="right">右侧比较对象。</param>
    /// <returns>如果左侧对象小于右侧对象则返回true，否则返回false。</returns>
    public static bool operator <(YiJingElement left, YiJingElement right)
    {
        return left.Value < right.Value;
    }
    
    /// <summary>
    /// 判断左侧<see cref="YiJingElement"/>是否大于右侧<see cref="YiJingElement"/>。
    /// </summary>
    /// <param name="left">左侧比较对象。</param>
    /// <param name="right">右侧比较对象。</param>
    /// <returns>如果左侧对象大于右侧对象则返回true，否则返回false。</returns>
    public static bool operator >(YiJingElement left, YiJingElement right)
    {
        return left.Value > right.Value;
    }
}