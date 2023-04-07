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

namespace Buble.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void log_out(object sender, EventArgs e)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = Application.ResourceAssembly.Location,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process.Start(startInfo);

            // Shut down the current instance of the application
            Application.Current.Shutdown();

            Console.ReadLine();
        }

        private void close(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void minimize(object sender, RoutedEventArgs e)
        {
            // Get a reference to the parent window
            var window = Window.GetWindow(this);

            // Minimize the window
            window.WindowState = WindowState.Minimized;
        }
    }
}
