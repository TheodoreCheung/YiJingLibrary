namespace YiJingLibrary.Core.Abstractions;

/// <summary>
/// 爻接口，定义了爻的基本操作。
/// </summary>
public interface ILine
{
    /// <summary>
    /// 为爻设置阴阳属性。
    /// </summary>
    /// <param name="yinYang">阴阳属性。</param>
    /// <returns>返回设置了阴阳属性的爻。</returns>
    Line WithYinYang(YinYang yinYang);
}

