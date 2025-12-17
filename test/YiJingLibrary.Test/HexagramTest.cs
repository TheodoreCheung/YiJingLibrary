using YiJingLibrary.Core;

namespace YiJingLibrary.Test;

public class HexagramTest
{
    [Fact]
    public void HexagramBasicProperties_AreCorrect()
    {
        var theCreative = Hexagram.TheCreative;
        
        Assert.NotNull(theCreative.Palace);
        Assert.NotNull(theCreative.Upper);
        Assert.NotNull(theCreative.Lower);
        Assert.Equal(Trigram.Qian, theCreative.Palace);
        Assert.Equal(Trigram.Qian, theCreative.Upper);
        Assert.Equal(Trigram.Qian, theCreative.Lower);
    }

    [Fact]
    public void HexagramIndexer_ReturnsCorrectLines()
    {
        var theCreative = Hexagram.TheCreative;
        
        // The Creative has all yang lines: 111111
        for (byte i = 1; i <= 6; i++)
        {
            Assert.NotNull(theCreative[i]);
            Assert.Equal(YinYang.Yang, theCreative[i].YinYang);
        }
    }

    [Fact]
    public void HexagramIndexer_InvalidIndex_ThrowsException()
    {
        var theCreative = Hexagram.TheCreative;
        Assert.Throws<IndexOutOfRangeException>(() => theCreative[0]);
        Assert.Throws<IndexOutOfRangeException>(() => theCreative[7]);
    }

    [Fact]
    public void FromValue_ReturnsCorrectHexagram()
    {
        Assert.Equal(Hexagram.TheCreative, Hexagram.FromValue(0b0111_0111));
        Assert.Equal(Hexagram.TheReceptive, Hexagram.FromValue(0b0000_0000));
        Assert.Equal(Hexagram.FellowshipWithMen, Hexagram.FromValue(0b0111_0101));
    }

    [Fact]
    public void FromValue_InvalidValue_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Hexagram.FromValue(0b1111_1111));
    }

    [Fact]
    public void QueryByYinYang_ReturnsCorrectHexagram()
    {
        // The Creative: all yang
        var yinYangArray = new[]
        {
            YinYang.Yang, YinYang.Yang, YinYang.Yang,
            YinYang.Yang, YinYang.Yang, YinYang.Yang
        };
        var result = Hexagram.QueryByYinYang(yinYangArray);
        Assert.Equal(Hexagram.TheCreative, result);

        // The Receptive: all yin
        var yinYangArray2 = new[]
        {
            YinYang.Yin, YinYang.Yin, YinYang.Yin,
            YinYang.Yin, YinYang.Yin, YinYang.Yin
        };
        var result2 = Hexagram.QueryByYinYang(yinYangArray2);
        Assert.Equal(Hexagram.TheReceptive, result2);
    }

    [Fact]
    public void QueryByYinYang_InvalidLength_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => Hexagram.QueryByYinYang(YinYang.Yang));
        Assert.Throws<ArgumentException>(() => Hexagram.QueryByYinYang(
            YinYang.Yang, YinYang.Yang, YinYang.Yang, 
            YinYang.Yang, YinYang.Yang, YinYang.Yang, 
            YinYang.Yang)); // 7 elements
    }

    [Fact]
    public void All_ReturnsAllHexagrams()
    {
        var allHexagrams = Hexagram.All.ToList();
        Assert.NotEmpty(allHexagrams);
        Assert.Contains(Hexagram.TheCreative, allHexagrams);
        Assert.Contains(Hexagram.TheReceptive, allHexagrams);
    }

    [Fact]
    public void SameHexagram_Equal_IsTrue()
    {
        var a = Hexagram.TheCreative;
        var b = Hexagram.TheCreative;
        Assert.True(a.Equals(b));
        Assert.True(a == b);
    }

    [Fact]
    public void DifferentHexagram_Equal_IsFalse()
    {
        var a = Hexagram.TheCreative;
        var b = Hexagram.TheReceptive;
        Assert.False(a.Equals(b));
        Assert.False(a == b);
    }

    [Fact]
    public void Hexagram_NotEqual_IsTrue()
    {
        var a = Hexagram.TheCreative;
        var b = Hexagram.TheReceptive;
        Assert.True(a != b);
    }
}