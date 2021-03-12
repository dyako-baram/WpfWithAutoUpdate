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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWithAutoUpdate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Data.CreateTable();
            listViewData.ItemsSource = Data.GetAllData();

        }
        private void buttonAddToListView_Click(object sender, RoutedEventArgs e)
        {
            Data.SaveData(textName.Text);
            listViewData.ItemsSource = Data.GetAllData();

        }
    }
}
