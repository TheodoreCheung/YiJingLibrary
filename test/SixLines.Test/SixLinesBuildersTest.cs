using YiJingLibrary.Core;
using SixLine = YiJingLibrary.SixLines.SixLines;

namespace SixLinesLibrary.Test;

public class SixLinesBuildersTest
{
    [Fact]
    public void CreateManualDivinationBuilder_WithValidParameters_ReturnsBuilder()
    {
        var solar = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);
        var fourSymbols = new[]
        {
            FourSymbol.YoungYang, FourSymbol.YoungYin, FourSymbol.OldYang,
            FourSymbol.OldYin, FourSymbol.YoungYang, FourSymbol.YoungYin
        };

        var builder = SixLine.CreateManualDivinationBuilder(solar, fourSymbols);

        Assert.NotNull(builder);
    }

    [Fact]
    public void CreateManualDivinationBuilder_WithInvalidArrayLength_ThrowsException()
    {
        var solar = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);
        var invalidFourSymbols = new[] { FourSymbol.YoungYang }; // Only 1 element

        Assert.Throws<ArgumentException>(() => 
            SixLine.CreateManualDivinationBuilder(solar, invalidFourSymbols));
    }

    [Fact]
    public void CreateNumericalDivinationBuilder_WithValidParameters_ReturnsBuilder()
    {
        var solar = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);

        var builder = SixLine.CreateNumericalDivinationBuilder(solar, 10, 20);

        Assert.NotNull(builder);
    }

    [Fact]
    public void CreateNumericalDivinationBuilder_WithNegativeNumbers_ThrowsException()
    {
        var solar = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);

        Assert.Throws<ArgumentException>(() => 
            SixLine.CreateNumericalDivinationBuilder(solar, -1, 20));
        Assert.Throws<ArgumentException>(() => 
            SixLine.CreateNumericalDivinationBuilder(solar, 10, -1));
    }

    [Fact]
    public void CreateTimeDivinationBuilder_WithValidParameters_ReturnsBuilder()
    {
        var solar = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);

        var builder = SixLine.CreateTimeDivinationBuilder(solar);

        Assert.NotNull(builder);
    }

    [Fact]
    public void CreateSpecifyDivinationBuilder_WithValidParameters_ReturnsBuilder()
    {
        var solar = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);
        const byte originalHexagramValue = 0b0111_0111; // The Creative
        const byte changedHexagramValue = 0b0000_0000; // The Receptive

        var builder = SixLine.CreateSpecifyDivinationBuilder(
            solar, originalHexagramValue, changedHexagramValue);

        Assert.NotNull(builder);
    }

    [Fact]
    public void CreateSpecifyDivinationBuilder_WithoutChangedHexagram_ReturnsBuilder()
    {
        var solar = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);
        const byte originalHexagramValue = 0b0111_0111; // The Creative

        var builder = SixLine.CreateSpecifyDivinationBuilder(
            solar, originalHexagramValue);

        Assert.NotNull(builder);
    }

    [Fact]
    public void Builder_BuildMethod_CreatesValidDivination()
    {
        var solar = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);
        const byte originalHexagramValue = 0b0111_0111; // The Creative
        const byte changedHexagramValue = 0b0000_0000; // The Receptive

        var builder = SixLine.CreateSpecifyDivinationBuilder(
            solar, originalHexagramValue, changedHexagramValue);
        var divination = builder.Build();

        Assert.NotNull(divination);
        Assert.NotNull(divination.InquiryTime);
        Assert.NotNull(divination.Original);
        Assert.NotNull(divination.Changed);
        Assert.Equal(Hexagram.TheCreative, divination.Original);
        Assert.Equal(Hexagram.TheReceptive, divination.Changed);
    }

    [Fact]
    public void Builder_ConfigureMethod_WorksCorrectly()
    {
        var solar = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);
        const byte originalHexagramValue = 0b0111_0111; // The Creative

        var builder = SixLine.CreateSpecifyDivinationBuilder(
            solar, originalHexagramValue);
        
        // Just test that we can configure without exceptions
        var configuredBuilder = builder.Configure(options => options.SetCulture("zh-CN"));
        var divination = configuredBuilder.Build();

        Assert.NotNull(divination);
    }
}