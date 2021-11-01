using System;
using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace WebScrapper
{
    class Program
    {
        public class Row
        {
            public string Title { get; set; }
        }

        public static HtmlNodeCollection GetProductNames(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectNodes("//a[@class='card-v2-title semibold mrg-btm-xxs js-product-url']");
        }

        public static HtmlNodeCollection GetProductPrices(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectNodes("//p[@class='product-new-price']");
        }

        public static List<string> ScrapeProducts(HtmlNodeCollection itemsName, HtmlNodeCollection itemsPrices)
        {
            string[] items = System.IO.File.ReadAllLines("ItemsToScrape.csv");
            List<string> products = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                foreach (var item in itemsName)
                {
                    if (item.InnerText == items[i])
                    {
                        string title = item.InnerText.Trim();
                        string rawPrice = itemsPrices[i].InnerText;
                        string formatedPrice = rawPrice.Remove(rawPrice.Length - 4, 4).ToString();
                        double finalPrice = Convert.ToDouble(formatedPrice) / 100;

                        products.Add($"Product: {title} , price: {finalPrice}лв.");
                    }
                }
            }

            return products;
        }

        public static void CreateReadPrintCSV(List<string> products)
        {
            var rows = new List<Row>();
            foreach (var item in products)
            {
                rows.Add(new Row { Title = item });
            }
            using (var writer = new StreamWriter("result.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(rows);
            }

            string[] print = System.IO.File.ReadAllLines("result.csv");
            foreach (string line in print)
            {
                string[] columns = line.Split(',');
                foreach (string column in columns)
                {
                    Console.WriteLine(column);
                }
            }
        }

        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.emag.bg/mishki/stock/filter/tip-f6329,gejming-v23008/c?ref=lst_leftbar_6408_stock");
            HtmlNodeCollection itemsName = GetProductNames(doc);
            HtmlNodeCollection itemsPrices = GetProductPrices(doc);

            CreateReadPrintCSV(ScrapeProducts(itemsName, itemsPrices));

        }
    }
}
