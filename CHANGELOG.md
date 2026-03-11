# Changelog

## 0.1.0 (2026-03-10)

- Initial release
- `RelativeTime.From` — convert a `DateTimeOffset` to a human-readable relative phrase
- Supports past phrases: "just now", "X minutes ago", "yesterday", "X months ago", etc.
- Supports future phrases: "in X minutes", "tomorrow", "in X months", etc.
- Accepts an optional reference time for testable comparisons
