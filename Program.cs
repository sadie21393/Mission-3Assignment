//initiate variables
using System.ComponentModel;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Mission_3Assignment;

internal class Program
{
    private static void Main(string[] args)
    {
        gatheruserinput();
    }
    private static void gatheruserinput()
    {
        string option1 = "1 - Add a food item";
        string option2 = "2 - Delete a food item";
        string option3 = "3 - Print a list of current food items";
        string option4 = "4 - Exit the program";

        //start the program and give the user options


        //recieve user input and control for user error  
        bool oValid = false;
        int userInput = 0;

        while (oValid == false)
        {
            Console.WriteLine("Welcome to your local food bank inventory system! What would you like to do?\n" +
            option1 + "\n" +
            option2 + "\n" +
            option3 + "\n" +
            option4);

            if (int.TryParse(Console.ReadLine(), out userInput) && userInput > 0)
            {
                string selectedOption = userInput switch
                {
                    1 => option1,
                    2 => option2,
                    3 => option3,
                    4 => option4,
                    _ => "Invalid option selected.",
                };
                Console.WriteLine("You Entered " + selectedOption);
                oValid = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer (ex: 1-4)");
            }

            mainfunctions(userInput);
        }
    }


    
    private static void mainfunctions(int userInput)
    {
        
        //OPTION 1 - Add Food Items
        bool addfood = false;
        string name = "";
        string category = "";
        int quantity = 0;
        string expiration = "";
        
        while (addfood == false)
            {
                if (userInput == 1)
                {
                    bool nValid = false;

                    while (nValid == false)
                    {
                        Console.WriteLine("Enter the name of the food item you would like to add: ");
                        string nInput = Console.ReadLine();
                        if (nInput != null)
                        {
                            name = nInput;
                            nValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid food name");
                        }

                    }

                    bool cValid = false;

                    while (cValid == false)
                    {
                        Console.WriteLine("Enter the name of the category of the food item you would like to add: ");
                        string cInput = Console.ReadLine();
                        if (cInput != null)
                        {
                            category = cInput;
                            cValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid category name");
                        }

                    }


                    bool qValid = false;

                    while (qValid == false)
                    {
                        Console.WriteLine("Enter the quantity of units of the food item you would like to add (ex: 15): ");

                        if (int.TryParse(Console.ReadLine(), out int qInput) && qInput > 0)
                        {
                            quantity = qInput;
                            qValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer (ex: 1-100)");
                        }
                    }

                    bool eValid = false;

                    while (eValid == false)
                    {
                        Console.WriteLine("Enter the expiration date of the food item you would like to add (ex:MM/DD/YYYY ): ");
                        string eInput = Console.ReadLine();
                        if (eInput != null)
                        {
                            expiration = eInput;
                            eValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid date");
                        }

                    }
                FoodItem fi = new FoodItem(name, category, quantity, expiration);
                    fi.addFood();
                    bool doneadd = false;
                    while (doneadd == false)
                    {
                        Console.WriteLine("are you done adding food? (y/n)");
                        string userprogram = Console.ReadLine();
                        if (userprogram.ToLower() == "y")
                        {
                            addfood = true;
                            doneadd = true;
                        }
                        else if (userprogram.ToLower() == "n")
                        {
                            Console.WriteLine("lets add more food!");
                            doneadd = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid input (y/n)");
                        }
                    }
                }
            else 
            {
                addfood = true;
            }
                
            }

            
            if (userInput == 3)
            {
                FoodItem fi2 = new FoodItem(name, category, quantity, expiration);
                fi2.printList();
            }

            if (userInput == 2)
            {
                FoodItem fi3 = new FoodItem(name, category, quantity, expiration);
                fi3.deleteFood(userInput);
            }

            if (userInput == 4)
            {
                
                Environment.Exit(0);
            }

        
            bool doneprogram = false;
            while (doneprogram == false)
            {
                Console.WriteLine("Are you done with the program?(y/n): ");
                string userprogram = Console.ReadLine();
                if (userprogram.ToLower() == "y")
                {
                    
                    doneprogram = true;
                    
                }
                else if (userprogram.ToLower() == "n")
                {
                    Console.WriteLine("Great!");
                    doneprogram = true;
                    gatheruserinput();
                }
                else
                {
                    Console.WriteLine("Please enter a valid input (y/n)");
                }

            }
        }


}



    
    
    

             
            

            