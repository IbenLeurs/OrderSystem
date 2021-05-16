using System;
using System.Windows;
using System.Collections.Generic;
using RegisterSystem.Resources;

namespace RegisterSystem
{
    public partial class StudentInput : Window
    {
        private StudentHandler sHandler;
        private List<string> students;

        public StudentInput()
        {
            InitializeComponent();

            sHandler = new StudentHandler();
            students = sHandler.GetList();
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
            if (students.Contains(ResponseTextBox.Text)) {
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