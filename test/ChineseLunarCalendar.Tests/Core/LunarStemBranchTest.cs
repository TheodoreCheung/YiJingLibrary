using YiJingLibrary.ChineseLunarCalendar;
using YiJingLibrary.Core;

namespace ChineseLunarCalendar.Tests.Core;

public class LunarStemBranchTest
{
    [Fact]
    public void LunarStemBranchConstructor_SetsPropertiesCorrectly()
    {
        var year = new StemBranch(HeavenlyStem.Jia, EarthlyBranch.Zi);
        var month = new StemBranch(HeavenlyStem.Yi, EarthlyBranch.Chou);
        var day = new StemBranch(HeavenlyStem.Bing, EarthlyBranch.Yin);
        var hour = new StemBranch(HeavenlyStem.Ding, EarthlyBranch.Mao);

        var lunarStemBranch = new LunarStemBranch(year, month, day, hour);

        Assert.Equal(year, lunarStemBranch.Year);
        Assert.Equal(month, lunarStemBranch.Month);
        Assert.Equal(day, lunarStemBranch.Day);
        Assert.Equal(hour, lunarStemBranch.Hour);
    }

    [Fact]
    public void LunarStemBranchToString_ReturnsCorrectFormat()
    {
        var year = new StemBranch(HeavenlyStem.Jia, EarthlyBranch.Zi);
        var month = new StemBranch(HeavenlyStem.Yi, EarthlyBranch.Chou);
        var day = new StemBranch(HeavenlyStem.Bing, EarthlyBranch.Yin);
        var hour = new StemBranch(HeavenlyStem.Ding, EarthlyBranch.Mao);

        var lunarStemBranch = new LunarStemBranch(year, month, day, hour);
        var expected = "JiaZi年YiChou月BingYin日DingMao时";

        Assert.Equal(expected, lunarStemBranch.ToString());
    }
}