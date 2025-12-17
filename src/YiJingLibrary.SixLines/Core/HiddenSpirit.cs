using YiJingLibrary.Core;
using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.SixLines;

/// <summary>
/// 伏神元素
/// </summary>
public sealed class HiddenSpirit : YiJingElement
{
    /// <summary>
    /// 干支。
    /// </summary>
    public StemBranch StemBranch { get; }
    
    /// <summary>
    /// 六亲。
    /// </summary>
    public SixKin SixKin { get; }

    /// <summary>
    /// 初始化<see cref="HiddenSpirit"/>类的新实例。
    /// </summary>
    /// <param name="stemBranch">干支。</param>
    /// <param name="sixKin">六亲。</param>
    internal HiddenSpirit(StemBranch stemBranch, SixKin sixKin) : base(0, string.Empty)
    {
        StemBranch = stemBranch;
        SixKin = sixKin;
    }
}