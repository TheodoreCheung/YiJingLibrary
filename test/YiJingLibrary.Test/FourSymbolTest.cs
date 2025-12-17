using YiJingLibrary.Core;

namespace YiJingLibrary.Test;

public class FourSymbolTest
{
    [Fact]
    public void FourSymbolValues_AreCorrect()
    {
        Assert.Equal(6, FourSymbol.OldYin);
        Assert.Equal(7, FourSymbol.YoungYang);
        Assert.Equal(8, FourSymbol.YoungYin);
        Assert.Equal(9, FourSymbol.OldYang);
    }

    [Fact]
    public void FromValue_ReturnsCorrectFourSymbol()
    {
        Assert.Equal(FourSymbol.OldYin, FourSymbol.FromValue(6));
        Assert.Equal(FourSymbol.YoungYang, FourSymbol.FromValue(7));
        Assert.Equal(FourSymbol.YoungYin, FourSymbol.FromValue(8));
        Assert.Equal(FourSymbol.OldYang, FourSymbol.FromValue(9));
    }

    [Fact]
    public void FromValue_InvalidValue_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => FourSymbol.FromValue(5));
        Assert.Throws<ArgumentOutOfRangeException>(() => FourSymbol.FromValue(10));
    }

    [Fact]
    public void SameFourSymbol_Equal_IsTrue()
    {
        var a = FourSymbol.YoungYang;
        var b = FourSymbol.YoungYang;
        Assert.True(a.Equals(b));
        Assert.True(a == b);
    }

    [Fact]
    public void DifferentFourSymbol_Equal_IsFalse()
    {
        var a = FourSymbol.OldYin;
        var b = FourSymbol.YoungYang;
        Assert.False(a.Equals(b));
        Assert.False(a == b);
    }

    [Fact]
    public void FourSymbol_NotEqual_IsTrue()
    {
        var a = FourSymbol.OldYang;
        var b = FourSymbol.YoungYin;
        Assert.True(a != b);
    }
}