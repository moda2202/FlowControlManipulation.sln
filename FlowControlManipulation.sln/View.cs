using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControlManipulation.sln
{
    internal class View
    {
        // Method take a title and a list of menu items to display the menu
        public void Show(string title, IReadOnlyList<string> menuItems)
        {
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine("Choose one of the following option by entering the number and press Enter");

            foreach (var item in menuItems)
            {
                Console.WriteLine(item);
            }

            Console.Write("Select an option: ");
        }
    }
}
