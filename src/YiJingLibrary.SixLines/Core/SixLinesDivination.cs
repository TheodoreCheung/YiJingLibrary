using System.Collections.Generic;
using System.Linq;
using System.Text;
using YiJingLibrary.Core;
using YiJingLibrary.ChineseLunarCalendar;
using YiJingLibrary.Core.Internationalization;
using YiJingLibrary.SixLines.Extensions;

namespace YiJingLibrary.SixLines;

/// <summary>
/// 六爻卦
/// </summary>
public class SixLinesDivination
{
    /// <summary>
    /// 起卦时间
    /// </summary>
    public InquiryTime InquiryTime { get; }

    /// <summary>
    /// 神煞
    /// </summary>
    internal readonly List<SpiritAndMalignity> SpiritAndMalignityList = [];

    /// <summary>
    /// 神煞
    /// </summary>
    public IReadOnlyCollection<SpiritAndMalignity> SpiritAndMalignity => SpiritAndMalignityList.AsReadOnly();

    /// <summary>
    /// 主卦
    /// </summary>
    public Hexagram Original { get; }

    /// <summary>
    /// 变卦
    /// </summary>
    public Hexagram? Changed { get; }

    /// <summary>
    /// 初始化<see cref="SixLinesDivination"/>类的新实例。
    /// </summary>
    /// <param name="inquiryTime">起卦时间。</param>
    /// <param name="original">主卦。</param>
    /// <param name="changed">变卦。</param>
    internal SixLinesDivination(InquiryTime inquiryTime, Hexagram original, Hexagram? changed = null)
    {
        InquiryTime = inquiryTime;
        Original = original;
        Changed = changed;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"# {Original}{(Changed is null ? "" : $" {L.GetText("D_To")} {Changed}")} {L.GetText("D_Hexagram")}\n");
        
        sb.AppendLine($"## {L.GetText("D_InquiryTime")}");
        sb.AppendLine($"**{L.GetText("D_GregorianCalendar")}**: _{InquiryTime.Solar.ToString(L.GetText("D_DateFormat"))}_  ");
        sb.AppendLine($"**{L.GetText("D_LunarCalendar")}**: _{InquiryTime.Lunar}_  ");
        sb.AppendLine($"**{L.GetText("D_DayEmptiness")}**: _{string.Join("、", InquiryTime.Lunar.Day.EmptyBranches.Select(b => b.ToString()))}_  \n");

        sb.AppendLine($"## {L.GetText("D_OriginalHexagram")}");
        sb.AppendLine($"**{L.GetText("D_HexagramName")}**: _{Original}{(string.IsNullOrWhiteSpace(Original.Feature.ToString()) ? "" : $"（{Original.Feature}{L.GetText("D_Hexagram")}）")}_  ");
        sb.AppendLine($"**{L.GetText("D_HexagramPalace")}**: _{Original.Palace}{L.GetText("D_Palace")}_  ");
        sb.AppendLine($"**{L.GetText("D_PalaceFivePhases")}**: _{Original.Palace.FivePhase}_  \n");

        sb.AppendLine($"|{L.GetText("D_LinePosition")}|{L.GetText("D_StemBranch")}|{L.GetText("D_SixKin")}|{L.GetText("D_FourSymbols")}|{L.GetText("D_SixSpirits")}|{L.GetText("D_Position")}|{L.GetText("D_HiddenSpiritSixKin")}|{L.GetText("D_HiddenSpiritStemBranch")}|");
        sb.AppendLine("|---|---|---|---|---|---|---|---|");
        for (byte i = 6; i >= 1; i--)
        {
            sb.Append($"|{Original[i]}|{Original[i].StemBranch}|{Original[i].SixKin}|{Original[i].FourSymbol}|{Original[i].SixSpirit}|");
            if (Original[i].Position is not null)
            {
                sb.Append($"{Original[i].Position}|");
            }
            else
            {
                sb.Append("_|");
            }
            
            var hiddenSpirit = Original[i].HiddenSpirit;
            if (hiddenSpirit is not null)
            {
                sb.Append($"{hiddenSpirit.SixKin}|{hiddenSpirit.StemBranch}|  \n");
            }
            else
            {
                sb.Append("_|_|  \n");
            }
        }

        if (Changed is null)
            return sb.ToString();
        
        sb.AppendLine($"\n## {L.GetText("D_ChangedHexagram")}");
        sb.AppendLine($"**{L.GetText("D_HexagramName")}**: _{Changed}{(string.IsNullOrWhiteSpace(Changed.Feature.ToString()) ? "" : $"（{Changed.Feature}{L.GetText("D_Hexagram")}）")}_  ");
        sb.AppendLine($"**{L.GetText("D_HexagramPalace")}**: _{Changed.Palace}{L.GetText("D_Palace")}_  ");
        sb.AppendLine($"**{L.GetText("D_PalaceFivePhases")}**: _{Changed.Palace.FivePhase}_  \n");

        sb.AppendLine($"|{L.GetText("D_LinePosition")}|{L.GetText("D_StemBranch")}|{L.GetText("D_SixKin")}|");
        sb.AppendLine("|---|---|---|");
        for (byte i = 6; i >= 1; i--)
        {
            sb.AppendLine($"|{Changed[i]}|{Changed[i].StemBranch}|{Changed[i].SixKin}|");
        }
        
        sb.AppendLine($"\n## {L.GetText("D_SpiritAndMalignity")}");
        sb.AppendLine($"|{L.GetText("D_SpiritAndMalignityName")}|{L.GetText("D_SpiritAndMalignityBranch")}|");
        sb.AppendLine("|---|---|");
        foreach (var spiritAndMalignity in SpiritAndMalignity)
        {
            sb.AppendLine($"|{spiritAndMalignity}|{string.Join("、", spiritAndMalignity.Branches(this))}|");
        }
        
        return sb.ToString();
    }
}