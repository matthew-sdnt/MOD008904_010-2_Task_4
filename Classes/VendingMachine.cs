using System;
using System.Collections.Generic;
using System.Text;
using Task_4.Classes.Drinks;
using Task_4.Classes.Extras;

namespace Task_4.Classes
{
    internal class VendingMachine
    {
        //Fields
        List<Drink> drinks;
        List<Extra> extras;
        StreamWriter stream;

        //Properties
        public int DrinkNum {
            get { return drinks.Count; }
        }
        public int ExtrasNum
        {
            get { return extras.Count; }
        }

        //Constructor
        public VendingMachine(string p_log_file)
        {
            drinks = new List<Drink>();
            drinks.Add(new Tea()); //Leaving blank so the class will use its default stock amount.
            drinks.Add(new Coffee()); //Leaving blank so the class will use its default stock amount.

            extras = new List<Extra>();
            extras.Add(new ExtraHot());
            extras.Add(new Milk());
            extras.Add(new Sugar());

            if (!File.Exists(p_log_file))
            {
                stream = new StreamWriter(p_log_file);
                stream.Write("Drink Name,Extras,Total Price,Inputted Total,Refund Total");
                stream.Flush();
            }
            else
            {
                stream = new StreamWriter(p_log_file);
            }
        }

        //Behaviours
        public double buy_drink(int p_selection, List<int> p_addons, double p_payment)
        {
            double original_payment = p_payment;
            double total_price = drinks[p_selection - 1].Price;
            bool enough_extra_stock = true;

            for (int i = 0; i < p_addons.Count; i++)
            {
                if (p_addons[i] == 1)
                {
                    total_price += extras[i].Price;
                    if (extras[i].Stock == 0)
                    {
                        enough_extra_stock = false;
                    }
                }
            }

            if (p_payment < total_price)
            {
                Console.WriteLine("You have not inputted enough money to purchase this item, no purchase processing.");
            }
            else if (drinks[p_selection - 1].Stock == 0 && enough_extra_stock)
            {
                Console.WriteLine("Not enough stock to purchase this item, no purchase processing.");
            }
            else if (p_payment == total_price)
            {
                Console.WriteLine("You have inputted exactly enough money to purchase this item, purchase processing.");
                p_payment -= total_price; //Same as just setting p_payment to 0 for the change but this way is better practice.
                drinks[p_selection - 1].make_purchase();
                for (int i = 0; i < p_addons.Count; i++)
                {
                    if (p_addons[i] == 1)
                    {
                        extras[i].make_purchase();
                    }
                }
            }
            else
            {
                Console.WriteLine("You have inputted more than enough to purchase this item, purchase processing.");
                p_payment -= total_price;
                drinks[p_selection - 1].make_purchase();
                for (int i = 0; i < p_addons.Count; i++)
                {
                    if (p_addons[i] == 1)
                    {
                        extras[i].make_purchase();
                    }
                }
            }

            Console.WriteLine($"Returning unused {p_payment}.");

            stream.WriteLine($"{drinks[p_selection - 1].Name},{extras.ToString().Replace(",", "")},{total_price},{original_payment},{p_payment}");
            stream.Flush();
            return p_payment;
        }
        public void list_drinks()
        {
            for (int i = 0; i < drinks.Count; i++)
            {
                Console.WriteLine($"Drink {i + 1}: {drinks[i].Name}, price: {drinks[i].Price}, stock left: {drinks[i].Stock}");
            }
        }
        public void list_extras()
        {
            for (int i = 0; i < extras.Count; i++)
            {
                Console.WriteLine($"Extra {i + 1}: {extras[i].Name}, price: {extras[i].Price}, stock left: {extras[i].Stock}");
            }
        }
    }
}
