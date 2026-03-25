using Xunit;
namespace Philiprehberger.TimeAgo.Tests;

public class RelativeTimeTests
{
    private static readonly DateTimeOffset Now = new(2026, 3, 24, 12, 0, 0, TimeSpan.Zero);

    [Fact]
    public void From_JustNow_ReturnsJustNow()
    {
        var timestamp = Now.AddSeconds(-5);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("just now", result);
    }

    [Fact]
    public void From_FutureWithinThirtySeconds_ReturnsJustNow()
    {
        var timestamp = Now.AddSeconds(10);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("just now", result);
    }

    [Fact]
    public void From_OneMinuteAgo_ReturnsSingularMinute()
    {
        var timestamp = Now.AddSeconds(-60);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("1 minute ago", result);
    }

    [Theory]
    [InlineData(-120, "2 minutes ago")]
    [InlineData(-300, "5 minutes ago")]
    [InlineData(-2700, "45 minutes ago")]
    public void From_MinutesAgo_ReturnsCorrectPhrase(int seconds, string expected)
    {
        var timestamp = Now.AddSeconds(seconds);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void From_OneHourAgo_ReturnsSingularHour()
    {
        var timestamp = Now.AddHours(-1);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("1 hour ago", result);
    }

    [Theory]
    [InlineData(-2, "2 hours ago")]
    [InlineData(-5, "5 hours ago")]
    [InlineData(-23, "23 hours ago")]
    public void From_HoursAgo_ReturnsCorrectPhrase(int hours, string expected)
    {
        var timestamp = Now.AddHours(hours);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void From_Yesterday_ReturnsYesterday()
    {
        var timestamp = Now.AddDays(-1);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("yesterday", result);
    }

    [Fact]
    public void From_DaysAgo_ReturnsCorrectPhrase()
    {
        var timestamp = Now.AddDays(-4);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("4 days ago", result);
    }

    [Fact]
    public void From_OneWeekAgo_ReturnsSingularWeek()
    {
        var timestamp = Now.AddDays(-10);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("1 week ago", result);
    }

    [Fact]
    public void From_OneMonthAgo_ReturnsSingularMonth()
    {
        var timestamp = Now.AddDays(-35);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("1 month ago", result);
    }

    [Fact]
    public void From_MonthsAgo_ReturnsCorrectPhrase()
    {
        var timestamp = Now.AddDays(-180);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("6 months ago", result);
    }

    [Fact]
    public void From_OneYearAgo_ReturnsSingularYear()
    {
        var timestamp = Now.AddDays(-400);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("1 year ago", result);
    }

    [Fact]
    public void From_YearsAgo_ReturnsCorrectPhrase()
    {
        var timestamp = Now.AddDays(-900);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("2 years ago", result);
    }

    [Fact]
    public void From_FutureOneMinute_ReturnsInOneMinute()
    {
        var timestamp = Now.AddSeconds(60);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("in 1 minute", result);
    }

    [Theory]
    [InlineData(120, "in 2 minutes")]
    [InlineData(7200, "in 2 hours")]
    public void From_FutureTimestamps_ReturnsCorrectPhrase(int seconds, string expected)
    {
        var timestamp = Now.AddSeconds(seconds);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void From_Tomorrow_ReturnsTomorrow()
    {
        var timestamp = Now.AddDays(1);

        var result = RelativeTime.From(timestamp, Now);

        Assert.Equal("tomorrow", result);
    }

    [Fact]
    public void From_DefaultRelativeTo_UsesUtcNow()
    {
        var timestamp = DateTimeOffset.UtcNow.AddSeconds(-5);

        var result = RelativeTime.From(timestamp);

        Assert.Equal("just now", result);
    }
}
