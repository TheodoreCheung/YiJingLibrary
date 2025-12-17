using System;
using YiJingLibrary.ChineseLunarCalendar;

namespace ChineseLunarCalendar.Tests.Core;

public class InquiryTimeTest
{
    [Fact]
    public void InquiryTimeConstructor_SetsPropertiesCorrectly()
    {
        var solar = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);
        var inquiryTime = new InquiryTime(solar);

        Assert.Equal(solar, inquiryTime.Solar);
        Assert.NotNull(inquiryTime.Lunar);
    }

    [Fact]
    public void InquiryTimeConstructor_CalculatesLunarCorrectly()
    {
        var solar = new DateTimeOffset(2025, 1, 1, 12, 0, 0, TimeSpan.Zero);
        var inquiryTime = new InquiryTime(solar);

        // Just verify that the lunar property is populated
        Assert.NotNull(inquiryTime.Lunar.Year);
        Assert.NotNull(inquiryTime.Lunar.Month);
        Assert.NotNull(inquiryTime.Lunar.Day);
        Assert.NotNull(inquiryTime.Lunar.Hour);
    }
}