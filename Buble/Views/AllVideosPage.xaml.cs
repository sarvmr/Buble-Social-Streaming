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

namespace Buble.Views
{
    /// <summary>
    /// Interaction logic for AllVideosPage.xaml
    /// </summary>
    public partial class AllVideosPage : Page
    {

        public string clickedUid = null;
        HomeViewModel homeView;

        public AllVideosPage()
        {
            InitializeComponent();

            homeView = new HomeViewModel();
            DataContext = new HomeViewModel();
        }

        private void On_Video_Button_Click(object sender, EventArgs e)
        {

            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                homeView.clickedVideoID = clickedButton.Uid;
                this.NavigationService.Navigate(new VideoPlayer(clickedButton.Uid));
            }

        }
    }
}
