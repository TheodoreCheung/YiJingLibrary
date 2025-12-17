using System;
using System.Collections.Generic;
using System.Linq;
using YiJingLibrary.ChineseLunarCalendar;
using YiJingLibrary.Core;
using YiJingLibrary.SixLines.Extensions;

namespace YiJingLibrary.SixLines;

/// <summary>
/// 六十四卦建造者
/// </summary>
public static class SixLines
{
    /// <summary>
    /// 手工起卦构建器
    /// </summary>
    /// <param name="solar">阳历时间。</param>
    /// <param name="fourSymbolsElements">从初爻到上爻的四象。</param>
    /// <param name="customBuilder">自定义构建器。</param>
    /// <returns>返回六爻盘构建器。</returns>
    /// <exception cref="ArgumentException">当fourSymbolsElements数组元素数量不等于6时抛出此异常。</exception>
    public static ISixLinesDivinationBuilder CreateManualDivinationBuilder(
        DateTimeOffset solar, 
        IEnumerable<FourSymbol> fourSymbolsElements,
        Func<SixLinesDivination, ISixLinesDivinationBuilder>? customBuilder = null)
    {
        var fourSymbols = fourSymbolsElements.ToArray();
        
        if (fourSymbols.Length != 6)
            throw new ArgumentException("fourSymbols array must contain exactly 6 elements");

        byte original = 0;
        byte changed = 0;
        
        for (var i = 0; i < 6; i++)
        {
            if (fourSymbols[i].Equals(FourSymbol.YoungYang))
            {
                original |= SetYangBit(i);
                changed |= SetYangBit(i);
            }

            if (fourSymbols[i].Equals(FourSymbol.OldYang))
            {
                original |= SetYangBit(i);
            }

            if (fourSymbols[i].Equals(FourSymbol.OldYin))
            {
                changed |= SetYangBit(i);
            }
        }

        return original == changed
            ? CreateSpecifyDivinationBuilder(solar, original, null, customBuilder)
            : CreateSpecifyDivinationBuilder(solar, original, changed, customBuilder);

        byte SetYangBit(int bitIndex)
        {
            return bitIndex > 2 ? (byte)(1 << (bitIndex + 1)) : (byte)(1 << bitIndex);
        }
    }

    /// <summary>
    /// 随机数起卦构建器
    /// </summary>
    /// <param name="solar">阳历时间。</param>
    /// <param name="upperNumber">上卦随机数。</param>
    /// <param name="lowerNumber">下卦随机数。</param>
    /// <param name="customBuilder">自定义构建器。</param>
    /// <returns>返回六爻盘构建器。</returns>
    /// <exception cref="ArgumentException">当upperNumber或lowerNumber为负数时抛出此异常。</exception>
    public static ISixLinesDivinationBuilder CreateNumericalDivinationBuilder(
        DateTimeOffset solar, 
        int upperNumber, 
        int lowerNumber, 
        Func<SixLinesDivination, ISixLinesDivinationBuilder>? customBuilder = null)
    {
        if (upperNumber < 0 || lowerNumber < 0)
            throw new ArgumentException("upperNumber and lowerNumber must be non-negative.");

        var upper = Trigram.GetByRandomNumber(upperNumber);
        var lower = Trigram.GetByRandomNumber(lowerNumber);
        var original = (byte)(upper << 4 | lower);
        
        // 计算动爻位置
        var changingLine = (upperNumber + lowerNumber + solar.ToLunarStemBranch().Day.EarthlyBranch) % 6;
        if (changingLine > 2) changingLine += 1;
        
        var changed = (byte)(original ^ (1 << changingLine));

        return CreateSpecifyDivinationBuilder(solar, original, changed, customBuilder);
    }

    /// <summary>
    /// 时间起卦构建器
    /// </summary>
    /// <param name="solar">阳历时间。</param>
    /// <param name="customBuilder">自定义构建器。</param>
    /// <returns>返回六爻盘构建器。</returns>
    public static ISixLinesDivinationBuilder CreateTimeDivinationBuilder(
        DateTimeOffset solar, 
        Func<SixLinesDivination, ISixLinesDivinationBuilder>? customBuilder = null)
    {
        var lunarStemBranch = solar.ToLunarStemBranch();
        var year = (byte)lunarStemBranch.Year.EarthlyBranch;
        var hour = (byte)lunarStemBranch.Hour.EarthlyBranch;

        var (_, month, day) = solar.ToLunarDateTime();

        var upper = Trigram.GetByRandomNumber(year + month + day);
        var lower = Trigram.GetByRandomNumber(year + month + day + hour);
        
        var original = (byte)((upper << 4) | lower);
        
        var changingLine = (year + month + day + hour) % 6;
        if (changingLine > 2) changingLine += 1;
        
        var changed = (byte)(original ^ (1 << changingLine));
        
        return CreateSpecifyDivinationBuilder(solar, original, changed, customBuilder);
    }

    /// <summary>
    /// 指定内、外卦起卦构建器
    /// </summary>
    /// <param name="solar">阳历时间。</param>
    /// <param name="originalHexagramValue">主卦值。</param>
    /// <param name="changedHexagramValue">变卦值。</param>
    /// <param name="customBuilder">自定义构建器。</param>
    /// <returns>返回六爻盘构建器。</returns>
    public static ISixLinesDivinationBuilder CreateSpecifyDivinationBuilder(
        DateTimeOffset solar, 
        byte originalHexagramValue, 
        byte? changedHexagramValue = null,
        Func<SixLinesDivination, ISixLinesDivinationBuilder>? customBuilder = null)
    {
        // 起卦时间
        var inquiryTime = new InquiryTime(solar);

        // 主卦
        var original = Hexagram.FromValue(originalHexagramValue);
        
        // 变卦
        var changed = changedHexagramValue.HasValue ? Hexagram.FromValue(changedHexagramValue.Value) : null;

        var basicDivination = new SixLinesDivination(inquiryTime, original, changed);

        return customBuilder is null
            ? new DefaultDivinationBuilder { BasicDivination = basicDivination }
            : customBuilder(basicDivination);
    }
}