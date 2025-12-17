using YiJingLibrary.Core;

namespace YiJingLibrary.Test;

public class TrigramTest
{
    [Fact]
    public void TrigramValues_AreCorrect()
    {
        Assert.Equal(0b0000_0111, Trigram.Qian);
        Assert.Equal(0b0000_0011, Trigram.Dui);
        Assert.Equal(0b0000_0101, Trigram.Li);
        Assert.Equal(0b0000_0001, Trigram.Zhen);
        Assert.Equal(0b0000_0110, Trigram.Xun);
        Assert.Equal(0b0000_0010, Trigram.Kan);
        Assert.Equal(0b0000_0100, Trigram.Gen);
        Assert.Equal(0b0000_0000, Trigram.Kun);
    }

    [Fact]
    public void TrigramFivePhases_AreCorrect()
    {
        Assert.Equal(FivePhase.Metal, Trigram.Qian.FivePhase);
        Assert.Equal(FivePhase.Metal, Trigram.Dui.FivePhase);
        Assert.Equal(FivePhase.Fire, Trigram.Li.FivePhase);
        Assert.Equal(FivePhase.Wood, Trigram.Zhen.FivePhase);
        Assert.Equal(FivePhase.Wood, Trigram.Xun.FivePhase);
        Assert.Equal(FivePhase.Water, Trigram.Kan.FivePhase);
        Assert.Equal(FivePhase.Earth, Trigram.Gen.FivePhase);
        Assert.Equal(FivePhase.Earth, Trigram.Kun.FivePhase);
    }

    [Fact]
    public void TrigramLines_AreInitialized()
    {
        var qian = Trigram.Qian;
        Assert.NotNull(qian.Lines);
        Assert.Equal(3, qian.Lines.Count);
        
        // Check that all lines are initialized
        for (byte i = 1; i <= 3; i++)
        {
            Assert.NotNull(qian[i]);
        }
    }

    [Fact]
    public void TrigramIndexer_ReturnsCorrectLines()
    {
        var qian = Trigram.Qian;
        
        // Qian has all yang lines: 111
        Assert.Equal(YinYang.Yang, qian[1].YinYang);
        Assert.Equal(YinYang.Yang, qian[2].YinYang);
        Assert.Equal(YinYang.Yang, qian[3].YinYang);
    }

    [Fact]
    public void TrigramIndexer_InvalidIndex_ThrowsException()
    {
        var qian = Trigram.Qian;
        Assert.Throws<IndexOutOfRangeException>(() => qian[0]);
        Assert.Throws<IndexOutOfRangeException>(() => qian[4]);
    }

    [Fact]
    public void SameTrigram_Equal_IsTrue()
    {
        var a = Trigram.Qian;
        var b = Trigram.Qian;
        Assert.True(a.Equals(b));
        Assert.True(a == b);
    }

    [Fact]
    public void DifferentTrigram_Equal_IsFalse()
    {
        var a = Trigram.Qian;
        var b = Trigram.Kun;
        Assert.False(a.Equals(b));
        Assert.False(a == b);
    }

    [Fact]
    public void Trigram_NotEqual_IsTrue()
    {
        var a = Trigram.Li;
        var b = Trigram.Kan;
        Assert.True(a != b);
    }
}