using System;

namespace InventorySystem
{
    class Inventory
    {
        // Private field to store the inventory data
        private Item[] items;

        // Constructor to initialize the inventory with a specified number of items
        public Inventory(int size)
        {
            items = new Item[size];
        }

        // Method to add a new item to the inventory
        public void AddItem(Item item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    return;
                }
            }
            Console.WriteLine("Error: Inventory is full.");
        }

        // Method to update the quantity of an existing item in the inventory
        public void UpdateQuantity(string name, int quantity)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null && items[i].Name == name)
                {
                    items[i].Quantity += quantity;
                    return;
                }
            }
            Console.WriteLine("Error: Item not found.");
        }

        // Method to display the current inventory
        public void DisplayInventory()
        {
            Console.WriteLine("Current inventory: ");
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    Console.WriteLine(items[i].ToString());
                }
            }
        }
    }

    // Item class to represent a single item in the inventory
    class Item
    {
        // Private fields to store the item's name, quantity, and price
        private string name;
        private int quantity;
        private double price;

        // Constructor to create a new item with a specified name, quantity, and price
        public Item(string name, int quantity, double price)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
        }

        // Public properties to access the private fields
        public string Name
        {
            get { return name; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double Price
        {
            get { return price; }
        }

        // Overridden ToString method to display the item's name, quantity, and price
        public override string ToString()
        {
            return $"{name}: {quantity} @ ${price:F2} each";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a new inventory with a capacity of 10 items
            Inventory inventory = new Inventory(10);

            // Loop until the user chooses to exit
            bool exit = false;
            while (!exit)
            {
                // Display the menu and prompt the user for a choice
                Console.WriteLine("Inventory System");
                Console.WriteLine("1. View inventory");
                Console.WriteLine("2. Add item");
                Console.WriteLine("3. Update quantity");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                // Process the user's choice
                switch (choice)
                {
                    case "1":
                        // Display the current inventory
                        inventory.DisplayInventory();
                        break;
                    case "2":
                        // Prompt the user for the item's name, quantity, and price
                        Console.Write("Enter the item's name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter the item's quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        Console.Write("Enter the item's price: ");
                        double price = double.Parse(console.ReadLine());

                        // Add the new item to the inventory
                        Item item = new Item(name, quantity, price);
                        inventory.AddItem(item);
                        break;
                    case "3":
                        // Prompt the user for the item's name and the quantity to add
                        Console.Write("Enter the item's name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter the quantity to add: ");
                        quantity = int.Parse(console.ReadLine());

                        // Update the quantity of the item
                        inventory.UpdateQuantity(name, quantity);
                        break;
                    case "4":
                        // Set the exit flag to true to end the loop
                        exit = true;
                        break;
                    default:
                        // Display an error message for invalid choices
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
