using YiJingLibrary.Core;

namespace YiJingLibrary.Test;

public class YinYangTest
{
    [Fact]
    public void YinYangValues_AreCorrect()
    {
        Assert.Equal(6, YinYang.Yin);
        Assert.Equal(9, YinYang.Yang);
    }

    [Fact]
    public void SameYinYang_Equal_IsTrue()
    {
        var a = YinYang.Yin;
        var b = YinYang.Yin;
        Assert.True(a.Equals(b));
        Assert.True(a == b);
    }

    [Fact]
    public void DifferentYinYang_Equal_IsFalse()
    {
        var a = YinYang.Yin;
        var b = YinYang.Yang;
        Assert.False(a.Equals(b));
        Assert.False(a == b);
    }

    [Fact]
    public void YinYang_NotEqual_IsTrue()
    {
        var a = YinYang.Yin;
        var b = YinYang.Yang;
        Assert.True(a != b);
    }
}