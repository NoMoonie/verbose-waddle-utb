using System;

namespace uppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int minNum = 200;
            int maxNum = 500; 
            */
            
            
            while(true){
                Console.WriteLine("Skriv in produkter, Avsluta med att skriva \'exit\'");

                string data = GetNameFromUser();

                string[] DataList = new string[10];




                if(data.Trim().ToLower() == "exit"){
                   
                    writeList(DataList);
                    break;
                }

            }

        }


        static void writeList(string[] arr){
            foreach(string i in arr){
                Console.WriteLine("* {0}", i);
            }
        }

        static string GetNameFromUser(){
            Console.Write("Enter Prodoct: ");
            string Name = Console.ReadLine();
            return Name;
        }

        
    }
}
