//
// Author:        Ajay Sogi
// University ID: S12773251
// Build Date:    07-JAN-2014
// Project Name:  Profit_Application
// File Name:     Program.cs
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication3
{

   public class Program
   {

       static void Main(string[] args)
       {
           // Set new windows size
           ApplyWindowSize();

           // Run Intro()
           Intro(); 

           // Call MainInterface Class to use the functions within it.
           MainInterface IF = new MainInterface();

           // Call and execute function that displays the interface.
           IF.Int();
       }

       private static void Intro()
       {
           // Create local variable string called intro
           string intro;

           // Generate text and assign to the string variable
           intro =  "\n\n\n**************************************************";
           intro += "\n          Profit Calculator Application";
           intro += "\n             Developer: Ajay Sogi (c)";
           intro += "\n            Date Developed: 07/10/2014";
           intro += "\n**************************************************";
           intro += "\n           Press ANY key to continue . . .";

           // Write out string to console screen
           Console.WriteLine(intro);

           // Pause screen and wait for user input
           Console.ReadLine();

           // Clear screen
           Console.Clear();
       } // End Intro()

       // Create new Window Size
       public static void ApplyWindowSize()
       {
           int origWidth = Console.WindowWidth = 70;
           int origHeight = Console.WindowHeight = 35;

           int width = origWidth;
           int height = origHeight;

          Console.SetWindowSize(width, height);
       }


   } // End Program
}
