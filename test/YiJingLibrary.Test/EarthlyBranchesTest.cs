using YiJingLibrary.Core;

namespace YiJingLibrary.Test;

public class EarthlyBranchTest
{
    [Fact]
    public void WoodGeneratesFire_IsTrue()
    {
        Assert.True(EarthlyBranch.Yin.Generates(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.Yin.Generates(EarthlyBranch.Wu));
        Assert.True(EarthlyBranch.Mao.Generates(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.Mao.Generates(EarthlyBranch.Wu));
        
        Assert.True(EarthlyBranch.Si.GeneratesBy(EarthlyBranch.Yin));
        Assert.True(EarthlyBranch.Si.GeneratesBy(EarthlyBranch.Mao));
        Assert.True(EarthlyBranch.Wu.GeneratesBy(EarthlyBranch.Yin));
        Assert.True(EarthlyBranch.Wu.GeneratesBy(EarthlyBranch.Mao));
    }

    [Fact]
    public void FireGeneratesEarth_IsTrue()
    {
        Assert.True(EarthlyBranch.Si.Generates(EarthlyBranch.Chen));
        Assert.True(EarthlyBranch.Si.Generates(EarthlyBranch.Wei));
        Assert.True(EarthlyBranch.Si.Generates(EarthlyBranch.Xu));
        Assert.True(EarthlyBranch.Si.Generates(EarthlyBranch.Chou));
        Assert.True(EarthlyBranch.Wu.Generates(EarthlyBranch.Chen));
        Assert.True(EarthlyBranch.Wu.Generates(EarthlyBranch.Wei));
        Assert.True(EarthlyBranch.Wu.Generates(EarthlyBranch.Xu));
        Assert.True(EarthlyBranch.Wu.Generates(EarthlyBranch.Chou));
        
        Assert.True(EarthlyBranch.Chen.GeneratesBy(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.Chen.GeneratesBy(EarthlyBranch.Wu));
        Assert.True(EarthlyBranch.Wei.GeneratesBy(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.Wei.GeneratesBy(EarthlyBranch.Wu));
        Assert.True(EarthlyBranch.Xu.GeneratesBy(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.Xu.GeneratesBy(EarthlyBranch.Wu));
        Assert.True(EarthlyBranch.Chou.GeneratesBy(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.Chou.GeneratesBy(EarthlyBranch.Wu));
    }

    [Fact]
    public void EarthGeneratesMetal_IsTrue()
    {
        Assert.True(EarthlyBranch.Chen.Generates(EarthlyBranch.Shen));
        Assert.True(EarthlyBranch.Chen.Generates(EarthlyBranch.You));
        Assert.True(EarthlyBranch.Wei.Generates(EarthlyBranch.Shen));
        Assert.True(EarthlyBranch.Wei.Generates(EarthlyBranch.You));
        Assert.True(EarthlyBranch.Xu.Generates(EarthlyBranch.Shen));
        Assert.True(EarthlyBranch.Xu.Generates(EarthlyBranch.You));
        Assert.True(EarthlyBranch.Chou.Generates(EarthlyBranch.Shen));
        Assert.True(EarthlyBranch.Chou.Generates(EarthlyBranch.You));
        
        Assert.True(EarthlyBranch.Shen.GeneratesBy(EarthlyBranch.Chen));
        Assert.True(EarthlyBranch.Shen.GeneratesBy(EarthlyBranch.Wei));
        Assert.True(EarthlyBranch.Shen.GeneratesBy(EarthlyBranch.Xu));
        Assert.True(EarthlyBranch.Shen.GeneratesBy(EarthlyBranch.Chou));
        Assert.True(EarthlyBranch.You.GeneratesBy(EarthlyBranch.Chen));
        Assert.True(EarthlyBranch.You.GeneratesBy(EarthlyBranch.Wei));
        Assert.True(EarthlyBranch.You.GeneratesBy(EarthlyBranch.Xu));
        Assert.True(EarthlyBranch.You.GeneratesBy(EarthlyBranch.Chou));
    }

    [Fact]
    public void MetalGeneratesWater_IsTrue()
    {
        Assert.True(EarthlyBranch.Shen.Generates(EarthlyBranch.Hai));
        Assert.True(EarthlyBranch.Shen.Generates(EarthlyBranch.Zi));
        Assert.True(EarthlyBranch.You.Generates(EarthlyBranch.Hai));
        Assert.True(EarthlyBranch.You.Generates(EarthlyBranch.Zi));
        
        Assert.True(EarthlyBranch.Hai.GeneratesBy(EarthlyBranch.Shen));
        Assert.True(EarthlyBranch.Hai.GeneratesBy(EarthlyBranch.You));
        Assert.True(EarthlyBranch.Zi.GeneratesBy(EarthlyBranch.Shen));
        Assert.True(EarthlyBranch.Zi.GeneratesBy(EarthlyBranch.You));
    }

    [Fact]
    public void WaterGeneratesWood_IsTrue()
    {
        Assert.True(EarthlyBranch.Hai.Generates(EarthlyBranch.Yin));
        Assert.True(EarthlyBranch.Hai.Generates(EarthlyBranch.Mao));
        Assert.True(EarthlyBranch.Zi.Generates(EarthlyBranch.Yin));
        Assert.True(EarthlyBranch.Zi.Generates(EarthlyBranch.Mao));
        
        Assert.True(EarthlyBranch.Yin.GeneratesBy(EarthlyBranch.Hai));
        Assert.True(EarthlyBranch.Yin.GeneratesBy(EarthlyBranch.Zi));
        Assert.True(EarthlyBranch.Mao.GeneratesBy(EarthlyBranch.Hai));
        Assert.True(EarthlyBranch.Mao.GeneratesBy(EarthlyBranch.Zi));
    }

    [Fact]
    public void WoodRestrainsEarth_IsTrue()
    {
        Assert.True(EarthlyBranch.Yin.Restrains(EarthlyBranch.Chen));
        Assert.True(EarthlyBranch.Yin.Restrains(EarthlyBranch.Wei));
        Assert.True(EarthlyBranch.Yin.Restrains(EarthlyBranch.Xu));
        Assert.True(EarthlyBranch.Yin.Restrains(EarthlyBranch.Chou));
        Assert.True(EarthlyBranch.Mao.Restrains(EarthlyBranch.Chen));
        Assert.True(EarthlyBranch.Mao.Restrains(EarthlyBranch.Wei));
        Assert.True(EarthlyBranch.Mao.Restrains(EarthlyBranch.Xu));
        Assert.True(EarthlyBranch.Mao.Restrains(EarthlyBranch.Chou));
        
        Assert.True(EarthlyBranch.Chen.RestrainsBy(EarthlyBranch.Yin));
        Assert.True(EarthlyBranch.Chen.RestrainsBy(EarthlyBranch.Mao));
        Assert.True(EarthlyBranch.Wei.RestrainsBy(EarthlyBranch.Yin));
        Assert.True(EarthlyBranch.Wei.RestrainsBy(EarthlyBranch.Mao));
        Assert.True(EarthlyBranch.Xu.RestrainsBy(EarthlyBranch.Yin));
        Assert.True(EarthlyBranch.Xu.RestrainsBy(EarthlyBranch.Mao));
        Assert.True(EarthlyBranch.Chou.RestrainsBy(EarthlyBranch.Yin));
        Assert.True(EarthlyBranch.Chou.RestrainsBy(EarthlyBranch.Mao));
    }

    [Fact]
    public void FireRestrainsMetal_IsTrue()
    {
        Assert.True(EarthlyBranch.Si.Restrains(EarthlyBranch.Shen));
        Assert.True(EarthlyBranch.Si.Restrains(EarthlyBranch.You));
        Assert.True(EarthlyBranch.Wu.Restrains(EarthlyBranch.Shen));
        Assert.True(EarthlyBranch.Wu.Restrains(EarthlyBranch.You));
        
        Assert.True(EarthlyBranch.Shen.RestrainsBy(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.Shen.RestrainsBy(EarthlyBranch.Wu));
        Assert.True(EarthlyBranch.You.RestrainsBy(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.You.RestrainsBy(EarthlyBranch.Wu));
    }

    [Fact]
    public void EarthRestrainsWater_IsTrue()
    {
        Assert.True(EarthlyBranch.Chen.Restrains(EarthlyBranch.Hai));
        Assert.True(EarthlyBranch.Chen.Restrains(EarthlyBranch.Zi));
        Assert.True(EarthlyBranch.Wei.Restrains(EarthlyBranch.Hai));
        Assert.True(EarthlyBranch.Wei.Restrains(EarthlyBranch.Zi));
        Assert.True(EarthlyBranch.Xu.Restrains(EarthlyBranch.Hai));
        Assert.True(EarthlyBranch.Xu.Restrains(EarthlyBranch.Zi));
        Assert.True(EarthlyBranch.Chou.Restrains(EarthlyBranch.Hai));
        Assert.True(EarthlyBranch.Chou.Restrains(EarthlyBranch.Zi));
        
        Assert.True(EarthlyBranch.Hai.RestrainsBy(EarthlyBranch.Chen));
        Assert.True(EarthlyBranch.Hai.RestrainsBy(EarthlyBranch.Wei));
        Assert.True(EarthlyBranch.Hai.RestrainsBy(EarthlyBranch.Xu));
        Assert.True(EarthlyBranch.Hai.RestrainsBy(EarthlyBranch.Chou));
        Assert.True(EarthlyBranch.Zi.RestrainsBy(EarthlyBranch.Chen));
        Assert.True(EarthlyBranch.Zi.RestrainsBy(EarthlyBranch.Wei));
        Assert.True(EarthlyBranch.Zi.RestrainsBy(EarthlyBranch.Xu));
        Assert.True(EarthlyBranch.Zi.RestrainsBy(EarthlyBranch.Chou));
    }

    [Fact]
    public void MetalRestrainsWood_IsTrue()
    {
        Assert.True(EarthlyBranch.Shen.Restrains(EarthlyBranch.Yin));
        Assert.True(EarthlyBranch.Shen.Restrains(EarthlyBranch.Mao));
        Assert.True(EarthlyBranch.You.Restrains(EarthlyBranch.Yin));
        Assert.True(EarthlyBranch.You.Restrains(EarthlyBranch.Mao));
        
        Assert.True(EarthlyBranch.Yin.RestrainsBy(EarthlyBranch.Shen));
        Assert.True(EarthlyBranch.Yin.RestrainsBy(EarthlyBranch.You));
        Assert.True(EarthlyBranch.Mao.RestrainsBy(EarthlyBranch.Shen));
        Assert.True(EarthlyBranch.Mao.RestrainsBy(EarthlyBranch.You));
    }

    [Fact]
    public void WaterRestrainsFire_IsTrue()
    {
        Assert.True(EarthlyBranch.Hai.Restrains(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.Hai.Restrains(EarthlyBranch.Wu));
        Assert.True(EarthlyBranch.Zi.Restrains(EarthlyBranch.Si));
        Assert.True(EarthlyBranch.Zi.Restrains(EarthlyBranch.Wu));
        
        Assert.True(EarthlyBranch.Si.RestrainsBy(EarthlyBranch.Hai));
        Assert.True(EarthlyBranch.Si.RestrainsBy(EarthlyBranch.Zi));
        Assert.True(EarthlyBranch.Wu.RestrainsBy(EarthlyBranch.Hai));
        Assert.True(EarthlyBranch.Wu.RestrainsBy(EarthlyBranch.Zi));
    }
}