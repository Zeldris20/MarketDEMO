using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal Wallet = 1000.00M; // M means its decimal I guess
            Console.WriteLine($"Balance : {Wallet}");




            Dictionary<string, double> groceryItems = new Dictionary<string, double>
            {
                { "Apples (per pound)", 1.99},
            { "Bananas (per pound)", 0.79},
            { "Milk (1 gallon)", 2.99},
            { "Eggs (dozen)", 2.49},
            { "Bread (loaf)", 2.19},
            { "Chicken Breast (per pound)", 3.99},
            { "Ground Beef (per pound)", 4.49},
            { "Salmon (per pound)", 7.99},
            { "Rice (per pound)", 1.49},
            { "Pasta (per pound)", 1.29},
            { "Tomatoes (per pound)", 1.89},
            { "Potatoes (per pound)", 0.99},
            { "Onions (per pound)", 0.79},
            { "Carrots (per pound)", 0.89},
            { "Cereal (box)", 3.49}

            };
            List<string> purchasedItems = new List<string>();
            Random rand = new Random();
            bool keepSelecting = true;

            while (keepSelecting)
            {
                Console.WriteLine("1: Buy");
                Console.WriteLine("2: Sell");


                Console.Write("\n Please select an option: ");
                string UserInput = Console.ReadLine();

                double selectedPrice = 0;
                Console.WriteLine($"you selected: {UserInput}");

                if (UserInput == "1")
                {
                    Console.WriteLine("Available grocery items: ");
                    int index = 1;
                    foreach (var item in groceryItems.Keys)
                    {
                        Console.WriteLine($"{index}. {item}");
                        index++;
                    }
                    Console.Write("Please select the item you want: ");
                    if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= groceryItems.Count)
                    {
                        string selectedKey = groceryItems.Keys.ElementAt(selectedIndex - 1);
                        selectedPrice = groceryItems[selectedKey];

                        if (Wallet >= (decimal)selectedPrice)
                        {
                            Wallet -= (decimal)selectedPrice;
                            Console.WriteLine($"You selected: {selectedKey} - ${selectedPrice:F2}");
                            Console.WriteLine($"Remaining wallet balance: ${Wallet}");

                            purchasedItems.Add(selectedKey);
                        }
                        else
                        {
                            Console.WriteLine("Insufficent funds");

                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }


                else if (UserInput == "2")
                {
                    if (purchasedItems.Count == 0)
                    {
                        Console.WriteLine("You have no items to sell");
                    }
                    else if (Wallet == 1000.00M)

                    {
                        Console.WriteLine("your wallet is full you cannot sell items");

                    }
                    else
                    {
                        Console.WriteLine("Your purchases: ");
                        for (int i = 0; i < purchasedItems.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {purchasedItems[i]}");

                        }
                        Console.WriteLine($"Current wallet balance: ${Wallet:F2}");

                        Console.Write("Enter the item number to refund (Y/N to continue): ");
                        string refundInput = Console.ReadLine();

                        if (refundInput.ToUpper() == "Y")
                        {
                            Console.Write("Enter the item number to refund: ");
                            if (int.TryParse(Console.ReadLine(), out int refundIndex) && refundIndex >= 1 && refundIndex <= purchasedItems.Count)
                            {
                                string refundedItem = purchasedItems[refundIndex - 1];
                                double refundedPrice = groceryItems[refundedItem];

                                Wallet += (decimal)refundedPrice;
                                purchasedItems.RemoveAt(refundIndex - 1);
                                Console.WriteLine($"Refunded: {refundedItem} - ${refundedPrice:F2}");
                                Console.WriteLine($"Updated wallet balance: ${Wallet:F2}");
                            }
                            else
                            {
                                Console.WriteLine("Invalid item number");
                            }
                }
                else if (refundInput.ToUpper() == "N")
                {
                    if (purchasedItems.Count > 0)
                    {
                        Console.WriteLine("Moving to the next item");
                    }

                    else
                    {
                        Console.WriteLine("No more items to sell.");
                        keepSelecting = false;
                    }
                }
                    } // End of the while loop

                }
            }
        }
    }
}

