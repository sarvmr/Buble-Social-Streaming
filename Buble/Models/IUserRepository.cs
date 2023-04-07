using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Buble.Models
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        void UpdatetById(string id, string name, string username, string email);
        UserModel GetByUsername(string username);
        List<UserModel> GetByAll();
        void ChangeUserPassword(string username, string Password);
        void addFollowing(string username, string Uid);
        void addFollower(string username, string Uid);
        bool AddUser(string firstname, string username, string email, string password);
    }
}
