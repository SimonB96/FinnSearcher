using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Data;

namespace FinnScraper
{

    public class FinnScraperBrain
    {
        public static List<Product> FinnForsaleSearch(string searchString)
        {
            List<Product> bufferList = new List<Product>();

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://www.finn.no/bap/forsale/search.json?q=" + searchString).Result;

            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();

            string content = response.Content.ReadAsStringAsync().Result;

            var search = JsonConvert.DeserializeObject<FinnSearch>(content);
            string[] splitText = { };

            if (searchString.Contains(" "))
            {
                splitText = searchString.Split(' ');
            }

            foreach (var item in search.displaySearchResults)
            {

                if (!string.IsNullOrEmpty(item.titleRow) && item.bodyRow.Count > 0 && item.bodyRow[0].Any(char.IsDigit) && !string.IsNullOrEmpty(item.topRowCenter))
                    if (item.titleRow.ToLower().Contains(searchString.ToLower()) ||
                        (searchString.ToLower().Contains(' ') && item.titleRow.ToLower().Contains(splitText[0].ToLower()) && item.titleRow.ToLower().Contains(splitText[1].ToLower())))
                    {

                        {

                            bufferList.Add(new Product(
                                                     item.titleRow,
                                                     item.adUrl,
                                                     Int32.Parse(new string(item.bodyRow[0].Where(Char.IsDigit).ToArray())),
                                                     item.topRowCenter,
                                                     item.topRowLeft.displayText,
                                                     item.imageUrl,
                                                    "N/A",
                                                    0
                                                     )
                                                 );


                        }
                    }

            }




            return bufferList;
        }
        public static string GetCity()
        {
            IpInfo ipInfo = new IpInfo();

            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://ipinfo.io").Result;

            response.EnsureSuccessStatusCode();

            string content = response.Content.ReadAsStringAsync().Result;
            ipInfo = JsonConvert.DeserializeObject<IpInfo>(content);;

            return ipInfo.City;
        }

        private class IpInfo
        {
            
            public string Country { get; set; }
            public string City { get; set; }
        }
    
    public static string GetTravelTime(string origin, string destination)
        {
            string route;
            var httpClient = new HttpClient();
            String APIkey = ""; // Your API key.
            var response = httpClient.GetAsync("https://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&key=" + APIkey).Result;
           
            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();

            string content = response.Content.ReadAsStringAsync().Result;

            var search = JsonConvert.DeserializeObject<GoogleDistance>(content);

            try
            {
                route = search.routes[0].legs[0].duration.text;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
            return route;
        }

        public List<Product> FinnSearch(String search)
        {
            string currentCity = GetCity();
            var bufferList = FinnForsaleSearch(search);

            double gjennomsnittPris;

            var tempList = new List<Product>();
            List<Product> productList = new List<Product>();
            if (bufferList.Count > 0)
            {
                gjennomsnittPris = bufferList.Select(x => x.Price).Average();

                foreach (var buffItem in bufferList)
                {
                    if (!(buffItem.Price < gjennomsnittPris / 4) && buffItem.Price < gjennomsnittPris * 1.1)
                    {
                        tempList.Add(buffItem);
                    }
                }

                if (tempList.Count < 10)
                {
                    return null;
                }

                bufferList = tempList;
                var minPrice = bufferList.Select(x => x.Price).Min();
                var cheapestProduct = bufferList.First(x => x.Price == minPrice);
                for (int i = 0; i < 10; i++)
                {
                    productList.Add(cheapestProduct);
                    bufferList.Remove(cheapestProduct);
                    minPrice = bufferList.Select(x => x.Price).Min();
                    cheapestProduct = bufferList.First(x => x.Price == minPrice);
                }


                foreach (Product myProd in productList)
                {
                    if (!string.IsNullOrEmpty(GetTravelTime(currentCity, myProd.City)))
                    {
                        myProd.Kjoretid = GetTravelTime(currentCity, myProd.City);
                        var hour = GetTravelTime(currentCity, myProd.City).Split(' ');
                        if (hour.Length < 3)
                        {
                                myProd.GoodValue = (myProd.Price * Int32.Parse(hour[0]) / 30) / 100;
                            
                        }
                        else
                        {
                                myProd.GoodValue = (myProd.Price * Int32.Parse(hour[0])) / 100;
                            
                        }
                        
                    }
                    else
                    {
                        myProd.GoodValue = 10000;
                    }
                }
                return productList;
            }
            return null;

        }

    }
}


