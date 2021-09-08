using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace OrderSystem.Classes
{
    public class FileSetup
    {
        private string path = "Files/";
        private string ticketFolder = "Tickets/";
        private string errorFolder = "Errors/";
        private string menuFolder = "Menu/";

        private string catergory = "Category.txt";
        private string studentFile = "StudentenID.txt";
        private string tableFile = "Tafels.txt";

        private bool closeApp = false;
        private List<string> list = new List<string>(0);

        public void SetupFiles()
        {
            ticketFolder = ValidateFolder(ticketFolder);
            errorFolder = ValidateFolder(errorFolder);
            menuFolder = ValidateFolder(menuFolder);

            //studentFile = ValidateFile(studentFile);
            ValidateFile($"{path}{studentFile}", "Plaats hier de ID voor elke student op een aparte regel.\n");

            //tableFile = ValidateFile(tableFile);
            ValidateFile($"{path}{tableFile}", TableMatrixText());

            if (closeApp)
            {
                MessageBox.Show("The missing files were generated. Please restart the program");
                Environment.Exit(1);
            }
        }

        private string ValidateFolder(string location)
        {
            if (!Directory.Exists($"{path}{location}"))
            {
                Directory.CreateDirectory($"{path}{location}");

                closeApp = true;
            }

            return $"{path}{location}";
        }

        private void ValidateFile(string file, string text)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

                closeApp = true;
            }

            if (File.Exists(file))
            {
                return;
            }


            string fileText = "";

            fileText += text;

            File.WriteAllText(file, fileText);

            closeApp = true;
        }

        private void SetupCatFile(string file)
        {
            if (File.Exists(file))
            {
                return;
            }

            string fileText = "";

            foreach(string s in list)
            {
                fileText += $"{s}\n";
            }

            File.WriteAllText(file, fileText);

            closeApp = true;
        }

        private void SetupMainDishFile(string file)
        {
            if (File.Exists(file))
            {
                return;
            }

            string fileText = "";

            fileText += "Plaats op elke regel een hoofdgerecht in het volgende formaat: Hoofdgerecht;Optie 1, Optie 2\n(Opties zijn enkel nodig indien er verschillende bereidingswijzes zijn, max. 50 items)";

            //for(int i = 0; i < 50; i++)
            //{
            //    fileText += $"\n";
            //}

            //fileText += $"---Max # Gerechten---";

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

            fileText += "Plaats op elke regel een menuitem.\nLet op, gebruik maar 1 item per regel (Max. 50 items).";

            //for(int i = 0; i < 50; i++)
            //{
            //    fileText += $"\n";
            //}

            //fileText += $"---Max # Gerechten---";

            File.WriteAllText(file, fileText);

            closeApp = true;
        }

        private string TableMatrixText()
        {
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

                if (i != 3)
                    fileText += "\n";
            }

            return fileText;
        }

        public string GetTableFile()
        {
            return $"{path}{tableFile}";
        }

        public string GetStudentFile()
        {
            return $"{path}{studentFile}";
        }

        public string GetTicketPath()
        {
            return $"{path}{ticketFolder}";
        }
    }
}