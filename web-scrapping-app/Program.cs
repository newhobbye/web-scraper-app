using web_scrapping_app.Drivers;

var webExtractItems = new WebScraper();

var allinone = webExtractItems.GetData("https://webscraper.io/test-sites/e-commerce/allinone");

Console.WriteLine();
