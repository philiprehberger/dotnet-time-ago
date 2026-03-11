namespace Philiprehberger.TimeAgo;

public static class RelativeTime
{
    public static string From(DateTimeOffset timestamp, DateTimeOffset? relativeTo = null)
    {
        var now = relativeTo ?? DateTimeOffset.UtcNow;
        var diff = now - timestamp;
        var totalSeconds = diff.TotalSeconds;
        var isFuture = totalSeconds < 0;
        var abs = Math.Abs(totalSeconds);

        if (abs < 30)
            return "just now";

        if (isFuture)
        {
            var absDiff = timestamp - now;
            return FormatFuture(absDiff);
        }

        return FormatPast(diff);
    }

    private static string FormatPast(TimeSpan diff)
    {
        var totalSeconds = diff.TotalSeconds;

        if (totalSeconds < 90)
            return "1 minute ago";

        if (totalSeconds < 3600)
        {
            var minutes = (int)Math.Round(diff.TotalMinutes);
            return $"{minutes} minutes ago";
        }

        if (diff.TotalHours < 1.5)
            return "1 hour ago";

        if (diff.TotalHours < 24)
        {
            var hours = (int)Math.Round(diff.TotalHours);
            return $"{hours} hours ago";
        }

        if (diff.TotalDays < 1.5)
            return "yesterday";

        if (diff.TotalDays < 7)
        {
            var days = (int)Math.Round(diff.TotalDays);
            return $"{days} days ago";
        }

        if (diff.TotalDays < 14)
            return "1 week ago";

        if (diff.TotalDays < 30)
        {
            var weeks = (int)Math.Round(diff.TotalDays / 7);
            return $"{weeks} weeks ago";
        }

        if (diff.TotalDays < 45)
            return "1 month ago";

        if (diff.TotalDays < 365)
        {
            var months = (int)Math.Round(diff.TotalDays / 30);
            return $"{months} months ago";
        }

        if (diff.TotalDays < 545)
            return "1 year ago";

        var years = (int)Math.Round(diff.TotalDays / 365);
        return $"{years} years ago";
    }

    private static string FormatFuture(TimeSpan diff)
    {
        var totalSeconds = diff.TotalSeconds;

        if (totalSeconds < 90)
            return "in 1 minute";

        if (totalSeconds < 3600)
        {
            var minutes = (int)Math.Round(diff.TotalMinutes);
            return $"in {minutes} minutes";
        }

        if (diff.TotalHours < 1.5)
            return "in 1 hour";

        if (diff.TotalHours < 24)
        {
            var hours = (int)Math.Round(diff.TotalHours);
            return $"in {hours} hours";
        }

        if (diff.TotalDays < 1.5)
            return "tomorrow";

        if (diff.TotalDays < 7)
        {
            var days = (int)Math.Round(diff.TotalDays);
            return $"in {days} days";
        }

        if (diff.TotalDays < 14)
            return "in 1 week";

        if (diff.TotalDays < 30)
        {
            var weeks = (int)Math.Round(diff.TotalDays / 7);
            return $"in {weeks} weeks";
        }

        if (diff.TotalDays < 45)
            return "in 1 month";

        if (diff.TotalDays < 365)
        {
            var months = (int)Math.Round(diff.TotalDays / 30);
            return $"in {months} months";
        }

        if (diff.TotalDays < 545)
            return "in 1 year";

        var years = (int)Math.Round(diff.TotalDays / 365);
        return $"in {years} years";
    }
}
