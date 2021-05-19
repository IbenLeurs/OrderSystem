using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterSystem.Resources
{
    public class FoodItem
    {
        private string main;
        private string[] options;
        private string[] sides;

        public FoodItem(string data)
        {
            Seperater(data);
        }

        public FoodItem(string item, string[] option, string[] side)
        {
            main = item;
            options = option;
            sides = side;
        }

        public void Seperater(string data)
        {
            string[] split = data.Split(';');

            main = split[0];

            if (split[1] != null && !split[1].Equals(string.Empty))
            {
                options = split[1].Split(',').Select(o => o.TrimStart()).ToArray();
            }

            if (split[2].Contains(','))
            {
                sides = split[2].Split(',');

                for(int i = 0; i < sides.Length; i++)
                {
                    sides[i] = sides[i].Trim();
                }
            }
            else
            {
                sides = new string[] { split[2] };
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

        public string[] GetSides()
        {
            return sides;
        }
    }
}