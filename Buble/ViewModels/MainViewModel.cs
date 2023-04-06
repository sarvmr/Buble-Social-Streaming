using Buble.Models;
using Buble.Repositories;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Buble.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;
        private IUserRepository userRepository;


        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChnaged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView; set
            {
                _currentChildView = value;
                OnPropertyChnaged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get => _caption; set
            {
                _caption = value;
                OnPropertyChnaged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get => _icon; set
            {
                _icon = value;
                OnPropertyChnaged(nameof(Icon));
            }
        }

        //--> Command for user interactions
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowSettingsViewCommand { get; }
        public ICommand ShowUserProfileViewCommand { get; }
        public ICommand ShowUploadViewCommand { get; }
        public ICommand ShowScreenRecorderViewCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //Initialize command
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteCustomerViewCommand);
            ShowSettingsViewCommand = new ViewModelCommand(ExecuteShowSettingsViewCommand);
            ShowUserProfileViewCommand = new ViewModelCommand(ExecuteUserProfileViewCommand);
            ShowUploadViewCommand = new ViewModelCommand(ExecuteUploadViewCommand);
            ShowScreenRecorderViewCommand = new ViewModelCommand(ExecuteScreenRecorderViewCommand);
            //Default View
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteScreenRecorderViewCommand(object obj)
        {
            CurrentChildView = new ScreenRecorderViewModel();
            Caption = "Screen Recorder";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Customers";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteUploadViewCommand(object obj)
        {
            CurrentChildView = new UploadViewModel();
            Caption = "Upload Video";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void ExecuteShowSettingsViewCommand(object obj)
        {
            //CurrentChildView = new SettingsViewModel();
            Caption = "Settings";
            Icon = IconChar.Gears;
        }

        private void ExecuteUserProfileViewCommand(object obj)
        {
            CurrentChildView = new UserProfileViewModel();
            Caption = "User Profile";
            Icon = IconChar.Users;
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"{user.Firstname} {user.LastName}";
                CurrentUserAccount.Email = user.Email;
                CurrentUserAccount.ID = user.Id;

                string imagePath = "\\Images\\user-icon.png";
                //CurrentUserAccount.ProfilePicture = (CurrentUserAccount.ProfilePicture == null) ?
                //    File.ReadAllBytes(imagePath) : user.ProfilePicture;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                //Hide child views.
            }
        }
    }
}
