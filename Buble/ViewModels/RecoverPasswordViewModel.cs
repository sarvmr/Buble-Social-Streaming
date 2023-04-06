using Buble.Models;
using Buble.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buble.ViewModels
{
    public class RecoverPasswordViewModel : ViewModelBase
    {
        UserRepository userRepository;

        public void changePassword(string username)
        {

            userRepository = new UserRepository();
            string new_password = RecoverPasswordModel.GenerateRandomPassword();
            userRepository.ChangeUserPassword(username, new_password); // Make this to take email as well.

            UserModel user = userRepository.GetByUsername(username);
            RecoverPasswordModel.SendNewPasswordToUser(
                user.Email,
                EmailTemplateModel.HTML_code_email_template(new_password));
        }
    }
}
