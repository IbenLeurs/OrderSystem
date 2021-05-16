using RegisterSystem.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace RegisterSystem
{
    public partial class ItemWindow : Window
    {
        private ButtonMatrix mainButtons;
        private ButtonMatrix optionButtons;
        private ButtonMatrix sideButtons;
        private Order fillOrder;
        private Window preWindow;
        private MenuHandler mHandler = new MenuHandler();
        private Dictionary<string, int> orderList = new Dictionary<string, int>();
        private Dictionary<object, int> itemList = new Dictionary<object, int>();
        private FoodItem curMain;
        private FileSetup fs = new FileSetup();
        private bool switchCancel = true;

        public ItemWindow(int table, string student, Window window)
        {
            InitializeComponent();

            SetupButtons();
            SetupMain();
            preWindow = window;

            txtData.Text = $"Student: {student}\nTafel: {table}";

            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        private void SetupButtons()
        {
            mainButtons = new ButtonMatrix("btnMain", 10, 5, 20, MenuGrid);
            optionButtons = new ButtonMatrix("btnOption", 10, 5, 20, MenuGrid);
            sideButtons = new ButtonMatrix("btnSide", 10, 5, 20, MenuGrid);

            optionButtons.SetInvisible();
            sideButtons.SetInvisible();
        }

        private void SetupMain()
        {
            int counter = 0;
            Button[] buttons = mainButtons.GetButtons();

            foreach (FoodItem m in mHandler.GetList())
            {
                if (!m.GetMain().Equals(""))
                {
                    buttons[counter].Content = m.GetMain();
                    buttons[counter].Click += FoodSelected;
                }
                else
                {
                    buttons[counter].IsEnabled = false;
                }

                counter++;
            }
        }

        private void SetupOption(FoodItem main)
        {
            int counter = 0;
            Button[] buttons = optionButtons.GetButtons();

            foreach (string o in main.GetOptions())
            {
                if (!o.Equals(string.Empty))
                {
                    buttons[counter].Content = o;
                    buttons[counter].Click += OptionSelected;
                    buttons[counter].IsEnabled = true;
                }
                counter++;
            }

            for (int i = counter; i < buttons.Length; i++)
            {
                buttons[i].Content = "";
                buttons[i].IsEnabled = false;
            }

            if (counter == 0)
            {
                fillOrder.SetOption("");
                optionButtons.SetInvisible();
                sideButtons.SetVisible();
            }
        }

        private void SetupSide(FoodItem main)
        {
            int counter = 0;
            Button[] buttons = sideButtons.GetButtons();

            foreach (string o in main.GetSides())
            {
                if (!o.Equals(string.Empty))
                {
                    buttons[counter].Content = o;
                    buttons[counter].Click += SideSelected;
                    buttons[counter].IsEnabled = true;
                }
                counter++;
            }

            for (int i = counter; i < buttons.Length; i++)
            {
                buttons[i].IsEnabled = false;
                buttons[i].Content = "";
            }
        }

        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            Close();
            preWindow.Activate();
        }


        private void FoodSelected(object sender, RoutedEventArgs e)
        {
            if (switchCancel)
            {
                btnCancel.IsEnabled = false;
                btnCancel.Visibility = Visibility.Collapsed;
                //btnDelete.Visibility = Visibility.Visible;

                btnFinish.IsEnabled = true;

                switchCancel = false;
            }


            fillOrder = new Order();

            fillOrder.SetMain(((Button)e.Source).Content.ToString());

            int pos = Convert.ToInt32(((Button)e.Source).Name.Substring(7));

            curMain = mHandler.GetItem(pos);

            SetupOption(curMain);

            mainButtons.SetInvisible();
            optionButtons.SetVisible();
        }

        private void OptionSelected(object sender, RoutedEventArgs e)
        {
            fillOrder.SetOption(((Button)e.Source).Content.ToString());
            
            SetupSide(curMain);

            optionButtons.SetInvisible();
            sideButtons.SetVisible();

            e.Handled = true;
        }

        private void SideSelected(object sender, RoutedEventArgs e)
        {
            fillOrder.SetSide(((Button)e.Source).Content.ToString());
            
            sideButtons.SetInvisible();
            mainButtons.SetVisible();

            AddOrder();

            e.Handled = true;
        }

        private void AddOrder()
        {
            string order = fillOrder.GetOrder();

            if (orderList.ContainsKey(order))
            {
                orderList[order] += 1;

                string fOrder = $"{orderList[order]}x {fillOrder.FormatedOrder()}";
                GetItem($"{orderList[order] - 1}x {fillOrder.FormatedOrder()}", fOrder);
            }
            else
            {
                orderList.Add(order, 1);

                string fOrder = $"{orderList[order]}x {fillOrder.FormatedOrder()}";

                lstItems.Items.Add(fOrder);
            }
        }

        private void GetItem(string text, string newText)
        {
            int i = 0;

            foreach(object o in lstItems.Items)
            {
                if(o.ToString() == text)
                {
                    i = lstItems.Items.IndexOf(o);
                }
            }

            lstItems.Items.RemoveAt(i);
            lstItems.Items.Insert(i, newText);
        }

        private void BtnFinish_Click(object sender, RoutedEventArgs e)
        {
            string time = $"{DateTime.Now.TimeOfDay.Hours}.{DateTime.Now.TimeOfDay.Minutes}";

            string fileName = $"{fs.GetTicketPath()}{time}.txt";
            string text = "";

            foreach(object o in lstItems.Items)
            {
                text += $"{o.ToString()}\n";
            }

            File.WriteAllText(fileName, text);

            Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            string item = lstItems.SelectedItem.ToString();

            MessageBox.Show(item.ToString());

            //string order = fillOrder.GetOrder();

            //if (orderList.ContainsKey(order))
            //{
            //    orderList[order] += 1;

            //    string fOrder = $"{orderList[order]}x {fillOrder.FormatedOrder()}";
            //    GetItem($"{orderList[order] - 1}x {fillOrder.FormatedOrder()}", fOrder);
            //}
            //else
            //{
            //    orderList.Add(order, 1);

            //    string fOrder = $"{orderList[order]}x {fillOrder.FormatedOrder()}";

            //    lstItems.Items.Add(fOrder);
            //}
        }
    }
}