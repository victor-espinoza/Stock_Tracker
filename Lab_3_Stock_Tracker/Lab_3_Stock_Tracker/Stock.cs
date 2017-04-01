//Team Members: Victor Espinoza, Jeff Yoshida
//CECS 475 - Application Programming using .NET
//Assignment #3 - Stock Tracking Program
//Due: 2/18/16

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_3_Stock_Tracker {
   class Stock {
      private string stockName; //name of stock
      private int initialValue; //stock price
      private int maxChange; //stock price change
      private int notificationThreshold; //value to measure changes of stock
      private int currentStockValue;//current value of the stock
      private int numberOfChanges; //number of changes made to the stock
      private Thread t1;
      public event EventHandler<StockThresholdReachedEventArgs> StockThresholdReached; //Event for Writing to Console  
      public event EventHandler<StockThresholdReachedEventArgs> WriteThresholdReached; //Event for Writing to File 
      public static object threadLock = new object();


      public Stock(string name, int startingValue, int maximumChange, int threshold) {
         stockName = name; //assign stockName
         initialValue = startingValue; //assign initialValue
         currentStockValue = initialValue; //assign currentStockValue
         maxChange = maximumChange; //assign maxChange
         notificationThreshold = threshold; //assign notificationThreshold
         numberOfChanges = 0; //initialize numberOfChanges
         t1 = new Thread(new ThreadStart(Activate)); //create thread for each new Stock
         t1.Start(); //start thread
      }//close Stock(...) 4 parameter constructor


      public void Activate() {
         for (int i = 0; i < 30; i = i + 1) {
            Thread.Sleep(500); //sleep for 1/2 second
            ChangeStockValue(); //Update the stock value        
         }//end for loop         
      }//close Activate()


      public void ChangeStockValue() {
         Random random = new Random();  //Declare random variable
         currentStockValue += random.Next(1, maxChange + 1); //update currentStockValue by random number
         //int randomNumber = random.Next(1, maxChange+1);
         //int sign = random.Next(0, 2);
         //randomNumber = (sign == 0) ? randomNumber : -randomNumber;
         //currentStockValue += randomNumber;
         numberOfChanges++; //increment the number of changes related to the designated stock.
         //if ((Math.Abs(currentStockValue - initialValue)) > notificationThreshold){
         if ((currentStockValue - initialValue) > notificationThreshold) {
            lock (threadLock) { //lock - create critical section that can only be accessed by 1 thread at a time
               //Declare new StockThresholdReachedEventArgs
               StockThresholdReachedEventArgs args = new StockThresholdReachedEventArgs();
               args.StockName = stockName; //set StockName data
               args.CurrentStockValue = currentStockValue; //set CurrentStockValue attribute 
               args.StockChangeNum = numberOfChanges; //set StockChangeNum 
               OnStockThresholdReached(args); //Raise Event - Display To Console
               OnWriteThresholdReached(args); //Raise Event - Write To Console
            }//close lock
         }//end if    
      }//close ChangeStockValue()


      public class StockThresholdReachedEventArgs : EventArgs {
         public string StockName { get; set; } //stores StockName data for event
         public int CurrentStockValue { get; set; } //stores CurrentStockValue data for event
         public int StockChangeNum { get; set; } //CurrentStockValue
      }//close class StockThresholdReachedEventArgs 


      protected virtual void OnStockThresholdReached(StockThresholdReachedEventArgs e) {
         EventHandler<StockThresholdReachedEventArgs> handler = StockThresholdReached;
         //make sure that the event is not null
         if (handler != null)
            handler(this, e); // raise the event
      }//close OnStockThresholdReached(...)


      protected virtual void OnWriteThresholdReached(StockThresholdReachedEventArgs e) {
         EventHandler<StockThresholdReachedEventArgs> handler = WriteThresholdReached;
         //make sure that the event is not null
         if (handler != null)
            handler(this, e); // raise the event
      }//close OnWriteThresholdReached(...)

   }//close class Stock
}//close namespace Lab_3_Stock_Tracker
