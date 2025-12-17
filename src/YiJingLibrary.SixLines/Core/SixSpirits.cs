using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.SixLines;

/// <summary>
/// 六神
/// </summary>
/// <param name="value">六神值。</param>
/// <param name="label">六神标签。</param>
public sealed class SixSpirit(byte value, string label) : YiJingElement(value, label)
{
    /// <summary>
    /// 青龙
    /// </summary>
    public static readonly SixSpirit AzureDragon = new(1, nameof(AzureDragon));

    /// <summary>
    /// 朱雀
    /// </summary>
    public static readonly SixSpirit VermilionBird = new(2, nameof(VermilionBird));

    /// <summary>
    /// 勾陈
    /// </summary>
    public static readonly SixSpirit HookChen = new(3, nameof(HookChen));

    /// <summary>
    /// 螣蛇
    /// </summary>
    public static readonly SixSpirit CoiledSnake = new(4, nameof(CoiledSnake));

    /// <summary>
    /// 白虎
    /// </summary>
    public static readonly SixSpirit WhiteTiger = new(5, nameof(WhiteTiger));

    /// <summary>
    /// 玄武
    /// </summary>
    public static readonly SixSpirit BlackTortoise = new(6, nameof(BlackTortoise));
}