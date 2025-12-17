using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.SixLines;

/// <summary>
/// 世应。
/// </summary>
/// <param name="value">世应值。</param>
/// <param name="label">世应标签。</param>
public sealed class Position(byte value, string label) : YiJingElement(value, label)
{
    /// <summary>
    /// 世
    /// </summary>
    public static readonly Position Worldly = new(1, nameof(Worldly));
        
    /// <summary>
    /// 应
    /// </summary>
    public static readonly Position Corresponding = new(2, nameof(Corresponding));
}