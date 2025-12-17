using System;
using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.Core;

/// <summary>
/// 六十四卦。
/// </summary>
public partial class Hexagram : Trigram
{
    /// <summary>
    /// 卦宫。
    /// </summary>
    public Trigram Palace { get; }

    /// <summary>
    /// 外卦。
    /// </summary>
    public Trigram Upper { get; }

    /// <summary>
    /// 内卦。
    /// </summary>
    public Trigram Lower { get; }

    /// <inheritdoc />
    /// <remarks>索引从1到6分别表示初爻、二爻、三爻、四爻、五爻、上爻。</remarks>
    public override Line this[byte index]
    {
        get
        {
            return index switch
            {
                1 => LineList[0],
                2 => LineList[1],
                3 => LineList[2],
                4 => LineList[3],
                5 => LineList[4],
                6 => LineList[5],
                _ => throw new IndexOutOfRangeException()
            };
        }
    }

    /// <summary>
    /// 构造函数。
    /// </summary>
    /// <param name="upper">外卦。</param>
    /// <param name="lower">内卦。</param>
    /// <param name="label">卦名标签。</param>
    /// <param name="palace">卦宫。</param>
    /// <remarks>
    /// 利用byte的8个位，高4位表示外卦(第8位不用)；低4位表示内卦(第4位不用)。<br/>
    /// bit从右到左分别表示初爻、二爻、三爻。四爻、五爻、上爻。为1表示阳爻，为0表示阴爻。<br />
    /// 例如乾卦：0b0111_0111
    /// </remarks>
    private Hexagram(Trigram upper, Trigram lower, string label, Trigram palace)
        : base((byte)(upper << 4 | lower), label, palace.FivePhase)
    {
        Upper = upper;
        Lower = lower;
        Palace = palace;
    }
    
    /// <inheritdoc />
    protected override void InitializeLines()
    {
        // 父类初始化内卦三个爻。
        base.InitializeLines();
        
        // 初始化外卦三个爻。
        for (var i = 4; i <= 6; i++)
        {
            AddLine(i, i);
        }
        
        // 初始化六个爻的爻辞。
        for (byte i = 1; i <= 6; i++)
        {
            LineList[i - 1].Attributes.Set(new LineStatement(i, $"{ElementName}-{i}"));
        }
    }
    
    /// <summary>
    /// 爻辞。
    /// </summary>
    /// <param name="value">爻辞的值。</param>
    /// <param name="label">爻辞的标签。</param>
    public class LineStatement(byte value, string label) : YiJingElement(value, label)
    {
    }
}