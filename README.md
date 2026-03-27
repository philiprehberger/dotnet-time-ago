# Philiprehberger.TimeAgo

[![CI](https://github.com/philiprehberger/dotnet-time-ago/actions/workflows/ci.yml/badge.svg)](https://github.com/philiprehberger/dotnet-time-ago/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/Philiprehberger.TimeAgo.svg)](https://www.nuget.org/packages/Philiprehberger.TimeAgo)
[![License](https://img.shields.io/github/license/philiprehberger/dotnet-time-ago)](LICENSE)
[![Sponsor](https://img.shields.io/badge/sponsor-GitHub%20Sponsors-ec6cb9)](https://github.com/sponsors/philiprehberger)

Convert timestamps into human-readable relative phrases like "3 hours ago" or "in 2 days".

## Installation

```bash
dotnet add package Philiprehberger.TimeAgo
```

## Usage

```csharp
using Philiprehberger.TimeAgo;

var now = DateTimeOffset.UtcNow;

RelativeTime.From(now.AddSeconds(-10));          // "just now"
RelativeTime.From(now.AddMinutes(-1));           // "1 minute ago"
RelativeTime.From(now.AddMinutes(-45));          // "45 minutes ago"
RelativeTime.From(now.AddHours(-1));             // "1 hour ago"
RelativeTime.From(now.AddHours(-5));             // "5 hours ago"
RelativeTime.From(now.AddDays(-1));              // "yesterday"
RelativeTime.From(now.AddDays(-3));              // "3 days ago"
RelativeTime.From(now.AddDays(-10));             // "1 week ago"
RelativeTime.From(now.AddDays(-20));             // "3 weeks ago"
RelativeTime.From(now.AddMonths(-1));            // "1 month ago"
RelativeTime.From(now.AddMonths(-6));            // "6 months ago"
RelativeTime.From(now.AddYears(-1));             // "1 year ago"
RelativeTime.From(now.AddYears(-3));             // "3 years ago"

// Future
RelativeTime.From(now.AddMinutes(5));            // "in 5 minutes"
RelativeTime.From(now.AddDays(1));               // "tomorrow"
RelativeTime.From(now.AddMonths(2));             // "in 2 months"

// Custom reference time (useful for testing)
RelativeTime.From(timestamp, relativeTo: someFixedTime);
```

### Different Time Ranges

```csharp
using Philiprehberger.TimeAgo;

var now = DateTimeOffset.UtcNow;
RelativeTime.From(now.AddSeconds(-30));  // "just now"
RelativeTime.From(now.AddMinutes(-5));   // "5 minutes ago"
RelativeTime.From(now.AddHours(-3));     // "3 hours ago"
RelativeTime.From(now.AddDays(-1));      // "yesterday"
RelativeTime.From(now.AddDays(-14));     // "2 weeks ago"
RelativeTime.From(now.AddMonths(-6));    // "6 months ago"
RelativeTime.From(now.AddYears(-2));     // "2 years ago"
```

### Custom Reference Time

```csharp
using Philiprehberger.TimeAgo;

var reference = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
var timestamp = new DateTimeOffset(2025, 12, 25, 0, 0, 0, TimeSpan.Zero);
RelativeTime.From(timestamp, reference); // "last week"
```

## API

### `RelativeTime`

| Method | Description |
|--------|-------------|
| `From(DateTimeOffset timestamp, DateTimeOffset? relativeTo = null)` | Return a relative phrase for `timestamp`; uses `DateTimeOffset.UtcNow` when `relativeTo` is omitted |

**Thresholds:**

| Delta | Phrase |
|-------|--------|
| < 30 s | "just now" |
| < 90 s | "1 minute ago" |
| < 60 min | "X minutes ago" |
| < 1.5 h | "1 hour ago" |
| < 24 h | "X hours ago" |
| < 1.5 d | "yesterday" |
| < 7 d | "X days ago" |
| < 14 d | "1 week ago" |
| < 30 d | "X weeks ago" |
| < 45 d | "1 month ago" |
| < 365 d | "X months ago" |
| < 545 d | "1 year ago" |
| ≥ 545 d | "X years ago" |

Future phrases follow the same thresholds with "in …" and "tomorrow" in place of "yesterday".

## Development

```bash
dotnet build src/Philiprehberger.TimeAgo.csproj --configuration Release
```

## License

MIT
