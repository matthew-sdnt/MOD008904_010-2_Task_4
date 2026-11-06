using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4.Classes.Extras
{
    internal class ExtraHot : Extra
    {
        public ExtraHot(int p_stock_left = 20) : base(p_stock_left)
        {
            this.extra_name = "Extra Hot Water";
            this.price = 0.25;
        }
    }
}
