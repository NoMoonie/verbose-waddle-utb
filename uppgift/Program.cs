using System;
using uppgiftlibrary;

namespace uppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = GetNameFromUser();
            string id = GetIdFromUser();
            
            ItemModel itemModel = new ItemModel
            {
                ItemName = name,
                ItemID = id
            };

            Console.WriteLine($"Name: {itemModel.ItemName} | ID: {itemModel.ItemID}");

        }


        static string GetNameFromUser(){
            Console.Write("enter name: ");
            string Name = Console.ReadLine();
            
            return Name;
        }

        static string GetIdFromUser(){
            Console.Write("enter id: ");
            string id = Console.ReadLine();

            return id ;
        }
    }
}
