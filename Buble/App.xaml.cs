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
            w.Register.Click += registerButton_Click;

            //mainView.Log_Out.Click += Log_Out;
        }

        public void Log_Out(object sender, EventArgs e)
        {
            w.Show();
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

        public void registerButton_Click(object sender, RoutedEventArgs e)
        {
            var signupView = new SignUpView();

            w.Content = signupView;

            signupView.IsVisibleChanged += (s, ev) =>
            {
                if (signupView.IsVisible == false && signupView.IsLoaded)
                {
                    var mainView = new MainView();
                    w.Content = mainView;
                    signupView = null;
                }
            };
        }
    }
}
