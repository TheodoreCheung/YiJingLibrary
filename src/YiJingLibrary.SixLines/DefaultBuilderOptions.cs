using System.Globalization;
using System.Threading;

namespace YiJingLibrary.SixLines;

/// <summary>
/// 六爻盘构建器选项。
/// </summary>
public class DefaultBuilderOptions
{
    /// <summary>
    /// 特定文化区域信息
    /// </summary>
    public CultureInfo CultureInfo { get; private set; } = CultureInfo.GetCultureInfo("zh-CN");
        
    /// <summary>
    /// 设置特定文化区域信息。
    /// </summary>
    /// <param name="cultureInfo">文化区域信息。</param>
    /// <returns>返回当前实例，支持链式调用。</returns>
    public DefaultBuilderOptions SetCulture(CultureInfo cultureInfo)
    {
        CultureInfo = cultureInfo;
        Thread.CurrentThread.CurrentCulture = CultureInfo;
        
        return this;
    }

    /// <summary>
    /// 设置特定文化区域信息。
    /// </summary>
    /// <param name="cultureName">文化区域名称，如en-US, zh-CN等。</param>
    /// <returns>返回当前实例，支持链式调用。</returns>
    public DefaultBuilderOptions SetCulture(string cultureName)
    {
        var cultureInfo = CultureInfo.GetCultureInfo(cultureName);
        return SetCulture(cultureInfo);
    }
}