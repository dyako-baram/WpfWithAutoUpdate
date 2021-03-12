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
using Squirrel;

namespace WpfWithAutoUpdate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UpdateManager update;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private async void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Data.CreateTable();
            listViewData.ItemsSource = Data.GetAllData();
            update =await UpdateManager.GitHubUpdateManager(@"https://github.com/dyako-baram/WpfWithAutoUpdate");


        }
        public async void CheckForUpdate()
        {
            var updateInfo = await update.CheckForUpdate();

            if (updateInfo.ReleasesToApply.Count > 0)
            {
                var dialog = MessageBox.Show("do you want update to newer version?", "Update?", MessageBoxButton.YesNo);
                if(dialog == MessageBoxResult.Yes)
                {
                    await update.UpdateApp();
                    MessageBox.Show("Updated succesfuly!\n Please Restart to apply the changes");
                }
            }
            
        }
        private void buttonAddToListView_Click(object sender, RoutedEventArgs e)
        {
            Data.SaveData(textName.Text);
            listViewData.ItemsSource = Data.GetAllData();

        }
    }
}
