using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4.Classes.Drinks
{
    internal class Coffee : Drink
    {
        public Coffee(int p_stock_left = 10) : base(p_stock_left)
        {
            this.drink_name = "Coffee";
            this.price = 1.99;
        }
    }
}
