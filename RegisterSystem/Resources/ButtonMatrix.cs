using System;
using System.Windows;
using System.Windows.Controls;

namespace RegisterSystem.Resources
{
    public class ButtonMatrix
    {
        private Button[] buttons;

        public ButtonMatrix(string btnName, int rows, int columns, double fontSize, Grid grid)
        {
            buttons = new Button[rows * columns];

            int buttonCounter = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button button = new Button();
                    button.Name = $"{btnName}{buttonCounter}";
                    button.Margin = new Thickness(5);
                    button.FontSize = fontSize;
                    buttons[buttonCounter] = button;

                    buttonCounter++;

                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);

                    grid.Children.Add(button);
                }
            }
        }

        //public void SetClick(RoutedEventHandler func)
        //{
        //    foreach(Button b in buttons)
        //    {
        //        b.Click += func;
        //    }
        //}

        public Button[] GetButtons()
        {
            return buttons;
        }

        public void SetInvisible()
        {
            foreach(Button b in buttons)
            {
                b.Visibility = Visibility.Hidden;
                //b.IsEnabled = false;
            }
        }

        public void SetVisible()
        {
            foreach(Button b in buttons)
            {
                b.Visibility = Visibility.Visible;
                //b.IsEnabled = true;
            }
        }
    }
}
