using Task_4.Classes;

namespace Task_4
{
    internal class Program
    {
        static int input_int(string p_prompt) //Method to input integers. For this program, this is only here to provide function to the range restricted overload of this method.
        {
            //Variables
            int num;

            //Logic
            Console.Write(p_prompt); //Prompt user.
            while (!int.TryParse(Console.ReadLine(), out num)) //Takes input, loops if not a double.
            {
                Console.Clear();
                Console.WriteLine("Please input an integer."); //Error.
                Console.Write(p_prompt); //Reprompt user.
            }

            return num;
        }
        static int input_int(string p_prompt, int p_min, int p_max) //An overload of the input_int method that reprompts if the input is not in a certain range.
        {
            //Variables
            int num;

            //Logic
            do
            {
                num = input_int(p_prompt); //Calls the input_int method defined prior and passes the prompt in.
                if (num < p_min || num > p_max)
                {
                    Console.Clear();
                    Console.WriteLine($"Please input a number in the given range ({p_min} - {p_max}).");
                }
            } while (num < p_min || num > p_max); //Check if number is in the given range.

            Console.Clear();
            return num;
        }
        static double input_double(string p_prompt) //Method to input doubles, this exists as a method of abstracting this logic from the main function.
        {
            //Variables
            double num;

            //Logic
            Console.Write(p_prompt); //Prompt user.
            while (!double.TryParse(Console.ReadLine(), out num)) //Takes input, loops if not a double..
            {
                Console.Clear();
                Console.WriteLine("Please input a decimal number or integer."); //Error.
                Console.Write(p_prompt); //Reprompt user.
            }

            Console.Clear();
            return num;
        }
        static void Main(string[] args)
        {
            //MOD008904 010-2 Task_4 - Software for Hot Drinks Vending Machine
            //Variables
            VendingMachine vending = new VendingMachine("log.csv");
            int drink_choice;
            List<int> extra_choice;

            //Logic
            do
            {
                extra_choice= new List<int>();
                drink_choice = input_int(vending.list_drinks() + "Choice: ", 1, vending.Drinks.Count);
                for (int i = 0;  i < vending.Extras.Count; i++)
                {
                    extra_choice.Add(input_int($"{vending.Extras[i].Name}, price: {vending.Extras[i].Price}, stock left: {vending.Extras[i].Stock}\n1. Yes\n2. No\nChoice:", 1, 2));
                }
                vending.buy_drink(drink_choice, extra_choice, input_double("Input your payment: "));
            } while (drink_choice != 5);
        }
    }
}
