namespace YiJingLibrary.Core.Abstractions;

/// <summary>
/// 元素相生接口，定义了易经元素之间的相生关系。
/// </summary>
/// <typeparam name="T"><see cref="YiJingElement"/>的派生类。</typeparam>
public interface IGenerative<in T> where T : YiJingElement
{
    /// <summary>
    /// 判断当前<see cref="YiJingElement"/>是否与另一个<see cref="YiJingElement"/>相生。
    /// </summary>
    /// <param name="other">要比较的另一个<see cref="YiJingElement"/>元素。</param>
    /// <returns>如果两个元素相生则返回true，否则返回false。</returns>
    bool IsGenerates(T other);

    /// <summary>
    /// 判断当前<see cref="YiJingElement"/>是否生另一个<see cref="YiJingElement"/>。
    /// </summary>
    /// <param name="other">被当前元素所生的<see cref="YiJingElement"/>元素。</param>
    /// <returns>如果当前元素生另一个元素则返回true，否则返回false。</returns>
    bool Generates(T other);

    /// <summary>
    /// 判断当前<see cref="YiJingElement"/>是否被另一个<see cref="YiJingElement"/>所生。
    /// </summary>
    /// <param name="other">生当前元素的<see cref="YiJingElement"/>元素。</param>
    /// <returns>如果当前元素被另一个元素所生则返回true，否则返回false。</returns>
    bool GeneratesBy(T other);
}