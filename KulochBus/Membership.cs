using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KulochBus
{
    class Membership
    {
        //klassvariabel
        public string Name;
        public int Price;
        
        public Membership()
        {

        }

        //konstruktor
        public Membership(string name, int price)
        {
            Name = name;
            Price = price;
        }

        // Generates the text shown in the combo box
        public override string ToString()
        {
            return Name;
        }
    }
}
