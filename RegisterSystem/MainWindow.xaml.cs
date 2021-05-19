using RegisterSystem.Resources;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RegisterSystem
{
    public partial class MainWindow : Window
    {
        private ButtonMatrix buttons;
        private TableHandler tb;
        private FileSetup fs = new FileSetup();

        public MainWindow()
        {
            fs.SetupFiles();

            InitializeComponent();

            tb = new TableHandler();
            buttons = new ButtonMatrix("btnTable", 4, 5, 36, TableGrid);
            SetupButtons();

            WindowState = WindowState.Maximized;
            //WindowStyle = WindowStyle.None;
        }

        public void SetupButtons()
        {
            string[] tables = tb.GetTables();
            Button[] b = buttons.GetButtons();

            for(int i = 0; i < tables.Length; i++)
            {
                if (!tables[i].Equals(string.Empty))
                {
                    b[i].Content = $"Tafel {tables[i]}";
                    b[i].Click += TableOrder;
                }
                else
                {
                    b[i].IsEnabled = false;
                }
            }
        }

        public void TableOrder(object sender, RoutedEventArgs e)
        {
            var student = new StudentInput();
            if (student.ShowDialog() == true)
            {
                string text = ((Button)e.Source).Content.ToString();
                int tableNr = Convert.ToInt32(text.Substring(text.IndexOf(' ')));
                
                new ItemWindow(tableNr, student.StudentID, this).Show();
                Hide();

            }
        }
    }
}