using Xunit.Abstractions;
using YiJingLibrary.Core;
using YiJingLibrary.SixLines;
using YiJingLibrary.SixLines.Extensions;

namespace SixLines.Test;

public class SpecifyDivinationTest(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void FellowshipWithMen_TheCreative_Test()
    {
        var sixLinesDivination = YiJingLibrary.SixLines.SixLines
            .CreateSpecifyDivinationBuilder(
                new DateTime(2025, 11, 19, 14, 30, 0),
                Hexagram.FellowshipWithMen,
                Hexagram.TheCreative)
            .Configure(options => options.SetCulture("zh-CN"))
            .Build();

        Assert.Equal(new StemBranch(HeavenlyStem.Yi, EarthlyBranch.Si), sixLinesDivination.InquiryTime.Lunar.Year);
        Assert.Equal(new StemBranch(HeavenlyStem.Ding, EarthlyBranch.Hai), sixLinesDivination.InquiryTime.Lunar.Month);
        Assert.Equal(new StemBranch(HeavenlyStem.Ren, EarthlyBranch.Chen), sixLinesDivination.InquiryTime.Lunar.Day);
        Assert.Equal(new StemBranch(HeavenlyStem.Ding, EarthlyBranch.Wei), sixLinesDivination.InquiryTime.Lunar.Hour);
        Assert.Contains(EarthlyBranch.Wu, sixLinesDivination.InquiryTime.Lunar.Day.EmptyBranches);
        Assert.Contains(EarthlyBranch.Wei, sixLinesDivination.InquiryTime.Lunar.Day.EmptyBranches);
        
        Assert.Equal(HexagramFeature.ReturningSoul, sixLinesDivination.Original.Feature);

        var originalFirstYaoStemBranch = sixLinesDivination.Original[1].StemBranch;
        Assert.NotNull(originalFirstYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Ji, EarthlyBranch.Mao), originalFirstYaoStemBranch);
        
        var originalSecondYaoStemBranch = sixLinesDivination.Original[2].StemBranch;
        Assert.NotNull(originalSecondYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Ji, EarthlyBranch.Chou), originalSecondYaoStemBranch);
        
        var originalThirdYaoStemBranch = sixLinesDivination.Original[3].StemBranch;
        Assert.NotNull(originalThirdYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Ji, EarthlyBranch.Hai), originalThirdYaoStemBranch);
        
        var worldly = sixLinesDivination.Original[3].Position;
        Assert.NotNull(worldly);
        Assert.Equal(Position.Worldly, worldly);
        
        var originalFourthYaoStemBranch = sixLinesDivination.Original[4].StemBranch;
        Assert.NotNull(originalFourthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Ren, EarthlyBranch.Wu), originalFourthYaoStemBranch);
        
        var originalFifthYaoStemBranch = sixLinesDivination.Original[5].StemBranch;
        Assert.NotNull(originalFifthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Ren, EarthlyBranch.Shen), originalFifthYaoStemBranch);
        
        var originalSixthYaoStemBranch = sixLinesDivination.Original[6].StemBranch;
        Assert.NotNull(originalSixthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Ren, EarthlyBranch.Xu), originalSixthYaoStemBranch);

        var corresponding = sixLinesDivination.Original[6].Position;
        Assert.NotNull(corresponding);
        Assert.Equal(Position.Corresponding, corresponding);

        var originalFirstYaoSixKin = sixLinesDivination.Original[1].SixKin;
        Assert.NotNull(originalFirstYaoSixKin);
        Assert.Equal(SixKin.Parent, originalFirstYaoSixKin);
        
        var originalSecondYaoSixKin = sixLinesDivination.Original[2].SixKin;
        Assert.NotNull(originalSecondYaoSixKin);
        Assert.Equal(SixKin.Offspring, originalSecondYaoSixKin);
        
        var originalThirdYaoSixKin = sixLinesDivination.Original[3].SixKin;
        Assert.NotNull(originalThirdYaoSixKin);
        Assert.Equal(SixKin.Officer, originalThirdYaoSixKin);
        
        var originalFourthYaoSixKin = sixLinesDivination.Original[4].SixKin;
        Assert.NotNull(originalFourthYaoSixKin);
        Assert.Equal(SixKin.Sibling, originalFourthYaoSixKin);
        
        var originalFifthYaoSixKin = sixLinesDivination.Original[5].SixKin;
        Assert.NotNull(originalFifthYaoSixKin);
        Assert.Equal(SixKin.Wealth, originalFifthYaoSixKin);
        
        var originalSixthYaoSixKin = sixLinesDivination.Original[6].SixKin;
        Assert.NotNull(originalSixthYaoSixKin);
        Assert.Equal(SixKin.Offspring, originalSixthYaoSixKin);
        
        var originalFirstFourSymbol = sixLinesDivination.Original[1].FourSymbol;
        Assert.NotNull(originalFirstFourSymbol);
        Assert.Equal(FourSymbol.YoungYang, originalFirstFourSymbol);
        
        var originalSecondFourSymbol = sixLinesDivination.Original[2].FourSymbol;
        Assert.NotNull(originalSecondFourSymbol);
        Assert.Equal(FourSymbol.OldYin, originalSecondFourSymbol);
        
        var originalThirdFourSymbol = sixLinesDivination.Original[3].FourSymbol;
        Assert.NotNull(originalThirdFourSymbol);
        Assert.Equal(FourSymbol.YoungYang, originalThirdFourSymbol);
        
        var originalFourthFourSymbol = sixLinesDivination.Original[4].FourSymbol;
        Assert.NotNull(originalFourthFourSymbol);
        Assert.Equal(FourSymbol.YoungYang, originalFourthFourSymbol);
        
        var originalFifthFourSymbol = sixLinesDivination.Original[5].FourSymbol;
        Assert.NotNull(originalFifthFourSymbol);
        Assert.Equal(FourSymbol.YoungYang, originalFifthFourSymbol);
        
        var originalSixthFourSymbol = sixLinesDivination.Original[6].FourSymbol;
        Assert.NotNull(originalSixthFourSymbol);
        Assert.Equal(FourSymbol.YoungYang, originalSixthFourSymbol);
        
        Assert.NotNull(sixLinesDivination.Changed);
        
        Assert.Equal(HexagramFeature.Clashing, sixLinesDivination.Changed.Feature);
        
        var changedFirstYaoStemBranch = sixLinesDivination.Changed[1].StemBranch;
        Assert.NotNull(changedFirstYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Jia, EarthlyBranch.Zi), changedFirstYaoStemBranch);

        var changedSecondYaoStemBranch = sixLinesDivination.Changed[2].StemBranch;
        Assert.NotNull(changedSecondYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Jia, EarthlyBranch.Yin), changedSecondYaoStemBranch);

        var changedThirdYaoStemBranch = sixLinesDivination.Changed[3].StemBranch;
        Assert.NotNull(changedThirdYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Jia, EarthlyBranch.Chen), changedThirdYaoStemBranch);

        var changedFourthYaoStemBranch = sixLinesDivination.Changed[4].StemBranch;
        Assert.NotNull(changedFourthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Ren, EarthlyBranch.Wu), changedFourthYaoStemBranch);

        var changedFifthYaoStemBranch = sixLinesDivination.Changed[5].StemBranch;
        Assert.NotNull(changedFifthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Ren, EarthlyBranch.Shen), changedFifthYaoStemBranch);

        var changedSixthYaoStemBranch = sixLinesDivination.Changed[6].StemBranch;
        Assert.NotNull(changedSixthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Ren, EarthlyBranch.Xu), changedSixthYaoStemBranch);

        var changedFirstYaoSixKin = sixLinesDivination.Changed[1].SixKin;
        Assert.NotNull(changedFirstYaoSixKin);
        Assert.Equal(SixKin.Officer, changedFirstYaoSixKin);

        var changedSecondYaoSixKin = sixLinesDivination.Changed[2].SixKin;
        Assert.NotNull(changedSecondYaoSixKin);
        Assert.Equal(SixKin.Parent, changedSecondYaoSixKin);

        var changedThirdYaoSixKin = sixLinesDivination.Changed[3].SixKin;
        Assert.NotNull(changedThirdYaoSixKin);
        Assert.Equal(SixKin.Offspring, changedThirdYaoSixKin);

        var changedFourthYaoSixKin = sixLinesDivination.Changed[4].SixKin;
        Assert.NotNull(changedFourthYaoSixKin);
        Assert.Equal(SixKin.Sibling, changedFourthYaoSixKin);

        var changedFifthYaoSixKin = sixLinesDivination.Changed[5].SixKin;
        Assert.NotNull(changedFifthYaoSixKin);
        Assert.Equal(SixKin.Wealth, changedFifthYaoSixKin);

        var changedSixthYaoSixKin = sixLinesDivination.Changed[6].SixKin;
        Assert.NotNull(changedSixthYaoSixKin);
        Assert.Equal(SixKin.Offspring, changedSixthYaoSixKin);

        testOutputHelper.WriteLine(sixLinesDivination.ToString());
    }
    
    [Fact]
    public void TheCornersOfTheMouth_TheWell_Test()
    {
        var sixLinesDivination = YiJingLibrary.SixLines.SixLines
            .CreateSpecifyDivinationBuilder(
                new DateTime(2025, 8, 22, 22, 30, 0),
                Hexagram.TheCornersOfTheMouth,
                Hexagram.TheWell)
            .Build();
        
        Assert.Equal(new StemBranch(HeavenlyStem.Yi, EarthlyBranch.Si), sixLinesDivination.InquiryTime.Lunar.Year);
        Assert.Equal(new StemBranch(HeavenlyStem.Jia, EarthlyBranch.Shen), sixLinesDivination.InquiryTime.Lunar.Month);
        Assert.Equal(new StemBranch(HeavenlyStem.Gui, EarthlyBranch.Hai), sixLinesDivination.InquiryTime.Lunar.Day);
        Assert.Equal(new StemBranch(HeavenlyStem.Gui, EarthlyBranch.Hai), sixLinesDivination.InquiryTime.Lunar.Hour);
        Assert.Contains(EarthlyBranch.Zi, sixLinesDivination.InquiryTime.Lunar.Day.EmptyBranches);
        Assert.Contains(EarthlyBranch.Chou, sixLinesDivination.InquiryTime.Lunar.Day.EmptyBranches);
        
        Assert.Equal(HexagramFeature.WanderingSoul, sixLinesDivination.Original.Feature);

        var originalFirstYaoStemBranch = sixLinesDivination.Original[1].StemBranch;
        Assert.NotNull(originalFirstYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Geng, EarthlyBranch.Zi), originalFirstYaoStemBranch);
        
        var corresponding = sixLinesDivination.Original[1].Position;
        Assert.NotNull(corresponding);
        Assert.Equal(Position.Corresponding, corresponding);
        
        var originalSecondYaoStemBranch = sixLinesDivination.Original[2].StemBranch;
        Assert.NotNull(originalSecondYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Geng, EarthlyBranch.Yin), originalSecondYaoStemBranch);
        
        var originalThirdYaoStemBranch = sixLinesDivination.Original[3].StemBranch;
        Assert.NotNull(originalThirdYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Geng, EarthlyBranch.Chen), originalThirdYaoStemBranch);
        
        var originalFourthYaoStemBranch = sixLinesDivination.Original[4].StemBranch;
        Assert.NotNull(originalFourthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Bing, EarthlyBranch.Xu), originalFourthYaoStemBranch);
        
        var worldly = sixLinesDivination.Original[4].Position;
        Assert.NotNull(worldly);
        Assert.Equal(Position.Worldly, worldly);
        
        var originalFifthYaoStemBranch = sixLinesDivination.Original[5].StemBranch;
        Assert.NotNull(originalFifthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Bing, EarthlyBranch.Zi), originalFifthYaoStemBranch);
        
        var originalSixthYaoStemBranch = sixLinesDivination.Original[6].StemBranch;
        Assert.NotNull(originalSixthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Bing, EarthlyBranch.Yin), originalSixthYaoStemBranch);

        var originalFirstYaoSixKin = sixLinesDivination.Original[1].SixKin;
        Assert.NotNull(originalFirstYaoSixKin);
        Assert.Equal(SixKin.Parent, originalFirstYaoSixKin);
        
        var originalSecondYaoSixKin = sixLinesDivination.Original[2].SixKin;
        Assert.NotNull(originalSecondYaoSixKin);
        Assert.Equal(SixKin.Sibling, originalSecondYaoSixKin);
        
        var originalThirdYaoSixKin = sixLinesDivination.Original[3].SixKin;
        Assert.NotNull(originalThirdYaoSixKin);
        Assert.Equal(SixKin.Wealth, originalThirdYaoSixKin);
        
        var originalFourthYaoSixKin = sixLinesDivination.Original[4].SixKin;
        Assert.NotNull(originalFourthYaoSixKin);
        Assert.Equal(SixKin.Wealth, originalFourthYaoSixKin);
        
        var originalFifthYaoSixKin = sixLinesDivination.Original[5].SixKin;
        Assert.NotNull(originalFifthYaoSixKin);
        Assert.Equal(SixKin.Parent, originalFifthYaoSixKin);
        
        var originalSixthYaoSixKin = sixLinesDivination.Original[6].SixKin;
        Assert.NotNull(originalSixthYaoSixKin);
        Assert.Equal(SixKin.Sibling, originalSixthYaoSixKin);

        var originalThirdHiddenSpirit = sixLinesDivination.Original[3].HiddenSpirit;
        Assert.NotNull(originalThirdHiddenSpirit);
        var originalThirdHiddenSpiritStemBranch = originalThirdHiddenSpirit.StemBranch;
        Assert.NotNull(originalThirdHiddenSpiritStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Xin, EarthlyBranch.You), originalThirdHiddenSpiritStemBranch);
        var originalThirdHiddenSpiritSixKin = originalThirdHiddenSpirit.SixKin;
        Assert.NotNull(originalThirdHiddenSpiritSixKin);
        Assert.Equal(SixKin.Officer, originalThirdHiddenSpiritSixKin);

        var originalFifthHiddenSpirit = sixLinesDivination.Original[5].HiddenSpirit;
        Assert.NotNull(originalFifthHiddenSpirit);
        var originalFifthHiddenSpiritStemBranch = originalFifthHiddenSpirit.StemBranch;
        Assert.NotNull(originalFifthHiddenSpiritStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Xin, EarthlyBranch.Si), originalFifthHiddenSpiritStemBranch);
        var originalFifthHiddenSpiritSixKin = originalFifthHiddenSpirit.SixKin;
        Assert.NotNull(originalFifthHiddenSpiritSixKin);
        Assert.Equal(SixKin.Offspring, originalFifthHiddenSpiritSixKin);

        var originalFirstFourSymbol = sixLinesDivination.Original[1].FourSymbol;
        Assert.NotNull(originalFirstFourSymbol);
        Assert.Equal(FourSymbol.OldYang, originalFirstFourSymbol);
        
        var originalSecondFourSymbol = sixLinesDivination.Original[2].FourSymbol;
        Assert.NotNull(originalSecondFourSymbol);
        Assert.Equal(FourSymbol.OldYin, originalSecondFourSymbol);
        
        var originalThirdFourSymbol = sixLinesDivination.Original[3].FourSymbol;
        Assert.NotNull(originalThirdFourSymbol);
        Assert.Equal(FourSymbol.OldYin, originalThirdFourSymbol);
        
        var originalFourthFourSymbol = sixLinesDivination.Original[4].FourSymbol;
        Assert.NotNull(originalFourthFourSymbol);
        Assert.Equal(FourSymbol.YoungYin, originalFourthFourSymbol);
        
        var originalFifthFourSymbol = sixLinesDivination.Original[5].FourSymbol;
        Assert.NotNull(originalFifthFourSymbol);
        Assert.Equal(FourSymbol.OldYin, originalFifthFourSymbol);
        
        var originalSixthFourSymbol = sixLinesDivination.Original[6].FourSymbol;
        Assert.NotNull(originalSixthFourSymbol);
        Assert.Equal(FourSymbol.OldYang, originalSixthFourSymbol);

        Assert.NotNull(sixLinesDivination.Changed);
        
        var changedFirstYaoStemBranch = sixLinesDivination.Changed[1].StemBranch;
        Assert.NotNull(changedFirstYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Xin, EarthlyBranch.Chou), changedFirstYaoStemBranch);

        var changedSecondYaoStemBranch = sixLinesDivination.Changed[2].StemBranch;
        Assert.NotNull(changedSecondYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Xin, EarthlyBranch.Hai), changedSecondYaoStemBranch);

        var changedThirdYaoStemBranch = sixLinesDivination.Changed[3].StemBranch;
        Assert.NotNull(changedThirdYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Xin, EarthlyBranch.You), changedThirdYaoStemBranch);

        var changedFourthYaoStemBranch = sixLinesDivination.Changed[4].StemBranch;
        Assert.NotNull(changedFourthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Wu, EarthlyBranch.Shen), changedFourthYaoStemBranch);

        var changedFifthYaoStemBranch = sixLinesDivination.Changed[5].StemBranch;
        Assert.NotNull(changedFifthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Wu, EarthlyBranch.Xu), changedFifthYaoStemBranch);

        var changedSixthYaoStemBranch = sixLinesDivination.Changed[6].StemBranch;
        Assert.NotNull(changedSixthYaoStemBranch);
        Assert.Equal(new StemBranch(HeavenlyStem.Wu, EarthlyBranch.Zi), changedSixthYaoStemBranch);

        var changedFirstYaoSixKin = sixLinesDivination.Changed[1].SixKin;
        Assert.NotNull(changedFirstYaoSixKin);
        Assert.Equal(SixKin.Wealth, changedFirstYaoSixKin);

        var changedSecondYaoSixKin = sixLinesDivination.Changed[2].SixKin;
        Assert.NotNull(changedSecondYaoSixKin);
        Assert.Equal(SixKin.Parent, changedSecondYaoSixKin);

        var changedThirdYaoSixKin = sixLinesDivination.Changed[3].SixKin;
        Assert.NotNull(changedThirdYaoSixKin);
        Assert.Equal(SixKin.Officer, changedThirdYaoSixKin);

        var changedFourthYaoSixKin = sixLinesDivination.Changed[4].SixKin;
        Assert.NotNull(changedFourthYaoSixKin);
        Assert.Equal(SixKin.Officer, changedFourthYaoSixKin);

        var changedFifthYaoSixKin = sixLinesDivination.Changed[5].SixKin;
        Assert.NotNull(changedFifthYaoSixKin);
        Assert.Equal(SixKin.Wealth, changedFifthYaoSixKin);

        var changedSixthYaoSixKin = sixLinesDivination.Changed[6].SixKin;
        Assert.NotNull(changedSixthYaoSixKin);
        Assert.Equal(SixKin.Parent, changedSixthYaoSixKin);
        
        testOutputHelper.WriteLine(sixLinesDivination.ToString());
    }

    [Fact]
    public void Test()
    {
        var sixLinesDivination = YiJingLibrary.SixLines.SixLines
            .CreateSpecifyDivinationBuilder(
                new DateTime(2025, 11, 13, 10, 30, 0),
                Hexagram.TheCreative,
                Hexagram.FellowshipWithMen)
            .Build();
        
        testOutputHelper.WriteLine(sixLinesDivination.ToString());
    }
}