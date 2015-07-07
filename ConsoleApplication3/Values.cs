//
// Author:        Ajay Sogi
// University ID: S12773251
// Build Date:    07-JAN-2014
// Project Name:  Profit_Application
// File Name:     Values.cs
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    public class Values
    {
        // Default Set Values that will constantly change
        public double maxprod = 4000;
        public double overhead = 2015, material = 0.6, Price = 2;

        // Public Variable for units sold
        public double sold = 0;

        // Public variables which store Production Costs, Profit Percentage, Total Profit in £'s
        public double cost = 0, profit = 0, GrossProfit = 0, totalProfit = 0;
    } // End Values
}
