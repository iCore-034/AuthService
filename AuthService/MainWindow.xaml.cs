using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AuthService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private void AutorizationPage()
        {
            this.Hide();
            Window window = new AutorizationWindow();
            window.ShowDialog();
            if (Data.AuthSuccess)
                this.Close();
            else
                this.ShowDialog();
        }
        private void nextPage_Switcher(object sender, RoutedEventArgs e)
        {
            AutorizationPage();
        }
        private void StackPanelTableTranslationData(string x, string header)
        {
            Label label = new Label() { Content = x };
            panelTable.Children.Add(label);
            TextBox textBox = new TextBox() { Name = $"textbox{x}", TextAlignment = TextAlignment.Center};
            if (x != header)
                panelTable.Children.Add(textBox);
        }
        private void menuItem_Clicked(object sender, RoutedEventArgs e)
        {
            panelTable.Children.Clear();
            MenuItem mi = sender as MenuItem;
            if (Data.tables.Contains(mi.Header))
            {
                gridData.ItemsSource = "";
                Data.choosedTable = mi.Header.ToString().ToLower();
                switch (mi.Header.ToString())
                {
                    case "Service":
                        DataTable.serviceList.ForEach(x =>
                        {
                            StackPanelTableTranslationData(x, mi.Header.ToString()); 
                        });
                        PostgresConnection.SelectAllFromTable(Data.choosedTable);
                        gridData.ItemsSource = Data.services;
                        break;
                    case "Client":
                        DataTable.clientList.ForEach(x =>
                        {
                            StackPanelTableTranslationData(x, mi.Header.ToString());
                        });
                        PostgresConnection.SelectAllFromTable(Data.choosedTable);
                        gridData.ItemsSource = Data.clients;
                        break;
                    case "Car":
                        DataTable.carList.ForEach(x =>
                        {
                            StackPanelTableTranslationData(x, mi.Header.ToString());
                        });
                        PostgresConnection.SelectAllFromTable(Data.choosedTable);
                        gridData.ItemsSource = Data.cars;
                        break;
                    case "Position":
                        DataTable.positonList.ForEach(x =>
                        {
                            StackPanelTableTranslationData(x, mi.Header.ToString());
                        });
                        PostgresConnection.SelectAllFromTable(Data.choosedTable);
                        gridData.ItemsSource = Data.positions;
                        break;
                    case "Employee":
                        DataTable.employeeList.ForEach(x =>
                        {
                            StackPanelTableTranslationData(x, mi.Header.ToString());
                        });
                        PostgresConnection.SelectAllFromTable(Data.choosedTable);
                        gridData.ItemsSource = Data.employees;
                        break;
                    case "Order":
                        DataTable.employeeList.ForEach(x =>
                        {
                            StackPanelTableTranslationData(x, mi.Header.ToString());
                        });
                        PostgresConnection.SelectAllFromTable(Data.choosedTable);
                        gridData.ItemsSource = Data.orders;
                        break;
                    default:
                        break;
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            PostgresConnection pg = new PostgresConnection();
            for (int i = 0; i < 6; i++)
            {
                MenuItem menuitem = new MenuItem()
                {
                    Header = Data.tables[i],
                    Background = new SolidColorBrush(Colors.Transparent),
                    Margin = new Thickness(10, 0, 20, 0),
                    Foreground = new SolidColorBrush(Colors.White),

                };

                menuitem.Click += menuItem_Clicked;
                mainMenu.Items.Add(menuitem);
            }
            mainMenu.Background = new SolidColorBrush(Colors.Transparent);


            JsonReadOrCreate jsonReadOrCreate = new JsonReadOrCreate();

            AutorizationPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (Data.adminRights == false) // Here is must be "true"
            {
                if (button.Uid == "Confirm")
                {
                    MessageBox.Show($"Change is clicked", "Hehehe");
                }
                else if (button.Uid == "Add")
                {
                    MessageBox.Show("Add is clicked", "Hehehe");

                }
                else if (button.Uid == "Delete")
                {
                    MessageBox.Show("Delete is clicked", "Hehehe");
                }
                else if (button.Uid == "FormDoc" && Data.choosedTable == "order")
                {
                    MessageBox.Show("Test", "hehe");
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            PostgresConnection.connection.Close();
            Console.WriteLine("Something");
        }
    }
}
