using System;

namespace uppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                invalid tests

                AC-123    (Number lower than 200)
                BC-700    (Number higher than 500)
                B -300    (One space after B)
                BC- 301   (One space after -)
                CD-499    (One space after 499)
                DC-355-   (One - after 355)
            */

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

                bool valid = validateInput(data);
                
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
            //checks for spacial chars 
            if(checkForSpecialChar(input)){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No special charecters allowed");
                return false;
            }
            //check if the string is empty
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

            //split string
            string[] SplitArr = input.Split("-");
            
            //ends with space
            if(SplitArr[1].EndsWith(" ")){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format \'space\' after " + SplitArr[1]);
                return false;
            }
            //start with space
            if(SplitArr[0].StartsWith(" ")) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format \'space\' before " + SplitArr[0].Trim());
                return false;
            }

            //check if the string has more the one dash "-"
            if(SplitArr.Length > 2){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format \'-\' after " + SplitArr[1]);
                return false;
            }

            //check for if there is spaces in middle off the string
            string[] lastValue = checkForSpaces(input);
            if(lastValue[0] == "true"){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("One space after " + lastValue[1]);  
                return false;
            }
            
            //checks if the first part off the string is empty
            if(SplitArr[0] == ""){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format on the left side!");
                return false;
            }
            //checks if the second part off the string is empty
            if(SplitArr[1] == ""){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format on the right side!");
                return false;
            }

            //checks if the first part has numbers
            if(findnum(SplitArr[0])){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format on the left side!");
                return false;
            }else{
                result = true;
            }

            //checks the second part if is a number and in the range of the min and max 
            bool isInt = int.TryParse(SplitArr[1], out int value2);
            //check second part
            if(isInt){
                if(value2 < 200){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Number lower than 200");
                    return false;

                }
                else if (value2 > 500){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Number higher than 500");
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

        static string[] checkForSpaces(string value){
            char[] charaar = value.ToCharArray();
            string[] resultarr = new string[2];
            string result = "false";
            string oldvalue = "";
            foreach(char i in charaar){
                string valueTemp = i.ToString();
                if(valueTemp == " "){
                    result = "true";
                    break;
                }
                oldvalue = i.ToString();
            }
            resultarr[0] = result;
            resultarr[1] = oldvalue;
            return resultarr;
        }


        static bool checkForSpecialChar(string value){
            string specialChar = "_@$#\"\'\\|!%&/(){}[]€";
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
