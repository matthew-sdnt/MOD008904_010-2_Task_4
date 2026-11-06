using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4.Classes.Extras
{
    internal class Milk : Extra
    {
        public Milk(int p_stock_left = 20) : base(p_stock_left)
        {
            this.extra_name = "Milk";
            this.price = 0.50;
        }
    }
}
