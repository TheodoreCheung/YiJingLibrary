using System;
using YiJingLibrary.Core;

namespace YiJingLibrary.SixLines.Extensions;

/// <summary>
/// 爻扩展。
/// </summary>
public static class LineExtensions
{
    /// <summary>
    /// 扩展爻的属性。简化读写。
    /// </summary>
    /// <param name="line"></param>
    extension(Line line)
    {
        /// <summary>
        /// 爻辞。
        /// </summary>
        public Hexagram.LineStatement? LineStatement
        {
            get => line.Attributes.Get<Hexagram.LineStatement>();
            internal set
            {
                if (value is null) 
                    throw new InvalidOperationException("The line statement can not be null.");
                line.Attributes.Set(value);
            }
        }

        /// <summary>
        /// 世应。
        /// </summary>
        public Position? Position
        {
            get => line.Attributes.Get<Position>();
            internal set
            {
                if (value is null) 
                    throw new InvalidOperationException("The position can not be null.");
                line.Attributes.Set(value);
            }
        }
        
        /// <summary>
        /// 干支。
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public StemBranch StemBranch
        {
            get => line.Attributes.Get<StemBranch>() ?? throw new InvalidOperationException("The line does not have stem branch.");
            internal set => line.Attributes.Set(value);
        }
        
        /// <summary>
        /// 六亲。
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public SixKin SixKin
        {
            get => line.Attributes.Get<SixKin>() ?? throw new InvalidOperationException("The line does not have six kin.");
            internal set => line.Attributes.Set(value);
        }
        
        /// <summary>
        /// 伏神。
        /// </summary>
        public HiddenSpirit? HiddenSpirit
        {
            get => line.Attributes.Get<HiddenSpirit>();
            internal set
            {
                if (value is null) 
                    throw new InvalidOperationException("The hidden spirit can not be null.");
                line.Attributes.Set(value);
            }
        }
        
        /// <summary>
        /// 六神。
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public SixSpirit SixSpirit
        {
            get => line.Attributes.Get<SixSpirit>() ?? throw new InvalidOperationException("The line does not have six spirit.");
            internal set => line.Attributes.Set(value);
        }

        /// <summary>
        /// 四象。
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public FourSymbol FourSymbol
        {
            get => line.Attributes.Get<FourSymbol>() ?? throw new InvalidOperationException("The line does not have four symbol.");
            internal set => line.Attributes.Set(value);
        }
    }
}