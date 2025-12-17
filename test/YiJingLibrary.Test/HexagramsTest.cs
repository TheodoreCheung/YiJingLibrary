using System.Reflection;
using Xunit.Abstractions;
using YiJingLibrary.Core;

namespace YiJingLibrary.Test;

public class HexagramsTest(ITestOutputHelper testOutputHelper)
{
    private IEnumerable<Hexagram> GetSixtyFourHexagrams()
    {
        var type = typeof(Hexagram);
        return type.GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(p => p.PropertyType == typeof(Hexagram))
            .Select(p => p.GetValue(null) as Hexagram ?? throw new NullReferenceException());
    }
    
    [Fact]
    public void HexagramsCount_Is64()
    {
        Assert.Equal(64, GetSixtyFourHexagrams().Count());
    }

    [Fact]
    public void Palace_IsCorrect()
    {
        Dictionary<byte, List<byte>> palaceDict = new()
        {
            {
                Trigram.Qian,
                [
                    Hexagram.TheCreative, Hexagram.ComingToMeet, Hexagram.Retreat, Hexagram.Standstill,
                    Hexagram.Contemplation, Hexagram.SplittingApart, Hexagram.Progress,
                    Hexagram.PossessionInGreatMeasure
                ]
            },
            {
                Trigram.Dui,
                [
                    Hexagram.TheJoyous, Hexagram.Oppression, Hexagram.GatheringTogether, Hexagram.Influence,
                    Hexagram.Obstruction, Hexagram.Modesty, Hexagram.PreponderanceOfTheSmall, Hexagram.TheMarryingMaiden
                ]
            },
            {
                Trigram.Li,
                [
                    Hexagram.TheClinging, Hexagram.TheWanderer, Hexagram.TheCauldron, Hexagram.BeforeCompletion,
                    Hexagram.YouthfulFolly, Hexagram.Dispersion, Hexagram.Conflict, Hexagram.FellowshipWithMen
                ]
            },
            {
                Trigram.Zhen,
                [
                    Hexagram.TheArousing, Hexagram.Enthusiasm, Hexagram.Deliverance, Hexagram.Duration,
                    Hexagram.PushingUpward, Hexagram.TheWell, Hexagram.PreponderanceOfTheGreat, Hexagram.Following
                ]
            },
            {
                Trigram.Xun,
                [
                    Hexagram.TheGentle, Hexagram.TheTamingPowerOfTheSmall, Hexagram.TheFamily, Hexagram.Increase,
                    Hexagram.Innocence, Hexagram.BitingThrough, Hexagram.TheCornersOfTheMouth, Hexagram.WorkOnTheDecayed
                ]
            },
            {
                Trigram.Kan,
                [
                    Hexagram.TheAbysmal, Hexagram.Limitation, Hexagram.DifficultyAtTheBeginning, Hexagram.AfterCompletion,
                    Hexagram.Revolution, Hexagram.Abundance, Hexagram.DarkeningOfTheLight, Hexagram.TheArmy
                ]
            },
            {
                Trigram.Gen,
                [
                    Hexagram.KeepingStill, Hexagram.Grace, Hexagram.TheTamingPowerOfTheGreat, Hexagram.Decrease,
                    Hexagram.Opposition, Hexagram.Treading, Hexagram.InnerTruth, Hexagram.Development
                ]
            },
            {
                Trigram.Kun,
                [
                    Hexagram.TheReceptive, Hexagram.Return, Hexagram.Approach, Hexagram.Peace,
                    Hexagram.ThePowerOfTheGreat, Hexagram.BreakThrough, Hexagram.Waiting, Hexagram.HoldingTogether
                ]
            }
        };

        Dictionary<byte, int> countDict = new()
        {
            { Trigram.Qian, 0 },
            { Trigram.Dui, 0 },
            { Trigram.Li, 0 },
            { Trigram.Zhen, 0 },
            { Trigram.Xun, 0 },
            { Trigram.Kan, 0 },
            { Trigram.Gen, 0 },
            { Trigram.Kun, 0 }
        };

        foreach (var hexagram in GetSixtyFourHexagrams())
        {
            var hexagramInPalace = palaceDict[hexagram.Palace].Contains(hexagram);
            Assert.True(hexagramInPalace);
            countDict[hexagram.Palace]++;
        }
        
        Assert.Equal(8, countDict[Trigram.Qian]);
        Assert.Equal(8, countDict[Trigram.Dui]);
        Assert.Equal(8, countDict[Trigram.Li]);
        Assert.Equal(8, countDict[Trigram.Zhen]);
        Assert.Equal(8, countDict[Trigram.Xun]);
        Assert.Equal(8, countDict[Trigram.Kan]);
        Assert.Equal(8, countDict[Trigram.Gen]);
        Assert.Equal(8, countDict[Trigram.Kun]);
    }
    
    [Fact]
    public void QueryByYaoYinYang_IsCorrect()
    {
        foreach (var hexagram in GetSixtyFourHexagrams())
        {
            var result = Hexagram.QueryByYinYang([
                hexagram[1].YinYang, hexagram[2].YinYang, hexagram[3].YinYang,
                hexagram[4].YinYang, hexagram[5].YinYang, hexagram[6].YinYang
            ]);
            Assert.Equal(hexagram, result);
        }
    }

    [Fact]
    public void TheCreative_IsCorrect()
    {
        var qian = Hexagram.TheCreative;

        var json = System.Text.Json.JsonSerializer.Serialize(qian);
        testOutputHelper.WriteLine(json);

        var yangCount = qian.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(6, yangCount);

        testOutputHelper.WriteLine(qian.ToString());
    }

    [Fact]
    public void TheReceptive_IsCorrect()
    {
        var kun = Hexagram.TheReceptive;

        var yangCount = kun.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(6, yangCount);

        testOutputHelper.WriteLine(kun.ToString());
    }

    [Fact]
    public void DifficultyAtTheBeginning_IsCorrect()
    {
        var zhun = Hexagram.DifficultyAtTheBeginning;

        Assert.True(zhun[6].YinYang.Equals(YinYang.Yin));
        Assert.True(zhun[5].YinYang.Equals(YinYang.Yang));
        Assert.True(zhun[4].YinYang.Equals(YinYang.Yin));
        Assert.True(zhun[3].YinYang.Equals(YinYang.Yin));
        Assert.True(zhun[2].YinYang.Equals(YinYang.Yin));
        Assert.True(zhun[1].YinYang.Equals(YinYang.Yang));

        var yangCount = zhun.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = zhun.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(zhun.ToString());
    }

    [Fact]
    public void YouthfulFolly_IsCorrect()
    {
        var meng = Hexagram.YouthfulFolly;

        Assert.True(meng[6].YinYang.Equals(YinYang.Yang));
        Assert.True(meng[5].YinYang.Equals(YinYang.Yin));
        Assert.True(meng[4].YinYang.Equals(YinYang.Yin));
        Assert.True(meng[3].YinYang.Equals(YinYang.Yin));
        Assert.True(meng[2].YinYang.Equals(YinYang.Yang));
        Assert.True(meng[1].YinYang.Equals(YinYang.Yin));

        var yangCount = meng.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = meng.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(meng.ToString());
    }

    [Fact]
    public void Waiting_IsCorrect()
    {
        var xu = Hexagram.Waiting;

        Assert.True(xu[6].YinYang.Equals(YinYang.Yin));
        Assert.True(xu[5].YinYang.Equals(YinYang.Yang));
        Assert.True(xu[4].YinYang.Equals(YinYang.Yin));
        Assert.True(xu[3].YinYang.Equals(YinYang.Yang));
        Assert.True(xu[2].YinYang.Equals(YinYang.Yang));
        Assert.True(xu[1].YinYang.Equals(YinYang.Yang));

        var yangCount = xu.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = xu.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(xu.ToString());
    }

    [Fact]
    public void Conflict_IsCorrect()
    {
        var song = Hexagram.Conflict;

        Assert.True(song[6].YinYang.Equals(YinYang.Yang));
        Assert.True(song[5].YinYang.Equals(YinYang.Yang));
        Assert.True(song[4].YinYang.Equals(YinYang.Yang));
        Assert.True(song[3].YinYang.Equals(YinYang.Yin));
        Assert.True(song[2].YinYang.Equals(YinYang.Yang));
        Assert.True(song[1].YinYang.Equals(YinYang.Yin));

        var yangCount = song.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = song.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(song.ToString());
    }

    [Fact]
    public void TheArmy_IsCorrect()
    {
        var shi = Hexagram.TheArmy;

        Assert.True(shi[6].YinYang.Equals(YinYang.Yin));
        Assert.True(shi[5].YinYang.Equals(YinYang.Yin));
        Assert.True(shi[4].YinYang.Equals(YinYang.Yin));
        Assert.True(shi[3].YinYang.Equals(YinYang.Yin));
        Assert.True(shi[2].YinYang.Equals(YinYang.Yang));
        Assert.True(shi[1].YinYang.Equals(YinYang.Yin));

        var yangCount = shi.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(1, yangCount);
        var yinCount = shi.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(5, yinCount);

        testOutputHelper.WriteLine(shi.ToString());
    }

    [Fact]
    public void HoldingTogether_IsCorrect()
    {
        var bi = Hexagram.HoldingTogether;

        Assert.True(bi[6].YinYang.Equals(YinYang.Yin));
        Assert.True(bi[5].YinYang.Equals(YinYang.Yang));
        Assert.True(bi[4].YinYang.Equals(YinYang.Yin));
        Assert.True(bi[3].YinYang.Equals(YinYang.Yin));
        Assert.True(bi[2].YinYang.Equals(YinYang.Yin));
        Assert.True(bi[1].YinYang.Equals(YinYang.Yin));

        var yangCount = bi.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(1, yangCount);
        var yinCount = bi.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(5, yinCount);

        testOutputHelper.WriteLine(bi.ToString());
    }

    [Fact]
    public void TheTamingPowerOfTheSmall_IsCorrect()
    {
        var xiaoXu = Hexagram.TheTamingPowerOfTheSmall;

        Assert.True(xiaoXu[6].YinYang.Equals(YinYang.Yang));
        Assert.True(xiaoXu[5].YinYang.Equals(YinYang.Yang));
        Assert.True(xiaoXu[4].YinYang.Equals(YinYang.Yin));
        Assert.True(xiaoXu[3].YinYang.Equals(YinYang.Yang));
        Assert.True(xiaoXu[2].YinYang.Equals(YinYang.Yang));
        Assert.True(xiaoXu[1].YinYang.Equals(YinYang.Yang));

        var yangCount = xiaoXu.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(5, yangCount);
        var yinCount = xiaoXu.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(1, yinCount);

        testOutputHelper.WriteLine(xiaoXu.ToString());
    }

    [Fact]
    public void Treading_IsCorrect()
    {
        var lv = Hexagram.Treading;

        Assert.True(lv[6].YinYang.Equals(YinYang.Yang));
        Assert.True(lv[5].YinYang.Equals(YinYang.Yang));
        Assert.True(lv[4].YinYang.Equals(YinYang.Yang));
        Assert.True(lv[3].YinYang.Equals(YinYang.Yin));
        Assert.True(lv[2].YinYang.Equals(YinYang.Yang));
        Assert.True(lv[1].YinYang.Equals(YinYang.Yang));

        var yangCount = lv.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(5, yangCount);
        var yinCount = lv.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(1, yinCount);

        testOutputHelper.WriteLine(lv.ToString());
    }

    [Fact]
    public void Peace_IsCorrect()
    {
        var tai = Hexagram.Peace;

        Assert.True(tai[6].YinYang.Equals(YinYang.Yin));
        Assert.True(tai[5].YinYang.Equals(YinYang.Yin));
        Assert.True(tai[4].YinYang.Equals(YinYang.Yin));
        Assert.True(tai[3].YinYang.Equals(YinYang.Yang));
        Assert.True(tai[2].YinYang.Equals(YinYang.Yang));
        Assert.True(tai[1].YinYang.Equals(YinYang.Yang));

        var yangCount = tai.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = tai.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(tai.ToString());
    }

    [Fact]
    public void Standstill_IsCorrect()
    {
        var pi = Hexagram.Standstill;

        Assert.True(pi[6].YinYang.Equals(YinYang.Yang));
        Assert.True(pi[5].YinYang.Equals(YinYang.Yang));
        Assert.True(pi[4].YinYang.Equals(YinYang.Yang));
        Assert.True(pi[3].YinYang.Equals(YinYang.Yin));
        Assert.True(pi[2].YinYang.Equals(YinYang.Yin));
        Assert.True(pi[1].YinYang.Equals(YinYang.Yin));

        var yangCount = pi.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = pi.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(pi.ToString());
    }

    [Fact]
    public void FellowshipWithMen_IsCorrect()
    {
        var tongRen = Hexagram.FellowshipWithMen;

        Assert.True(tongRen[6].YinYang.Equals(YinYang.Yang));
        Assert.True(tongRen[5].YinYang.Equals(YinYang.Yang));
        Assert.True(tongRen[4].YinYang.Equals(YinYang.Yang));
        Assert.True(tongRen[3].YinYang.Equals(YinYang.Yang));
        Assert.True(tongRen[2].YinYang.Equals(YinYang.Yin));
        Assert.True(tongRen[1].YinYang.Equals(YinYang.Yang));

        var yangCount = tongRen.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(5, yangCount);
        var yinCount = tongRen.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(1, yinCount);

        testOutputHelper.WriteLine(tongRen.ToString());
    }

    [Fact]
    public void PossessionInGreatMeasure_IsCorrect()
    {
        var daYou = Hexagram.PossessionInGreatMeasure;

        Assert.True(daYou[6].YinYang.Equals(YinYang.Yang));
        Assert.True(daYou[5].YinYang.Equals(YinYang.Yin));
        Assert.True(daYou[4].YinYang.Equals(YinYang.Yang));
        Assert.True(daYou[3].YinYang.Equals(YinYang.Yang));
        Assert.True(daYou[2].YinYang.Equals(YinYang.Yang));
        Assert.True(daYou[1].YinYang.Equals(YinYang.Yang));

        var yangCount = daYou.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(5, yangCount);
        var yinCount = daYou.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(1, yinCount);

        testOutputHelper.WriteLine(daYou.ToString());
    }

    [Fact]
    public void Modesty_IsCorrect()
    {
        var qian = Hexagram.Modesty;

        Assert.True(qian[6].YinYang.Equals(YinYang.Yin));
        Assert.True(qian[5].YinYang.Equals(YinYang.Yin));
        Assert.True(qian[4].YinYang.Equals(YinYang.Yin));
        Assert.True(qian[3].YinYang.Equals(YinYang.Yang));
        Assert.True(qian[2].YinYang.Equals(YinYang.Yin));
        Assert.True(qian[1].YinYang.Equals(YinYang.Yin));

        var yangCount = qian.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(1, yangCount);
        var yinCount = qian.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(5, yinCount);

        testOutputHelper.WriteLine(qian.ToString());
    }

    [Fact]
    public void Enthusiasm_IsCorrect()
    {
        var yu = Hexagram.Enthusiasm;

        Assert.True(yu[6].YinYang.Equals(YinYang.Yin));
        Assert.True(yu[5].YinYang.Equals(YinYang.Yin));
        Assert.True(yu[4].YinYang.Equals(YinYang.Yang));
        Assert.True(yu[3].YinYang.Equals(YinYang.Yin));
        Assert.True(yu[2].YinYang.Equals(YinYang.Yin));
        Assert.True(yu[1].YinYang.Equals(YinYang.Yin));

        var yangCount = yu.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(1, yangCount);
        var yinCount = yu.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(5, yinCount);

        testOutputHelper.WriteLine(yu.ToString());
    }

    [Fact]
    public void Following_IsCorrect()
    {
        var sui = Hexagram.Following;

        Assert.True(sui[6].YinYang.Equals(YinYang.Yin));
        Assert.True(sui[5].YinYang.Equals(YinYang.Yang));
        Assert.True(sui[4].YinYang.Equals(YinYang.Yang));
        Assert.True(sui[3].YinYang.Equals(YinYang.Yin));
        Assert.True(sui[2].YinYang.Equals(YinYang.Yin));
        Assert.True(sui[1].YinYang.Equals(YinYang.Yang));

        var yangCount = sui.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = sui.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(sui.ToString());
    }

    [Fact]
    public void WorkOnTheDecayed_IsCorrect()
    {
        var gu = Hexagram.WorkOnTheDecayed;

        Assert.True(gu[6].YinYang.Equals(YinYang.Yang));
        Assert.True(gu[5].YinYang.Equals(YinYang.Yin));
        Assert.True(gu[4].YinYang.Equals(YinYang.Yin));
        Assert.True(gu[3].YinYang.Equals(YinYang.Yang));
        Assert.True(gu[2].YinYang.Equals(YinYang.Yang));
        Assert.True(gu[1].YinYang.Equals(YinYang.Yin));

        var yangCount = gu.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = gu.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(gu.ToString());
    }

    [Fact]
    public void Approach_IsCorrect()
    {
        var lin = Hexagram.Approach;

        Assert.True(lin[6].YinYang.Equals(YinYang.Yin));
        Assert.True(lin[5].YinYang.Equals(YinYang.Yin));
        Assert.True(lin[4].YinYang.Equals(YinYang.Yin));
        Assert.True(lin[3].YinYang.Equals(YinYang.Yin));
        Assert.True(lin[2].YinYang.Equals(YinYang.Yang));
        Assert.True(lin[1].YinYang.Equals(YinYang.Yang));

        var yangCount = lin.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = lin.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(lin.ToString());
    }

    [Fact]
    public void Contemplation_IsCorrect()
    {
        var guan = Hexagram.Contemplation;

        Assert.True(guan[6].YinYang.Equals(YinYang.Yang));
        Assert.True(guan[5].YinYang.Equals(YinYang.Yang));
        Assert.True(guan[4].YinYang.Equals(YinYang.Yin));
        Assert.True(guan[3].YinYang.Equals(YinYang.Yin));
        Assert.True(guan[2].YinYang.Equals(YinYang.Yin));
        Assert.True(guan[1].YinYang.Equals(YinYang.Yin));

        var yangCount = guan.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = guan.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(guan.ToString());
    }

    [Fact]
    public void BitingThrough_IsCorrect()
    {
        var shiKe = Hexagram.BitingThrough;

        Assert.True(shiKe[6].YinYang.Equals(YinYang.Yang));
        Assert.True(shiKe[5].YinYang.Equals(YinYang.Yin));
        Assert.True(shiKe[4].YinYang.Equals(YinYang.Yang));
        Assert.True(shiKe[3].YinYang.Equals(YinYang.Yin));
        Assert.True(shiKe[2].YinYang.Equals(YinYang.Yin));
        Assert.True(shiKe[1].YinYang.Equals(YinYang.Yang));

        var yangCount = shiKe.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = shiKe.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(shiKe.ToString());
    }

    [Fact]
    public void Grace_IsCorrect()
    {
        var bi = Hexagram.Grace;

        Assert.True(bi[6].YinYang.Equals(YinYang.Yang));
        Assert.True(bi[5].YinYang.Equals(YinYang.Yin));
        Assert.True(bi[4].YinYang.Equals(YinYang.Yin));
        Assert.True(bi[3].YinYang.Equals(YinYang.Yang));
        Assert.True(bi[2].YinYang.Equals(YinYang.Yin));
        Assert.True(bi[1].YinYang.Equals(YinYang.Yang));

        var yangCount = bi.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = bi.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(bi.ToString());
    }

    [Fact]
    public void SplittingApart_IsCorrect()
    {
        var bo = Hexagram.SplittingApart;

        Assert.True(bo[6].YinYang.Equals(YinYang.Yang));
        Assert.True(bo[5].YinYang.Equals(YinYang.Yin));
        Assert.True(bo[4].YinYang.Equals(YinYang.Yin));
        Assert.True(bo[3].YinYang.Equals(YinYang.Yin));
        Assert.True(bo[2].YinYang.Equals(YinYang.Yin));
        Assert.True(bo[1].YinYang.Equals(YinYang.Yin));

        var yangCount = bo.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(1, yangCount);
        var yinCount = bo.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(5, yinCount);

        testOutputHelper.WriteLine(bo.ToString());
    }

    [Fact]
    public void Return_IsCorrect()
    {
        var fu = Hexagram.Return;

        Assert.True(fu[6].YinYang.Equals(YinYang.Yin));
        Assert.True(fu[5].YinYang.Equals(YinYang.Yin));
        Assert.True(fu[4].YinYang.Equals(YinYang.Yin));
        Assert.True(fu[3].YinYang.Equals(YinYang.Yin));
        Assert.True(fu[2].YinYang.Equals(YinYang.Yin));
        Assert.True(fu[1].YinYang.Equals(YinYang.Yang));

        var yangCount = fu.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(1, yangCount);
        var yinCount = fu.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(5, yinCount);

        testOutputHelper.WriteLine(fu.ToString());
    }

    [Fact]
    public void Innocence_IsCorrect()
    {
        var wuWang = Hexagram.Innocence;

        Assert.True(wuWang[6].YinYang.Equals(YinYang.Yang));
        Assert.True(wuWang[5].YinYang.Equals(YinYang.Yang));
        Assert.True(wuWang[4].YinYang.Equals(YinYang.Yang));
        Assert.True(wuWang[3].YinYang.Equals(YinYang.Yin));
        Assert.True(wuWang[2].YinYang.Equals(YinYang.Yin));
        Assert.True(wuWang[1].YinYang.Equals(YinYang.Yang));

        var yangCount = wuWang.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = wuWang.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(wuWang.ToString());
    }

    [Fact]
    public void TheTamingPowerOfTheGreat_IsCorrect()
    {
        var daChu = Hexagram.TheTamingPowerOfTheGreat;

        Assert.True(daChu[6].YinYang.Equals(YinYang.Yang));
        Assert.True(daChu[5].YinYang.Equals(YinYang.Yin));
        Assert.True(daChu[4].YinYang.Equals(YinYang.Yin));
        Assert.True(daChu[3].YinYang.Equals(YinYang.Yang));
        Assert.True(daChu[2].YinYang.Equals(YinYang.Yang));
        Assert.True(daChu[1].YinYang.Equals(YinYang.Yang));

        var yangCount = daChu.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = daChu.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(daChu.ToString());
    }

    [Fact]
    public void TheCornersOfTheMouth_IsCorrect()
    {
        var yi = Hexagram.TheCornersOfTheMouth;

        Assert.True(yi[6].YinYang.Equals(YinYang.Yang));
        Assert.True(yi[5].YinYang.Equals(YinYang.Yin));
        Assert.True(yi[4].YinYang.Equals(YinYang.Yin));
        Assert.True(yi[3].YinYang.Equals(YinYang.Yin));
        Assert.True(yi[2].YinYang.Equals(YinYang.Yin));
        Assert.True(yi[1].YinYang.Equals(YinYang.Yang));

        var yangCount = yi.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = yi.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(yi.ToString());
    }

    [Fact]
    public void PreponderanceOfTheGreat_IsCorrect()
    {
        var daGuo = Hexagram.PreponderanceOfTheGreat;

        Assert.True(daGuo[6].YinYang.Equals(YinYang.Yin));
        Assert.True(daGuo[5].YinYang.Equals(YinYang.Yang));
        Assert.True(daGuo[4].YinYang.Equals(YinYang.Yang));
        Assert.True(daGuo[3].YinYang.Equals(YinYang.Yang));
        Assert.True(daGuo[2].YinYang.Equals(YinYang.Yang));
        Assert.True(daGuo[1].YinYang.Equals(YinYang.Yin));

        var yangCount = daGuo.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = daGuo.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(daGuo.ToString());
    }

    [Fact]
    public void TheAbysmal_IsCorrect()
    {
        var shui = Hexagram.TheAbysmal;

        Assert.True(shui[6].YinYang.Equals(YinYang.Yin));
        Assert.True(shui[5].YinYang.Equals(YinYang.Yang));
        Assert.True(shui[4].YinYang.Equals(YinYang.Yin));
        Assert.True(shui[3].YinYang.Equals(YinYang.Yin));
        Assert.True(shui[2].YinYang.Equals(YinYang.Yang));
        Assert.True(shui[1].YinYang.Equals(YinYang.Yin));

        var yangCount = shui.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = shui.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(shui.ToString());
    }

    [Fact]
    public void TheClinging_IsCorrect()
    {
        var huo = Hexagram.TheClinging;

        Assert.True(huo[6].YinYang.Equals(YinYang.Yang));
        Assert.True(huo[5].YinYang.Equals(YinYang.Yin));
        Assert.True(huo[4].YinYang.Equals(YinYang.Yang));
        Assert.True(huo[3].YinYang.Equals(YinYang.Yang));
        Assert.True(huo[2].YinYang.Equals(YinYang.Yin));
        Assert.True(huo[1].YinYang.Equals(YinYang.Yang));

        var yangCount = huo.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = huo.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(huo.ToString());
    }

    [Fact]
    public void Influence_IsCorrect()
    {
        var xian = Hexagram.Influence;

        Assert.True(xian[6].YinYang.Equals(YinYang.Yin));
        Assert.True(xian[5].YinYang.Equals(YinYang.Yang));
        Assert.True(xian[4].YinYang.Equals(YinYang.Yang));
        Assert.True(xian[3].YinYang.Equals(YinYang.Yang));
        Assert.True(xian[2].YinYang.Equals(YinYang.Yin));
        Assert.True(xian[1].YinYang.Equals(YinYang.Yin));

        var yangCount = xian.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = xian.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(xian.ToString());
    }

    [Fact]
    public void Duration_IsCorrect()
    {
        var heng = Hexagram.Duration;

        Assert.True(heng[6].YinYang.Equals(YinYang.Yin));
        Assert.True(heng[5].YinYang.Equals(YinYang.Yin));
        Assert.True(heng[4].YinYang.Equals(YinYang.Yang));
        Assert.True(heng[3].YinYang.Equals(YinYang.Yang));
        Assert.True(heng[2].YinYang.Equals(YinYang.Yang));
        Assert.True(heng[1].YinYang.Equals(YinYang.Yin));

        var yangCount = heng.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = heng.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(heng.ToString());
    }

    [Fact]
    public void Retreat_IsCorrect()
    {
        var dun = Hexagram.Retreat;

        Assert.True(dun[6].YinYang.Equals(YinYang.Yang));
        Assert.True(dun[5].YinYang.Equals(YinYang.Yang));
        Assert.True(dun[4].YinYang.Equals(YinYang.Yang));
        Assert.True(dun[3].YinYang.Equals(YinYang.Yang));
        Assert.True(dun[2].YinYang.Equals(YinYang.Yin));
        Assert.True(dun[1].YinYang.Equals(YinYang.Yin));

        var yangCount = dun.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = dun.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(dun.ToString());
    }

    [Fact]
    public void ThePowerOfTheGreat_IsCorrect()
    {
        var daZhuang = Hexagram.ThePowerOfTheGreat;

        Assert.True(daZhuang[6].YinYang.Equals(YinYang.Yin));
        Assert.True(daZhuang[5].YinYang.Equals(YinYang.Yin));
        Assert.True(daZhuang[4].YinYang.Equals(YinYang.Yang));
        Assert.True(daZhuang[3].YinYang.Equals(YinYang.Yang));
        Assert.True(daZhuang[2].YinYang.Equals(YinYang.Yang));
        Assert.True(daZhuang[1].YinYang.Equals(YinYang.Yang));

        var yangCount = daZhuang.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = daZhuang.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(daZhuang.ToString());
    }

    [Fact]
    public void Progress_IsCorrect()
    {
        var jin = Hexagram.Progress;

        Assert.True(jin[6].YinYang.Equals(YinYang.Yang));
        Assert.True(jin[5].YinYang.Equals(YinYang.Yin));
        Assert.True(jin[4].YinYang.Equals(YinYang.Yang));
        Assert.True(jin[3].YinYang.Equals(YinYang.Yin));
        Assert.True(jin[2].YinYang.Equals(YinYang.Yin));
        Assert.True(jin[1].YinYang.Equals(YinYang.Yin));

        var yangCount = jin.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = jin.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(jin.ToString());
    }

    [Fact]
    public void DarkeningOfTheLight_IsCorrect()
    {
        var mingYi = Hexagram.DarkeningOfTheLight;

        Assert.True(mingYi[6].YinYang.Equals(YinYang.Yin));
        Assert.True(mingYi[5].YinYang.Equals(YinYang.Yin));
        Assert.True(mingYi[4].YinYang.Equals(YinYang.Yin));
        Assert.True(mingYi[3].YinYang.Equals(YinYang.Yang));
        Assert.True(mingYi[2].YinYang.Equals(YinYang.Yin));
        Assert.True(mingYi[1].YinYang.Equals(YinYang.Yang));

        var yangCount = mingYi.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = mingYi.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(mingYi.ToString());
    }

    [Fact]
    public void TheFamily_IsCorrect()
    {
        var jiaRen = Hexagram.TheFamily;

        Assert.True(jiaRen[6].YinYang.Equals(YinYang.Yang));
        Assert.True(jiaRen[5].YinYang.Equals(YinYang.Yang));
        Assert.True(jiaRen[4].YinYang.Equals(YinYang.Yin));
        Assert.True(jiaRen[3].YinYang.Equals(YinYang.Yang));
        Assert.True(jiaRen[2].YinYang.Equals(YinYang.Yin));
        Assert.True(jiaRen[1].YinYang.Equals(YinYang.Yang));

        var yangCount = jiaRen.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = jiaRen.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(jiaRen.ToString());
    }

    [Fact]
    public void Opposition_IsCorrect()
    {
        var kui = Hexagram.Opposition;

        Assert.True(kui[6].YinYang.Equals(YinYang.Yang));
        Assert.True(kui[5].YinYang.Equals(YinYang.Yin));
        Assert.True(kui[4].YinYang.Equals(YinYang.Yang));
        Assert.True(kui[3].YinYang.Equals(YinYang.Yin));
        Assert.True(kui[2].YinYang.Equals(YinYang.Yang));
        Assert.True(kui[1].YinYang.Equals(YinYang.Yang));

        var yangCount = kui.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = kui.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(kui.ToString());
    }

    [Fact]
    public void Obstruction_IsCorrect()
    {
        var jian = Hexagram.Obstruction;

        Assert.True(jian[6].YinYang.Equals(YinYang.Yin));
        Assert.True(jian[5].YinYang.Equals(YinYang.Yang));
        Assert.True(jian[4].YinYang.Equals(YinYang.Yin));
        Assert.True(jian[3].YinYang.Equals(YinYang.Yang));
        Assert.True(jian[2].YinYang.Equals(YinYang.Yin));
        Assert.True(jian[1].YinYang.Equals(YinYang.Yin));

        var yangCount = jian.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = jian.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(jian.ToString());
    }

    [Fact]
    public void Deliverance_IsCorrect()
    {
        var xie = Hexagram.Deliverance;

        Assert.True(xie[6].YinYang.Equals(YinYang.Yin));
        Assert.True(xie[5].YinYang.Equals(YinYang.Yin));
        Assert.True(xie[4].YinYang.Equals(YinYang.Yang));
        Assert.True(xie[3].YinYang.Equals(YinYang.Yin));
        Assert.True(xie[2].YinYang.Equals(YinYang.Yang));
        Assert.True(xie[1].YinYang.Equals(YinYang.Yin));

        var yangCount = xie.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = xie.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(xie.ToString());
    }

    [Fact]
    public void Decrease_IsCorrect()
    {
        var sun = Hexagram.Decrease;

        Assert.True(sun[6].YinYang.Equals(YinYang.Yang));
        Assert.True(sun[5].YinYang.Equals(YinYang.Yin));
        Assert.True(sun[4].YinYang.Equals(YinYang.Yin));
        Assert.True(sun[3].YinYang.Equals(YinYang.Yin));
        Assert.True(sun[2].YinYang.Equals(YinYang.Yang));
        Assert.True(sun[1].YinYang.Equals(YinYang.Yang));

        var yangCount = sun.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = sun.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(sun.ToString());
    }

    [Fact]
    public void Increase_IsCorrect()
    {
        var yi = Hexagram.Increase;

        Assert.True(yi[6].YinYang.Equals(YinYang.Yang));
        Assert.True(yi[5].YinYang.Equals(YinYang.Yang));
        Assert.True(yi[4].YinYang.Equals(YinYang.Yin));
        Assert.True(yi[3].YinYang.Equals(YinYang.Yin));
        Assert.True(yi[2].YinYang.Equals(YinYang.Yin));
        Assert.True(yi[1].YinYang.Equals(YinYang.Yang));

        var yangCount = yi.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = yi.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(yi.ToString());
    }

    [Fact]
    public void BreakThrough_IsCorrect()
    {
        var guai = Hexagram.BreakThrough;

        Assert.True(guai[6].YinYang.Equals(YinYang.Yin));
        Assert.True(guai[5].YinYang.Equals(YinYang.Yang));
        Assert.True(guai[4].YinYang.Equals(YinYang.Yang));
        Assert.True(guai[3].YinYang.Equals(YinYang.Yang));
        Assert.True(guai[2].YinYang.Equals(YinYang.Yang));
        Assert.True(guai[1].YinYang.Equals(YinYang.Yang));

        var yangCount = guai.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(5, yangCount);
        var yinCount = guai.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(1, yinCount);

        testOutputHelper.WriteLine(guai.ToString());
    }

    [Fact]
    public void ComingToMeet_IsCorrect()
    {
        var gou = Hexagram.ComingToMeet;

        Assert.True(gou[6].YinYang.Equals(YinYang.Yang));
        Assert.True(gou[5].YinYang.Equals(YinYang.Yang));
        Assert.True(gou[4].YinYang.Equals(YinYang.Yang));
        Assert.True(gou[3].YinYang.Equals(YinYang.Yang));
        Assert.True(gou[2].YinYang.Equals(YinYang.Yang));
        Assert.True(gou[1].YinYang.Equals(YinYang.Yin));

        var yangCount = gou.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(5, yangCount);
        var yinCount = gou.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(1, yinCount);

        testOutputHelper.WriteLine(gou.ToString());
    }

    [Fact]
    public void GatheringTogether_IsCorrect()
    {
        var cui = Hexagram.GatheringTogether;

        Assert.True(cui[6].YinYang.Equals(YinYang.Yin));
        Assert.True(cui[5].YinYang.Equals(YinYang.Yang));
        Assert.True(cui[4].YinYang.Equals(YinYang.Yang));
        Assert.True(cui[3].YinYang.Equals(YinYang.Yin));
        Assert.True(cui[2].YinYang.Equals(YinYang.Yin));
        Assert.True(cui[1].YinYang.Equals(YinYang.Yin));

        var yangCount = cui.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = cui.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(cui.ToString());
    }

    [Fact]
    public void PushingUpward_IsCorrect()
    {
        var sheng = Hexagram.PushingUpward;

        Assert.True(sheng[6].YinYang.Equals(YinYang.Yin));
        Assert.True(sheng[5].YinYang.Equals(YinYang.Yin));
        Assert.True(sheng[4].YinYang.Equals(YinYang.Yin));
        Assert.True(sheng[3].YinYang.Equals(YinYang.Yang));
        Assert.True(sheng[2].YinYang.Equals(YinYang.Yang));
        Assert.True(sheng[1].YinYang.Equals(YinYang.Yin));

        var yangCount = sheng.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = sheng.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(sheng.ToString());
    }

    [Fact]
    public void Oppression_IsCorrect()
    {
        var kun = Hexagram.Oppression;

        Assert.True(kun[6].YinYang.Equals(YinYang.Yin));
        Assert.True(kun[5].YinYang.Equals(YinYang.Yang));
        Assert.True(kun[4].YinYang.Equals(YinYang.Yang));
        Assert.True(kun[3].YinYang.Equals(YinYang.Yin));
        Assert.True(kun[2].YinYang.Equals(YinYang.Yang));
        Assert.True(kun[1].YinYang.Equals(YinYang.Yin));

        var yangCount = kun.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = kun.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(kun.ToString());
    }

    [Fact]
    public void TheWell_IsCorrect()
    {
        var jing = Hexagram.TheWell;

        Assert.True(jing[6].YinYang.Equals(YinYang.Yin));
        Assert.True(jing[5].YinYang.Equals(YinYang.Yang));
        Assert.True(jing[4].YinYang.Equals(YinYang.Yin));
        Assert.True(jing[3].YinYang.Equals(YinYang.Yang));
        Assert.True(jing[2].YinYang.Equals(YinYang.Yang));
        Assert.True(jing[1].YinYang.Equals(YinYang.Yin));

        var yangCount = jing.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = jing.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(jing.ToString());
    }

    [Fact]
    public void Revolution_IsCorrect()
    {
        var ge = Hexagram.Revolution;

        Assert.True(ge[6].YinYang.Equals(YinYang.Yin));
        Assert.True(ge[5].YinYang.Equals(YinYang.Yang));
        Assert.True(ge[4].YinYang.Equals(YinYang.Yang));
        Assert.True(ge[3].YinYang.Equals(YinYang.Yang));
        Assert.True(ge[2].YinYang.Equals(YinYang.Yin));
        Assert.True(ge[1].YinYang.Equals(YinYang.Yang));

        var yangCount = ge.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = ge.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(ge.ToString());
    }

    [Fact]
    public void TheCauldron_IsCorrect()
    {
        var ding = Hexagram.TheCauldron;

        Assert.True(ding[6].YinYang.Equals(YinYang.Yang));
        Assert.True(ding[5].YinYang.Equals(YinYang.Yin));
        Assert.True(ding[4].YinYang.Equals(YinYang.Yang));
        Assert.True(ding[3].YinYang.Equals(YinYang.Yang));
        Assert.True(ding[2].YinYang.Equals(YinYang.Yang));
        Assert.True(ding[1].YinYang.Equals(YinYang.Yin));

        var yangCount = ding.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = ding.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(ding.ToString());
    }

    [Fact]
    public void TheArousing_IsCorrect()
    {
        var lei = Hexagram.TheArousing;

        Assert.True(lei[6].YinYang.Equals(YinYang.Yin));
        Assert.True(lei[5].YinYang.Equals(YinYang.Yin));
        Assert.True(lei[4].YinYang.Equals(YinYang.Yang));
        Assert.True(lei[3].YinYang.Equals(YinYang.Yin));
        Assert.True(lei[2].YinYang.Equals(YinYang.Yin));
        Assert.True(lei[1].YinYang.Equals(YinYang.Yang));

        var yangCount = lei.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = lei.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(lei.ToString());
    }

    [Fact]
    public void KeepingStill_IsCorrect()
    {
        var shan = Hexagram.KeepingStill;

        Assert.True(shan[6].YinYang.Equals(YinYang.Yang));
        Assert.True(shan[5].YinYang.Equals(YinYang.Yin));
        Assert.True(shan[4].YinYang.Equals(YinYang.Yin));
        Assert.True(shan[3].YinYang.Equals(YinYang.Yang));
        Assert.True(shan[2].YinYang.Equals(YinYang.Yin));
        Assert.True(shan[1].YinYang.Equals(YinYang.Yin));

        var yangCount = shan.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = shan.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(shan.ToString());
    }

    [Fact]
    public void Development_IsCorrect()
    {
        var jian = Hexagram.Development;

        Assert.True(jian[6].YinYang.Equals(YinYang.Yang));
        Assert.True(jian[5].YinYang.Equals(YinYang.Yang));
        Assert.True(jian[4].YinYang.Equals(YinYang.Yin));
        Assert.True(jian[3].YinYang.Equals(YinYang.Yang));
        Assert.True(jian[2].YinYang.Equals(YinYang.Yin));
        Assert.True(jian[1].YinYang.Equals(YinYang.Yin));

        var yangCount = jian.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = jian.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(jian.ToString());
    }

    [Fact]
    public void TheMarryingMaiden_IsCorrect()
    {
        var guiMei = Hexagram.TheMarryingMaiden;

        Assert.True(guiMei[6].YinYang.Equals(YinYang.Yin));
        Assert.True(guiMei[5].YinYang.Equals(YinYang.Yin));
        Assert.True(guiMei[4].YinYang.Equals(YinYang.Yang));
        Assert.True(guiMei[3].YinYang.Equals(YinYang.Yin));
        Assert.True(guiMei[2].YinYang.Equals(YinYang.Yang));
        Assert.True(guiMei[1].YinYang.Equals(YinYang.Yang));

        var yangCount = guiMei.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = guiMei.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(guiMei.ToString());
    }

    [Fact]
    public void Abundance_IsCorrect()
    {
        var feng = Hexagram.Abundance;

        Assert.True(feng[6].YinYang.Equals(YinYang.Yin));
        Assert.True(feng[5].YinYang.Equals(YinYang.Yin));
        Assert.True(feng[4].YinYang.Equals(YinYang.Yang));
        Assert.True(feng[3].YinYang.Equals(YinYang.Yang));
        Assert.True(feng[2].YinYang.Equals(YinYang.Yin));
        Assert.True(feng[1].YinYang.Equals(YinYang.Yang));

        var yangCount = feng.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = feng.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(feng.ToString());
    }

    [Fact]
    public void TheWanderer_IsCorrect()
    {
        var lv = Hexagram.TheWanderer;

        Assert.True(lv[6].YinYang.Equals(YinYang.Yang));
        Assert.True(lv[5].YinYang.Equals(YinYang.Yin));
        Assert.True(lv[4].YinYang.Equals(YinYang.Yang));
        Assert.True(lv[3].YinYang.Equals(YinYang.Yang));
        Assert.True(lv[2].YinYang.Equals(YinYang.Yin));
        Assert.True(lv[1].YinYang.Equals(YinYang.Yin));

        var yangCount = lv.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = lv.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(lv.ToString());
    }

    [Fact]
    public void TheGentle_IsCorrect()
    {
        var feng = Hexagram.TheGentle;

        Assert.True(feng[6].YinYang.Equals(YinYang.Yang));
        Assert.True(feng[5].YinYang.Equals(YinYang.Yang));
        Assert.True(feng[4].YinYang.Equals(YinYang.Yin));
        Assert.True(feng[3].YinYang.Equals(YinYang.Yang));
        Assert.True(feng[2].YinYang.Equals(YinYang.Yang));
        Assert.True(feng[1].YinYang.Equals(YinYang.Yin));

        var yangCount = feng.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = feng.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(feng.ToString());
    }

    [Fact]
    public void TheJoyous_IsCorrect()
    {
        var ze = Hexagram.TheJoyous;

        Assert.True(ze[6].YinYang.Equals(YinYang.Yin));
        Assert.True(ze[5].YinYang.Equals(YinYang.Yang));
        Assert.True(ze[4].YinYang.Equals(YinYang.Yang));
        Assert.True(ze[3].YinYang.Equals(YinYang.Yin));
        Assert.True(ze[2].YinYang.Equals(YinYang.Yang));
        Assert.True(ze[1].YinYang.Equals(YinYang.Yang));

        var yangCount = ze.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = ze.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(ze.ToString());
    }

    [Fact]
    public void Dispersion_IsCorrect()
    {
        var huan = Hexagram.Dispersion;

        Assert.True(huan[6].YinYang.Equals(YinYang.Yang));
        Assert.True(huan[5].YinYang.Equals(YinYang.Yang));
        Assert.True(huan[4].YinYang.Equals(YinYang.Yin));
        Assert.True(huan[3].YinYang.Equals(YinYang.Yin));
        Assert.True(huan[2].YinYang.Equals(YinYang.Yang));
        Assert.True(huan[1].YinYang.Equals(YinYang.Yin));

        var yangCount = huan.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = huan.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(huan.ToString());
    }

    [Fact]
    public void Limitation_IsCorrect()
    {
        var jie = Hexagram.Limitation;

        Assert.True(jie[6].YinYang.Equals(YinYang.Yin));
        Assert.True(jie[5].YinYang.Equals(YinYang.Yang));
        Assert.True(jie[4].YinYang.Equals(YinYang.Yin));
        Assert.True(jie[3].YinYang.Equals(YinYang.Yin));
        Assert.True(jie[2].YinYang.Equals(YinYang.Yang));
        Assert.True(jie[1].YinYang.Equals(YinYang.Yang));

        var yangCount = jie.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = jie.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(jie.ToString());
    }

    [Fact]
    public void InnerTruth_IsCorrect()
    {
        var zhongFu = Hexagram.InnerTruth;

        Assert.True(zhongFu[6].YinYang.Equals(YinYang.Yang));
        Assert.True(zhongFu[5].YinYang.Equals(YinYang.Yang));
        Assert.True(zhongFu[4].YinYang.Equals(YinYang.Yin));
        Assert.True(zhongFu[3].YinYang.Equals(YinYang.Yin));
        Assert.True(zhongFu[2].YinYang.Equals(YinYang.Yang));
        Assert.True(zhongFu[1].YinYang.Equals(YinYang.Yang));

        var yangCount = zhongFu.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(4, yangCount);
        var yinCount = zhongFu.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);

        testOutputHelper.WriteLine(zhongFu.ToString());
    }

    [Fact]
    public void PreponderanceOfTheSmall_IsCorrect()
    {
        var xiaoGuo = Hexagram.PreponderanceOfTheSmall;

        Assert.True(xiaoGuo[6].YinYang.Equals(YinYang.Yin));
        Assert.True(xiaoGuo[5].YinYang.Equals(YinYang.Yin));
        Assert.True(xiaoGuo[4].YinYang.Equals(YinYang.Yang));
        Assert.True(xiaoGuo[3].YinYang.Equals(YinYang.Yang));
        Assert.True(xiaoGuo[2].YinYang.Equals(YinYang.Yin));
        Assert.True(xiaoGuo[1].YinYang.Equals(YinYang.Yin));

        var yangCount = xiaoGuo.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        var yinCount = xiaoGuo.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(4, yinCount);

        testOutputHelper.WriteLine(xiaoGuo.ToString());
    }

    [Fact]
    public void AfterCompletion_IsCorrect()
    {
        var jiji = Hexagram.AfterCompletion;

        Assert.True(jiji[6].YinYang.Equals(YinYang.Yin));
        Assert.True(jiji[5].YinYang.Equals(YinYang.Yang));
        Assert.True(jiji[4].YinYang.Equals(YinYang.Yin));
        Assert.True(jiji[3].YinYang.Equals(YinYang.Yang));
        Assert.True(jiji[2].YinYang.Equals(YinYang.Yin));
        Assert.True(jiji[1].YinYang.Equals(YinYang.Yang));

        var yangCount = jiji.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = jiji.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(jiji.ToString());
    }

    [Fact]
    public void BeforeCompletion_IsCorrect()
    {
        var weiJi = Hexagram.BeforeCompletion;

        Assert.True(weiJi[6].YinYang.Equals(YinYang.Yang));
        Assert.True(weiJi[5].YinYang.Equals(YinYang.Yin));
        Assert.True(weiJi[4].YinYang.Equals(YinYang.Yang));
        Assert.True(weiJi[3].YinYang.Equals(YinYang.Yin));
        Assert.True(weiJi[2].YinYang.Equals(YinYang.Yang));
        Assert.True(weiJi[1].YinYang.Equals(YinYang.Yin));

        var yangCount = weiJi.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        var yinCount = weiJi.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);

        testOutputHelper.WriteLine(weiJi.ToString());
    }

    [Fact]
    public void GetAll_Test()
    {
        Assert.Equal(64, Hexagram.All.Count());
    }
}