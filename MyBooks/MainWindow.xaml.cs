using MyBooks.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using MyBooks.Other;
using MyBooks.MVVM.Model;
using MyBooks.Windows;

namespace MyBooks
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();
            NavButtonHome.SetResourceReference(Button.StyleProperty, "CurrentNavigationTabStyle");
            Buttons.Source = StackPanelNavigation;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NavButtonBooks_Click(object sender, RoutedEventArgs e)
        {
            Buttons.ChangeButtonStyles("NavButtonBooks");
        }

        private void NavButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Buttons.ChangeButtonStyles("NavButtonHome");
        }

        private void NavButtonAuthors_Click(object sender, RoutedEventArgs e)
        {
            Buttons.ChangeButtonStyles("NavButtonAuthors");
        }

        private void NavButtonCategories_Click(object sender, RoutedEventArgs e)
        {
            Buttons.ChangeButtonStyles("NavButtonCategories");
        }

        private void NavButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Buttons.ChangeButtonStyles("NavButtonEdit");
        }

        private void NavButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            Buttons.ChangeButtonStyles("NavButtonSettings");
        }

        private void NavButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            Buttons.ChangeButtonStyles("NavButtonHelp");
        }
    }
}
