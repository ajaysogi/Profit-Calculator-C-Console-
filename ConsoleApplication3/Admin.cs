//
// Author:        Ajay Sogi
// University ID: S12773251
// Build Date:    07-JAN-2014
// Project Name:  Profit_Application
// File Name:     Admin.cs
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms; // Access properties for using GUI functions
using System.Text.RegularExpressions;

namespace ConsoleApplication3
{
    public class Admin
    {
        // VALIDATION AND OVERRIDING VALUES USING CLASS REFERENCE
        // ======================================================

        // regeular expression that only accepts numbers
        public Regex regex = new Regex("[0-9]");

        // Create public method that takes in user input and overrides the values in the Values.cs class for Max Prod.
        public void ChangeMaxProd(Values cv)
        {
            // Display current value maxprod is set to.
            Console.WriteLine("Current Max Product Value is: {0}", cv.maxprod);

            // Prompt user to enter a value
            Console.Write("\nEnter New Value (UNITS): ");

        VALIDMAX: // Create a starting point called VALIDMAX

            PresenceCheck();

            // Reject any no numeric input
            if (!regex.IsMatch(invalid))
            {
                Console.Beep();
               MessageBox.Show("This is not a valid entry", "Input Format Error");
               goto VALIDMAX;
            }

            // pass the string value as a double.
            cv.maxprod = double.Parse(invalid);

            // Initiate a check constraint to check if the number entered is more than 0
            if (cv.maxprod < 0)
            {
                // Beep to alert user of error
                Console.Beep();
                // Use GUI function to Display a pop out box showing error
                MessageBox.Show("a Value less than 0 cannot be entered!");
                // Go to starting point VALIDMAX
                goto VALIDMAX;
            }

            Console.Clear();
        }

        // Create public method that takes in user input and overrides the values in the Values.cs class for Overheads.
        public void ChangeOverhead(Values cv)
        {
            // Display current value maxprod is set to.
            Console.WriteLine("Current Overheads Value is: £{0:0.00}", cv.overhead);

            // Prompt user to enter value
            Console.Write("\nEnter New Value £(00.00): ");

        VALIDOVER: // Create starting point 

            PresenceCheck();

            // Reject any no numeric input
            if (!regex.IsMatch(invalid))
            {
                Console.Beep();
                MessageBox.Show("This is not a valid entry", "Input Format Error");
                goto VALIDOVER;
            }

            // Take user string input and convert to double
            cv.overhead = double.Parse(invalid);

            // Check Constraint | Value should not be less than 0
            if (cv.overhead < 0)
            {
                // Alert User of error
                Console.Beep();
                // Display error message using GUI
                MessageBox.Show("a Value less than 0 cannot be entered!");
                // Goto starting point VALIDOVER to reask user to enter a value
                goto VALIDOVER;
            }

            Console.Clear();
        }

        // Create public method that takes in user input and overrides the values in the Values.cs class for selling price.
        public void ChangePrice(Values cv)
        {
            // Display current overhead value
            Console.WriteLine("Current Selling Price is: £{0:0.00}", cv.Price);

            // Prompt user to enter a value
            Console.Write("\nEnter New Value £(00.00): ");

        VALIDPRICE: // Create starting point VALIDPRICE

            PresenceCheck();

            // Reject any no numeric input
            if (!regex.IsMatch(invalid))
            {
                Console.Beep();
                MessageBox.Show("This is not a valid entry", "Input Format Error");
                goto VALIDPRICE;
            }

            // Take user string input and convert to double
            cv.Price = double.Parse(invalid);

            // Check Constraint | Reject value less than 0
            if (cv.Price < 0)
            {
                // Beep to alert user of error
                Console.Beep();
                // Display error message
                MessageBox.Show("a Value less than 0 cannot be entered!");
                // got to starting point VALIDPRICE
                goto VALIDPRICE;
            }

            Console.Clear();
        }

        // // Create public method that takes in user input and overrides the values in the Values.cs class for Material costs
        public void ChangeMaterial(Values cv)
        {
            // Display current results to screen
            Console.WriteLine("Current Materials Cost is: £{0:0.00}", cv.material);

            // Prompt user to enter new value
            Console.Write("\nEnter New Value £(00.00): ");

        VALIDMATERIAL: // Create starting point VALIDMATERIAL

            PresenceCheck();

            // Reject any no numeric input
            if (!regex.IsMatch(invalid))
            {
                Console.Beep();
                MessageBox.Show("This is not a valid entry", "Input Format Error");
                goto VALIDMATERIAL;
            }

            // Take user sting input and convert to double
            cv.material = double.Parse(invalid);

            // Check Constraint | Reject number less than 0
            if (cv.material < 0)
            {
                // Alert user of error
                Console.Beep();
                //Display error message
                MessageBox.Show("a Value less than 0 cannot be entered!");
                // goto starting point VALID MATERIAL
                goto VALIDMATERIAL;
            }

            Console.Clear();
        }

        // Calculate Profit
        // ========================================================================

        public void ForecastProfit(Values cv)
        {

            // Prompt user to enter number of widgits and display the max limit of what the can enter.
            // Convert string input into a double.
            Console.WriteLine("Please enter the number of wigits sold (MIN: 0 | MAX: {0}): ", cv.maxprod);

        TOP: // Create starting point TOP

            PresenceCheck();

            // Reject any no numeric input
            if (!regex.IsMatch(invalid))
            {
                Console.Beep();
                MessageBox.Show("This is not a valid entry", "Input Format Error");
                goto TOP;
            }

            cv.sold = double.Parse(invalid);
            
            // CHECK CONSTRAINT | Return error message for any value that is entered outside the range.
            if (cv.sold < 0 || cv.sold > cv.maxprod)
            {
                // Display Error message
                //Console.WriteLine("\nPlease Enter A Number Within The Range Of: 0 - {0}\n", cv.maxprod);
                string Error = "Range Error:";
                Console.Beep();
                MessageBox.Show("Please Enter A Number Within The Range Of: 0 - " + cv.maxprod.ToString(), Error);
                // goto Starting point
                goto TOP;

            }

            // execute all calculation methods 
            GetProductionCost(cv);
            GetProfitPercentage(cv);
            GrossProfit(cv);
            Achive10Percent(cv);

            //Prompt user to continue
            Console.WriteLine("\n\n\nPress ANY key to view results . . .");
            Console.ReadLine();
            Console.Clear();

            // Display results 
            DisplayResultsTable(cv);

        }

        // CALCULATION METHODS
        // ==============================================================================
        // Calculate Production costs
        public void GetProductionCost(Values cv)
        {
            cv.cost = (cv.material + (cv.overhead / cv.sold));
        }
        // Calculate Profit Percentage
        public void GetProfitPercentage(Values cv)
        {
            cv.profit = ((cv.Price - cv.cost) / cv.Price);
        }
        // Calculate Profit in £'s
        public void GrossProfit(Values cv)
        {

            cv.GrossProfit = cv.Price - cv.cost;
        }

        // Create public double variable
        public double MinimumUnitToBeSold;

        // Calculate how many units are needed to achive 10%
        public void Achive10Percent(Values cv)
        {
            // Create local variable which will be used to convert negative number into posotive for the formula
            double ConvertToPosotive = -1;
            // Formula for calculating minimum units.
            MinimumUnitToBeSold = (cv.overhead / ((((0.1 * cv.Price) - cv.Price) * ConvertToPosotive) - cv.material) + 1);
        }

        // DRAW TABLE CONTAINING ALL REQUIRED RESULTS
        // ==========================================

        public void DisplayResultsTable(Values cv)
        {
            // Creat local double variables
            double targetProfit = 0.1;
            double SoldInMultiplesOf100 = cv.sold / 100;

            // CHECK CONSTRAINT | Display results only if profit made was above 10%
            // Else display error message
            if (cv.profit > targetProfit)
            {
                // Display todays Date
                DateTime today = DateTime.UtcNow.Date;
                
                // Draw Table and enter appropriate values 
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("|                                                                  |");
                Console.WriteLine("|       P R O F I T   F O R E C A S T   C A L C U L A T E D        |");
                Console.WriteLine("|                                                                  |");
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("|Date       |Sold (1 x 100)| Price(£) | Cost(£) |  Gross Profit(£) |");
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine(String.Format("|{0,-5} | {1,-12} | {2,8} | {3,7} | {4,16} |", today.ToString("dd/MM/yyyy"), SoldInMultiplesOf100, String.Format("{0:0.00}", cv.Price), String.Format("{0:0.00}", cv.cost), String.Format("{0:0.00}", cv.GrossProfit)));
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine("|                        Pofit Percentage (%)                      |");
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine(String.Format("|{0,37}         \t\t           |", cv.profit.ToString("#0.##%")));
                Console.WriteLine("--------------------------------------------------------------------");
            }
            else 
            {
                // Display Error Message
                Console.WriteLine("Target Profit of 10% Was not met");
            }

            // Pause
            HoldScreen();
        }
        
        // PAUSE
        //====================================================================================
        // Create public class that will pause the screen
        public void HoldScreen()
        {
            Console.WriteLine("\n\n\nPress ANY key to continue . . .");
            Console.ReadLine();
            Console.Clear();
        }

        // PRESCENCE CHECK
        //=========================================================================================
        // Creat loal string variable invalid and set it to empty string
        public string invalid = "";

        // Check the field has not been left blank
        public void PresenceCheck()
        {
            do
            {
            

                //Prompt user to enter value
                Console.Write("\n=> ");
                invalid = Console.ReadLine();

                //prompt error if the field has been left blank
                if (invalid == "")
                {
                    Console.Beep();
                    MessageBox.Show("Please Enter A Valid Input Number Within Range", "Input Error:"); ;
                }

            } while (invalid.Trim() == "");
        }

        public void DrawDetailedTable(Values cv)
        {
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("|                                                                  |");
            Console.WriteLine("|        D E T A I L E D    F O R E C A S T    R E P O R T         |");
            Console.WriteLine("|                                                                  |");
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("|    Units    |   Cost (£)  |   Profit (%)   |   Gross Profit (£)  |");
            Console.WriteLine("====================================================================");

            if (MinimumUnitToBeSold > 0)
            {
                for (int i = 0; i < cv.maxprod + 1; i += 100)
                {
                    cv.sold = i;
                    GetProductionCost(cv);
                    GetProfitPercentage(cv);
                    GrossProfit(cv);
                    Achive10Percent(cv);

                    if (i > MinimumUnitToBeSold)
                    {

                        Console.WriteLine(String.Format("|    {0, -9}| {1, 8}    | {2, 10}     | {3, 12}        |", i, String.Format("{0:0.00}", cv.cost), String.Format("{0:0.00}", cv.profit * 100), String.Format("{0:0.00}", cv.GrossProfit)));

                    }

                }
            }
            else
            {
                Console.WriteLine("There is no potential Profit to be made.");
            }
            Console.WriteLine("====================================================================");

            // Pause
            HoldScreen();
        }


    } // End Admin
} // End Namespace
