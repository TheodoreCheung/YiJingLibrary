using System;

namespace YiJingLibrary.SixLines;

/// <summary>
/// 六爻盘构建器接口
/// </summary>
public interface ISixLinesDivinationBuilder
{
    /// <summary>
    /// 基础六爻盘。
    /// 只包含起卦时间、本卦和变卦信息。纳甲，安世应，配六亲、六神等信息在<see cref="Build"/>方法中实现。
    /// </summary>
    SixLinesDivination BasicDivination { get; }

    /// <summary>
    /// 配置构建器选项。
    /// </summary>
    /// <param name="configuration">配置操作。</param>
    /// <returns>返回六爻盘构建器。</returns>
    ISixLinesDivinationBuilder Configure(Action<DefaultBuilderOptions> configuration);
    
    /// <summary>
    /// 构建六爻盘。
    /// </summary>
    /// <returns>返回构建好的六爻盘。</returns>
    SixLinesDivination Build();
}