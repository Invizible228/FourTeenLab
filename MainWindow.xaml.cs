using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MVVMp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new CarViewModel();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ((CarViewModel)DataContext).AddCar();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ((CarViewModel)DataContext).DeleteCar();
            }
            catch { MessageBox.Show("Вы удалили элемент"); }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ((CarViewModel)DataContext).SaveList();
        }

        private void RadioClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ((CarViewModel)DataContext).RClick(tb.Text, int.Parse(tb2.Text));
            }
            catch { MessageBox.Show("Выберете элемент!"); }
        }

        private void HardChanging(object sender, TextChangedEventArgs e)
        {
            
            ((CarViewModel)DataContext).HChanging(cb.IsChecked, tb.Text, int.Parse(tb2.Text));
        
        }
    }
}
