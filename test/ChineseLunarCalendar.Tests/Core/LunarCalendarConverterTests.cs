using YiJingLibrary.ChineseLunarCalendar.Core;

namespace ChineseLunarCalendar.Tests.Core;

public class LunarCalendarConverterTests
{
    [Fact]
    public void ConvertFromSolar_SpringFestival2024_ReturnsFirstDayFirstMonth()
    {
        // Arrange
        var springFestival = new DateTime(2024, 2, 10);

        // Act
        var lunarDate = new LunarCalendarConverter().ConvertFromSolar(springFestival);

        // Assert
        Assert.Equal(2024, lunarDate.Year);
        Assert.Equal(1, lunarDate.Month);
        Assert.Equal(1, lunarDate.Day);
        Assert.False(lunarDate.IsLeapMonth);
    }

    [Fact]
    public void ConvertFromSolar_SpringFestival2023_ReturnsFirstDayFirstMonth()
    {
        // Arrange
        var springFestival = new DateTime(2023, 1, 22);

        // Act
        var lunarDate = new LunarCalendarConverter().ConvertFromSolar(springFestival);

        // Assert
        Assert.Equal(2023, lunarDate.Year);
        Assert.Equal(1, lunarDate.Month);
        Assert.Equal(1, lunarDate.Day);
        Assert.False(lunarDate.IsLeapMonth);
    }

    [Fact]
    public void ConvertFromSolar_NewYearsEve2023_ReturnsLastDayLastMonth()
    {
        // Arrange
        var newYearsEve = new DateTime(2023, 1, 21); // 除夕

        // Act
        var lunarDate = new LunarCalendarConverter().ConvertFromSolar(newYearsEve);

        // Assert
        Assert.Equal(2022, lunarDate.Year); // 还是农历2022年
        Assert.Equal(12, lunarDate.Month);
        Assert.Equal(30, lunarDate.Day);
        Assert.False(lunarDate.IsLeapMonth);
    }

    [Fact]
    public void ConvertFromSolar_LeapMonth2023_ReturnsCorrectLeapMonth()
    {
        // Arrange
        // 2023年闰二月，测试闰二月中的日期
        var leapMonthDate = new DateTime(2023, 3, 22); // 闰二月初一

        // Act
        var lunarDate = new LunarCalendarConverter().ConvertFromSolar(leapMonthDate);

        // Assert
        Assert.Equal(2023, lunarDate.Year);
        Assert.Equal(2, lunarDate.Month);
        Assert.Equal(1, lunarDate.Day);
        Assert.True(lunarDate.IsLeapMonth);
    }

    [Fact]
    public void ConvertFromSolar_NormalMonth2024_ReturnsCorrectDate()
    {
        // Arrange
        var normalDate = new DateTime(2024, 6, 1); // 2024年四月廿五

        // Act
        var lunarDate = new LunarCalendarConverter().ConvertFromSolar(normalDate);

        // Assert
        Assert.Equal(2024, lunarDate.Year);
        Assert.Equal(4, lunarDate.Month);
        Assert.Equal(25, lunarDate.Day);
        Assert.False(lunarDate.IsLeapMonth);
    }

    [Fact]
    public void ConvertFromSolar_LastDayOfMonth_ReturnsCorrectDate()
    {
        // Arrange
        var lastDay = new DateTime(2024, 2, 9); // 2023年腊月三十

        // Act
        var lunarDate = new LunarCalendarConverter().ConvertFromSolar(lastDay);

        // Assert
        Assert.Equal(2023, lunarDate.Year);
        Assert.Equal(12, lunarDate.Month);
        Assert.Equal(30, lunarDate.Day);
        Assert.False(lunarDate.IsLeapMonth);
    }

    [Fact]
    public void ConvertFromSolar_DateBeforeSupportedRange_ThrowsException()
    {
        // Arrange
        var earlyDate = new DateTime(2019, 12, 31);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new LunarCalendarConverter().ConvertFromSolar(earlyDate));
    }

    [Fact]
    public void ConvertFromSolar_DateAfterSupportedRange_ThrowsException()
    {
        // Arrange
        var lateDate = new DateTime(2031, 1, 1);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new LunarCalendarConverter().ConvertFromSolar(lateDate));
    }

    [Fact]
    public void GetSupportedSolarRange_ReturnsCorrectRange()
    {
        // Act
        var range = new LunarCalendarConverter().GetSupportedSolarRange();

        // Assert
        Assert.Equal(new DateTime(2020, 1, 25), range.StartDate); // 2020年春节
        Assert.Equal(new DateTime(2030, 12, 31), range.EndDate); // 2030年年底
    }

    [Fact]
    public void ConvertFromSolar_MultipleDates_ReturnsValidLunarDates()
    {
        // 测试多个关键日期
        var testCases = new[]
        {
            (solar: new DateTime(2020, 1, 25), lunar: (year: 2020, month: 1, day: 1, leap: false)), // 春节
            (solar: new DateTime(2021, 2, 12), lunar: (year: 2021, month: 1, day: 1, leap: false)), // 春节
            (solar: new DateTime(2022, 2, 1), lunar: (year: 2022, month: 1, day: 1, leap: false)), // 春节
            (solar: new DateTime(2023, 1, 22), lunar: (year: 2023, month: 1, day: 1, leap: false)), // 春节
            (solar: new DateTime(2024, 2, 10), lunar: (year: 2024, month: 1, day: 1, leap: false)), // 春节
        };

        foreach (var (solar, expected) in testCases)
        {
            // Act
            var lunarDate = new LunarCalendarConverter().ConvertFromSolar(solar);

            // Assert
            Assert.Equal(expected.year, lunarDate.Year);
            Assert.Equal(expected.month, lunarDate.Month);
            Assert.Equal(expected.day, lunarDate.Day);
            Assert.Equal(expected.leap, lunarDate.IsLeapMonth);
        }
    }
}