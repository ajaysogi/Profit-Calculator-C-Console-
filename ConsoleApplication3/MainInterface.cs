//
// Author:        Ajay Sogi
// University ID: S12773251
// Build Date:    07-JAN-2014
// Project Name:  Profit_Application
// File Name:     MainInterface.cs
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms; // Access properties for using GUI functions
using System.Text.RegularExpressions;

namespace ConsoleApplication3
{
    // Create a Public class 
    public class MainInterface
    {

        // Call all classes so approiate methods/functions can be retrived from each class
        Values v = new Values();
        Program p = new Program();
        Admin a = new Admin();

        // Create two strings called password and input
        string password = "0000"; // Set 4 digit password
        string input = string.Empty; 

        // Create public method which generates the interface
        public void Int()
        {
            
            // Create local string variable to handle interface input
            int adminChoice;

            // Initiate do loop to handle menu navigation
            do
            {
                // Execute formula to find the minimum units needed to achive atleast 10 % of sales.
                a.Achive10Percent(v);

                // Draw Menu Out to user 
                InstructionMenu();

            TopAdminChoice: // Generate staring point for when exiting loop

                // Presence Check
                a.PresenceCheck();

                // Accept only numeric numbers
                if (!a.regex.IsMatch(a.invalid))
                {
                    Console.Beep();
                    MessageBox.Show("This is not a valid entry", "Input Format Error");
                    goto TopAdminChoice;
                }

                // Take user input as an int
                adminChoice = int.Parse(a.invalid);
                
                // Initiate Constraint Check for user input
                if (adminChoice < 0 || adminChoice > 6)
                {
                    // Beep to alert user of error
                    Console.Beep();

                    // Access GUI function to display error message as a pop up.
                    MessageBox.Show("Please Enter a Valid Number!");
                    
                    // Head back to starting point 
                    goto TopAdminChoice;
                }

                // Clear Screen
                Console.Clear();

                // Take user input and direct user to appropriate menus
                switch (adminChoice)
                {
                    case 1: // Change Max Number
                        AdminChoiceOne();
                        break;

                    case 2: // Change Selling Price
                        AdminChoiceTwo();
                        break;

                    case 3: // Change Overhead
                        AdminChoiceThree();
                        break;

                    case 4: // Change Material Cost
                        AdminChoiceFour();
                        break;

                    case 5: // Calculate Production cost, calculate profit percentage and display results
                        a.ForecastProfit(v);
                        break;

                    case 6: // Display Detailed Forecast Report
                        a.DrawDetailedTable(v);
                        break;
                } // End Switch Statement
            } while (adminChoice != 0); // Exit Application if the "0" key is entered.
        } // End Int()


        // SECURITY PROTECTED 
        //===========================================================================================

        // Password protection on changing max value 
        private void AdminChoiceOne()
        {
            // Prompt user to enter password and store as a string input
            Console.WriteLine("Please Enter The 4-Digit Code To Proceed: ");
            Console.Write("\n4 Digit Code -> ");
            input = Console.ReadLine();

            // Denny Access if passwords dont match or allow acces if passwords match
            if (input != password)
            {
                // Deny access and prompt user back to menus
                AccessDenied();
            }
            else
            {
                // grant access and allow user to change values
                AccessGranted();

                // Call function from admin class to change maximum products value
                a.ChangeMaxProd(v);

                // Display Updated output for maximum units that can be sold
                Console.WriteLine("\n\nUpdated Value is: {0}", v.maxprod);

                // Call pause function from admin class
                a.HoldScreen();
            }
        } // End admin choice one

        // Password protection on changing selling price
        private void AdminChoiceTwo()
        {
            // Prompt user to enter password and store as a string input
            Console.WriteLine("Please Enter The 4-Digit Code To Proceed: ");
            Console.Write("\n4 Digit Code -> ");
            input = Console.ReadLine();

            // Denny Access if passwords dont match or allow acces if passwords match
            if (input != password)
            {
                // Deny access and prompt user back to menus
                AccessDenied();
            }
            else
            {
                // grant access and allow user to change values
                AccessGranted();

                // Call function from admin class to change price 
                a.ChangePrice(v);

                // Display Updated output for selling price
                Console.WriteLine("Updated Value is: {0:0.00}", v.Price);

                // Call pause function from admin class
                a.HoldScreen();
            }
        } // End adminchoicetwo()

        // Password protected overheads
        private void AdminChoiceThree()
        {
            // Prompt user to enter password and store as a string input
            Console.WriteLine("Please Enter The 4-Digit Code To Proceed: ");
            Console.Write("\n4 Digit Code -> ");
            input = Console.ReadLine();

            // Denny Access if passwords dont match or allow acces if passwords match
            if (input != password)
            {
                // Deny access and prompt user back to menus
                AccessDenied();
            }
            else
            {
                // grant access and allow user to change values
                AccessGranted();

                // Call function from admin class to change overheads 
                a.ChangeOverhead(v);

                // Display Updated output for Overheads
                Console.WriteLine("Updated Value is: {0:0.00}", v.overhead);

                // Call pause function from admin class
                a.HoldScreen();
            }
        } // End adminchoicethree()

        // Password protected material costs
        private void AdminChoiceFour()
        {
            // Prompt user to enter password and store as a string input
            Console.WriteLine("Please Enter The 4-Digit Code To Proceed: ");
            Console.Write("\n4 Digit Code -> ");
            input = Console.ReadLine();

            // Denny Access if passwords dont match or allow acces if passwords match
            if (input != password)
            {
                // Deny access and prompt user back to menus
                AccessDenied();
            }
            else
            {
                // grant access and allow user to change values
                AccessGranted();

                // Call function from admin class to change material costs
                a.ChangeMaterial(v);

                // Display Updated output for material costs
                Console.WriteLine("Updated Value is: {0:0.00}", v.material);

                // Call pause function from admin class
                a.HoldScreen();
            }
        } // End adminchoicefour()


        private void AccessDenied()
        {
            Console.WriteLine("\n***************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nA C C E S S  -  D E N I E D\n");
            Console.ResetColor();
            Console.WriteLine("***************************\n");

            Console.WriteLine("Password was incorect\n\nYou will now be returned back to options screen");

            a.HoldScreen();
        }
        private void AccessGranted()
        {
            Console.WriteLine("\n******************************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nA C C E S S  - G R A N T E D\n");
            Console.ResetColor();
            Console.WriteLine("******************************\n");

            // Prompt continue
            a.HoldScreen();
        }
        private void InstructionMenu()
        {
            Console.WriteLine("=====================================================");
            
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("                                                     ");
            Console.WriteLine("\t   ! A D M I N - S E T T I N G S !           ");
            Console.WriteLine("                                                     ");
            Console.ResetColor();
            
            Console.WriteLine("=====================================================");
            Console.WriteLine("[1] Change Maximum Number | Current: {0} Units", v.maxprod);
            Console.WriteLine("[2] Change Selling Price  | Current: £{0:0.00}", v.Price);
            Console.WriteLine("[3] Change Overhead Cost  | Current: £{0:0.00}", v.overhead);
            Console.WriteLine("[4] Change Material Cost  | Current: £{0:0.00}", v.material);
            Console.WriteLine("=====================================================\n");
            Console.WriteLine("\t\tU S E R - O P T I O N S\n");
            Console.WriteLine("=====================================================");
            Console.WriteLine("[5] Display Accurate Profit Report");
            Console.WriteLine("[6] Display Overview Profit Report");
            Console.WriteLine("[0] Exit Application");
            Console.WriteLine("=====================================================\n");
            Console.WriteLine("  T A R G E T - S A L E S - T O - M E E T - 1 0 %");


            if (a.MinimumUnitToBeSold < v.maxprod || a.MinimumUnitToBeSold == v.maxprod)
            {
                Console.WriteLine("\n\t\t    {0:0} UNITS\n", a.MinimumUnitToBeSold);
            }
            else
            {
                Console.WriteLine("\n\t\t    {0:0} UNITS\n", a.MinimumUnitToBeSold);
                Console.WriteLine("\t\tThis Is Not Achieveable\n");
            }

            //Console.WriteLine("\n\t\t    {0:0} UNITS\n", a.MinimumUnitToBeSold);
            Console.WriteLine("=====================================================");
            Console.WriteLine("\nPress one of the following indicated keys to proceed:");
        }
        


    } // End MainInterface Class

}

