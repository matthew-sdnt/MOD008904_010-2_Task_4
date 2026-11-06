using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4.Classes.Extras
{
    internal abstract class Extra
    {
        //Fields
        protected string extra_name;
        protected int stock_left;
        protected double price;

        //Properties
        public string Name
        {
            get { return this.extra_name; }
        }
        public int Stock
        {
            get { return this.stock_left; }
        }
        public double Price
        {
            get { return this.price; }
        }


        //Constructor
        protected Extra(int p_stock_left = 20)
        {
            this.stock_left = p_stock_left;
        }

        //Behaviours
        public void make_purchase()
        {
            this.stock_left--;
        }
    }
}
