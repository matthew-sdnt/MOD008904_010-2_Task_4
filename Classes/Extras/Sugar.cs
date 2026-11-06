using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4.Classes.Extras
{
    internal class Sugar : Extra
    {
        public Sugar(int p_stock_left = 20) : base(p_stock_left)
        {
            this.extra_name = "Sugar";
            this.price = 0.50;
        }
    }
}
