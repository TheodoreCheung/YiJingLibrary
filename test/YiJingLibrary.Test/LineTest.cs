using YiJingLibrary.Core;

namespace YiJingLibrary.Test;

public class LineTest
{
    [Fact]
    public void LineFactory_CreatesCorrectLines()
    {
        var firstLine = Line.First.WithYinYang(YinYang.Yang);
        var secondLine = Line.Second.WithYinYang(YinYang.Yin);
        var thirdLine = Line.Third.WithYinYang(YinYang.Yang);
        var fourthLine = Line.Fourth.WithYinYang(YinYang.Yin);
        var fifthLine = Line.Fifth.WithYinYang(YinYang.Yang);
        var topLine = Line.Top.WithYinYang(YinYang.Yin);

        Assert.Equal(1, firstLine);
        Assert.Equal(2, secondLine);
        Assert.Equal(3, thirdLine);
        Assert.Equal(4, fourthLine);
        Assert.Equal(5, fifthLine);
        Assert.Equal(6, topLine);

        Assert.Equal(YinYang.Yang, firstLine.YinYang);
        Assert.Equal(YinYang.Yin, secondLine.YinYang);
        Assert.Equal(YinYang.Yang, thirdLine.YinYang);
        Assert.Equal(YinYang.Yin, fourthLine.YinYang);
        Assert.Equal(YinYang.Yang, fifthLine.YinYang);
        Assert.Equal(YinYang.Yin, topLine.YinYang);
    }

    [Fact]
    public void FromValue_ReturnsCorrectLineFactory()
    {
        Assert.NotNull(Line.FromValue(1));
        Assert.NotNull(Line.FromValue(2));
        Assert.NotNull(Line.FromValue(3));
        Assert.NotNull(Line.FromValue(4));
        Assert.NotNull(Line.FromValue(5));
        Assert.NotNull(Line.FromValue(6));
    }

    [Fact]
    public void FromValue_InvalidValue_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Line.FromValue(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => Line.FromValue(7));
    }

    [Fact]
    public void LineAttributes_AreInitialized()
    {
        var line = Line.First.WithYinYang(YinYang.Yang);
        Assert.NotNull(line.Attributes);
    }
}