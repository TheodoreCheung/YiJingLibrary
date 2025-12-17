using YiJingLibrary.Core;

namespace YiJingLibrary.Test;

public class StemBranchTest
{
    [Fact]
    public void StemBranchConstructor_SetsPropertiesCorrectly()
    {
        var stemBranch = new StemBranch(HeavenlyStem.Jia, EarthlyBranch.Zi);
        
        Assert.Equal(HeavenlyStem.Jia, stemBranch.HeavenlyStem);
        Assert.Equal(EarthlyBranch.Zi, stemBranch.EarthlyBranch);
    }

    [Fact]
    public void HeavenlyStemProperties_AreCorrect()
    {
        var jia = HeavenlyStem.Jia;
        Assert.Equal(YinYang.Yang, jia.YinYang);
        Assert.Equal(FivePhase.Wood, jia.FivePhase);
        Assert.Equal(1, jia);

        var yi = HeavenlyStem.Yi;
        Assert.Equal(YinYang.Yin, yi.YinYang);
        Assert.Equal(FivePhase.Wood, yi.FivePhase);
        Assert.Equal(2, yi);
    }

    [Fact]
    public void EarthlyBranchProperties_AreCorrect()
    {
        var zi = EarthlyBranch.Zi;
        Assert.Equal(YinYang.Yang, zi.YinYang);
        Assert.Equal(FivePhase.Water, zi.FivePhase);
        Assert.Equal(1, zi);

        var chou = EarthlyBranch.Chou;
        Assert.Equal(YinYang.Yin, chou.YinYang);
        Assert.Equal(FivePhase.Earth, chou.FivePhase);
        Assert.Equal(2, chou);
    }

    [Fact]
    public void HeavenlyStemFromValue_ReturnsCorrectStem()
    {
        Assert.Equal(HeavenlyStem.Jia, HeavenlyStem.FromValue(1));
        Assert.Equal(HeavenlyStem.Yi, HeavenlyStem.FromValue(2));
        Assert.Equal(HeavenlyStem.Bing, HeavenlyStem.FromValue(3));
        Assert.Equal(HeavenlyStem.Ding, HeavenlyStem.FromValue(4));
        Assert.Equal(HeavenlyStem.Wu, HeavenlyStem.FromValue(5));
        Assert.Equal(HeavenlyStem.Ji, HeavenlyStem.FromValue(6));
        Assert.Equal(HeavenlyStem.Geng, HeavenlyStem.FromValue(7));
        Assert.Equal(HeavenlyStem.Xin, HeavenlyStem.FromValue(8));
        Assert.Equal(HeavenlyStem.Ren, HeavenlyStem.FromValue(9));
        Assert.Equal(HeavenlyStem.Gui, HeavenlyStem.FromValue(10));
    }

    [Fact]
    public void HeavenlyStemFromValue_InvalidValue_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => HeavenlyStem.FromValue(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => HeavenlyStem.FromValue(11));
    }

    [Fact]
    public void EarthlyBranchFromValue_ReturnsCorrectBranch()
    {
        Assert.Equal(EarthlyBranch.Zi, EarthlyBranch.FromValue(1));
        Assert.Equal(EarthlyBranch.Chou, EarthlyBranch.FromValue(2));
        Assert.Equal(EarthlyBranch.Yin, EarthlyBranch.FromValue(3));
        Assert.Equal(EarthlyBranch.Mao, EarthlyBranch.FromValue(4));
        Assert.Equal(EarthlyBranch.Chen, EarthlyBranch.FromValue(5));
        Assert.Equal(EarthlyBranch.Si, EarthlyBranch.FromValue(6));
        Assert.Equal(EarthlyBranch.Wu, EarthlyBranch.FromValue(7));
        Assert.Equal(EarthlyBranch.Wei, EarthlyBranch.FromValue(8));
        Assert.Equal(EarthlyBranch.Shen, EarthlyBranch.FromValue(9));
        Assert.Equal(EarthlyBranch.You, EarthlyBranch.FromValue(10));
        Assert.Equal(EarthlyBranch.Xu, EarthlyBranch.FromValue(11));
        Assert.Equal(EarthlyBranch.Hai, EarthlyBranch.FromValue(12));
    }

    [Fact]
    public void EarthlyBranchFromValue_InvalidValue_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => EarthlyBranch.FromValue(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => EarthlyBranch.FromValue(13));
    }

    [Fact]
    public void HeavenlyStemGenerates_RelationshipsAreCorrect()
    {
        // Wood generates Fire
        Assert.True(HeavenlyStem.Jia.Generates(HeavenlyStem.Bing));
        Assert.True(HeavenlyStem.Yi.Generates(HeavenlyStem.Bing));
        Assert.True(HeavenlyStem.Jia.Generates(HeavenlyStem.Ding));
        Assert.True(HeavenlyStem.Yi.Generates(HeavenlyStem.Ding));
        
        // Fire generates Earth
        Assert.True(HeavenlyStem.Bing.Generates(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Ding.Generates(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Bing.Generates(HeavenlyStem.Ji));
        Assert.True(HeavenlyStem.Ding.Generates(HeavenlyStem.Ji));
    }

    [Fact]
    public void HeavenlyStemRestrains_RelationshipsAreCorrect()
    {
        // Wood restrains Earth
        Assert.True(HeavenlyStem.Jia.Restrains(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Yi.Restrains(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Jia.Restrains(HeavenlyStem.Ji));
        Assert.True(HeavenlyStem.Yi.Restrains(HeavenlyStem.Ji));
    }

    [Fact]
    public void EarthlyBranchGenerates_RelationshipsAreCorrect()
    {
        // Wood generates Fire
        Assert.True(EarthlyBranch.Yin.Generates(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.Mao.Generates(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.Yin.Generates(EarthlyBranch.Wu));
        Assert.True(EarthlyBranch.Mao.Generates(EarthlyBranch.Wu));
    }

    [Fact]
    public void EarthlyBranchRestrains_RelationshipsAreCorrect()
    {
        // Wood restrains Earth
        Assert.True(EarthlyBranch.Yin.Restrains(EarthlyBranch.Chen));
        Assert.True(EarthlyBranch.Mao.Restrains(EarthlyBranch.Chen));
        Assert.True(EarthlyBranch.Yin.Restrains(EarthlyBranch.Chou));
        Assert.True(EarthlyBranch.Mao.Restrains(EarthlyBranch.Chou));
        Assert.True(EarthlyBranch.Yin.Restrains(EarthlyBranch.Xu));
        Assert.True(EarthlyBranch.Mao.Restrains(EarthlyBranch.Xu));
        Assert.True(EarthlyBranch.Yin.Restrains(EarthlyBranch.Wei));
        Assert.True(EarthlyBranch.Mao.Restrains(EarthlyBranch.Wei));
    }

    [Fact]
    public void HeavenlyStemEquality_WorksCorrectly()
    {
        var a = HeavenlyStem.Jia;
        var b = HeavenlyStem.Jia;
        Assert.True(a.Equals(b));
        Assert.True(a == b);
        
        var c = HeavenlyStem.Yi;
        Assert.False(a.Equals(c));
        Assert.False(a == c);
        Assert.True(a != c);
    }

    [Fact]
    public void EarthlyBranchEquality_WorksCorrectly()
    {
        var a = EarthlyBranch.Zi;
        var b = EarthlyBranch.Zi;
        Assert.True(a.Equals(b));
        Assert.True(a == b);
        
        var c = EarthlyBranch.Chou;
        Assert.False(a.Equals(c));
        Assert.False(a == c);
        Assert.True(a != c);
    }
}