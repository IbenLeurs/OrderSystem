using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterSystem.Resources
{
    public class Order
    {
        private string main;
        private string option;
        private string side;
        private char arrow = '\u2BA9';

        public Order()
        {

        }

        public Order(string m, string o, string s)
        {
            main = m;
            option = o;
            side = s;
        }

        public void SetMain(string m)
        {
            main = m;
        }

        public void SetOption(string o)
        {
            option = o;
        }

        public void SetSide(string s)
        {
            side = s;
        }

        public string GetOrder()
        {
            return $"{main};{option};{side}";
        }

        public string FormatedOrder()
        {
            if(option == "")
            {
                return $"{main}\n{arrow}{side}";
            }
            else
            {
                return $"{main} - {option}\n{arrow}{side}";
            }
        }
    }
}
