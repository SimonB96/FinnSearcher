using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinnScraper
{
    public class Product
    {
        public Product(string name, string uRL, int price, string city, string date, string imageURL, string kjoretid, double goodvalue)
        {
            Name = name;
            URL = uRL;
            Price = price;
            City = city;
            Date = date;
            ImageURL = imageURL;
            Kjoretid = kjoretid;
            GoodValue = goodvalue;

        }
        public double GoodValue { get; set; }
        public string Name { get; set; }

        public string Kjoretid { get; set; }

        public string URL { get; set; }

        public int Price { get; set; }

        public string City { get; set; }

        public string Date { get; set; }

        public string ImageURL { get; set; }


    }
}
