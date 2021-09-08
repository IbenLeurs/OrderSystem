using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace OrderSystem.Classes
{
    public class DataHandler
    {
        private FileSetup fs = new FileSetup();

        public string[] GetTables()
        {
            string[] tables = new string[20];
            string data = File.ReadAllText(fs.GetTableFile());

            int t = 0;
            string[] lines = data.Split('\n');

            for (int i = 3; i < lines.Length; i++)
            {
                foreach (string s in lines[i].Split(' '))
                {

                    tables[t] = Regex.Match(s, @"\[([^]]*)\]").Groups[1].Value;

                    t++;
                }
            }

            return tables;
        }

        public List<string> GetStudentList()
        {
            List<string> studentId = new List<string>();
            string data = File.ReadAllText(fs.GetStudentFile());

            string[] lines = data.Split('\n');

            for (int i = 1; i < lines.Length; i++)
            {
                studentId.Add(lines[i].TrimEnd('\r'));
            }

            //if (!data.Equals(""))
            //{
            //    foreach (string s in data.Split('\n'))
            //    {
            //        if (!s.Equals(data.Split('\n')[0]))
            //        {
            //            studentId.Add(s.TrimEnd('\r'));
            //        }                    
            //    }
            //}

            return studentId;
        }

        public List<Order> GetMenuList(string file)
        {
            List<Order> foodItems = new List<Order>();

            string data = File.ReadAllText(file);

            string[] lines = data.Split('\n');

            List<string> str = new List<string>();

            if (lines.Length != 52)
            {
                for (int i = 2; i < lines.Length; i++)
                {
                    str.Add(lines[i]);
                }

                for (int i = str.Count; i < 50; i++)
                {
                    str.Add("");
                }
            }

            for (int i = 0; i < 50; i++)
            {
                if (!str[i].Equals(""))
                {
                    str[i] = str[i].Trim();
                    //foodItems.Add(new Order(str[i]));
                }
                else
                {
                    //foodItems.Add(new Order(string.Empty, new string[0], new string[0]));
                }
            }

            return foodItems;
        }

        public List<MainDish> GetMainDishes()
        {
            List<MainDish> foodItems = new List<MainDish>();

            //string data = File.ReadAllText(fs.GetMainDishesFile());

            //string[] lines = data.Split('\n');

            //List<string> str = new List<string>();

            //if (lines.Length != 52)
            //{
            //    for (int i = 2; i < lines.Length; i++)
            //    {
            //        str.Add(lines[i]);
            //    }

            //    for (int i = str.Count; i < 50; i++)
            //    {
            //        str.Add("");
            //    }
            //}

            //for (int i = 0; i < 50; i++)
            //{
            //    if (!str[i].Equals(""))
            //    {
            //        str[i] = str[i].Trim();
            //        foodItems.Add(new MainDish(str[i]));
            //    }
            //    else
            //    {
            //        foodItems.Add(new MainDish(string.Empty, new string[0]));
            //    }
            //}

            return foodItems;
        }
    }
}