using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   abstract class HotDrink
    {
        public abstract int Milk { get; set; }
        public abstract int Sugar { get; set; }
        public abstract int AddMilk(int count);
        public abstract int AddSugar(int count);
        public abstract bool Drink(int number);

    }
}
