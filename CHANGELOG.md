# Changelog

## 0.1.8 (2026-03-24)

- Add unit tests
- Add test step to CI workflow

## 0.1.7 (2026-03-23)

- Sync .csproj description with README

## 0.1.6 (2026-03-22)

- Add dates to changelog entries

## 0.1.5 (2026-03-20)

- Expand README with time range and custom reference examples
- Add LangVersion and TreatWarningsAsErrors to csproj

## 0.1.4 (2026-03-16)

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
