using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Console_Project_Inventory_Array
{
    class ItemClass
    {
        private string name;
        private int itemID, quantity;
        private double price;

        // constructor
        public ItemClass(int id, string n, int q, double p)
        {
            this.itemID = id;
            this.name = n;
            this.quantity = q;
            this.price = p;
        }

        // getter
        public int getItemID() { return this.itemID; }
        public int getQuantity() { return this.quantity; }

        // setter
        public void setQuantity(int q)
        {
            this.quantity = q;
        }

        // expression-bodied method to display info
        public string display() => $"{itemID} {name}, price: {price:c}, {quantity} on hand";

        // method to set the quantity for restock
        public int restockMethod(int newQty)
        {
            quantity += newQty;
            WriteLine($"{display()}");
            return 0;
        }

        // method to subtract from the available quantity for sale.
        // needs to return a boolean that indicates if the sale was successful or not.
        // Only change the quantity if there is enough on hand for the sale.
        public bool sellMethod(int soldQty, bool sellCheck)
        {
            sellCheck = false;

            if (soldQty < quantity)
            {
                sellCheck = true;
                quantity -= soldQty;
                WriteLine($"{display()}");
            }
            else
            {
                WriteLine("Not enough on hand to sell that many.");
                WriteLine($"{display()}");
                sellCheck = true;
            }
            return sellCheck;
        }
    }
}
