﻿using System;

namespace uppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] DataList = new string[1];
            int index = 0;
            string commandStr = "\ncommands:\nExit: quits the program\nList: lists out the qurrently enterd products\nHelp: lists out commands\n";
            Console.WriteLine("\nWrite in productnumbers");
            Console.WriteLine(commandStr);
            while(true){

                string data = GetNameFromUser();
                string dataTrim = data.Trim();

                if(dataTrim.ToLower() == "exit"){
                    Array.Sort(DataList);
                    writeList(DataList);
                    break;
                }else if(dataTrim.ToLower() == "list"){
                    Array.Sort(DataList);
                    writeList(DataList);
                    continue;
                }
                else if(dataTrim.ToLower() == "help"){
                    Console.WriteLine(commandStr);
                    continue;
                }

                bool valid = validateInput(dataTrim);
                
                if(valid){
                    DataList[index] = dataTrim;
                    index++;
                    Array.Resize(ref DataList, index+1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("product added: " + dataTrim);
                }
                Console.ResetColor();
            }

        }


        static bool validateInput(string input){
            if(checkForSpecialChar(input)){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No special charecters allowed");
                return false;
            }

            bool result = false; 
            if(input == ""){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("must add productnumber!");
                return false;
            }
            
            //check the string
            if(!input.Contains("-")){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format \'-\' was not found");
                return false;
            }

            string[] SplitArr = input.Split("-");
            
            if(SplitArr[0] == ""){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format on the left side!");
                return false;
            }
            
            if(SplitArr[1] == ""){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format on the right side!");
                return false;
            }

            //check fist part
            if(findnum(SplitArr[0])){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format on the left side!");
                return false;
            }else{
                result = true;
            }

            bool isInt = int.TryParse(SplitArr[1], out int value2); 
            //check second part
            if(isInt){
                if(value2 < 200){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("must be between 200 and 500");
                    return false;

                }
                else if (value2 > 500){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("must be between 200 and 500");
                    return false; 

                }
                else{
                    result = true;
                }
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format on the right side");
                return false; 
            }
            
            
            return result;
        }


        static bool checkForSpecialChar(string value){
            string specialChar = "_@£$#\"";
            char[] specialarr = specialChar.ToCharArray();

            char[] chararr = value.ToCharArray();
            foreach(char i in chararr){
                string inputTemp = i.ToString();
                foreach(char j in specialChar){
                    string specialTemp = j.ToString();
                    bool result = inputTemp.Equals(specialTemp);
                    if(result){
                        return true;
                    }
                }
            }
            return false; 
        }

        static bool findnum(string value){
            char[] chararr = value.ToCharArray();
            for(var i = 0; i < chararr.Length; i++){
                string temp = chararr[i].ToString();
                bool isint = int.TryParse(temp, out int in1);
                if(isint){
                    return true;
                }
            }
            return false;
        }

        static void writeList(string[] arr){

            if(arr.Length == 1){
                Console.WriteLine("\nNo products enterd\n");
            }else{
                Console.WriteLine("\nYou enterd these product (sorted):\n");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach(string i in arr){
                    if(i != null){
                        Console.WriteLine("* {0}", i);
                    }
                }
                Console.ResetColor();
                Console.WriteLine("");
            }

           
        }

        static string GetNameFromUser(){
            Console.Write("Enter Prodoct: ");
            string Name = Console.ReadLine();
            return Name;
        }

        
    }
}
