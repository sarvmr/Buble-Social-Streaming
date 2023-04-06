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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Buble.Views.Pages
{
    /// <summary>
    /// Interaction logic for AllUsersView.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for AllUsersView.xaml
    /// </summary>
    public partial class AllUsersView : Page
    {
        CustomerViewModel userViewModel;
        public AllUsersView()
        {
            InitializeComponent();

            DataContext = new CustomerViewModel();
            userViewModel = new CustomerViewModel();
        }

        private void user_button_cliked(object sender, EventArgs e)
        {
            var button = sender as Button;
            userViewModel.update_followings_and_followers(button.Uid);
        }
    }
}
