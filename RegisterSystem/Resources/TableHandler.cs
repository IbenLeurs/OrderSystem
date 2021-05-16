using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RegisterSystem.Resources
{
    public class TableHandler
    {
        private string[] tables = new string[20];
        private FileSetup fs = new FileSetup();

        public TableHandler()
        {
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
        }

        public string[] GetTables()
        {
            return tables;
        }
    }
}
