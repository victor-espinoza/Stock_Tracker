//Team Members: Victor Espinoza, Jeff Yoshida
//CECS 475 - Application Programming using .NET
//Assignment #3 - Stock Tracking Program
//Due: 2/18/16

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Stock_Tracker {
   class StockBroker {
      public delegate void ThresholdReachedEventHandler(Object sender,
       Lab_3_Stock_Tracker.Stock.StockThresholdReachedEventArgs e); //define Delegate event handler
      private string brokerName; //name of the broker
      private List<Stock> stocks; //list of stocks that the broker has


      public StockBroker(string name) {
         brokerName = name; //assign broker name
         stocks = new List<Stock>(); //declare a new list of Stock items
         DisplayColumnNames(); //print out the header to the console (since we can't modify the main method).
      }//close StockBroker(...) 1 parameter constructor


      public void AddStock(Stock newStock) {
         stocks.Add(newStock); //add the stock item to the list
         newStock.StockThresholdReached += StockThresholdReached; //add the StockThresholdReached Event Handler to the event
         newStock.WriteThresholdReached += WriteThresholdReached; //add the WriteThresholdReached Event Handler to the event
      }//close AddStock(...)


      private void DisplayColumnNames() {
         if (brokerName.Equals("Broker 1")) { //only want header to be displayed once, so check for broker with name of "Broker 1"
            string fileInfo = String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "Broker Name:",
              "Stock Name:", "Current Value:", "Changes:");
            Console.WriteLine(fileInfo); //display header in console
            new FileProcessing(); //write header to output file.
         }//end if
      }//close DisplayColumnNames()


      public void StockThresholdReached(Object sender,
       Lab_3_Stock_Tracker.Stock.StockThresholdReachedEventArgs e) {
         lock (Stock.threadLock) { //lock - create critical section that can only be accessed by 1 thread at a time (Uses the 
            //same lock object created in the Stock class)
            string fileInfo = String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", brokerName, e.StockName,
             e.CurrentStockValue, e.StockChangeNum);
            Console.WriteLine(fileInfo);//display information on console
         }//close lock
      }//close StockThresholdReached(...)


      public void WriteThresholdReached(Object sender,
       Lab_3_Stock_Tracker.Stock.StockThresholdReachedEventArgs e) {
         lock (Stock.threadLock) { //lock - create critical section that can only be accessed by 1 thread at a time (Uses the 
            //same lock object created in the Stock class)
            string fileInfo = String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", brokerName, e.StockName,
             e.CurrentStockValue, e.StockChangeNum);
            new FileProcessing(fileInfo); //write information to file
         }//close lock
      }//close WriteThresholdReached(...)

   }//close class StockBroker
}//close namespace Lab_3_Stock_Tracker
