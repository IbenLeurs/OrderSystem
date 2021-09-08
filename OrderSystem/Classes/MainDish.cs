using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Classes
{
    public class MainDish
    {
        private string main;
        private string[] options;

        public MainDish(string data)
        {
            Seperater(data);
        }

        public MainDish(string item, string[] option)
        {
            main = item;
            options = option;
        }

        public void Seperater(string data)
        {
            string[] split = data.Trim().Split(';');

            main = split[0];

            if (split[1] != null && !split[1].Equals(string.Empty))
            {
                options = split[1].Trim().Split(',');
            }
        }

        public string GetMain()
        {
            return main;
        }

        public string[] GetOptions()
        {
            return options;
        }
    }
}