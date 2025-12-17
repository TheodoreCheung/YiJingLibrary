using System;
using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.Core;

/// <summary>
/// 五行
/// </summary>
public sealed class FivePhase : YiJingElement, IGenerative<FivePhase>, IRestrictive<FivePhase>
{
    /// <inheritdoc />
    private FivePhase(byte value, string name) : base(value, name)
    {
    }
    
    /// <summary>
    /// 金
    /// </summary>
    public static readonly FivePhase Metal = new(1, nameof(Metal));
        
    /// <summary>
    /// 水
    /// </summary>
    public static readonly FivePhase Water = new(2, nameof(Water));
        
    /// <summary>
    /// 木
    /// </summary>
    public static readonly FivePhase Wood = new(3, nameof(Wood));
        
    /// <summary>
    /// 火
    /// </summary>
    public static readonly FivePhase Fire = new(4, nameof(Fire));
        
    /// <summary>
    /// 土
    /// </summary>
    public static readonly FivePhase Earth = new(5, nameof(Earth));

    /// <inheritdoc />
    public bool IsGenerates(FivePhase other) => Math.Abs(Value - other.Value) is 1 or 4;

    /// <inheritdoc />
    public bool Generates(FivePhase other)
    {
        if  (!IsGenerates(other)) return false;
        
        return (Equals(Metal) && other.Equals(Water)) ||
               (Equals(Water) && other.Equals(Wood)) ||
               (Equals(Wood) && other.Equals(Fire)) ||
               (Equals(Fire) && other.Equals(Earth)) || 
               (Equals(Earth) && other.Equals(Metal));
    }

    /// <inheritdoc />
    public bool GeneratesBy(FivePhase other)
    {
        if  (!IsGenerates(other)) return false;
        
        return (Equals(Metal) && other.Equals(Earth)) ||
               (Equals(Water) && other.Equals(Metal)) ||
               (Equals(Wood) && other.Equals(Water)) ||
               (Equals(Fire) && other.Equals(Wood)) ||
               (Equals(Earth) && other.Equals(Fire));
    }

    /// <inheritdoc />
    public bool IsRestrains(FivePhase other) => Math.Abs(Value - other.Value) is 2 or 3;

    /// <inheritdoc />
    public bool Restrains(FivePhase other)
    {
        if (!IsRestrains(other)) return false;
        
        return (Equals(Metal) && other.Equals(Wood)) ||
               (Equals(Water) && other.Equals(Fire)) ||
               (Equals(Wood) && other.Equals(Earth)) ||
               (Equals(Fire) && other.Equals(Metal)) ||
               (Equals(Earth) && other.Equals(Water));
    }

    /// <inheritdoc />
    public bool RestrainsBy(FivePhase other)
    {
        if (!IsRestrains(other)) return false;
        
        return (Equals(Metal) && other.Equals(Fire)) ||
               (Equals(Water) && other.Equals(Earth)) ||
               (Equals(Wood) && other.Equals(Metal)) ||
               (Equals(Fire) && other.Equals(Water)) ||
               (Equals(Earth) && other.Equals(Wood));
    }
}