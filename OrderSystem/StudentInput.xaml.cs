using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OrderSystem.Classes;

namespace OrderSystem
{
    /// <summary>
    /// Interaction logic for StudentInput.xaml
    /// </summary>
    public partial class StudentInput : Window
    {
        private List<string> students;

        public StudentInput()
        {
            InitializeComponent();

            students = new DataHandler().GetStudentList();
            ResponseTextBox.Focus();
            btnOkay.IsDefault = true;
        }

        public string StudentID
        {
            get { return ResponseTextBox.Text; }
            set { ResponseTextBox.Text = value; }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (students.Contains(ResponseTextBox.Text))
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Geef een geldig ID in.", "Foutieve ID", MessageBoxButton.OK);
                return;
            }
        }
    }
}
