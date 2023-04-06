using Buble.ViewModels;
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
using System.Windows.Shapes;

namespace Buble.Views
{
    public partial class RecoverPasswordView : Window
    {
        RecoverPasswordViewModel viewModel;

        public RecoverPasswordView()
        {
            InitializeComponent();
            viewModel = new RecoverPasswordViewModel();
        }

        private void send_btn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.changePassword(username.Text);
            var window = this as Window;
            window.Close();
        }
    }
}
