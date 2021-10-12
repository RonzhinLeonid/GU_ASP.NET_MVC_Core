using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Les1Ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int sleepTime;
        int count;
        object lockObject = new object();
        public MainWindow()
        {
            InitializeComponent();
            sleepTime = Convert.ToInt32(tbTaimer.Text);
            count = Convert.ToInt32(tbLength.Text);
            Thread thread = new Thread(PrintFibonacci);
            thread.Start();
            //thread.Abort();
            //System.PlatformNotSupportedException: "Thread abort is not supported on this platform."

        }

        public void PrintFibonacci()
        {
            int n = 1;
            lock (lockObject)
            {
                while (n <= count)
                {
                    Thread.Sleep(sleepTime);

                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                    {
                        tbText.Text = $"{tbText.Text} {Fibonacci(n)}";
                        sleepTime = Convert.ToInt32(tbTaimer.Text);
                        count = Convert.ToInt32(tbLength.Text);
                    }));
                    n++;
                }
            }
        }

        static int Fibonacci(int n)
        {
            return n > 1 ? Fibonacci(n - 1) + Fibonacci(n - 2) : n;
        }
    }

}

