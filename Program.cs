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
            int itemID = 0, quantity = 0, soldQty = 0, spot = 0;
            double price = 0;
            string reply;
            bool stop = false;

            WriteLine("Chapter 10 Console Project: Inventory Array by Jared Tims");

            //ItemClass temp = new ItemClass();

            // inventory array
            int size = 1;
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
                        try
                        {
                            Write("Enter the item ID: ");
                            itemID = int.Parse(ReadLine());
                            spot = findIt(inventory, itemID, stop);
                            Write("How many sold? ");
                            soldQty = int.Parse(ReadLine());
                            inventory[spot].sellMethod(soldQty, stop);
                        }
                        catch (FormatException)
                        {
                            WriteLine("Input is in the wrong format.");
                            stop = true;
                        }
                        //WriteLine(inventory[spot].getQuantity());
                    }
                    else if (reply == "r")
                    {

                    }
                    else if (reply == "p")
                    {

                    }
                    else if (reply == "x")
                    {

                    }
                    else
                    {
                        WriteLine("Invalid option, please try again");
                        stop = true;
                    }
                } while (stop == false);

            } while (reply != "x");

            WriteLine("\nPress any key to continue...");
            ReadKey();
        }


        // method to find an item in the array
        public static int findIt(ItemClass[] inventory, int itemID, bool stop)
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
            stop = true;
            return -1;
        }
    }
}
