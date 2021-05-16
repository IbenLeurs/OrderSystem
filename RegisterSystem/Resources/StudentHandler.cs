using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RegisterSystem.Resources
{
    public class StudentHandler
    {
        private List<string> studentId = new List<string>();
        private FileSetup fs = new FileSetup();

        public StudentHandler()
        {
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
        }

        public List<string> GetList()
        {
            return studentId;
        }
    }
}
