using System;
using System.Linq.Expressions;
using System.Threading;
using YiJingLibrary.Core.Properties;

namespace YiJingLibrary.Core.Internationalization;

/// <summary>
/// 国际化资源访问助手类
/// 提供基于当前线程区域性设置的本地化文本获取功能
/// </summary>
public static class L
{
    /// <summary>
    /// 根据资源键名获取对应区域性的本地化文本
    /// </summary>
    /// <param name="resourceKey">资源键名</param>
    /// <returns>返回对应区域性的本地化文本，如果未找到则返回null</returns>
    /// <example>
    /// 使用示例:
    /// <code>
    /// string text = L.GetText("HelloWorld");
    /// Console.WriteLine(text);
    /// </code>
    /// </example>
    public static string? GetText(string resourceKey) =>
        Resources.ResourceManager.GetString(resourceKey, Thread.CurrentThread.CurrentCulture);
    
    /// <summary>
    /// 通过表达式获取资源文本，提供强类型的方式来访问资源
    /// </summary>
    /// <typeparam name="TResource">资源类型</typeparam>
    /// <param name="expression">成员访问表达式</param>
    /// <returns>返回对应区域性的本地化文本，如果未找到则返回null</returns>
    /// <exception cref="ArgumentException">当表达式不是成员访问表达式时抛出</exception>
    /// <example>
    /// 使用示例:
    /// 假设有一个资源类MyResources，其中包含名为WelcomeMessage的属性
    /// <code>
    /// string text = L.GetString((MyResources u) => u.WelcomeMessage);
    /// Console.WriteLine(text);
    /// </code>
    /// </example>
    public static string? GetString<TResource>(Expression<Func<TResource, string>> expression) where TResource : class
    {
        if (expression.Body is MemberExpression memberExpression)
        {
            var resourceKey = memberExpression.Member.Name;
            return GetText(resourceKey);
        }

        throw new ArgumentException("Expression must be a MemberExpression (e.g., u => u.Name).");
    }
}