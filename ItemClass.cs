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

        // default constructor
        public ItemClass()
        {
            // default constructor added to allow an instantiation in main.
        }

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
        public void setQuantity(int newQty)
        {
            quantity = newQty;
            WriteLine($"{display()}");
        }

        // expression-bodied method to display info
        public string display() => $"{itemID} {name}, price: {price:c}, {quantity} on hand";

        // method to subtract from the available quantity for sale.
        // needs to return a boolean that indicates if the sale was successful or not.
        // Only change the quantity if there is enough on hand for the sale.
        public void sellMethod(int soldQty)
        {
            if (soldQty <= quantity)
            {
                quantity -= soldQty;
                WriteLine($"{display()}");
            }
            else
            {
                WriteLine("Not enough on hand to sell that many.");
                WriteLine($"{display()}");
            }
        }
    }
}
