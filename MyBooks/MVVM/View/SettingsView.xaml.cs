using MyBooks.MVVM.Model;
using MyBooks.Other;
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

namespace MyBooks.MVVM.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
            
            SettingsConnectionString.Text = ConnectionString.Address;
        }

        private void SaveSettingns_Click(object sender, RoutedEventArgs e)
        {
            if(SettingsConnectionString.Text != String.Empty)
            {
                ConnectionString.Address = SettingsConnectionString.Text;
                MessageBox.Show("Udało się zapisać ustawienia.");
            }
            else
            {
                MessageBox.Show("Nie udało się zapisać ustwień! Nieprawidłowo wypełnione pola");
            }
        }

        private void ButtonTestConnection_Click(object sender, RoutedEventArgs e)
        {
            Context context = new Context();

            if(context.Database.CanConnect())
                MessageBox.Show("Udało się połączyć z bazą danych.");
            else
                MessageBox.Show("Nie udało się połączyć z bazą danych.");
        }
    }
}
