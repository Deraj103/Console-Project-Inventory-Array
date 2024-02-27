using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Console_Project_Inventory_Array
{
    internal class Program
    {
        //private static bool sellCheck;

        static void Main(string[] args)
        {
            string name;
            int itemID = 0;
            int quantity = 0;
            int soldQty = 0;
            int spot = 0;
            double price = 0;
            string reply;

            WriteLine("Chapter 10 Console Project: Inventory Array by Jared Tims");

            // inventory array
            int size = 3;
            ItemClass[] inventory = new ItemClass[size];

            // temp object
            ItemClass temp = new ItemClass();

            for (int i = 0; i < inventory.Length; i++)
            {
                WriteLine("\nAdd items to inventory");
                Write("Enter name of new item: ");
                name = ReadLine();
                try
                {
                    Write("Enter a numeric ID number of new item: ");
                    itemID = int.Parse(ReadLine());
                    Write("Enter price of this time: $");
                    price = double.Parse(ReadLine());
                    Write("Enter quantity for this time: ");
                    quantity = int.Parse(ReadLine());
                }
                catch (FormatException)
                {
                    WriteLine("Input is in the wrong format.");
                }
                finally
                {
                    inventory[i] = new ItemClass(itemID, name, quantity, price);
                }
            }

            WriteLine("\nInventory");
            foreach (ItemClass item in inventory)
            {
                WriteLine($"{item.display()}");
            }

            do
            {
                Write("\nWhat do you want to do: (s)Sell, (r)Restock, (p)Print, (x)Exit? ");
                reply = ReadLine();
                if (reply == "s")
                {
                    // this block of code is for selling a quantity of a item.
                    try
                    {
                        Write("Enter the item ID: ");
                        itemID = int.Parse(ReadLine());
                        spot = findIt(inventory, itemID);
                        if (spot != -1)
                        {
                            temp = inventory[spot];
                            Write("How many sold? ");
                            soldQty = int.Parse(ReadLine());
                            temp.sellMethod(soldQty);
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine("Input is in the wrong format.");
                    }
                }
                else if (reply == "r")
                {
                    // this block of code updates the quantity of an item.
                    try
                    {
                        Write("Enter the item ID: ");
                        itemID = int.Parse(ReadLine());
                        spot = findIt(inventory, itemID);
                        if (spot != -1)
                        {
                            temp = inventory[spot];
                            Write("What is the new quantity? ");
                            quantity = int.Parse(ReadLine());
                            inventory[spot].setQuantity(quantity);
                        }
                    }
                    catch (FormatException)
                    {
                        WriteLine("Input is in the wrong format.");
                    }
                }
                else if (reply == "p")
                {
                    // this block of code displays the available items and inventory.
                    foreach (ItemClass item in inventory)
                    {
                        WriteLine($"{item.display()}");
                    }
                }
                else if (reply == "x")
                {
                    // calculates nothing except to check if input is x
                }
                else
                {
                    WriteLine("Invalid option, please try again");
                }

            } while (reply != "x");

            WriteLine("\nPress any key to continue...");
            ReadKey();
        }

        // method to find an item in the array
        public static int findIt(ItemClass[] inventory, int itemID)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].getItemID() == itemID)
                {
                    WriteLine($"Found it! {inventory[i].display()}");
                    return i;
                }
            }
            WriteLine("Invalid ID number.");
            return -1;
        }
    }
}
