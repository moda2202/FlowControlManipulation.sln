using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControlManipulation.sln
{
    // AppModel class to hold application data and constants representing the database of the application
    public class AppModel
    {
        // Menu text
        public string MainMenuTitle { get; } = "=== MAIN MENU ===";
        public string subMenuTitle { get; } = "=== SUB MENU ===";

        // main menu items
        public IReadOnlyList<string> MainMenuItems { get; } = new List<string>
    {
        "1. Check ticket price",
        "2. Repeat text ten times",
        "3. Get the third word from a sentence",
        "0. Exit program"
    };

        // sub menu items for the first option in main menu
        public IReadOnlyList<string> SubMenuItems { get; } = new List<string>
    {
        "1. Check ticket price for individual (youth or senior)",
        "2. Check total price for a group",
        "0. Return to main menu"
    };

        // Ticket prices
        public int PriceYouth { get; } = 80;
        public int PriceSenior { get; } = 90;
        public int PriceAdult { get; } = 120;
        public int PriceFree { get; } = 0;

        // Age limits
        public int YouthMaxAge { get; } = 20;
        public int SeniorMinAge { get; } = 65;
        public int FreeBelowAge { get; } = 5;
        public int FreeAboveAge { get; } = 100;
    }
}

