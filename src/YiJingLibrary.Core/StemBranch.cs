using System;
using System.Linq;
using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.Core;

/// <summary>
/// 干支。
/// </summary>
/// <param name="stem">天干</param>
/// <param name="branch">地支</param>
public class StemBranch(HeavenlyStem stem, EarthlyBranch branch)
    : YiJingElement((byte)(stem + branch), $"{stem.ElementName}{branch.ElementName}")
{
    /// <summary>
    /// 天干
    /// </summary>
    public HeavenlyStem HeavenlyStem { get; } = stem;

    /// <summary>
    /// 地支
    /// </summary>
    public EarthlyBranch EarthlyBranch { get; } = branch;

    /// <summary>
    /// 旬空
    /// </summary>
    public EarthlyBranch[] EmptyBranches
    {
        get
        {
            // 合并两组地支的值，以免计算时超出范围。
            var branches = Enumerable.Range(1, 12)
                .Concat(Enumerable.Range(1, 12))
                .Select(b => (byte)b)
                .ToList();

            // 计算当前天干与甲天干的差值。
            var offset = HeavenlyStem - HeavenlyStem.Jia;
            // 从branches末尾开始往前offset个索引，找当前旬的第一个地支在branches中的索引。
            var beginBranchIndex = branches.LastIndexOf(EarthlyBranch) - offset;
            // 从branches头开始找值为beginBranchIndex的索引，加上10天干，即为旬空的第一个地支。
            var firstEmptyBranchIndex = branches.IndexOf(branches[beginBranchIndex]) + 10;
            return
            [
                EarthlyBranch.FromValue(branches[firstEmptyBranchIndex]),
                EarthlyBranch.FromValue(branches[(byte)(firstEmptyBranchIndex + 1)])
            ];
        }
    }

    /// <inheritdoc />
    public override string ToString() => $"{HeavenlyStem}{EarthlyBranch}";
}

/// <summary>
/// 天干。
/// </summary>
public sealed class HeavenlyStem : YiJingElement, 
    IGenerative<HeavenlyStem>, 
    IRestrictive<HeavenlyStem>, 
    IRelationship<HeavenlyStem>
{
    /// <summary>
    /// 阴阳。
    /// </summary>
    public YinYang YinYang { get; }

    /// <summary>
    /// 五行。
    /// </summary>
    public FivePhase FivePhase { get; }

    /// <inheritdoc />
    private HeavenlyStem(byte value, string label, YinYang yinYang, FivePhase fivePhase)
        : base(value, label)
    {
        YinYang = yinYang;
        FivePhase = fivePhase;
    }

    /// <inheritdoc />
    public bool IsGenerates(HeavenlyStem other) => FivePhase.IsGenerates(other.FivePhase);

    /// <inheritdoc />
    public bool Generates(HeavenlyStem other) => FivePhase.Generates(other.FivePhase);

    /// <inheritdoc />
    public bool GeneratesBy(HeavenlyStem other) => FivePhase.GeneratesBy(other.FivePhase);

    /// <inheritdoc />
    public bool IsRestrains(HeavenlyStem other) => FivePhase.IsRestrains(other.FivePhase);

    /// <inheritdoc />
    public bool Restrains(HeavenlyStem other) => FivePhase.Restrains(other.FivePhase);

    /// <inheritdoc />
    public bool RestrainsBy(HeavenlyStem other) => FivePhase.RestrainsBy(other.FivePhase);

    /// <inheritdoc />
    public bool IsClashing(HeavenlyStem other) => 
        !other.Equals(Wu) && !other.Equals(Ji) && Math.Abs(this - other) == 6;

    /// <inheritdoc />
    public bool IsCombining(HeavenlyStem other) => Math.Abs(this - other) == 5;

    /// <summary>
    /// 甲
    /// </summary>
    public static readonly HeavenlyStem Jia = new(1, nameof(Jia), YinYang.Yang, FivePhase.Wood);

    /// <summary>
    /// 乙
    /// </summary>
    public static readonly HeavenlyStem Yi = new(2, nameof(Yi), YinYang.Yin, FivePhase.Wood);

    /// <summary>
    /// 丙
    /// </summary>
    public static readonly HeavenlyStem Bing = new(3, nameof(Bing), YinYang.Yang, FivePhase.Fire);

    /// <summary>
    /// 丁
    /// </summary>
    public static readonly HeavenlyStem Ding = new(4, nameof(Ding), YinYang.Yin, FivePhase.Fire);

    /// <summary>
    /// 戊
    /// </summary>
    public static readonly HeavenlyStem Wu = new(5, nameof(Wu), YinYang.Yang, FivePhase.Earth);

    /// <summary>
    /// 己
    /// </summary>
    public static readonly HeavenlyStem Ji = new(6, nameof(Ji), YinYang.Yin, FivePhase.Earth);

    /// <summary>
    /// 庚
    /// </summary>
    public static readonly HeavenlyStem Geng = new(7, nameof(Geng), YinYang.Yang, FivePhase.Metal);

    /// <summary>
    /// 辛
    /// </summary>
    public static readonly HeavenlyStem Xin = new(8, nameof(Xin), YinYang.Yin, FivePhase.Metal);

    /// <summary>
    /// 壬
    /// </summary>
    public static readonly HeavenlyStem Ren = new(9, nameof(Ren), YinYang.Yang, FivePhase.Water);

    /// <summary>
    /// 癸
    /// </summary>
    public static readonly HeavenlyStem Gui = new(10, nameof(Gui), YinYang.Yin, FivePhase.Water);
    
    /// <summary>
    /// 获取指定值对应的天干。
    /// </summary>
    /// <param name="value">十天干对应的值（1~10）</param>
    /// <returns><see cref="HeavenlyStem"/></returns>
    /// <exception cref="ArgumentOutOfRangeException">value 必须在 1 和 10 之间。</exception>
    public static HeavenlyStem FromValue(byte value)
    {
        return value switch
        {
            1 => Jia,
            2 => Yi,
            3 => Bing,
            4 => Ding,
            5 => Wu,
            6 => Ji,
            7 => Geng,
            8 => Xin,
            9 => Ren,
            10 => Gui,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "The value must be between 1 and 10.")
        };
    }
}

/// <summary>
/// 地支。
/// </summary>
public sealed class EarthlyBranch : YiJingElement, 
    IGenerative<EarthlyBranch>, 
    IRestrictive<EarthlyBranch>,
    IRelationship<EarthlyBranch>
{
    /// <summary>
    /// 阴阳。
    /// </summary>
    public YinYang YinYang { get; }

    /// <summary>
    /// 五行。
    /// </summary>
    public FivePhase FivePhase { get; }

    /// <inheritdoc />
    private EarthlyBranch(byte value, string label, YinYang yinYang, FivePhase fivePhase)
        : base(value, label)
    {
        YinYang = yinYang;
        FivePhase = fivePhase;
    }

    /// <inheritdoc />
    public bool IsGenerates(EarthlyBranch other) => FivePhase.IsGenerates(other.FivePhase);

    /// <inheritdoc />
    public bool Generates(EarthlyBranch other) => FivePhase.Generates(other.FivePhase);

    /// <inheritdoc />
    public bool GeneratesBy(EarthlyBranch other) => FivePhase.GeneratesBy(other.FivePhase);

    /// <inheritdoc />
    public bool IsRestrains(EarthlyBranch other) => FivePhase.IsRestrains(other.FivePhase);

    /// <inheritdoc />
    public bool Restrains(EarthlyBranch other) => FivePhase.Restrains(other.FivePhase);

    /// <inheritdoc />
    public bool RestrainsBy(EarthlyBranch other) => FivePhase.RestrainsBy(other.FivePhase);

    /// <inheritdoc />
    public bool IsClashing(EarthlyBranch other)
    {
        if (other.Equals(Zi))
            return Equals(Wu);
        if (other.Equals(Chou))
            return Equals(Wei);
        if (other.Equals(Yin))
            return Equals(Shen);
        if (other.Equals(Mao))
            return Equals(You);
        if (other.Equals(Chen))
            return Equals(Xu);
        if (other.Equals(Si))
            return Equals(Hai);
        if (other.Equals(Wu))
            return Equals(Zi);
        if (other.Equals(Wei))
            return Equals(Chou);
        if (other.Equals(Shen))
            return Equals(Yin);
        if (other.Equals(You))
            return Equals(Mao);
        if (other.Equals(Xu))
            return Equals(Chen);
        if (other.Equals(Hai))
            return Equals(Si);
        return false;
    }

    /// <inheritdoc />
    public bool IsCombining(EarthlyBranch other)
    {
        if (other.Equals(Zi))
            return Equals(Chou);
        if (other.Equals(Chou))
            return Equals(Zi);
        if (other.Equals(Yin))
            return Equals(Hai);
        if (other.Equals(Mao))
            return Equals(Xu);
        if (other.Equals(Chen))
            return Equals(You);
        if (other.Equals(Si))
            return Equals(Shen);
        if (other.Equals(Wu))
            return Equals(Wei);
        if (other.Equals(Wei))
            return Equals(Wu);
        if (other.Equals(Shen))
            return Equals(Si);
        if (other.Equals(You))
            return Equals(Chen);
        if (other.Equals(Xu))
            return Equals(Mao);
        if (other.Equals(Hai))
            return Equals(Yin);
        return false;
    }

    /// <summary>
    /// 寅
    /// </summary>
    public static readonly EarthlyBranch Yin = new(3, nameof(Yin), YinYang.Yang, FivePhase.Wood);

    /// <summary>
    /// 卯
    /// </summary>
    public static readonly EarthlyBranch Mao = new(4, nameof(Mao), YinYang.Yin, FivePhase.Wood);

    /// <summary>
    /// 辰
    /// </summary>
    public static readonly EarthlyBranch Chen = new(5, nameof(Chen), YinYang.Yang, FivePhase.Earth);

    /// <summary>
    /// 巳
    /// </summary>
    public static readonly EarthlyBranch Si = new(6, nameof(Si), YinYang.Yin, FivePhase.Fire);

    /// <summary>
    /// 午
    /// </summary>
    public static readonly EarthlyBranch Wu = new(7, nameof(Wu), YinYang.Yang, FivePhase.Fire);

    /// <summary>
    /// 未
    /// </summary>
    public static readonly EarthlyBranch Wei = new(8, nameof(Wei), YinYang.Yin, FivePhase.Earth);

    /// <summary>
    /// 申
    /// </summary>
    public static readonly EarthlyBranch Shen = new(9, nameof(Shen), YinYang.Yang, FivePhase.Metal);

    /// <summary>
    /// 酉
    /// </summary>
    public static readonly EarthlyBranch You = new(10, nameof(You), YinYang.Yin, FivePhase.Metal);

    /// <summary>
    /// 戌
    /// </summary>
    public static readonly EarthlyBranch Xu = new(11, nameof(Xu), YinYang.Yang, FivePhase.Earth);

    /// <summary>
    /// 亥
    /// </summary>
    public static readonly EarthlyBranch Hai = new(12, nameof(Hai), YinYang.Yin, FivePhase.Water);

    /// <summary>
    /// 子
    /// </summary>
    public static readonly EarthlyBranch Zi = new(1, nameof(Zi), YinYang.Yang, FivePhase.Water);

    /// <summary>
    /// 丑
    /// </summary>
    public static readonly EarthlyBranch Chou = new(2, nameof(Chou), YinYang.Yin, FivePhase.Earth);

    /// <summary>
    /// 获取指定值对应的地支。
    /// </summary>
    /// <param name="value">十二地支对应的值（1~12）</param>
    /// <returns><see cref="EarthlyBranch"/></returns>
    /// <exception cref="ArgumentOutOfRangeException">value 必须在 1 和 12 之间。</exception>
    public static EarthlyBranch FromValue(byte value)
    {
        return value switch
        {
            3 => Yin,
            4 => Mao,
            5 => Chen,
            6 => Si,
            7 => Wu,
            8 => Wei,
            9 => Shen,
            10 => You,
            11 => Xu,
            12 => Hai,
            1 => Zi,
            2 => Chou,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "The value must be between 1 and 12.")
        };
    }
}