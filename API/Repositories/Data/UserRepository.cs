using API.Context;
using API.Models;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Core.Composing.CompositionExtensions;

namespace API.Repositories.Data
{
    public class UserRepository : GeneralRepository<User, int>
    {
        MyContext myContext;
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;                
        }
        public User Login (string username, string password)
        {
            var user = myContext.User.SingleOrDefault(x => x.Username == username);

            if (user == null)
                return null;
            if (user.Password != password)
                return null;

            return user;

        }
        public int Create (Register register)
        {
            if (myContext.User.Any(x => x.Username == register.Email))
                return -2;

            var result = myContext.SaveChanges();

            return result; 
        }
        public int ChangePassword(User userParam)
        {
            var user = myContext.User.SingleOrDefault(x => x.Username == userParam.Username);
            if (user == null)
                return -1;
            if (!string.IsNullOrWhiteSpace(userParam.Password) && userParam.Password != user.Password)
            {
                user.Password = userParam.Password;
            }
            var result = myContext.SaveChanges();
            return result;
        }
        public int Update (User userparam)
        {
            var user = myContext.User.Find(userparam.Id);

            if (user == null)
                return -1;

            if(!string.IsNullOrWhiteSpace(userparam.Username) && userparam.Username != user.Username)
            {
                if (myContext.User.Any(x => x.Username == userparam.Username))
                    return -2;

                user.Username = userparam.Username;
            }
            if (!string.IsNullOrWhiteSpace(userparam.Password) && userparam.Password != user.Password)
            {
                user.Password = userparam.Password;
            }
            var result = myContext.SaveChanges();
            return result;
        }
        public int ForgotPassword(User userparam)
        {
            var user = myContext.User.SingleOrDefault(x => x.Username == userparam.Username);
            if (user == null)
            {
                return -1;
            }
            if(!string.IsNullOrWhiteSpace(userparam.Password))
            {
                user.Password = userparam.Password;
            }
            var result = myContext.SaveChanges();
            return result;
        }
        public UserRole GetRoleById(int UserId)
        {
            var user = myContext.UserRole.FirstOrDefault(x => x.UserId == UserId);

            return user;

        }
    }
}
