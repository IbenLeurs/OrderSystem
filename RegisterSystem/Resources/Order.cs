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

        public Order(string deformat)
        {
            deformat = deformat.Substring(deformat.IndexOf('x') + 1);

            //deformat = deformat.Replace(" ", "");
            deformat = deformat.Replace("\n", "");
            deformat = deformat.Replace(arrow, '/');

            if (deformat.Contains('-'))
            {
                main = deformat.Substring(0, deformat.IndexOf('-')).Replace(" ", "");
                option = deformat.Substring(deformat.IndexOf('-') + 1, deformat.IndexOf('/') - (deformat.IndexOf('-') + 1)).TrimStart();
                side = deformat.Substring(deformat.IndexOf('/') + 1);
            }
            else
            {
                main = deformat.Substring(0, deformat.IndexOf('/'));
                side = deformat.Substring(deformat.IndexOf('/') + 1);
            }
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