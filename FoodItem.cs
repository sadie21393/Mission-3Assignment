using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Mission_3Assignment
{
    internal class FoodItem
    {
        public string foodName;
        public string foodCategory;
        public int foodQuant;
        public string foodExpo;
        public static List<FoodItem> foodlist = new List<FoodItem>();

        public FoodItem(string name, string category, int quantity, string expirationDate)
        {
            foodName = name;
            foodCategory = category;
            foodQuant = quantity;
            foodExpo = expirationDate;

        }
        public void addFood()
        {
            foodlist.Add(this);

        }
        public void printList()
        {
            if (foodlist.Count == 0)
            {
                Console.WriteLine("No food items available.");
                return;
            }
            else
            {
                int counter = 1;
                foreach (var item in foodlist)
                {
                    Console.WriteLine($"{counter} - Name: {item.foodName}, Category: {item.foodCategory}, Quantity: {item.foodQuant}, Expiration: {item.foodExpo}");
                    counter++;
                }
            }
        }
        public void deleteFood()
        {

            int userInput = 0;
            bool removeValid = false;

            while (removeValid == false)
            {
                printList();
                Console.WriteLine("What item would you like to remove (ex:1-100)");

                if (int.TryParse(Console.ReadLine(), out int itemInput) && itemInput > 0)
                {
                    userInput = itemInput;
                    removeValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer (ex: 1-100)");
                }
            }

            if (userInput > 0 && userInput <= foodlist.Count)
            {
                foodlist.RemoveAt(userInput - 1);
                Console.WriteLine("Food Item Removed");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number from the list.");
            }
        }
    }
}
