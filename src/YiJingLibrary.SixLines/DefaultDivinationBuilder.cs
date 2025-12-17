using System;
using YiJingLibrary.SixLines.Extensions;

namespace YiJingLibrary.SixLines;

/// <summary>
/// 默认的六爻盘构建器
/// </summary>
public sealed class DefaultDivinationBuilder : ISixLinesDivinationBuilder
{
    /// <inheritdoc />
    public required SixLinesDivination BasicDivination { get; init; }

    private readonly DefaultBuilderOptions _options = new();

    /// <inheritdoc />
    public ISixLinesDivinationBuilder Configure(Action<DefaultBuilderOptions> configuration)
    {
        configuration.Invoke(_options);
        
        return this;
    }

    /// <inheritdoc />
    public SixLinesDivination Build()
    {
        return BasicDivination.CalculateLinePosition()
            .AssignStemBranch()
            .AssignSixKins()
            .FindHiddenSpirit()
            .AssignSixSpirits()
            .AssignFourSymbols()
            .AssignSpiritsAndMalignities();
    }
}