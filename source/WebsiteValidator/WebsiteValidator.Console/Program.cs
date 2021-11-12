/**
* Website Validator - crawl a website and collect loads of information
* 
* The website validator shall help you with the continuous surveillance
* of a website and enable the implementation of smaller helpers (e.g. in powershell)
* for your own custom rules.
* */
var urlOption = new Option<string>(new[] { "--url", "-u" }, description: "The url of the website you would like to crawl.");
urlOption.IsRequired = true;

var linksOption = new Option<bool>(new[] { "--links", "-l" }, description: "List all links that you can find.");
var crawlOption = new Option<bool>(new[] { "--crawl", "-c" }, description: "Crawl the full page and list all links.");
var sslOption = new Option<bool>(new[] { "--ignore-ssl" }, description: "Ignores SSL certificate");
var humanOption = new Option<bool>(new[] { "--human", "-h" }, "Human readable output (instead of json)");

var outputOption = new Option<string>(new[] { "--output", "-o" }, description: "Where to save the results. Without the option i'll write on the screen.");
var limitOption = new Option<int>(new[] { "--limit" }, description: "Maximum number of pages to crawl.");
var additionalEntryPoints = new Option<string>(
    new[] { "--additionalEntrypoints", "--ae" },
    "A simple text file with a list of urls, for e.g. sitemap-links...");

// Create a root command with some options
var rootCommand = new RootCommand
            {
                urlOption,
                linksOption,
                sslOption,
                humanOption,
                crawlOption,
                outputOption,
                limitOption,
                additionalEntryPoints
            };

rootCommand.Description = "WebsiteValidator, a tool to crawl a website and validate it";

// Note that the parameters of the handler method are matched according to the names of the options
rootCommand.Handler = CommandHandler.Create<string, bool, bool, bool, bool, string, int, string>(ProcessCommand);

// Parse the incoming args and invoke the handler
return rootCommand.InvokeAsync(args).Result;


static void ProcessCommand(string url, bool links, bool ignoreSsl, bool human, bool crawl, string output,
    int limit, string additionalEntryPoints)
{
    var outputHelper = new OutputHelperFactory().Get(human, output);

    if (links) ListLinksForUrl(url, ignoreSsl, outputHelper);

    if (!string.IsNullOrWhiteSpace(additionalEntryPoints))
    {
        var additionalKnownLinks = File.ReadAllLines(additionalEntryPoints);
        if (crawl) CrawlUrl(url, ignoreSsl, outputHelper, limit, additionalKnownLinks);
    }
    else
    {
        if (crawl) CrawlUrl(url, ignoreSsl, outputHelper, limit, new string[0]);
    }
}

static void CrawlUrl(string url, bool ignoreSsl, IOutputHelper outputHelper, int limit,
    string[] additionalKnownLinks)
{
    IDownloadAWebpage downloadWebpage = new DownloadAWebpage(ignoreSsl);

    var crawler = new Crawler(url, downloadWebpage, outputHelper, limit, additionalKnownLinks);
    var result = crawler.CrawlEverything();

    outputHelper.Write("crawlresult", result);
}

static void ListLinksForUrl(string url, bool ignoreSsl, IOutputHelper outputHelper)
{
    IDownloadAWebpage downloadWebpage = new DownloadAWebpage(ignoreSsl);

    var links =
        downloadWebpage
            .Download(url)
            .ExtractUrls()
            .ToAbsoluteUrls(url);

    outputHelper.Write("links", links);
}