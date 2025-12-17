using System;
using System.Collections.Generic;
using YiJingLibrary.Core;
using YiJingLibrary.Core.Abstractions;
using YiJingLibrary.SixLines.Extensions;

namespace YiJingLibrary.SixLines;

/// <summary>
/// 神煞
/// </summary>
public class SpiritAndMalignity : YiJingElement
{
    /// <summary>
    /// 获取神煞对应地支的函数。
    /// </summary>
    public Func<SixLinesDivination, IEnumerable<EarthlyBranch>> Branches { get; }

    /// <summary>
    /// 初始化<see cref="SpiritAndMalignity"/>类的新实例。
    /// </summary>
    /// <param name="value">神煞值。</param>
    /// <param name="label">神煞标签。</param>
    /// <param name="branches">获取神煞对应地支的函数。</param>
    private SpiritAndMalignity(byte value, string label, Func<SixLinesDivination, IEnumerable<EarthlyBranch>> branches)
        : base(value, label)
    {
        Branches = branches;
    }

    /// <summary>
    /// 贵人。
    /// </summary>
    /// <remarks>
    /// 甲戊并牛羊，乙己鼠猴乡，
    /// 丙丁猪鸡位；壬癸兔蛇藏，
    /// 庚辛逢马虎，此是贵人方。
    /// </remarks>
    public static SpiritAndMalignity Nobleman => new(1, nameof(Nobleman), divination =>
    {
        var stem = divination.InquiryTime.Lunar.Day.HeavenlyStem;

        if (stem.Equals(HeavenlyStem.Jia) || stem.Equals(HeavenlyStem.Wu))
            return [EarthlyBranch.Chou, EarthlyBranch.Wei];
        if (stem.Equals(HeavenlyStem.Yi) || stem.Equals(HeavenlyStem.Ji))
            return [EarthlyBranch.Zi, EarthlyBranch.Shen];
        if (stem.Equals(HeavenlyStem.Bing) || stem.Equals(HeavenlyStem.Ding))
            return [EarthlyBranch.Hai, EarthlyBranch.You];
        if (stem.Equals(HeavenlyStem.Ren) || stem.Equals(HeavenlyStem.Gui))
            return [EarthlyBranch.Mao, EarthlyBranch.Si];
        if (stem.Equals(HeavenlyStem.Geng) || stem.Equals(HeavenlyStem.Xin))
            return [EarthlyBranch.Wu, EarthlyBranch.Yin];

        return [];
    });

    /// <summary>
    /// 禄神。
    /// </summary>
    /// <remarks>
    /// 逢甲日禄在寅，逢乙日禄在卯，
    /// 逢丙日与戊日禄在巳，逢丁日与己日禄在午，
    /// 逢庚日禄在申，逢辛日禄在酉，
    /// 逢壬日禄在亥，逢癸日禄在子。
    /// </remarks>
    public static SpiritAndMalignity SalarySpirit => new(2, nameof(SalarySpirit), divination =>
    {
        var stem = divination.InquiryTime.Lunar.Day.HeavenlyStem;

        if (stem.Equals(HeavenlyStem.Jia))
            return [EarthlyBranch.Yin];
        if (stem.Equals(HeavenlyStem.Yi))
            return [EarthlyBranch.Mao];
        if (stem.Equals(HeavenlyStem.Bing) || stem.Equals(HeavenlyStem.Wu))
            return [EarthlyBranch.Si];
        if (stem.Equals(HeavenlyStem.Ding) || stem.Equals(HeavenlyStem.Ji))
            return [EarthlyBranch.Wu];
        if (stem.Equals(HeavenlyStem.Geng))
            return [EarthlyBranch.Shen];
        if (stem.Equals(HeavenlyStem.Xin))
            return [EarthlyBranch.You];
        if (stem.Equals(HeavenlyStem.Ren))
            return [EarthlyBranch.Hai];
        if (stem.Equals(HeavenlyStem.Gui))
            return [EarthlyBranch.Zi];

        return [];
    });

    /// <summary>
    /// 驿马。
    /// </summary>
    /// <remarks>
    /// 桃进马冲劫首生。
    /// 马冲，驿马冲三合局首位
    /// </remarks>
    public static SpiritAndMalignity PostHorse => new(3, nameof(PostHorse), divination =>
    {
        var branch = divination.InquiryTime.Lunar.Day.EarthlyBranch;

        if (branch.Equals(EarthlyBranch.Yin) || branch.Equals(EarthlyBranch.Wu) || branch.Equals(EarthlyBranch.Xu))
            return [EarthlyBranch.Shen];
        if (branch.Equals(EarthlyBranch.Si) || branch.Equals(EarthlyBranch.You) || branch.Equals(EarthlyBranch.Chou))
            return [EarthlyBranch.Hai];
        if (branch.Equals(EarthlyBranch.Shen) || branch.Equals(EarthlyBranch.Zi) || branch.Equals(EarthlyBranch.Chen))
            return [EarthlyBranch.Yin];
        if (branch.Equals(EarthlyBranch.Hai) || branch.Equals(EarthlyBranch.Mao) || branch.Equals(EarthlyBranch.Wei))
            return [EarthlyBranch.Si];

        return [];
    });

    /// <summary>
    /// 桃花。
    /// </summary>
    /// <remarks>
    /// 桃进马冲劫首生。
    /// 桃进，就是三合局首进一位
    /// </remarks>
    public static SpiritAndMalignity PeachBlossom => new(4, nameof(PeachBlossom), divination =>
    {
        var branch = divination.InquiryTime.Lunar.Day.EarthlyBranch;

        if (branch.Equals(EarthlyBranch.Yin) || branch.Equals(EarthlyBranch.Wu) || branch.Equals(EarthlyBranch.Xu))
            return [EarthlyBranch.Mao];
        if (branch.Equals(EarthlyBranch.Si) || branch.Equals(EarthlyBranch.You) || branch.Equals(EarthlyBranch.Chou))
            return [EarthlyBranch.Wu];
        if (branch.Equals(EarthlyBranch.Shen) || branch.Equals(EarthlyBranch.Zi) || branch.Equals(EarthlyBranch.Chen))
            return [EarthlyBranch.You];
        if (branch.Equals(EarthlyBranch.Hai) || branch.Equals(EarthlyBranch.Mao) || branch.Equals(EarthlyBranch.Wei))
            return [EarthlyBranch.Zi];

        return [];
    });

    /// <summary>
    /// 羊刃。
    /// </summary>
    /// <remarks>羊刃就是和禄神相同五行的地支，比如禄神在寅，羊刃就是卯。</remarks>
    public static SpiritAndMalignity YangBlade => new(5, nameof(YangBlade), divination =>
    {
        var stem = divination.InquiryTime.Lunar.Day.HeavenlyStem;

        if (stem.Equals(HeavenlyStem.Jia))
            return [EarthlyBranch.Mao];
        if (stem.Equals(HeavenlyStem.Yi))
            return [EarthlyBranch.Yin];
        if (stem.Equals(HeavenlyStem.Bing) || stem.Equals(HeavenlyStem.Wu))
            return [EarthlyBranch.Wu];
        if (stem.Equals(HeavenlyStem.Ding) || stem.Equals(HeavenlyStem.Ji))
            return [EarthlyBranch.Si];
        if (stem.Equals(HeavenlyStem.Geng))
            return [EarthlyBranch.You];
        if (stem.Equals(HeavenlyStem.Xin))
            return [EarthlyBranch.Shen];
        if (stem.Equals(HeavenlyStem.Ren))
            return [EarthlyBranch.Zi];
        if (stem.Equals(HeavenlyStem.Gui))
            return [EarthlyBranch.Hai];

        return [];
    });

    /// <summary>
    /// 文昌。
    /// </summary>
    /// <remarks>甲巳乙午丙戊申，丁己属鸡庚猪寻，辛鼠壬虎癸见卯。</remarks>
    public static SpiritAndMalignity CultureFlourish => new(6, nameof(CultureFlourish), divination =>
    {
        var stem = divination.InquiryTime.Lunar.Day.HeavenlyStem;

        if (stem.Equals(HeavenlyStem.Jia))
            return [EarthlyBranch.Si];
        if (stem.Equals(HeavenlyStem.Yi))
            return [EarthlyBranch.Wu];
        if (stem.Equals(HeavenlyStem.Bing) || stem.Equals(HeavenlyStem.Wu))
            return [EarthlyBranch.Shen];
        if (stem.Equals(HeavenlyStem.Ding) || stem.Equals(HeavenlyStem.Ji))
            return [EarthlyBranch.You];
        if (stem.Equals(HeavenlyStem.Geng))
            return [EarthlyBranch.Hai];
        if (stem.Equals(HeavenlyStem.Xin))
            return [EarthlyBranch.Zi];
        if (stem.Equals(HeavenlyStem.Ren))
            return [EarthlyBranch.Yin];
        if (stem.Equals(HeavenlyStem.Gui))
            return [EarthlyBranch.Wu];

        return [];
    });

    /// <summary>
    /// 天医。
    /// </summary>
    /// <remarks>月建在寅，天医就是丑，(这里的退不是指退神，是指相邻的地支退一位)。</remarks>
    public static SpiritAndMalignity CelestialPhysician => new(7, nameof(CelestialPhysician), divination =>
    {
        var branch = divination.InquiryTime.Lunar.Month.EarthlyBranch;

        if (branch.Equals(EarthlyBranch.Yin)) return [EarthlyBranch.Chou];
        if (branch.Equals(EarthlyBranch.Mao)) return [EarthlyBranch.Yin];
        if (branch.Equals(EarthlyBranch.Chen)) return [EarthlyBranch.Mao];
        if (branch.Equals(EarthlyBranch.Si)) return [EarthlyBranch.Chen];
        if (branch.Equals(EarthlyBranch.Wu)) return [EarthlyBranch.Si];
        if (branch.Equals(EarthlyBranch.Wei)) return [EarthlyBranch.Wu];
        if (branch.Equals(EarthlyBranch.Shen)) return [EarthlyBranch.Wei];
        if (branch.Equals(EarthlyBranch.You)) return [EarthlyBranch.Hai];
        if (branch.Equals(EarthlyBranch.Xu)) return [EarthlyBranch.You];
        if (branch.Equals(EarthlyBranch.Hai)) return [EarthlyBranch.Xu];
        if (branch.Equals(EarthlyBranch.Zi)) return [EarthlyBranch.Hai];
        if (branch.Equals(EarthlyBranch.Chou)) return [EarthlyBranch.Zi];

        return [];
    });

    /// <summary>
    /// 劫煞。
    /// </summary>
    /// <remarks>
    /// 桃进马冲劫首生。
    /// 劫首生，劫煞就是三合局首位的长生位
    /// </remarks>
    public static SpiritAndMalignity RobberyMalignity => new(8, nameof(RobberyMalignity), divination =>
    {
        var branch = divination.InquiryTime.Lunar.Day.EarthlyBranch;

        if (branch.Equals(EarthlyBranch.Yin) || branch.Equals(EarthlyBranch.Wu) || branch.Equals(EarthlyBranch.Xu))
            return [EarthlyBranch.Hai];
        if (branch.Equals(EarthlyBranch.Si) || branch.Equals(EarthlyBranch.You) || branch.Equals(EarthlyBranch.Chou))
            return [EarthlyBranch.Yin];
        if (branch.Equals(EarthlyBranch.Shen) || branch.Equals(EarthlyBranch.Zi) || branch.Equals(EarthlyBranch.Chen))
            return [EarthlyBranch.Si];
        if (branch.Equals(EarthlyBranch.Hai) || branch.Equals(EarthlyBranch.Mao) || branch.Equals(EarthlyBranch.Wei))
            return [EarthlyBranch.Shen];

        return [];
    });

    /// <summary>
    /// 灾煞。
    /// </summary>
    /// <remarks>
    /// 将坐帐中与灾冲
    /// 与灾冲，灾煞就是冲三合局中间的地支
    /// </remarks>
    public static SpiritAndMalignity DisasterMalignity => new(9, nameof(DisasterMalignity), divination =>
    {
        var branch = divination.InquiryTime.Lunar.Day.EarthlyBranch;

        if (branch.Equals(EarthlyBranch.Yin) || branch.Equals(EarthlyBranch.Wu) || branch.Equals(EarthlyBranch.Xu))
            return [EarthlyBranch.Zi];
        if (branch.Equals(EarthlyBranch.Si) || branch.Equals(EarthlyBranch.You) || branch.Equals(EarthlyBranch.Chou))
            return [EarthlyBranch.Mao];
        if (branch.Equals(EarthlyBranch.Shen) || branch.Equals(EarthlyBranch.Zi) || branch.Equals(EarthlyBranch.Chen))
            return [EarthlyBranch.Wu];
        if (branch.Equals(EarthlyBranch.Hai) || branch.Equals(EarthlyBranch.Mao) || branch.Equals(EarthlyBranch.Wei))
            return [EarthlyBranch.You];

        return [];
    });

    /// <summary>
    /// 将星。
    /// </summary>
    /// <remarks>
    /// 将坐帐中与灾冲
    /// 将星就是在三合局中间的地支
    /// </remarks>
    public static SpiritAndMalignity GeneralsStar => new(10, nameof(GeneralsStar), divination =>
    {
        var branch = divination.InquiryTime.Lunar.Day.EarthlyBranch;

        if (branch.Equals(EarthlyBranch.Yin) || branch.Equals(EarthlyBranch.Wu) || branch.Equals(EarthlyBranch.Xu))
            return [EarthlyBranch.Wu];
        if (branch.Equals(EarthlyBranch.Si) || branch.Equals(EarthlyBranch.You) || branch.Equals(EarthlyBranch.Chou))
            return [EarthlyBranch.You];
        if (branch.Equals(EarthlyBranch.Shen) || branch.Equals(EarthlyBranch.Zi) || branch.Equals(EarthlyBranch.Chen))
            return [EarthlyBranch.Zi];
        if (branch.Equals(EarthlyBranch.Hai) || branch.Equals(EarthlyBranch.Mao) || branch.Equals(EarthlyBranch.Wei))
            return [EarthlyBranch.Mao];

        return [];
    });

    /// <summary>
    /// 华盖。
    /// </summary>
    /// <remarks>
    /// 谋星冲尾华盖同
    /// 华盖同，就是指和三合局土支相同的
    /// </remarks>
    public static SpiritAndMalignity Canopy => new(11, nameof(Canopy), divination =>
    {
        var branch = divination.InquiryTime.Lunar.Day.EarthlyBranch;

        if (branch.Equals(EarthlyBranch.Yin) || branch.Equals(EarthlyBranch.Wu) || branch.Equals(EarthlyBranch.Xu))
            return [EarthlyBranch.Xu];
        if (branch.Equals(EarthlyBranch.Si) || branch.Equals(EarthlyBranch.You) || branch.Equals(EarthlyBranch.Chou))
            return [EarthlyBranch.Chou];
        if (branch.Equals(EarthlyBranch.Shen) || branch.Equals(EarthlyBranch.Zi) || branch.Equals(EarthlyBranch.Chen))
            return [EarthlyBranch.Chen];
        if (branch.Equals(EarthlyBranch.Hai) || branch.Equals(EarthlyBranch.Mao) || branch.Equals(EarthlyBranch.Wei))
            return [EarthlyBranch.Wei];

        return [];
    });

    /// <summary>
    /// 谋星。
    /// </summary>
    /// <remarks>
    /// 谋星冲尾华盖同
    /// 谋星冲尾就是指与三合局土支相冲的地支
    /// </remarks>
    public static SpiritAndMalignity StarOfStrategy => new(12, nameof(StarOfStrategy), divination =>
    {
        var branch = divination.InquiryTime.Lunar.Day.EarthlyBranch;

        if (branch.Equals(EarthlyBranch.Yin) || branch.Equals(EarthlyBranch.Wu) || branch.Equals(EarthlyBranch.Xu))
            return [EarthlyBranch.Chen];
        if (branch.Equals(EarthlyBranch.Si) || branch.Equals(EarthlyBranch.You) || branch.Equals(EarthlyBranch.Chou))
            return [EarthlyBranch.Wei];
        if (branch.Equals(EarthlyBranch.Shen) || branch.Equals(EarthlyBranch.Zi) || branch.Equals(EarthlyBranch.Chen))
            return [EarthlyBranch.Xu];
        if (branch.Equals(EarthlyBranch.Hai) || branch.Equals(EarthlyBranch.Mao) || branch.Equals(EarthlyBranch.Wei))
            return [EarthlyBranch.Chou];

        return [];
    });

    /// <summary>
    /// 亡神。
    /// </summary>
    /// <remarks>
    /// 寅午戌见巳，亥卯未见寅，巳酉丑见申，申子辰见亥
    /// </remarks>
    public static SpiritAndMalignity DeathSpirit => new(13, nameof(DeathSpirit), divination =>
    {
        var branch = divination.InquiryTime.Lunar.Day.EarthlyBranch;

        if (branch.Equals(EarthlyBranch.Yin) || branch.Equals(EarthlyBranch.Wu) || branch.Equals(EarthlyBranch.Xu))
            return [EarthlyBranch.Si];
        if (branch.Equals(EarthlyBranch.Si) || branch.Equals(EarthlyBranch.You) || branch.Equals(EarthlyBranch.Chou))
            return [EarthlyBranch.Shen];
        if (branch.Equals(EarthlyBranch.Shen) || branch.Equals(EarthlyBranch.Zi) || branch.Equals(EarthlyBranch.Chen))
            return [EarthlyBranch.Hai];
        if (branch.Equals(EarthlyBranch.Hai) || branch.Equals(EarthlyBranch.Mao) || branch.Equals(EarthlyBranch.Wei))
            return [EarthlyBranch.Yin];

        return [];
    });

    /// <summary>
    /// 天喜。
    /// </summary>
    /// <remarks>
    /// 春戌夏丑逢天喜，秋辰冬未喜来临
    /// 即：寅卯辰月见戌，巳午未月见丑，申酉戌月见辰，亥子丑月见未
    /// </remarks>
    public static SpiritAndMalignity HeavenlyJoy => new(14, "HeavenlyJoy", divination =>
    {
        var branch = divination.InquiryTime.Lunar.Month.EarthlyBranch;

        if (branch.Equals(EarthlyBranch.Yin) || branch.Equals(EarthlyBranch.Mao) || branch.Equals(EarthlyBranch.Chen))
            return [EarthlyBranch.Xu];
        if (branch.Equals(EarthlyBranch.Si) || branch.Equals(EarthlyBranch.Wu) || branch.Equals(EarthlyBranch.Wei))
            return [EarthlyBranch.Chou];
        if (branch.Equals(EarthlyBranch.Shen) || branch.Equals(EarthlyBranch.You) || branch.Equals(EarthlyBranch.Xu))
            return [EarthlyBranch.Chen];
        if (branch.Equals(EarthlyBranch.Hai) || branch.Equals(EarthlyBranch.Zi) || branch.Equals(EarthlyBranch.Chou))
            return [EarthlyBranch.Wei];

        return [];
    });

    /// <summary>
    /// 床帐。
    /// </summary>
    /// <remarks>
    /// 先求卦身：阳世起子阴起午，俱从初爻数到世。
    /// 卦身所生者为床帐
    /// </remarks>
    public static SpiritAndMalignity MarriageBed => new(15, nameof(MarriageBed), divination =>
    {
        var bodyBranch = divination.Original.Body;

        if (bodyBranch.FivePhase.Equals(FivePhase.Metal))
            return [EarthlyBranch.Hai, EarthlyBranch.Zi];
        if (bodyBranch.FivePhase.Equals(FivePhase.Water))
            return [EarthlyBranch.Yin, EarthlyBranch.Mao];
        if (bodyBranch.FivePhase.Equals(FivePhase.Wood))
            return [EarthlyBranch.Si, EarthlyBranch.Wu];
        if (bodyBranch.FivePhase.Equals(FivePhase.Fire))
            return [EarthlyBranch.Chen, EarthlyBranch.Xu, EarthlyBranch.Chou, EarthlyBranch.Wei];
        if (bodyBranch.FivePhase.Equals(FivePhase.Earth))
            return [EarthlyBranch.Shen, EarthlyBranch.You];

        return [];
    });

    /// <summary>
    /// 香闺。
    /// </summary>
    /// <remarks>
    /// 先求卦身：阳世起子阴起午，俱从初爻数到世。
    /// 卦身所克者为香闺
    /// </remarks>
    public static SpiritAndMalignity BridalChamber => new(16, nameof(BridalChamber), divination =>
    {
        var bodyBranch = divination.Original.Body;

        if (bodyBranch.FivePhase.Equals(FivePhase.Metal))
            return [EarthlyBranch.Yin, EarthlyBranch.Mao];
        if (bodyBranch.FivePhase.Equals(FivePhase.Water))
            return [EarthlyBranch.Si, EarthlyBranch.Wu];
        if (bodyBranch.FivePhase.Equals(FivePhase.Wood))
            return [EarthlyBranch.Chen, EarthlyBranch.Xu, EarthlyBranch.Chou, EarthlyBranch.Wei];
        if (bodyBranch.FivePhase.Equals(FivePhase.Fire))
            return [EarthlyBranch.Shen, EarthlyBranch.You];
        if (bodyBranch.FivePhase.Equals(FivePhase.Earth))
            return [EarthlyBranch.Hai, EarthlyBranch.Zi];

        return [];
    });
}