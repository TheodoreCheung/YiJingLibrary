namespace YiJingLibrary.Core.Abstractions;

/// <summary>
/// 元素关系接口，定义了易经元素之间的特殊关系（如相冲、相合等）。
/// </summary>
/// <typeparam name="T"><see cref="YiJingElement"/>的派生类。</typeparam>
public interface IRelationship<in T> where T : YiJingElement
{
    /// <summary>
    /// 判断当前<see cref="YiJingElement"/>是否与另一个<see cref="YiJingElement"/>相冲。
    /// </summary>
    /// <param name="other">要比较的另一个<see cref="YiJingElement"/>元素。</param>
    /// <returns>如果两个元素相冲则返回true，否则返回false。</returns>
    bool IsClashing(T other);

    /// <summary>
    /// 判断当前<see cref="YiJingElement"/>是否与另一个<see cref="YiJingElement"/>相合。
    /// </summary>
    /// <param name="other">要比较的另一个<see cref="YiJingElement"/>元素。</param>
    /// <returns>如果两个元素相合则返回true，否则返回false。</returns>
    bool IsCombining(T other);
}