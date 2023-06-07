using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
            TextBox textBox = new TextBox() { Name = $"textbox{x}", TextAlignment = TextAlignment.Center };
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
                Data.choosedTable = mi.Header.ToString();
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
                if (button.Uid == "Update")
                {
                    try
                    {
                        PostgresConnection.UpdateRowTable(gridData.SelectedItem);
                        PostgresConnection.SelectAllFromTable(Data.choosedTable);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something goes wrong..\n It may happend after you chande id-field", "Attention");

                    }
                }
                else if (button.Uid == "Add")
                {
                    try
                    {
                        PostgresConnection.AddToTable();
                        PostgresConnection.SelectAllFromTable(Data.choosedTable);
                        MessageBox.Show("The data is added", "Attention");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something goes wrong...", "Woops!");
                        PostgresConnection.SelectAllFromTable(Data.choosedTable);
                    }

                }
                else if (button.Uid == "Delete")
                {
                    try
                    {
                        PostgresConnection.DeleteFromTable(gridData.SelectedItem);
                        PostgresConnection.SelectAllFromTable(Data.choosedTable);
                        gridData.Items.Refresh();
                        MessageBox.Show("The data is deleted", "Attention");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something goes wrong...", "Woops!");
                        PostgresConnection.SelectAllFromTable(Data.choosedTable);
                    }
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
        }
        private void gridData_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
            {
                try
                {
                    PostgresConnection.DeleteFromTable(gridData.SelectedItem);
                    PostgresConnection.SelectAllFromTable(Data.choosedTable);
                    gridData.Items.Refresh();
                    MessageBox.Show("The data is deleted", "Attention");
                }
                catch (Exception) { MessageBox.Show("Something goes wrong...", "Woops!"); }
            }
        }







        // ------------ UNUSED --------------
        private void DeleteSelectedItem()
        {
            var selectedItem = gridData.SelectedItem;
            if (selectedItem is Service)
            {
                Data.services.Remove(selectedItem as Service);
            }
            if (selectedItem is Order)
            {
                Data.orders.Remove(selectedItem as Order);
            }
            gridData.Items.Refresh();
        }

        //private void GlobalSwitch()
        //{
        //    switch (Data.choosedTable)
        //    {
        //        case "Service":
        //            MessageBox.Show("Hehe", "hehe");
        //            break;
        //        case "Order":

        //            break;
        //        case "Car":

        //            break;
        //        case "Employee":

        //            break;
        //        case "Position":

        //            break;
        //        case "Client":

        //            break;
        //        default:
        //            break;
        //    }

        //}
    }
}
