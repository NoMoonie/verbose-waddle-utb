using System;

namespace uppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] DataList = new string[1];
            int index = 0;

            Console.WriteLine("\nWrite in productnumbers, To stop type \'exit\' \nType \'list\' to list out the products enterd \n");
            
            while(true){

                string data = GetNameFromUser();
                if(data.Trim().ToLower() == "exit"){
                    Array.Sort(DataList);

                    writeList(DataList);
                    break;
                }else if(data.Trim().ToLower() == "list"){
                    Array.Sort(DataList);
                    writeList(DataList);
                    continue;
                }

                bool valid = validateInput(data);
                
                if(valid){
                    DataList[index] = data;
                    index++;
                    Array.Resize(ref DataList, index+1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("product added: " + data);
                }
                Console.ResetColor();
            }

        }


        static bool validateInput(string input){
            //xx-000
            bool result = false; 
            if(input == ""){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("must add productnumber!");
                return false;
            }
            
            //check if the dash "-" exists
            string format = input.Substring(2, 1);
            if(format != "-"){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format need the \'-\' example: [xx-000]");
                return false;
            }else{
                result = true;
            }
            
            //check the string
            string[] SplitArr = input.Split("-");
            string FirstCheck = input.Substring(0, 2);
            bool isNotInt = int.TryParse(SplitArr[0], out int value1);
            bool isInt = int.TryParse(SplitArr[1], out int value2); 

            //check fisrt part
            if(!isNotInt){

                string FirstChar = SplitArr[0].Substring(0, 1);
                string secondChar = SplitArr[0].Substring(1, 1);
                bool isChar1 = int.TryParse(FirstChar, out int char1);
                bool isChar2 = int.TryParse(secondChar, out int char2);

                if(isChar1 && isChar2){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong format on the left side!");
                    return false; 
                } 
                else {
                    result = true;
                }
            }
            //check second part
            if(isInt){
                if(value2 < 200){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("must be between 200 and 500!");
                    return false; 

                }
                else if (value2 > 500){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("must be between 200 and 500!");
                    return false; 

                }
                else{
                    result = true;
                }
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong format on the right side!");
                return false; 
            }
            

            return result;
        }


        static void writeList(string[] arr){

            Console.WriteLine("\nYou enterd these prodoct (sorted):\n");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach(string i in arr){
                if(i != null){
                    Console.WriteLine("* {0}", i);
                }
            }
            Console.ResetColor();
            Console.WriteLine("");
        }

        static string GetNameFromUser(){
            Console.Write("Enter Prodoct: ");
            string Name = Console.ReadLine();
            return Name;
        }

        
    }
}
