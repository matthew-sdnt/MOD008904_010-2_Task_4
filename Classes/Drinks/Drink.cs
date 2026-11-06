using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4.Classes.Drinks
{
    internal abstract class Drink
    {
        //Fields
        protected string drink_name;
        protected int stock_left;
        protected double price;

        //Properties
        public string Name
        {
            get { return drink_name; }
        }
        public int Stock
        {
            get {  return this.stock_left; }
        }
        public double Price
        {
            get { return this.price; }
        }
        
        //Constructor
        protected Drink(int p_stock_left = 10)
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
