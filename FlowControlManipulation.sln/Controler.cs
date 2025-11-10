using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControlManipulation.sln
{
    internal class Controler
    {
        View menuView;
        AppModel appModel;
        private bool _isMainMenuRunning = true;
        private bool _isSubMenuRunning = true;


        // Constructor to initialize the Controler with View and AppModel
        public Controler(View menuView, AppModel appModel)
        {
            this.menuView = menuView;
            this.appModel = appModel;
        }

        // Main loop to run the application
        public void run()
        {
            do
            {
                menuView.Show(appModel.MainMenuTitle, appModel.MainMenuItems);
                HandelUserInputMainMenu(ReadInput());
            } while (_isMainMenuRunning);
        }


        // Methods to handle user input for main men 
        public void HandelUserInputMainMenu(string UserInput)
        {
            switch (UserInput)
            {
                case "0":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    _isMainMenuRunning = false;
                    break;
                case "1":
                    RunSubMenu();
                    break;
                case "2":
                    //RepeatTextTenTimes();
                    break;
                case "3":
                    //GetThirdWord();
                    break;
                default:
                    WriteError("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }

        // Methods to handle user input for sub menu
        public void HandelUserInputSubMenu(string UserInput)
        {

            switch (UserInput)
            {
                case "0":
                    _isSubMenuRunning = false;
                    break;
                case "1":
                    CheckIndividualTicketPrice();
                    break;
                case "2":
                    CheckGroupTicketPrice();
                    break;
                default:
                    WriteError("Invalid choice. Press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }

        // This method checks the total ticket price for a group based on their ages
        private void CheckGroupTicketPrice()
        {
            Console.Clear();
            Console.Write("Please enter number of people (or 0 to return to main menu): ");

            if (!int.TryParse(ReadInput(), out int persons) || persons < 0)
            {
                WriteError("Invalid input. Please enter a valid number.");
                return;
            }

            if (persons == 0)
                return;

            int totalPrice = 0;

            for (int i = 0; i < persons; i++)
            {
                Console.Write($"Enter age of person {i + 1}: ");
                if (!int.TryParse(ReadInput(), out int age) || age < 0)
                {
                    WriteError("Invalid age. This person will be skipped.");
                    continue;
                }

                totalPrice += GetTicketPriceByAge(age);
            }

            Console.WriteLine();
            Console.WriteLine($"Total people: {persons}");
            Console.WriteLine($"Total price: {totalPrice} kr.");
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        // This method checks the ticket price for an individual based on their age
        private void CheckIndividualTicketPrice()
        {
            Console.Write("Please enter your age in numbers (or 0 to return to main menu): ");
            if (!int.TryParse(ReadInput(), out int age))
            {
                Console.Clear();
                WriteError("Invalid input. Please enter a number or press 0 to return.");
                return;
            }

            if (age == 0)
            {
                this._isSubMenuRunning = false;
                return;
            }

            int price = GetTicketPriceByAge(age);

            if (price == 0)
                Console.WriteLine("Free ticket!");
            else
                Console.WriteLine($"The ticket price is {price} kr.");

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();

        }

        // Method to run the sub menu loop
        private void RunSubMenu()
        {
            _isSubMenuRunning = true;
            Console.Clear();
            do
            {
                menuView.Show(appModel.subMenuTitle, appModel.SubMenuItems);
                HandelUserInputSubMenu(ReadInput());
            } while (_isSubMenuRunning);
        }


        // Helper method to determine ticket price based on age
        private int GetTicketPriceByAge(int age)
        {
            if (age < appModel.FreeBelowAge || age > appModel.FreeAboveAge)
                return 0;
            if (age <= appModel.YouthMaxAge)
                return appModel.PriceYouth;
            if (age >= appModel.SeniorMinAge)
                return appModel.PriceSenior;

            return appModel.PriceAdult;
        }

        // Helper method to write error messages in red color
        private void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // Helper method to read and trim user input
        private string ReadInput() =>
            (Console.ReadLine() ?? string.Empty).Trim();
    }
}
