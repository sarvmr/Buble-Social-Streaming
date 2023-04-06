using Buble.Views.Windows;
using Buble.Views;
using System;
using System.Windows;

namespace Buble
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        StartWindowView w = new StartWindowView();

        protected void ApplicationStart(object sender, EventArgs e)
        {
            w.Show();
            w.startUp.Click += startButton_Click;
        }

        public void startButton_Click(object sender, RoutedEventArgs e)
        {
            var loginView = new LoginView();

            w.Content = loginView;

            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = new MainView();
                    w.Content = mainView;
                    loginView = null;
                }
            };
        }
    }
}
