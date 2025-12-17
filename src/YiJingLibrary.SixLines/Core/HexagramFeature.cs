using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.SixLines;

/// <summary>
/// 六十四卦特性。
/// </summary>
/// <param name="value">特性值。</param>
/// <param name="label">特性标签。</param>
public sealed class HexagramFeature(byte value, string label) : YiJingElement(value, label)
{ 
    /// <summary>
    /// 无特殊特性。
    /// </summary>
    public static readonly HexagramFeature None = new(0, string.Empty);
    
    /// <summary>
    /// 六冲卦。
    /// </summary>
    public static readonly HexagramFeature Clashing = new(1, nameof(Clashing));
    
    /// <summary>
    /// 六合卦。
    /// </summary>
    public static readonly HexagramFeature Combining = new(2, nameof(Combining));
    
    /// <summary>
    /// 游魂卦。
    /// </summary>
    public static readonly HexagramFeature WanderingSoul = new(3, nameof(WanderingSoul));
    
    /// <summary>
    /// 归魂卦。
    /// </summary>
    public static readonly HexagramFeature ReturningSoul = new(4, nameof(ReturningSoul));
}