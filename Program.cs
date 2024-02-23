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
        static void Main(string[] args)
        {
            string name;
            int itemID = 0;
            int quantity = 0;
            int soldQty = 0;
            int spot = 0;
            int newQty = 0;
            double price = 0;
            string reply;
            bool sellCheck = false;

            WriteLine("Chapter 10 Console Project: Inventory Array by Jared Tims");

            // inventory array
            int size = 3;
            ItemClass[] inventory = new ItemClass[size];

            for (int i = 0; i < inventory.Length; i++)
            {
                WriteLine("\nAdd items to inventory");
                Write("Enter name of new item: ");
                name = ReadLine();
                // is try/catch even needed?
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
                do
                {
                    if (reply == "s")
                    {
                        // this block of code is for selling a quantity of a item.
                        try
                        {
                            Write("Enter the item ID: ");
                            itemID = int.Parse(ReadLine());
                            (spot, sellCheck) = findIt(inventory, itemID, sellCheck);
                            if (spot != -1)
                            {
                                Write("How many sold? ");
                                soldQty = int.Parse(ReadLine());
                                (sellCheck) = inventory[spot].sellMethod(soldQty, sellCheck);
                            }
                        }
                        catch (FormatException)
                        {
                            WriteLine("Input is in the wrong format.");
                            sellCheck = true;
                        }
                        //WriteLine(inventory[spot].getQuantity());
                    }
                    else if (reply == "r")
                    {
                        // this block of code adds quantity to an item.
                        try
                        {
                            Write("Enter the item ID: ");
                            itemID = int.Parse(ReadLine());
                            (spot, sellCheck) = findIt(inventory, itemID, sellCheck);
                            Write("How many are we adding? ");
                            newQty = int.Parse(ReadLine());
                            inventory[spot].restockMethod(newQty);
                        }
                        catch (FormatException)
                        {
                            WriteLine("Input is in the wrong format.");
                            sellCheck = true;
                        }
                    }
                    else if (reply == "p")
                    {
                        // this block of code displays the available items and inventory.
                        foreach (ItemClass item in inventory)
                        {
                            WriteLine($"{item.display()}");
                            sellCheck = true;
                        }
                    }
                    else if (reply == "x")
                    {
                        sellCheck = true;
                    }
                    else
                    {
                        WriteLine("Invalid option, please try again");
                        sellCheck = true;
                    }
                } while (sellCheck == false);

            } while (reply != "x");

            WriteLine("\nPress any key to continue...");
            ReadKey();
        }


        // method to find an item in the array
        public static (int, bool) findIt(ItemClass[] inventory, int itemID, bool sellCheck)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].getItemID() == itemID)
                {
                    WriteLine($"Found it! {inventory[i].display()}");
                    return (i, sellCheck);
                }
            }
            WriteLine("Invalid ID number.");
            sellCheck = true;
            return (-1, sellCheck);
        }
    }
}
