# R00001 — Simple Cleanup and Welcome

## Quelle

GitHub Issue: #1

## Beschreibung

Grundlegende Repository-Hygiene: README aktualisieren und einen Build-Workflow fuer Continuous Integration einrichten.

## Akzeptanzkriterien

1. **README.md aktualisieren**: Die README soll den aktuellen Stand des Projekts widerspiegeln (.NET 10.0, aktuelle Features, Build-Anleitung).
2. **Build-Workflow erstellen**: Ein GitHub Actions Workflow (`.github/workflows/build.yml`) der bei Push und Pull Request auf `main` automatisch baut und Tests ausfuehrt.

## Technische Details

### README.md

- Projektbeschreibung aktualisieren
- Tech-Stack dokumentieren (.NET 10.0, HtmlAgilityPack, System.CommandLine, xUnit)
- Build- und Test-Befehle dokumentieren
- Verwendungsanleitung (CLI-Optionen) aktualisieren

### Build-Workflow (.github/workflows/build.yml)

- Trigger: push und pull_request auf `main`
- Steps: Checkout, .NET 10.0 Setup, Restore, Build, Test
- Runner: ubuntu-latest

## Betroffene Dateien

- `README.md` (aendern)
- `.github/workflows/build.yml` (neu)

## Teststrategie

- Build-Workflow: Syntaktische Korrektheit der YAML-Datei pruefen
- README: Inhaltliche Pruefung (manuelle Verifikation)
- Gesamter Build muss weiterhin fehlerfrei kompilieren
