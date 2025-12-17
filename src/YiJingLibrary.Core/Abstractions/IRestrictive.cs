namespace YiJingLibrary.Core.Abstractions;

/// <summary>
/// 元素相克接口，定义了易经元素之间的相克关系。
/// </summary>
/// <typeparam name="T"><see cref="YiJingElement"/>的派生类。</typeparam>
public interface IRestrictive<in T> where T : YiJingElement
{
    /// <summary>
    /// 判断另一个<see cref="YiJingElement"/>是否与当前<see cref="YiJingElement"/>相克。
    /// </summary>
    /// <param name="other">要比较的另一个<see cref="YiJingElement"/>元素。</param>
    /// <returns>如果另一个元素与当前元素为相克关系则返回true，否则返回false。</returns>
    bool IsRestrains(T other);

    /// <summary>
    /// 判断当前<see cref="YiJingElement"/>是否克另一个<see cref="YiJingElement"/>。
    /// </summary>
    /// <param name="other">被当前元素所克的<see cref="YiJingElement"/>元素。</param>
    /// <returns>如果当前元素克另一个元素则返回true，否则返回false。</returns>
    bool Restrains(T other);

    /// <summary>
    /// 判断当前<see cref="YiJingElement"/>是否被另一个<see cref="YiJingElement"/>所克。
    /// </summary>
    /// <param name="other">克当前元素的<see cref="YiJingElement"/>元素。</param>
    /// <returns>如果当前元素被另一个元素所克则返回true，否则返回false。</returns>
    bool RestrainsBy(T other);
}