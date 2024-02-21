using System;
using System.Collections.Generic;
using System.Linq;
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
            int itemID, quantity, soldQty;
            double price;
            string reply;

            WriteLine("Chapter 10 Console Project: Inventory Array by Jared Tims");

            ItemClass temp = new ItemClass();

            // inventory array
            int size = 1;
            ItemClass[] inventory = new ItemClass[size];

            for (int i = 0;  i < inventory.Length; i++)
            {
                WriteLine("\nAdd items to inventory");
                Write("Enter name of new item: ");
                name = ReadLine();
                Write("Enter ID number of new item: ");
                itemID = int.Parse(ReadLine());
                Write("Enter price of this time: $");
                price = double.Parse(ReadLine());
                Write("Enter quantity for this time: ");
                quantity = int.Parse(ReadLine());
                inventory[i] = new ItemClass(itemID, name, quantity, price);
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
                    Write("Enter item ID: ");
                    itemID = int.Parse(ReadLine());
                    //int spot = ItemClass.findIt(inventory, itemID);
                    ItemClass.findIt(inventory, itemID);
                    Write("How many sold? ");
                    soldQty = int.Parse(ReadLine());
                    if (soldQty < temp.getQuantity())
                    {
                        temp.quantity -= soldQty;
                    }
                    else
                    {
                        WriteLine("Not enough on hand to sell that many.");
                    }
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
                }
            } while (reply != "x");

            WriteLine("\nPress any key to continue...");
            ReadKey();
        }
    }
}
