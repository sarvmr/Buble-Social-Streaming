using Buble.Models;
using Buble.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Buble.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password;

        private string _signup_username;
        private string _signup_password;
        private string _signup_email;
        private string _signup_name;

        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;

        public string Username
        {
            get => _username; set
            {
                _username = value;
                OnPropertyChnaged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get => _password; set
            {
                _password = value;
                OnPropertyChnaged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage; set
            {
                _errorMessage = value;
                OnPropertyChnaged(nameof(ErrorMessage));
            }

        }

        public bool IsViewVisible
        {
            get => _isViewVisible; set
            {
                _isViewVisible = value;
                OnPropertyChnaged(nameof(IsViewVisible));
            }
        }

        public string SignUp_Username
        {
            get => _signup_username; set
            {
                _signup_username = value;
                OnPropertyChnaged(nameof(SignUp_Username));
            }
        }
        public string SignUp_Password
        {
            get => _signup_password; set
            {
                _signup_password = value;
                OnPropertyChnaged(nameof(SignUp_Password));
            }
        }

        public string SignUp_Email
        {
            get => _signup_email; set
            {
                _signup_email = value;
                OnPropertyChnaged(nameof(SignUp_Email));
            }
        }
        public string SignUp_Name
        {
            get => _signup_name; set
            {
                _signup_name = value;
                OnPropertyChnaged(nameof(SignUp_Name));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            SignUpCommand = new ViewModelCommand(ExecuteSignUpCommand, CanExecuteSignUpCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverCommand("", ""));
        }

        private void ExecuteRecoverCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else validData = true;
            return validData;
        }

        private bool CanExecuteSignUpCommand(object obj)
        {
            bool validData;
            if ((string.IsNullOrWhiteSpace(SignUp_Name) || SignUp_Name.Length < 3) 
                && (string.IsNullOrWhiteSpace(SignUp_Email) || SignUp_Email.Length < 15) 
                && (string.IsNullOrWhiteSpace(SignUp_Password) || SignUp_Password.Length < 3) 
                && (string.IsNullOrWhiteSpace(SignUp_Username) || SignUp_Username.Length < 3))
                validData = false;
            else validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new System.Net.NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }

        private void ExecuteSignUpCommand(object obj)
        {
            var isValidUser = userRepository.AddUser(SignUp_Name, SignUp_Username, SignUp_Email, SignUp_Password);
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(SignUp_Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Username already exists";
            }
        }
    }
}
