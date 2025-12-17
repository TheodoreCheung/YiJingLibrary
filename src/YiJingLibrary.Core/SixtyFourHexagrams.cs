using System;
using System.Collections.Generic;
using System.Linq;

namespace YiJingLibrary.Core;

public partial class Hexagram
{
    #region 乾宫

    /// <summary>
    /// 乾为天
    /// </summary>
    public static Hexagram TheCreative =>
        new(Qian, Qian, nameof(TheCreative), Qian);

    /// <summary>
    /// 天风姤
    /// </summary>
    public static Hexagram ComingToMeet =>
        new(Qian, Xun, nameof(ComingToMeet), Qian);

    /// <summary>
    /// 天山遁
    /// </summary>
    public static Hexagram Retreat =>
        new(Qian, Gen, nameof(Retreat), Qian);

    /// <summary>
    /// 天地否
    /// </summary>
    public static Hexagram Standstill =>
        new(Qian, Kun, nameof(Standstill), Qian);

    /// <summary>
    /// 风地观
    /// </summary>
    public static Hexagram Contemplation =>
        new(Xun, Kun, nameof(Contemplation), Qian);

    /// <summary>
    /// 山地剥
    /// </summary>
    public static Hexagram SplittingApart =>
        new(Gen, Kun, nameof(SplittingApart), Qian);

    /// <summary>
    /// 火地晋
    /// </summary>
    public static Hexagram Progress =>
        new(Li, Kun, nameof(Progress), Qian);

    /// <summary>
    /// 火天大有
    /// </summary>
    public static Hexagram PossessionInGreatMeasure =>
        new(Li, Qian, nameof(PossessionInGreatMeasure), Qian);

    #endregion

    #region 兑宫

    /// <summary>
    /// 兑为泽
    /// </summary>
    public static Hexagram TheJoyous =>
        new(Dui, Dui, nameof(TheJoyous), Dui);

    /// <summary>
    /// 泽水困
    /// </summary>
    public static Hexagram Oppression =>
        new(Dui, Kan, nameof(Oppression), Dui);

    /// <summary>
    /// 泽地萃
    /// </summary>
    public static Hexagram GatheringTogether =>
        new(Dui, Kun, nameof(GatheringTogether), Dui);

    /// <summary>
    /// 泽山咸
    /// </summary>
    public static Hexagram Influence =>
        new(Dui, Gen, nameof(Influence), Dui);

    /// <summary>
    /// 水山蹇
    /// </summary>
    public static Hexagram Obstruction =>
        new(Kan, Gen, nameof(Obstruction), Dui);

    /// <summary>
    /// 地山谦
    /// </summary>
    public static Hexagram Modesty =>
        new(Kun, Gen, nameof(Modesty), Dui);

    /// <summary>
    /// 雷山小过
    /// </summary>
    public static Hexagram PreponderanceOfTheSmall =>
        new(Zhen, Gen, nameof(PreponderanceOfTheSmall), Dui);

    /// <summary>
    /// 雷泽归妹
    /// </summary>
    public static Hexagram TheMarryingMaiden =>
        new(Zhen, Dui, nameof(TheMarryingMaiden), Dui);

    #endregion

    #region 离宫

    /// <summary>
    /// 离为火
    /// </summary>
    public static Hexagram TheClinging =>
        new(Li, Li, nameof(TheClinging), Li);

    /// <summary>
    /// 火山旅
    /// </summary>
    public static Hexagram TheWanderer =>
        new(Li, Gen, nameof(TheWanderer), Li);

    /// <summary>
    /// 火风鼎
    /// </summary>
    public static Hexagram TheCauldron =>
        new(Li, Xun, nameof(TheCauldron), Li);

    /// <summary>
    /// 火水未济
    /// </summary>
    public static Hexagram BeforeCompletion =>
        new(Li, Kan, nameof(BeforeCompletion), Li);

    /// <summary>
    /// 山水蒙
    /// </summary>
    public static Hexagram YouthfulFolly =>
        new(Gen, Kan, nameof(YouthfulFolly), Li);

    /// <summary>
    /// 风水涣
    /// </summary>
    public static Hexagram Dispersion =>
        new(Xun, Kan, nameof(Dispersion), Li);

    /// <summary>
    /// 天水讼
    /// </summary>
    public static Hexagram Conflict =>
        new(Qian, Kan, nameof(Conflict), Li);

    /// <summary>
    /// 天火同人
    /// </summary>
    public static Hexagram FellowshipWithMen =>
        new(Qian, Li, nameof(FellowshipWithMen), Li);

    #endregion

    #region 震宫

    /// <summary>
    /// 震为雷
    /// </summary>
    public static Hexagram TheArousing =>
        new(Zhen, Zhen, nameof(TheArousing), Zhen);

    /// <summary>
    /// 雷地豫
    /// </summary>
    public static Hexagram Enthusiasm =>
        new(Zhen, Kun, nameof(Enthusiasm), Zhen);

    /// <summary>
    /// 雷水解
    /// </summary>
    public static Hexagram Deliverance =>
        new(Zhen, Kan, nameof(Deliverance), Zhen);

    /// <summary>
    /// 雷风恒
    /// </summary>
    public static Hexagram Duration =>
        new(Zhen, Xun, nameof(Duration), Zhen);

    /// <summary>
    /// 地风升
    /// </summary>
    public static Hexagram PushingUpward =>
        new(Kun, Xun, nameof(PushingUpward), Zhen);

    /// <summary>
    /// 水风井
    /// </summary>
    public static Hexagram TheWell =>
        new(Kan, Xun, nameof(TheWell), Zhen);

    /// <summary>
    /// 泽风大过
    /// </summary>
    public static Hexagram PreponderanceOfTheGreat =>
        new(Dui, Xun, nameof(PreponderanceOfTheGreat), Zhen);

    /// <summary>
    /// 泽雷随
    /// </summary>
    public static Hexagram Following =>
        new(Dui, Zhen, nameof(Following), Zhen);

    #endregion

    #region 巽宫

    /// <summary>
    /// 巽为风
    /// </summary>
    public static Hexagram TheGentle =>
        new(Xun, Xun, nameof(TheGentle), Xun);

    /// <summary>
    /// 风天小畜
    /// </summary>
    public static Hexagram TheTamingPowerOfTheSmall =>
        new(Xun, Qian, nameof(TheTamingPowerOfTheSmall), Xun);

    /// <summary>
    /// 风火家人
    /// </summary>
    public static Hexagram TheFamily =>
        new(Xun, Li, nameof(TheFamily), Xun);

    /// <summary>
    /// 风雷益
    /// </summary>
    public static Hexagram Increase =>
        new(Xun, Zhen, nameof(Increase), Xun);

    /// <summary>
    /// 天雷无妄
    /// </summary>
    public static Hexagram Innocence =>
        new(Qian, Zhen, nameof(Innocence), Xun);

    /// <summary>
    /// 火雷噬嗑
    /// </summary>
    public static Hexagram BitingThrough =>
        new(Li, Zhen, nameof(BitingThrough), Xun);

    /// <summary>
    /// 山雷颐
    /// </summary>
    public static Hexagram TheCornersOfTheMouth =>
        new(Gen, Zhen, nameof(TheCornersOfTheMouth), Xun);

    /// <summary>
    /// 山风蛊
    /// </summary>
    public static Hexagram WorkOnTheDecayed =>
        new(Gen, Xun, nameof(WorkOnTheDecayed), Xun);

    #endregion

    #region 坎宫

    /// <summary>
    /// 坎为水
    /// </summary>
    public static Hexagram TheAbysmal =>
        new(Kan, Kan, nameof(TheAbysmal), Kan);

    /// <summary>
    /// 水泽节
    /// </summary>
    public static Hexagram Limitation =>
        new(Kan, Dui, nameof(Limitation), Kan);

    /// <summary>
    /// 水雷屯
    /// </summary>
    public static Hexagram DifficultyAtTheBeginning =>
        new(Kan, Zhen, nameof(DifficultyAtTheBeginning), Kan);

    /// <summary>
    /// 水火既济
    /// </summary>
    public static Hexagram AfterCompletion =>
        new(Kan, Li, nameof(AfterCompletion), Kan);

    /// <summary>
    /// 泽火革
    /// </summary>
    public static Hexagram Revolution =>
        new(Dui, Li, nameof(Revolution), Kan);

    /// <summary>
    /// 雷火丰
    /// </summary>
    public static Hexagram Abundance =>
        new(Zhen, Li, nameof(Abundance), Kan);

    /// <summary>
    /// 地火明夷
    /// </summary>
    public static Hexagram DarkeningOfTheLight =>
        new(Kun, Li, nameof(DarkeningOfTheLight), Kan);

    /// <summary>
    /// 地水师
    /// </summary>
    public static Hexagram TheArmy =>
        new(Kun, Kan, nameof(TheArmy), Kan);

    #endregion

    #region 艮宫

    /// <summary>
    /// 艮为山
    /// </summary>
    public static Hexagram KeepingStill =>
        new(Gen, Gen, nameof(KeepingStill), Gen);

    /// <summary>
    /// 山火贲
    /// </summary>
    public static Hexagram Grace =>
        new(Gen, Li, nameof(Grace), Gen);

    /// <summary>
    /// 山天大畜
    /// </summary>
    public static Hexagram TheTamingPowerOfTheGreat =>
        new(Gen, Qian, nameof(TheTamingPowerOfTheGreat), Gen);

    /// <summary>
    /// 山泽损
    /// </summary>
    public static Hexagram Decrease =>
        new(Gen, Dui, nameof(Decrease), Gen);

    /// <summary>
    /// 火泽睽
    /// </summary>
    public static Hexagram Opposition =>
        new(Li, Dui, nameof(Opposition), Gen);

    /// <summary>
    /// 天泽履
    /// </summary>
    public static Hexagram Treading =>
        new(Qian, Dui, nameof(Treading), Gen);

    /// <summary>
    /// 风泽中孚
    /// </summary>
    public static Hexagram InnerTruth =>
        new(Xun, Dui, nameof(InnerTruth), Gen);

    /// <summary>
    /// 风山渐
    /// </summary>
    public static Hexagram Development =>
        new(Xun, Gen, nameof(Development), Gen);

    #endregion

    #region 坤宫

    /// <summary>
    /// 坤为地
    /// </summary>
    public static Hexagram TheReceptive =>
        new(Kun, Kun, nameof(TheReceptive), Kun);

    /// <summary>
    /// 地雷复
    /// </summary>
    public static Hexagram Return =>
        new(Kun, Zhen, nameof(Return), Kun);

    /// <summary>
    /// 地泽临
    /// </summary>
    public static Hexagram Approach =>
        new(Kun, Dui, nameof(Approach), Kun);

    /// <summary>
    /// 地天泰
    /// </summary>
    public static Hexagram Peace =>
        new(Kun, Qian, nameof(Peace), Kun);

    /// <summary>
    /// 雷天大壮
    /// </summary>
    public static Hexagram ThePowerOfTheGreat =>
        new(Zhen, Qian, nameof(ThePowerOfTheGreat), Kun);

    /// <summary>
    /// 泽天夬
    /// </summary>
    public static Hexagram BreakThrough =>
        new(Dui, Qian, nameof(BreakThrough), Kun);

    /// <summary>
    /// 水天需
    /// </summary>
    public static Hexagram Waiting =>
        new(Kan, Qian, nameof(Waiting), Kun);

    /// <summary>
    /// 水地比
    /// </summary>
    public static Hexagram HoldingTogether =>
        new(Kan, Kun, nameof(HoldingTogether), Kun);

    #endregion

    /// <summary>
    /// 通过六十四卦的二进制值查询对应的六十四卦。
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static Hexagram FromValue(byte value) => value switch
    {
        // 乾宫
        0b0111_0111 => TheCreative,
        0b0111_0110 => ComingToMeet,
        0b0111_0100 => Retreat,
        0b0111_0000 => Standstill,
        0b0110_0000 => Contemplation,
        0b0100_0000 => SplittingApart,
        0b0101_0000 => Progress,
        0b0101_0111 => PossessionInGreatMeasure,

        // 兑宫
        0b0011_0011 => TheJoyous,
        0b0011_0010 => Oppression,
        0b0011_0000 => GatheringTogether,
        0b0011_0100 => Influence,
        0b0010_0100 => Obstruction,
        0b0000_0100 => Modesty,
        0b0001_0100 => PreponderanceOfTheSmall,
        0b0001_0011 => TheMarryingMaiden,

        // 离宫
        0b0101_0101 => TheClinging,
        0b0101_0100 => TheWanderer,
        0b0101_0110 => TheCauldron,
        0b0101_0010 => BeforeCompletion,
        0b0100_0010 => YouthfulFolly,
        0b0110_0010 => Dispersion,
        0b0111_0010 => Conflict,
        0b0111_0101 => FellowshipWithMen,

        // 震宫
        0b0001_0001 => TheArousing,
        0b0001_0000 => Enthusiasm,
        0b0001_0010 => Deliverance,
        0b0001_0110 => Duration,
        0b0000_0110 => PushingUpward,
        0b0010_0110 => TheWell,
        0b0011_0110 => PreponderanceOfTheGreat,
        0b0011_0001 => Following,

        // 巽宫
        0b0110_0110 => TheGentle,
        0b0110_0111 => TheTamingPowerOfTheSmall,
        0b0110_0101 => TheFamily,
        0b0110_0001 => Increase,
        0b0111_0001 => Innocence,
        0b0101_0001 => BitingThrough,
        0b0100_0001 => TheCornersOfTheMouth,
        0b0100_0110 => WorkOnTheDecayed,

        // 坎宫
        0b0010_0010 => TheAbysmal,
        0b0010_0011 => Limitation,
        0b0010_0001 => DifficultyAtTheBeginning,
        0b0010_0101 => AfterCompletion,
        0b0011_0101 => Revolution,
        0b0001_0101 => Abundance,
        0b0000_0101 => DarkeningOfTheLight,
        0b0000_0010 => TheArmy,

        // 艮宫
        0b0100_0100 => KeepingStill,
        0b0100_0101 => Grace,
        0b0100_0111 => TheTamingPowerOfTheGreat,
        0b0100_0011 => Decrease,
        0b0101_0011 => Opposition,
        0b0111_0011 => Treading,
        0b0110_0011 => InnerTruth,
        0b0110_0100 => Development,

        // 坤宫
        0b0000_0000 => TheReceptive,
        0b0000_0001 => Return,
        0b0000_0011 => Approach,
        0b0000_0111 => Peace,
        0b0001_0111 => ThePowerOfTheGreat,
        0b0011_0111 => BreakThrough,
        0b0010_0111 => Waiting,
        0b0010_0000 => HoldingTogether,

        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };

    /// <summary>
    /// 获取所有六十四卦。
    /// </summary>
    public static IEnumerable<Hexagram> All => Enumerable
        .Range(0, 0b0111_0111 + 1)
        .Where(v => (v & 0b1000_1000) == 0)
        .Select(v => FromValue((byte)v));
    
    /// <summary>
    /// 通过每个爻的阴阳查找对应的六十四卦。
    /// </summary>
    /// <param name="yinYang">阴阳元素数组，数组顺序必须从初爻到上爻。</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"><see cref="YinYang"/>数组长度不等于6时抛出此异常。</exception>
    public static Hexagram? QueryByYinYang(params YinYang[] yinYang)
    {
        if (yinYang.Length != 6)
            throw new ArgumentException("The length of yinYang should be 6.");

        byte hexagramValue = 0b0000_0000;
        
        for (var i = 0; i < 6; i++)
        {
            if (yinYang[i].Equals(YinYang.Yang))
            {
                hexagramValue |= i <= 2 ? (byte)(1 << i) : (byte)(1 << (i + 1));
            }
        }

        try
        {
            return FromValue(hexagramValue);
        }
        catch (ArgumentOutOfRangeException)
        {
            return null;
        }
    }
}