# CLAUDE.md

## Projektbeschreibung

Website-Validator -- ein Kommandozeilen-Tool zur automatisierten Validierung von Websites. Prueft unter anderem HTML-Struktur, Links und weitere Qualitaetsmerkmale.

## Tech-Stack

- .NET 10.0 (C#)
- xUnit (Tests)
- HtmlAgilityPack (HTML-Parsing)
- System.CommandLine (CLI)

## Build- und Test-Befehle

```bash
# Build
dotnet build source/WebsiteValidator/WebsiteValidator.Console/WebsiteValidator.Console.csproj

# Tests ausfuehren
dotnet test source/WebsiteValidator/WebsiteValidator.BL.Tests/WebsiteValidator.BL.Tests.csproj

# Gesamte Solution bauen
dotnet build source/WebsiteValidator/
```

## Konventionen

- TreatWarningsAsErrors ist in allen Projekten aktiviert
- Nullable Reference Types sind aktiviert
- ImplicitUsings sind aktiviert
- Block-scoped Namespaces (kein file-scoped namespace Refactoring)
- CodeQL mit security-extended Suite fuer statische Sicherheitsanalyse
- Dependabot fuer automatische Abhaengigkeitsaktualisierungen (NuGet, GitHub Actions)
