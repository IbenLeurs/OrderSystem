using OrderSystem.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OrderSystem
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private ButtonMatrix catButtons;
        private ButtonMatrix mainButtons;
        private ButtonMatrix optionButtons;
        private ButtonMatrix sideButtons;
        private Window preWindow;
        private DataHandler dHandler = new DataHandler();
        //private Dictionary<string, int> orderList = new Dictionary<string, int>();
        //private Dictionary<object, int> itemList = new Dictionary<object, int>();
        private FileSetup fs = new FileSetup();
        private bool switchCancel = true;

        private string tStudent;
        private int tTable;

        public MenuWindow(int table, string student, Window window)
        {
            InitializeComponent();

            SetupButtons();
            SetupBase();
            preWindow = window;

            txtData.Text = $"Student: {student}\nTafel: {table}";

            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

            tStudent = student;
            tTable = table;
        }

        private void SetupButtons()
        {
            catButtons = new ButtonMatrix("btnCat", 10, 5, 20, MenuGrid);
            mainButtons = new ButtonMatrix("btnMain", 10, 5, 20, MenuGrid);
            optionButtons = new ButtonMatrix("btnOption", 10, 5, 20, MenuGrid);
            //sideButtons = new ButtonMatrix("btnSide", 10, 5, 20, MenuGrid);


            mainButtons.SetInvisible();
            optionButtons.SetInvisible();
            //sideButtons.SetInvisible();
        }

        private void SetupBase()
        {
            int counter = 0;
            Button[] buttons = catButtons.GetButtons();

            //String[] l = fs.GetCatergories();

            //foreach (string s in l)
            //{
            //    buttons[counter].Content = s;
            //    //buttons[counter].Click += ;

            //    counter++;
            //}

            //for (int i = counter - 1; i <= buttons.Length - 1; i++)
            //{
            //    buttons[i].IsEnabled = false;
            //}
        }

        private void SetupMain()
        {
            int counter = 0;
            Button[] buttons = mainButtons.GetButtons();

            foreach (MainDish d in dHandler.GetMainDishes())
            {
                if (!d.GetMain().Equals(""))
                {
                    buttons[counter].Content = d.GetMain();
                    buttons[counter].Click += FoodSelected;
                }
                else
                {
                    buttons[counter].IsEnabled = false;
                }

                counter++;
            }
        }

        private void SetupOption(MainDish main)
        {
            int counter = 0;
            Button[] buttons = optionButtons.GetButtons();

            if (main.GetOptions() == null || main.GetOptions() == new String[0])
            {
                //fillOrder.SetOption("");
                //SetupSide(main);

                optionButtons.SetInvisible();
                sideButtons.SetVisible();

                return;
            }

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

            //if (counter == 0)
            //{
            //    fillOrder.SetOption("");
            //    optionButtons.SetInvisible();
            //    sideButtons.SetVisible();
            //}
        }

        //    private void SetupSide(FoodItem main)
        //    {
        //        int counter = 0;
        //        Button[] buttons = sideButtons.GetButtons();

        //        foreach (string o in main.GetSides())
        //        {
        //            if (!o.Equals(string.Empty))
        //            {
        //                buttons[counter].Content = o;
        //                buttons[counter].Click += SideSelected;
        //                buttons[counter].IsEnabled = true;
        //            }
        //            counter++;
        //        }

        //        for (int i = counter; i < buttons.Length; i++)
        //        {
        //            buttons[i].IsEnabled = false;
        //            buttons[i].Content = "";
        //        }
        //    }

        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            Close();
            preWindow.Activate();
        }

        private void FoodSelected(object sender, RoutedEventArgs e)
        {
            MainDish curMain;

            if (switchCancel)
            {
                btnCancel.IsEnabled = false;
                btnCancel.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Visible;

                switchCancel = false;
            }

            btnFinish.IsEnabled = false;
            btnDelete.IsEnabled = false;

            //fillOrder = new Order();

            //fillOrder.SetMain(((Button)e.Source).Content.ToString());

            int pos = Convert.ToInt32(((Button)e.Source).Name.Substring(7));

            curMain = dHandler.GetMainDishes()[pos];

            mainButtons.SetInvisible();
            optionButtons.SetVisible();

            SetupOption(curMain);
        }

        private void OptionSelected(object sender, RoutedEventArgs e)
        {
            //fillOrder.SetOption(((Button)e.Source).Content.ToString());

            optionButtons.SetInvisible();
            //sideButtons.SetVisible();

            e.Handled = true;
        }

        //private void SideSelected(object sender, RoutedEventArgs e)
        //{
        //    fillOrder.SetSide(((Button)e.Source).Content.ToString());

        //    sideButtons.SetInvisible();
        //    mainButtons.SetVisible();

        //    btnDelete.IsEnabled = true;
        //    btnFinish.IsEnabled = true;

        //    AddOrder();

        //    e.Handled = true;
        //}

        //    private void AddOrder()
        //    {
        //        string order = fillOrder.GetOrder();

        //        if (orderList.ContainsKey(order))
        //        {
        //            orderList[order] += 1;

        //            string fOrder = $"{orderList[order]}x {fillOrder.FormatedOrder()}";
        //            GetItem($"{orderList[order] - 1}x {fillOrder.FormatedOrder()}", fOrder);
        //        }
        //        else
        //        {
        //            orderList.Add(order, 1);
        //            string fOrder = $"{orderList[order]}x {fillOrder.FormatedOrder()}";
        //            //ListBoxItem fOrder = new ListBoxItem();
        //            //fOrder.Content = $"{orderList[order]}x {fillOrder.FormatedOrder()}";
        //            //fOrder.Selected += OnSelect;

        //            lstItems.Items.Add(fOrder);
        //        }
        //    }

        //    private void GetItem(string text, string newText)
        //    {
        //        int i = 0;

        //        foreach (object o in lstItems.Items)
        //        {
        //            if (o.ToString() == text)
        //            {
        //                i = lstItems.Items.IndexOf(o);
        //            }
        //        }

        //        lstItems.Items.RemoveAt(i);
        //        lstItems.Items.Insert(i, newText);
        //    }

        //    private void UpdateItem(string newText)
        //    {
        //        int i = lstItems.SelectedIndex;

        //        lstItems.Items.RemoveAt(i);
        //        lstItems.Items.Insert(i, newText);
        //    }

        //    private void OnSelect(object sender, RoutedEventArgs e)
        //    {
        //        btnDelete.IsEnabled = true;
        //    }

        //    private void DelItem()
        //    {
        //        int i = lstItems.SelectedIndex;

        //        lstItems.Items.RemoveAt(i);
        //    }

        private void BtnFinish_Click(object sender, RoutedEventArgs e)
        {
            string time = $"{DateTime.Now.TimeOfDay.Hours}u{DateTime.Now.TimeOfDay.Minutes} - T{tTable} {tStudent}";

            string fileName = $"{fs.GetTicketPath()}{time}.txt";
            string text = $"Ontvangen: {DateTime.Now.TimeOfDay.Hours}u{DateTime.Now.TimeOfDay.Minutes}\nTafel: {tTable}\nStudent: {tStudent}\n-------------\n\n";

            foreach (object o in lstItems.Items)
            {
                text += $"{o.ToString()}\n";
            }

            File.WriteAllText(fileName, text);

            preWindow.Show();
            Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            //        try
            //        {

            //            string item = lstItems.SelectedItem.ToString();

            //            Order fillOrder = new Order(item);

            //            string order = fillOrder.GetOrder();

            //            if (orderList.ContainsKey(order))
            //            {
            //                orderList[order] -= 1;

            //                if (orderList[order] <= 0)
            //                {
            //                    orderList.Remove(order);

            //                    DelItem();
            //                }
            //                else
            //                {
            //                    string fOrder = $"{orderList[order]}x {fillOrder.FormatedOrder()}";
            //                    UpdateItem(fOrder);
            //                }
            //            }

            //            e.Handled = true;
            //        }
            //        catch
            //        {

            //        }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.System && e.SystemKey == Key.F4)
            {
                Environment.Exit(0);
            }
        }
    }
}
