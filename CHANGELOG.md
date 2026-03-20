# Changelog

## 0.1.5

- Expand README with time range and custom reference examples
- Add LangVersion and TreatWarningsAsErrors to csproj

## 0.1.4

- Add Development section to README
- Add GenerateDocumentationFile and RepositoryType to .csproj

## 0.1.1 (2026-03-10)

- Fix README path in csproj so README displays on nuget.org

## 0.1.0 (2026-03-10)

- Initial release
- `RelativeTime.From` — convert a `DateTimeOffset` to a human-readable relative phrase
- Supports past phrases: "just now", "X minutes ago", "yesterday", "X months ago", etc.
- Supports future phrases: "in X minutes", "tomorrow", "in X months", etc.
- Accepts an optional reference time for testable comparisons
