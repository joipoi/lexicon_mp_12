using lexicon_mp_12;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {

        List<Item> itemList = new List<Item>();
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("To enter a new product - follow the steps | To search for a product - enter: 'S' | To display items - enter: 'D' | To quit - enter: 'Q' ");
            Console.ResetColor();

            Console.Write("Enter a category: ");
            string category = Console.ReadLine();
            if (category.ToLower().Trim() == "q")
            {
                break;
            }else if(category.ToLower().Trim() == "d")
            {
                DisplayItems(itemList);
                continue;
            }else if (category.ToLower().Trim() == "s")
            {
                Console.Write("Enter search term: ");
                string searchTerm = Console.ReadLine();
                DisplayItems(itemList, searchTerm);
                continue;
            }

            Console.Write("Enter a product name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter a price: ");
            int price;
            while (!int.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid non-negative price.");
                Console.ResetColor(); 
            }


            Item item = new Item(category, productName, price);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The product was succesfully added!");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------");
            itemList.Add(item);
        }
        
        DisplayItems(itemList);
       
        Console.ReadKey();
    }
    
    //if no searchTerm is given, it defaults to empty string
    private static void DisplayItems(List<Item> items, string searchTerm = "")
    {
        var query = items.OrderBy(item => item.Price).ToList();

        Console.WriteLine("_____________________________________________________");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Category".PadRight(20) + "Product".PadRight(20) + "Price".PadRight(20));
        Console.ResetColor();
        foreach (var item in query)
        {
            if (item.ProductName.ToLower().Contains(searchTerm.ToLower()))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            Console.WriteLine(item.ToString());
            Console.ResetColor();
        }
        int sum = items.Sum(item => item.Price);
        Console.WriteLine("Total Price is: " + sum);
        Console.WriteLine("_____________________________________________________");
    }
}