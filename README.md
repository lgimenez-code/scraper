
<h2>Book Scraper</h2>
<p>
  <b>Description:</b> This project is a .NET console application that extracts book information from a sample website using HtmlAgilityPack. The application collects book titles and prices and exports them to a CSV file for analysis and further use.
</p>

<h3>Features:</h3>
<ul>
  <li><b>Data Extraction:</b> Uses HtmlAgilityPack to navigate and extract data from the web page <a href="http://books.toscrape.com/catalogue/category/books/travel_2/index.html">books.toscrape.com</a>.</li>
  <li><b>Price Processing:</b> Converts prices from text format to numeric values.</li>
  <li><b>CSV Export:</b> Saves the extracted data to a CSV file for easy analysis.</li>
  <li><b>Time Measurement:</b> Uses Stopwatch to measure the time taken to complete the operation.</li>
</ul>

<h3>Requirements:</h3>
<ul>
  <li>.NET 9.0</li>
  <li><a href="https://html-agility-pack.net/select-nodes">htmlagilitypack</a></li>
  <li><a href="https://joshclose.github.io/CsvHelper/">CsvHelper</a></li>
</ul>

<h3>Usage:</h3>
<ul>
  <li>Clone the repository</li>
  <li>Run the project using "dotnet run"</li>
  <li>The extracted data will be saved in a books.csv file in the project directory.</li>
</ul>

<h3>Sample output:</h3>
![image](https://github.com/user-attachments/assets/bf9bbd97-2968-4173-a6f4-af3b92ed447e)





