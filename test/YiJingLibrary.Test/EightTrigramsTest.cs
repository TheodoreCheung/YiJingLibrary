using YiJingLibrary.Core;

namespace YiJingLibrary.Test;

public class EightTrigramsTest
{
    [Fact]
    public void Qian_YinYang_FivePhase_IsCorrect()
    {
        var qian = Trigram.Qian;
        
        var yangCount = qian.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(3, yangCount);
        
        Assert.True(qian[3].YinYang.Equals(YinYang.Yang));
        Assert.True(qian[2].YinYang.Equals(YinYang.Yang));
        Assert.True(qian[1].YinYang.Equals(YinYang.Yang));

        Assert.True(qian.FivePhase.Equals(FivePhase.Metal));
    }

    [Fact]
    public void Kun_YinYang_FivePhase_IsCorrect()
    {
        var kun = Trigram.Kun;
        
        var yinCount = kun.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(3, yinCount);
        
        Assert.True(kun[3].YinYang.Equals(YinYang.Yin));
        Assert.True(kun[2].YinYang.Equals(YinYang.Yin));
        Assert.True(kun[1].YinYang.Equals(YinYang.Yin));
        
        Assert.True(kun.FivePhase.Equals(FivePhase.Earth));
    }

    [Fact]
    public void Zhen_YinYang_FivePhase_IsCorrect()
    {
        var zhen = Trigram.Zhen;
        
        var yangCount = zhen.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(1, yangCount);
        
        var yinCount = zhen.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);
        
        Assert.True(zhen[3].YinYang.Equals(YinYang.Yin));
        Assert.True(zhen[2].YinYang.Equals(YinYang.Yin));
        Assert.True(zhen[1].YinYang.Equals(YinYang.Yang));
        
        Assert.True(zhen.FivePhase.Equals(FivePhase.Wood));
    }
    
    [Fact]
    public void Xun_YinYang_FivePhase_IsCorrect()
    {
        var xun = Trigram.Xun;
        
        var yangCount = xun.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        
        var yinCount = xun.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(1, yinCount);
        
        Assert.True(xun[3].YinYang.Equals(YinYang.Yang));
        Assert.True(xun[2].YinYang.Equals(YinYang.Yang));
        Assert.True(xun[1].YinYang.Equals(YinYang.Yin));
        
        Assert.True(xun.FivePhase.Equals(FivePhase.Wood));
    }
    
    [Fact]
    public void Kan_YinYang_FivePhase_IsCorrect()
    {
        var kan = Trigram.Kan;
        
        var yangCount = kan.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(1, yangCount);
        
        var yinCount = kan.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);
        
        Assert.True(kan[3].YinYang.Equals(YinYang.Yin));
        Assert.True(kan[2].YinYang.Equals(YinYang.Yang));
        Assert.True(kan[1].YinYang.Equals(YinYang.Yin));
        
        Assert.True(kan.FivePhase.Equals(FivePhase.Water));
    }
    
    [Fact]
    public void Li_YinYang_FivePhase_IsCorrect()
    {
        var li = Trigram.Li;
        
        var yangCount = li.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        
        var yinCount = li.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(1, yinCount);
        
        Assert.True(li[3].YinYang.Equals(YinYang.Yang));
        Assert.True(li[2].YinYang.Equals(YinYang.Yin));
        Assert.True(li[1].YinYang.Equals(YinYang.Yang));
        
        Assert.True(li.FivePhase.Equals(FivePhase.Fire));
    }
    
    [Fact]
    public void Gen_YinYang_FivePhase_IsCorrect()
    {
        var gen = Trigram.Gen;
        
        var yangCount = gen.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(1, yangCount);
        
        var yinCount = gen.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(2, yinCount);
        
        Assert.True(gen[3].YinYang.Equals(YinYang.Yang));
        Assert.True(gen[2].YinYang.Equals(YinYang.Yin));
        Assert.True(gen[1].YinYang.Equals(YinYang.Yin));
        
        Assert.True(gen.FivePhase.Equals(FivePhase.Earth));
    }
    
    [Fact]
    public void Dui_YinYang_FivePhase_IsCorrect()
    {
        var dui = Trigram.Dui;
        
        var yangCount = dui.Lines.Count(y => y.YinYang.Equals(YinYang.Yang));
        Assert.Equal(2, yangCount);
        
        var yinCount = dui.Lines.Count(y => y.YinYang.Equals(YinYang.Yin));
        Assert.Equal(1, yinCount);
        
        Assert.True(dui[3].YinYang.Equals(YinYang.Yin));
        Assert.True(dui[2].YinYang.Equals(YinYang.Yang));
        Assert.True(dui[1].YinYang.Equals(YinYang.Yang));
        
        Assert.True(dui.FivePhase.Equals(FivePhase.Metal));
    }
}