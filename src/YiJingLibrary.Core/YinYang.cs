using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.Core;

/// <summary>
/// 阴阳
/// </summary>
public sealed class YinYang : YiJingElement
{
    /// <inheritdoc />
    private YinYang(byte value, string label) : base(value, label)
    {
    }
    
    /// <summary>
    /// 阴
    /// </summary>
    public static readonly YinYang Yin = new(6, nameof(Yin));
        
    /// <summary>
    /// 阳
    /// </summary>
    public static readonly YinYang Yang = new(9, nameof(Yang));
}