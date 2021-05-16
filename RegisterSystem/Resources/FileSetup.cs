using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RegisterSystem.Resources
{
    public class FileSetup
    {
        private string path = "Files/";
        private string ticketPath = "Tickets/";
        private string studentFile = "StudentenID.txt";
        private string menuFile = "Menu.txt";
        private string tableFile = "Tafels.txt";

        private bool closeApp = false;

        public void SetupFiles()
        {
            ticketPath = ValidateStorage(ticketPath);

            studentFile = ValidateStorageLocation(studentFile);
            SetupStudentFile(studentFile);

            menuFile = ValidateStorageLocation(menuFile);
            SetupMenuFile(menuFile);

            tableFile = ValidateStorageLocation(tableFile);
            SetupTableFile(tableFile);

            if (closeApp)
            {
                MessageBox.Show("The missing files were generated. Please restart the program");
                Environment.Exit(1);
            }
        }

        private string ValidateStorage(string location)
        {
            if (!Directory.Exists($"{path}{location}"))
            {
                Directory.CreateDirectory($"{path}{location}");

                closeApp = true;
            }

            return $"{path}{location}";
        }

        private string ValidateStorageLocation(string file)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

                closeApp = true;
            }

            return $"{path}{file}";
        }

        private void SetupStudentFile(string file)
        {
            if (File.Exists(file))
            {
                return;
            }

            string fileText = "";

            fileText += "Plaats hier de ID voor elke student op een aparte regel.\n";

            File.WriteAllText(file, fileText);

            closeApp = true;
        }

        private void SetupMenuFile(string file)
        {
            if (File.Exists(file))
            {
                return;
            }

            string fileText = "";

            fileText += "Plaats op elke regel een menuitem in het volgende formaat:\nMain;Optie1,...;Side1,...\n";

            //for(int i = 0; i < 50; i++)
            //{
            //    fileText += $"\n";
            //}

            //fileText += $"---Max # Gerechten---";
            
            File.WriteAllText(file, fileText);

            closeApp = true;
        }

        private void SetupTableFile(string file)
        {
            if (File.Exists(file))
            {
                return;
            }

            string fileText = "";

            fileText += "Deze matrix vertegenwoordigd de tafels.\nVol het tafelnummer in tussen de [].\nLege [] zullen worden geinterpreteerd als niet beschikbare tafels.\n";

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    fileText += "[]";

                    if (j != 4)
                        fileText += " ";
                }

                if(i != 3)
                    fileText += "\n";
            }

            File.WriteAllText(file, fileText);

            closeApp = true;
        }

        public string GetTableFile()
        {
            return $"{path}{tableFile}";
        }

        public string GetStudentFile()
        {
            return $"{path}{studentFile}";
        }

        public string GetMenuFile()
        {
            return $"{path}{menuFile}";
        }

        public string GetTicketPath()
        {
            return $"{path}{ticketPath}";
        }
    }
}
