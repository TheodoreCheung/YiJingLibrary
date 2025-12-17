using YiJingLibrary.Core;

namespace YiJingLibrary.Test;

public class HeavenlyStemTest
{
    [Fact]
    public void WoodGeneratesFire_IsTrue()
    {
        Assert.True(HeavenlyStem.Jia.Generates(HeavenlyStem.Bing));
        Assert.True(HeavenlyStem.Jia.Generates(HeavenlyStem.Ding));
        Assert.True(HeavenlyStem.Yi.Generates(HeavenlyStem.Bing));
        Assert.True(HeavenlyStem.Yi.Generates(HeavenlyStem.Ding));
        
        Assert.True(HeavenlyStem.Bing.GeneratesBy(HeavenlyStem.Jia));
        Assert.True(HeavenlyStem.Bing.GeneratesBy(HeavenlyStem.Yi));
        Assert.True(HeavenlyStem.Ding.GeneratesBy(HeavenlyStem.Jia));
        Assert.True(HeavenlyStem.Ding.GeneratesBy(HeavenlyStem.Yi));
    }

    [Fact]
    public void FireGeneratesEarth_IsTrue()
    {
        Assert.True(HeavenlyStem.Bing.Generates(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Bing.Generates(HeavenlyStem.Ji));
        Assert.True(HeavenlyStem.Ding.Generates(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Ding.Generates(HeavenlyStem.Ji));
        
        Assert.True(HeavenlyStem.Wu.GeneratesBy(HeavenlyStem.Bing));
        Assert.True(HeavenlyStem.Wu.GeneratesBy(HeavenlyStem.Ding));
        Assert.True(HeavenlyStem.Ji.GeneratesBy(HeavenlyStem.Bing));
        Assert.True(HeavenlyStem.Ji.GeneratesBy(HeavenlyStem.Ding));
    }

    [Fact]
    public void EarthGeneratesMetal_IsTrue()
    {
        Assert.True(HeavenlyStem.Wu.Generates(HeavenlyStem.Geng));
        Assert.True(HeavenlyStem.Wu.Generates(HeavenlyStem.Xin));
        Assert.True(HeavenlyStem.Ji.Generates(HeavenlyStem.Geng));
        Assert.True(HeavenlyStem.Ji.Generates(HeavenlyStem.Xin));
        
        Assert.True(HeavenlyStem.Geng.GeneratesBy(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Geng.GeneratesBy(HeavenlyStem.Ji));
        Assert.True(HeavenlyStem.Xin.GeneratesBy(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Xin.GeneratesBy(HeavenlyStem.Ji));
    }

    [Fact]
    public void MetalGeneratesWater_IsTrue()
    {
        Assert.True(HeavenlyStem.Geng.Generates(HeavenlyStem.Ren));
        Assert.True(HeavenlyStem.Geng.Generates(HeavenlyStem.Gui));
        Assert.True(HeavenlyStem.Xin.Generates(HeavenlyStem.Ren));
        Assert.True(HeavenlyStem.Xin.Generates(HeavenlyStem.Gui));
        
        Assert.True(HeavenlyStem.Ren.GeneratesBy(HeavenlyStem.Geng));
        Assert.True(HeavenlyStem.Ren.GeneratesBy(HeavenlyStem.Xin));
        Assert.True(HeavenlyStem.Gui.GeneratesBy(HeavenlyStem.Geng));
        Assert.True(HeavenlyStem.Gui.GeneratesBy(HeavenlyStem.Xin));
    }

    [Fact]
    public void WaterGeneratesWood_IsTrue()
    {
        Assert.True(HeavenlyStem.Ren.Generates(HeavenlyStem.Jia));
        Assert.True(HeavenlyStem.Ren.Generates(HeavenlyStem.Yi));
        Assert.True(HeavenlyStem.Gui.Generates(HeavenlyStem.Jia));
        Assert.True(HeavenlyStem.Gui.Generates(HeavenlyStem.Yi));
        
        Assert.True(HeavenlyStem.Jia.GeneratesBy(HeavenlyStem.Ren));
        Assert.True(HeavenlyStem.Jia.GeneratesBy(HeavenlyStem.Gui));
        Assert.True(HeavenlyStem.Yi.GeneratesBy(HeavenlyStem.Ren));
        Assert.True(HeavenlyStem.Yi.GeneratesBy(HeavenlyStem.Gui));
    }

    [Fact]
    public void WoodRestrainsEarth_IsTrue()
    {
        Assert.True(HeavenlyStem.Jia.Restrains(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Jia.Restrains(HeavenlyStem.Ji));
        Assert.True(HeavenlyStem.Yi.Restrains(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Yi.Restrains(HeavenlyStem.Ji));
        
        Assert.True(HeavenlyStem.Wu.RestrainsBy(HeavenlyStem.Jia));
        Assert.True(HeavenlyStem.Wu.RestrainsBy(HeavenlyStem.Yi));
        Assert.True(HeavenlyStem.Ji.RestrainsBy(HeavenlyStem.Jia));
        Assert.True(HeavenlyStem.Ji.RestrainsBy(HeavenlyStem.Yi));
    }

    [Fact]
    public void FireRestrainsMetal_IsTrue()
    {
        Assert.True(HeavenlyStem.Bing.Restrains(HeavenlyStem.Geng));
        Assert.True(HeavenlyStem.Bing.Restrains(HeavenlyStem.Xin));
        Assert.True(HeavenlyStem.Ding.Restrains(HeavenlyStem.Geng));
        Assert.True(HeavenlyStem.Ding.Restrains(HeavenlyStem.Xin));
        
        Assert.True(HeavenlyStem.Geng.RestrainsBy(HeavenlyStem.Bing));
        Assert.True(HeavenlyStem.Geng.RestrainsBy(HeavenlyStem.Ding));
        Assert.True(HeavenlyStem.Xin.RestrainsBy(HeavenlyStem.Bing));
        Assert.True(HeavenlyStem.Xin.RestrainsBy(HeavenlyStem.Ding));
    }

    [Fact]
    public void EarthRestrainsMetal_IsTrue()
    {
        Assert.True(HeavenlyStem.Wu.Restrains(HeavenlyStem.Ren));
        Assert.True(HeavenlyStem.Wu.Restrains(HeavenlyStem.Gui));
        Assert.True(HeavenlyStem.Ji.Restrains(HeavenlyStem.Ren));
        Assert.True(HeavenlyStem.Ji.Restrains(HeavenlyStem.Gui));
        
        Assert.True(HeavenlyStem.Ren.RestrainsBy(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Ren.RestrainsBy(HeavenlyStem.Ji));
        Assert.True(HeavenlyStem.Gui.RestrainsBy(HeavenlyStem.Wu));
        Assert.True(HeavenlyStem.Gui.RestrainsBy(HeavenlyStem.Ji));
    }

    [Fact]
    public void MetalRestrainsWood_IsTrue()
    {
        Assert.True(HeavenlyStem.Geng.Restrains(HeavenlyStem.Jia));
        Assert.True(HeavenlyStem.Geng.Restrains(HeavenlyStem.Yi));
        Assert.True(HeavenlyStem.Xin.Restrains(HeavenlyStem.Jia));
        Assert.True(HeavenlyStem.Xin.Restrains(HeavenlyStem.Yi));
        
        Assert.True(HeavenlyStem.Jia.RestrainsBy(HeavenlyStem.Geng));
        Assert.True(HeavenlyStem.Jia.RestrainsBy(HeavenlyStem.Xin));
        Assert.True(HeavenlyStem.Yi.RestrainsBy(HeavenlyStem.Geng));
        Assert.True(HeavenlyStem.Yi.RestrainsBy(HeavenlyStem.Xin));
    }

    [Fact]
    public void WaterRestrainsFire_IsTrue()
    {
        Assert.True(HeavenlyStem.Ren.Restrains(HeavenlyStem.Bing));
        Assert.True(HeavenlyStem.Ren.Restrains(HeavenlyStem.Ding));
        Assert.True(HeavenlyStem.Gui.Restrains(HeavenlyStem.Bing));
        Assert.True(HeavenlyStem.Gui.Restrains(HeavenlyStem.Ding));
        
        Assert.True(HeavenlyStem.Bing.RestrainsBy(HeavenlyStem.Ren));
        Assert.True(HeavenlyStem.Bing.RestrainsBy(HeavenlyStem.Gui));
        Assert.True(HeavenlyStem.Ding.RestrainsBy(HeavenlyStem.Ren));
        Assert.True(HeavenlyStem.Ding.RestrainsBy(HeavenlyStem.Gui));
    }
}