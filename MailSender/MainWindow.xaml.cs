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
using WpfTestMailSender.Controls;

namespace WpfTestMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TabItemSwitcher_OnRightButtonClick(object sender, EventArgs e)
        {
            if (!(sender is TabItemSwitcher switcher)) return;
            MainTabControl.SelectedIndex++;

            if (MainTabControl.SelectedIndex == MainTabControl.Items.Count)
            {
                switcher.LeftButtonVisible = false;
            }

        }
        private void TabItemSwitcher_OnLeftButtonClick(object sender, EventArgs e)
        {
            if (!(sender is TabItemSwitcher switcher)) return;

            MainTabControl.SelectedIndex--;

            if (MainTabControl.SelectedIndex == 0)
            {
                switcher.LeftButtonVisible = false;
            }
        }
    }
}
