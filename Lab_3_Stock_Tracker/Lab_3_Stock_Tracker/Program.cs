//Team Members: Victor Espinoza, Jeff Yoshida
//CECS 475 - Application Programming using .NET
//Assignment #3 - Stock Tracking Program
//Due: 2/18/16

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Stock_Tracker {
   class Program {
      static void Main(string[] args) {

         //create new Stock objects
         Stock stock1 = new Stock("Technology", 160, 5, 15);
         Stock stock2 = new Stock("Retail", 30, 2, 6);
         Stock stock3 = new Stock("Banking", 90, 4, 10);
         Stock stock4 = new Stock("Commodity", 500, 20, 50);

         //create new StockBroker objects
         StockBroker b1 = new StockBroker("Broker 1");
         b1.AddStock(stock1);
         b1.AddStock(stock2);

         StockBroker b2 = new StockBroker("Broker 2");
         b2.AddStock(stock1);
         b2.AddStock(stock3);
         b2.AddStock(stock4);

         StockBroker b3 = new StockBroker("Broker 3");
         b3.AddStock(stock1);
         b3.AddStock(stock3);

         StockBroker b4 = new StockBroker("Broker 4");
         b4.AddStock(stock1);
         b4.AddStock(stock2);
         b4.AddStock(stock3);
         b4.AddStock(stock4);

         Console.ReadKey();
      }//close Main(...)
   }//close class Program
}//close namespace Lab_3_Stock_Tracker
