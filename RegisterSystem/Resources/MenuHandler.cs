using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterSystem.Resources
{
    public class MenuHandler
    {
        private FileSetup fs = new FileSetup();
        private List<FoodItem> foodItems = new List<FoodItem>();

        public MenuHandler()
        {
            string data = File.ReadAllText(fs.GetMenuFile());

            string[] lines = data.Split('\n');

            List<string> str = new List<string>();

            if (lines.Length != 52)
            {
                for(int i = 2; i < lines.Length; i++ )
                {
                    str.Add(lines[i]);
                }

                for(int i = str.Count; i < 50; i++)
                {
                    str.Add("");
                }
            }

            for (int i = 0; i < 50; i++)
            {
                if (!str[i].Equals(""))
                {
                    //str[i] = str[i].Replace(" ", "");
                    str[i] = str[i].Trim();
                    foodItems.Add(new FoodItem(str[i]));
                }
                else
                {
                    foodItems.Add(new FoodItem(string.Empty, new string[0], new string[0]));
                }
            }
        }

        public FoodItem GetItem(int pos)
        {
            return foodItems[pos];
        }

        public List<FoodItem> GetList()
        {
            return foodItems;
        }
    }
}
