using System;
using uppgiftlibrary;

namespace uppgift
{
    class Program
    {
        static void Main(string[] args)
        {

            ItemModel itemModel = new ItemModel
            {
                ItemName = "test",
                ItemID = "23"
            };

            System.Console.WriteLine($"Name: {itemModel.ItemName} ID: {itemModel.ItemID}");

        }
    }
}
