using System;
using System.Collections.Generic;
using YiJingLibrary.Core.Abstractions;

namespace YiJingLibrary.Core;

/// <summary>
/// 八卦
/// </summary>
public class Trigram : YiJingElement
{
    /// <summary>
    /// 五行。
    /// </summary>
    public FivePhase FivePhase { get; }

    /// <summary>
    /// 卦中三个爻的信息。
    /// </summary>
    protected readonly List<Line> LineList = new(6);

    /// <summary>
    /// 卦中所有的爻。
    /// </summary>
    public IReadOnlyCollection<Line> Lines => LineList;

    /// <summary>
    /// 获取指定爻的信息。
    /// </summary>
    /// <remarks>索引从1到3分别表示初爻、二爻、三爻。</remarks>
    /// <param name="index">爻的索引。</param>
    /// <exception cref="IndexOutOfRangeException">当索引超出范围时抛出异常。</exception>
    public virtual Line this[byte index]
    {
        get
        {
            return index switch
            {
                1 => LineList[0],
                2 => LineList[1],
                3 => LineList[2],
                _ => throw new IndexOutOfRangeException()
            };
        }
    }

    /// <summary>
    /// 卦的卦辞、彖辞、象辞。
    /// </summary>
    public string Statement
    {
        get => ToString(field) ?? string.Empty;
        set;
    }

    /// <inheritdoc />
    /// <remarks>
    /// 利用byte的8个位，低4位表示内卦(第4位不用)。<br/>
    /// 八卦只用低4位，bit从右到左分别表示初爻、二爻、三爻。为1表示阳爻，为0表示阴爻。<br />
    /// 例如乾卦：0b0000_0111
    /// </remarks>
    protected Trigram(byte value, string label, FivePhase fivePhase) : base(value, label)
    {
        FivePhase = fivePhase;
        Statement = $"{nameof(Statement)}_{label}";
        
        Initialize();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    private void Initialize()
    {
        InitializeLines();
    }
    
    /// <summary>
    /// 初始化卦中所有的爻。
    /// </summary>
    protected virtual void InitializeLines()
    {
        for (var i = 1; i <= 3; i++)
        {
            AddLine(i, i - 1);
        }
    }
    
    /// <summary>
    /// 添加一个爻。
    /// </summary>
    /// <param name="lineValue">爻的值。</param>
    /// <param name="lineValueIndex">爻的二进制值bit索引。</param>
    protected void AddLine(int lineValue, int lineValueIndex)
    {
        var line = Line.FromValue((byte)lineValue)
            .WithYinYang((byte)(Value & 1 << lineValueIndex) == 0 ? YinYang.Yin : YinYang.Yang);
        LineList.Add(line);
    }

    /// <summary>
    /// 乾
    /// </summary>
    public static Trigram Qian => new(0b0000_0111, nameof(Qian), FivePhase.Metal);
    
    /// <summary>
    /// 兑
    /// </summary>
    public static Trigram Dui => new(0b0000_0011, nameof(Dui), FivePhase.Metal);
    
    /// <summary>
    /// 离
    /// </summary>
    public static Trigram Li => new(0b0000_0101, nameof(Li), FivePhase.Fire);
    
    /// <summary>
    /// 震
    /// </summary>
    public static Trigram Zhen => new(0b0000_0001, nameof(Zhen), FivePhase.Wood);
    
    /// <summary>
    /// 巽
    /// </summary>
    public static Trigram Xun => new(0b0000_0110, nameof(Xun), FivePhase.Wood);
    
    /// <summary>
    /// 坎
    /// </summary>
    public static Trigram Kan => new(0b0000_0010, nameof(Kan), FivePhase.Water);
    
    /// <summary>
    /// 艮
    /// </summary>
    public static Trigram Gen => new(0b0000_0100, nameof(Gen), FivePhase.Earth);
    
    /// <summary>
    /// 坤
    /// </summary>
    public static Trigram Kun => new(0b0000_0000, nameof(Kun), FivePhase.Earth);
}