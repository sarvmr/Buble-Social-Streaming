using Buble.ViewModels;
using System;
using System.Windows.Controls;

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
