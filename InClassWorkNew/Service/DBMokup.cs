using InClassWorkNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InClassWorkNew.Service
{
    public class DBMokup
    {
        private List<AppUser> _users = new List<AppUser>();
        public DBMokup()
        {
            _users.Add(new AppUser { UserEmail = "admin@mail.com", UserPassword = "admin" , IsAdmin=true});
            _users.Add(new AppUser { UserEmail = "user1@mail.com", UserPassword = "pass1", IsAdmin = false });
            _users.Add(new AppUser { UserEmail = "user2@mail.com", UserPassword = "pass2", IsAdmin = false , RegDate=DateTime.Now.ToShortDateString()});
        }
        public bool isExist(string uEmail, string uPass)
        {
            return _users.Any(u => u.UserEmail == uEmail && u.UserPassword == uPass);
        }
        public void AddUser(AppUser newUser)
        {
            _users.Add(newUser);
        }
        public AppUser? GetUserByEmail(string uEmail)
        {
            return _users.FirstOrDefault(u => u.UserEmail == uEmail, null);
        }
        public void RemoveUser(AppUser user)
        {
            if (user != null && _users.Contains(user))
            {
                _users.Remove(user);
            }
        }
        public void UpdateUser(AppUser user)
        {
            if (user != null && _users.Contains(user))
            {
                var index = _users.IndexOf(user);
                if (index >= 0)
                {
                    _users[index] = user;
                }
            }
        }
        public List<AppUser> GetUsers() { return _users; }
    }
}
