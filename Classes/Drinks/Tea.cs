using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4.Classes.Drinks
{
    internal class Tea : Drink
    {
        public Tea(int p_stock_left = 10) : base(p_stock_left)
        {
            this.drink_name = "Tea";
            this.price = 0.99;
        }
    }
}
