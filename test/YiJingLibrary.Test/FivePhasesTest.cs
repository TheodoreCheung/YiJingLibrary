using YiJingLibrary.Core;

namespace YiJingLibrary.Test;

public class FivePhaseTest
{
    [Fact]
    public void MetalGeneratesWater_IsTrue()
    {
        Assert.True(FivePhase.Metal.Generates(FivePhase.Water));
        Assert.True(FivePhase.Water.GeneratesBy(FivePhase.Metal));
    }

    [Fact]
    public void WaterGeneratesWood_IsTrue()
    {
        Assert.True(FivePhase.Water.Generates(FivePhase.Wood));
        Assert.True(FivePhase.Wood.GeneratesBy(FivePhase.Water));
    }

    [Fact]
    public void WoodGeneratesFire_IsTrue()
    {
        Assert.True(FivePhase.Wood.Generates(FivePhase.Fire));
        Assert.True(FivePhase.Fire.GeneratesBy(FivePhase.Wood));
    }
    
    [Fact]
    public void FireGeneratesEarth_IsTrue()
    {
        Assert.True(FivePhase.Fire.Generates(FivePhase.Earth));
        Assert.True(FivePhase.Earth.GeneratesBy(FivePhase.Fire));
    }

    [Fact]
    public void EarthGeneratesMetal_IsTrue()
    {
        Assert.True(FivePhase.Earth.Generates(FivePhase.Metal));
        Assert.True(FivePhase.Metal.GeneratesBy(FivePhase.Earth));
    }

    [Fact]
    public void MetalGeneratesWood_IsFalse()
    {
        Assert.False(FivePhase.Metal.Generates(FivePhase.Wood));
        Assert.False(FivePhase.Wood.Generates(FivePhase.Metal));
    }
    
    [Fact]
    public void WaterGeneratesEarth_IsFalse()
    {
        Assert.False(FivePhase.Water.Generates(FivePhase.Earth));
        Assert.False(FivePhase.Earth.Generates(FivePhase.Water));
    }

    [Fact]
    public void MetalRestrainsWood_IsTrue()
    {
        Assert.True(FivePhase.Metal.Restrains(FivePhase.Wood));
        Assert.True(FivePhase.Wood.RestrainsBy(FivePhase.Metal));
    }

    [Fact]
    public void WaterRestrainsFire_IsTrue()
    {
        Assert.True(FivePhase.Water.Restrains(FivePhase.Fire));
        Assert.True(FivePhase.Fire.RestrainsBy(FivePhase.Water));
    }

    [Fact]
    public void WoodRestrainsEarth_IsTrue()
    {
        Assert.True(FivePhase.Wood.Restrains(FivePhase.Earth));
        Assert.True(FivePhase.Earth.RestrainsBy(FivePhase.Wood));
    }

    [Fact]
    public void FireRestrainsMetal_IsTrue()
    {
        Assert.True(FivePhase.Fire.Restrains(FivePhase.Metal));
        Assert.True(FivePhase.Metal.RestrainsBy(FivePhase.Fire));
    }

    [Fact]
    public void EarthRestrainsWater_IsTrue()
    {
        Assert.True(FivePhase.Earth.Restrains(FivePhase.Water));
        Assert.True(FivePhase.Water.RestrainsBy(FivePhase.Earth));
    }

    [Fact]
    public void SameFivePhaseEqual_IsTrue()
    {
        var a = FivePhase.Metal;
        var b = FivePhase.Metal;
        Assert.True(a.Equals(b));
        Assert.True(a == b);
    }

    [Fact]
    public void DifferentFivePhaseEqual_IsFalse()
    {
        var a = FivePhase.Water;
        var b = FivePhase.Earth;
        Assert.False(a.Equals(b));
        Assert.False(a == b);
    }

    [Fact]
    public void FivePhaseValueGreaterThan_IsTrue()
    {
        Assert.True(FivePhase.Earth > FivePhase.Fire);
        Assert.True(FivePhase.Fire > FivePhase.Wood);
        Assert.True(FivePhase.Wood > FivePhase.Water);
        Assert.True(FivePhase.Water > FivePhase.Metal);
    }

    [Fact]
    public void FivePhaseValueLessThan_IsTrue()
    {
        Assert.True(FivePhase.Metal < FivePhase.Water);
        Assert.True(FivePhase.Water < FivePhase.Wood);
        Assert.True(FivePhase.Wood < FivePhase.Fire);
        Assert.True(FivePhase.Fire < FivePhase.Earth);
    }
}