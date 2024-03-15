using EasyAutomationFramework;
using OpenQA.Selenium;
using System.Data;
using web_scrapping_app.Models;

namespace web_scrapping_app.Drivers
{
    public class WebScraper : Web
    {
        public DataTable GetData(string link)
        {
            var pathChromeDriver = @"C:\DEV\C#\crowler-scraping\web-scrapping-app\web-scrapping-app\chromedriver\chromedriver.exe";
            if (driver == null)
            {
                StartBrowser();
            }

            var items = new List<WebScraperIoTest>();

            Navigate(link);

            var elements = GetValue(TypeElement.Xpath, "/html/body/div[1]/div[3]/div/div[2]/div[2]")
                .element.FindElements(By.ClassName("card-body"));

            foreach (var element in elements)
            {
                items.Add(new WebScraperIoTest()
                {
                    Name = element.FindElement(By.ClassName("title"))
                    .GetAttribute("title"),
                    Price = element.FindElement(By.ClassName("price"))
                    .Text,
                    Description = element.FindElement(By.ClassName("description"))
                    .Text
                });
            }

            return Base.ConvertTo(items);
        }
    }
}
