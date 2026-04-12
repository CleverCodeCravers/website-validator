# Website Validator

A command-line tool that crawls a website and validates it -- checking for HTTP errors, broken links, and collecting structural information for further analysis.

## Tech Stack

- .NET 10.0 (C#)
- [HtmlAgilityPack](https://html-agility-pack.net/) -- HTML parsing and link extraction
- [System.CommandLine](https://github.com/dotnet/command-line-api) -- CLI argument parsing
- [xUnit](https://xunit.net/) -- Unit testing

## Build

```bash
dotnet build source/WebsiteValidator/
```

## Test

```bash
dotnet test source/WebsiteValidator/
```

## Usage

```bash
websitevalidator --url <URL> [options]
```

### Options

| Option | Short | Description |
|---|---|---|
| `--url` | `-u` | **(required)** The URL of the website to crawl |
| `--links` | `-l` | List all links found on the page |
| `--crawl` | `-c` | Crawl the full site and list all links |
| `--ignore-ssl` | | Ignore SSL certificate errors |
| `--human` | `-h` | Human-readable output (default is JSON) |
| `--output` | `-o` | Save results to a file |
| `--limit` | | Maximum number of pages to crawl |
| `--additionalEntrypoints` | `--ae` | Text file with additional entry point URLs (e.g. from a sitemap) |

### Examples

```bash
# List all links on a page
websitevalidator -u https://example.com -l

# Crawl a website and save results as JSON
websitevalidator -u https://example.com -c -o results.json

# Crawl with a page limit and human-readable output
websitevalidator -u https://example.com -c --limit 100 -h

# Crawl with additional entry points from a sitemap
websitevalidator -u https://example.com -c --ae sitemap-urls.txt -o results.json
```

## Output

Results are written as JSON by default -- a structured file suitable for further analysis with tools like PowerShell, jq, or custom scripts. Use `--human` for a more readable console output.
