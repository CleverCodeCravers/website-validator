/**
* Website Validator - crawl a website and collect loads of information
*
* The website validator shall help you with the continuous surveillance
* of a website and enable the implementation of smaller helpers (e.g. in powershell)
* for your own custom rules.
* */
var urlOption = new Option<string>("--url", "-u")
{
    Description = "The url of the website you would like to crawl.",
    Required = true
};

var linksOption = new Option<bool>("--links", "-l")
{
    Description = "List all links that you can find."
};

var crawlOption = new Option<bool>("--crawl", "-c")
{
    Description = "Crawl the full page and list all links."
};

var sslOption = new Option<bool>("--ignore-ssl")
{
    Description = "Ignores SSL certificate"
};

var humanOption = new Option<bool>("--human", "-h")
{
    Description = "Human readable output (instead of json)"
};

var outputOption = new Option<string>("--output", "-o")
{
    Description = "Where to save the results. Without the option i'll write on the screen."
};

var limitOption = new Option<int>("--limit")
{
    Description = "Maximum number of pages to crawl."
};

var additionalEntryPoints = new Option<string>("--additionalEntrypoints", "--ae")
{
    Description = "A simple text file with a list of urls, for e.g. sitemap-links..."
};

// Create a root command with some options
var rootCommand = new RootCommand("WebsiteValidator, a tool to crawl a website and validate it")
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

rootCommand.SetAction(parseResult =>
{
    var url = parseResult.GetValue(urlOption)!;
    var links = parseResult.GetValue(linksOption);
    var ignoreSsl = parseResult.GetValue(sslOption);
    var human = parseResult.GetValue(humanOption);
    var crawl = parseResult.GetValue(crawlOption);
    var output = parseResult.GetValue(outputOption) ?? string.Empty;
    var limit = parseResult.GetValue(limitOption);
    var entrypoints = parseResult.GetValue(additionalEntryPoints) ?? string.Empty;

    ProcessCommand(url, links, ignoreSsl, human, crawl, output, limit, entrypoints);
    return 0;
});

// Parse the incoming args and invoke the handler
return await rootCommand.Parse(args).InvokeAsync();


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
