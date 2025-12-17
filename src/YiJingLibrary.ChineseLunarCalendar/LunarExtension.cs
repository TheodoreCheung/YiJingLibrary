using System;

namespace YiJingLibrary.ChineseLunarCalendar;

/// <summary>
/// <see cref="LunarAdapter"/>扩展类
/// </summary>
public static class LunarExtension
{
    /// <param name="dt">要转换的DateTimeOffset时间。</param>
    extension(DateTimeOffset dt)
    {
        /// <summary>
        /// 将<see cref="DateTimeOffset"/>转换为农历干支。
        /// </summary>
        /// <returns>返回转换后的农历干支。</returns>
        public LunarStemBranch ToLunarStemBranch()
        {
            return LunarAdapter.AdaptToStemBranch(dt);
        }

        /// <summary>
        /// 将<see cref="DateTimeOffset"/>转换为农历日期。
        /// </summary>
        /// <returns>返回转换后的农历日期。</returns>
        public DateTime ToLunarDateTime()
        {
            return LunarAdapter.AdaptToDateTime(dt);
        }
    }
}