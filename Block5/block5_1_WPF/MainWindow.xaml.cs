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
using System.Threading;
using System.Windows.Threading;

namespace block5_1_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int countSleep = 9;
        private const int fibonachiCount = 100;
        private const int timerSleeep = 200;

        ListSafe<int> myList = new ListSafe<int>() { 1, 2, 3, 45 };

        private Thread f { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            listBox.ItemsSource = myList.ToList();
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            f = new Thread(FibonachiUpdater);
            f.Start();
        }

        private void Button_Stop_Click(object sender, RoutedEventArgs e)
        {
            f.Abort();
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
            {
                textBox.Text = textBox.Text + "\r\nВычисление прервано! \r\n";
            }));
        }

        private void FibonachiUpdater()
        {
            for (int i = 0; i < fibonachiCount; i++)
            {
                for (int j = countSleep; j >= 0; j--)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                    {
                        label.Content = "00:00:0" + j.ToString();
                    }));

                    Thread.Sleep(timerSleeep);
                }
                int fibonachi = FibonachiCalculator.Fibonachi(i);
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    textBox.Text = textBox.Text + " " + fibonachi.ToString();
                }));
            }
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            myList.AddSafe(7);
            myList.AddSafe(3);
            myList.AddSafe(93);
            myList.AddSafe(45);
            myList.AddSafe(3);
            myList.AddSafe(99);
            listBox.ItemsSource = myList.ToList();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            myList.RemoveSafe(3);
            listBox.ItemsSource = myList.ToList();
        }
    }
}
