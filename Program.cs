using HtmlAgilityPack;
using scraper;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Web;

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

Console.WriteLine($" - - - - - - - - Start Operation - - - - - - - - ");
string url = "http://books.toscrape.com/catalogue/category/books/travel_2/index.html";
List<string> listLinks = GetBookLinks(url);
List<Book> listBooks = GetBooks(listLinks);
Export(listBooks);

stopwatch.Stop();
Console.WriteLine($" - - - Success Operation in {stopwatch.Elapsed.TotalSeconds} - - - ");


#region methods

// export the book
void Export(List<Book> listBooks)
{
    using (StreamWriter writer = new StreamWriter("./books.csv"))
    using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
    {
        foreach (Book item in listBooks)
        {
            // decode characters HTML and write line by line in the file
            string line = HttpUtility.HtmlDecode(item.TitleAndPrice);
            Console.WriteLine(line);
            csv.WriteField(line);
            csv.NextRecord();
        }
    }
}

// get a List of books from the links
static List<Book> GetBooks(List<string> listLinks)
{
    List<Book> listBooks = new List<Book>();
    foreach (string item in listLinks)
    {
        HtmlDocument doc = GetDocument(item);
        // xpath: captures the item and the child item that has the price of the book
        string xpath = "//*[@class=\"col-sm-6 product_main\"]/*[@class=\"price_color\"]";
        string priceRaw = doc.DocumentNode.SelectSingleNode(xpath).InnerText;

        Book book = new Book();
        book.Title = doc.DocumentNode.SelectSingleNode("//h1").InnerText;
        book.Price = ExtractPrice(priceRaw);
        listBooks.Add(book);
    }
    return listBooks;
}

// extract the price of the book
static double ExtractPrice(string raw)
{
    Regex reg = new Regex(@"[\d\.,]+", RegexOptions.Compiled);
    Match match = reg.Match(raw);
    if (!match.Success)
    {
        return 0;
    }
    return Convert.ToDouble(match.Value);
}

// get all the links
static List<string> GetBookLinks(string url)
{
    HtmlDocument doc = GetDocument(url);
    HtmlNodeCollection linkNodes = doc.DocumentNode.SelectNodes("//h3/a");

    Uri baseUri = new Uri(url);
    List<string> listLinks = new List<string>();
    // merges the "base" URL with the "relative" link to form an "absolute" URL.
    foreach (HtmlNode item in linkNodes)
    {
        string link = item.Attributes["href"].Value;
        link = new Uri(baseUri, link).AbsoluteUri;
        listLinks.Add(link);
    }
    return listLinks;
}

// connect to the site and get the object
static HtmlDocument GetDocument(string url)
{
    HtmlWeb web = new HtmlWeb();
    HtmlDocument doc = web.Load(url);
    return doc;
}

#endregion