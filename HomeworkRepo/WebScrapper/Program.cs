using System;
using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq;

namespace WebScrapper
{
    class Program
    {
        public static HtmlNodeCollection itemsName { get; set; }
        public static HtmlNodeCollection itemsPrices { get; set; }
        public static HtmlNodeCollection GetProductNames(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectNodes("//a[@class='card-v2-title semibold mrg-btm-xxs js-product-url']");
        }
        public static HtmlNodeCollection GetProductPrices(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectNodes("//p[@class='product-new-price']");
        }

        static void Main(string[] args)
        {
            #region LoadingSite

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.emag.bg/mishki/stock/filter/tip-f6329,gejming-v23008/sort-pricedesc/c");

            #endregion

            #region Start

            Task first = new Task(
                () =>
                {
                    itemsName = GetProductNames(doc);
                    itemsPrices = GetProductPrices(doc);
                }
                );
            first.Start();

            #endregion

            #region FanOut

            first.Wait();
            string[] wantedItems = System.IO.File.ReadAllLines("ItemsToScrape.csv");
            List<Task<string>> taskList = new List<Task<string>>();
            List<string> products = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                int index = i;
                taskList.Add(Task.Run(() =>
                {
                    HtmlNode node = itemsName.Where(x => x.InnerText == wantedItems[index]).First();
                    string title = node.InnerText.Trim();
                    string rawPrice = itemsPrices[index].InnerText;
                    string formatedPrice = rawPrice.Remove(rawPrice.Length - 4, 4).ToString();
                    double finalPrice = Convert.ToDouble(formatedPrice) / 100;
                    string itemInfo = $"Product: {title} , price: {finalPrice}лв.";

                    products.Add(itemInfo);
                    return itemInfo;
                }));
            }

            #endregion

            #region FanIn

            var fanInTask = Task.WhenAll(taskList);
            var final = fanInTask.ContinueWith(prev => Console.WriteLine(string.Join("\n", prev.Result)));
            final.Wait();
            Console.ReadLine();

            #endregion
        }
    }
}
