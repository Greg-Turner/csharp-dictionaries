using System;
using System.Collections.Generic;
using System.Linq;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("GE", "General Electric");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("AAPL", "Apple");
            

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            purchases.Add((ticker: "GM", shares: 99, price: 25.00));
            purchases.Add((ticker: "GM", shares: 45, price: 26.00));
            purchases.Add((ticker: "GM", shares: 75, price: 20.00));
            purchases.Add((ticker: "GE", shares: 150, price: 23.21));
            purchases.Add((ticker: "GE", shares: 32, price: 17.87));
            purchases.Add((ticker: "GE", shares: 80, price: 19.02));
            purchases.Add((ticker: "CAT", shares: 15, price: 50.00));
            purchases.Add((ticker: "CAT", shares: 20, price: 52.50));
            purchases.Add((ticker: "CAT", shares: 25, price: 45.05));
            purchases.Add((ticker: "AAPL", shares: 5, price: 219.00));
            purchases.Add((ticker: "AAPL", shares: 10, price: 200.00));
            purchases.Add((ticker: "AAPL", shares: 15, price: 215.00));

            /*
            Define a new Dictionary to hold the aggregated purchase information.
            - The key should be a string that is the full company name.
            - The value will be the valuation of each stock (price*amount)

            {
                "General Electric": 35900,
                "AAPL": 8445,
                ...
            }
            */
            Dictionary<string, double> report = new Dictionary<string, double>();
            //List<string> ownedStocks = new List<string>();

            // Iterate over the purchases and update the valuation for each stock
            foreach ((string ticker, int shares, double price) purchase in purchases)
            {
                // get the stock fullname of the purchase ticker
                string stockName = stocks[purchase.ticker];
                // determine the total value of the stock purchase
                double stockValue = (purchase.shares * purchase.price);

                // Does the company name key already exist in the report dictionary?
                // If not, add the new key and set its value
                if (!report.ContainsKey(stockName))
                {
                    // add the new stock to the list of owned stocks
                    //ownedStocks.Add(stockName);
                    report.Add(stockName, stockValue);
                
                // If it does, update the total valuation
                } else {
                    report[stockName] += stockValue;
                }

            }

            // iterate over the owned stocks
            //foreach (string asset in ownedStocks)
            foreach (KeyValuePair<string, double> asset in report)
            {    
            Console.WriteLine(asset.Key+": $"+asset.Value); 
            }
        }
    }
}
