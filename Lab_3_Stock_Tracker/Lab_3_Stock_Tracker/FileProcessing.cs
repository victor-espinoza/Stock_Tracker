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
   class FileProcessing {

      public FileProcessing() {
         //Write the header to the file and overwrite any previously saved data.
         string fileInfo = String.Format("{0,-15}{1,-15}{2,-15}{3,-15}", "Broker Name:",
          "Stock Name:", "Current Value:", "Changes:");
         OverwriteFile(fileInfo);
      }//close FileProcessing() default constructor


      public FileProcessing(string fileData) {
         //Add stock data to the file without overwriting any previously saved data.
         AppendToFile(fileData);
      }//close FileProcessing(...) one parameter constructor


      private static void OverwriteFile(string fileData) {
         StreamWriter writer = null; //declare empty StreamWriter
         try {
            // Get the current directory.
            string path1 = Directory.GetCurrentDirectory();
            string path2 = "Console_Output.txt"; //set name of file

            //NOTE: The Console_Output.txt file is created in the 
            //...\Lab_3_Stock_Tracker\Lab_3_Stock_Tracker\bin\Debug directory.

            //update writer to write to designated file. Adds to the file / no overwriting
            writer = new StreamWriter(Path.Combine(path1, path2), false);
            writer.WriteLine(fileData); //write data to file
         }//end try
         catch {
            Console.WriteLine("File write operation failed..."); //display any errors in writing to file
         }//end catch
         finally {
            if (writer != null)
               writer.Close(); //close StreamWriter
         }//end finally
      }//close OverwriteFile(...)


      public static void AppendToFile(string fileData) {
         StreamWriter writer = null; //declare empty StreamWriter
         try {
            // Get the current directory.
            string path1 = Directory.GetCurrentDirectory();
            string path2 = "Console_Output.txt"; //set name of file

            //update writer to write to designated file. Overwrites any previously saved data in the file
            writer = new StreamWriter(Path.Combine(path1, path2), true);
            writer.WriteLine(fileData);
         }//end try
         catch {
            Console.WriteLine("File write operation failed...");
         }//end catch
         finally {
            if (writer != null)
               writer.Close(); //clse StreamWriter
         }//end finally
      }//close AppendToFile(...)

   }//close class FileProcessing
}//close namespace Lab_3_Stock_Tracker
