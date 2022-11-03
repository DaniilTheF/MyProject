
using MyProject.Objects.DB;
using MyProject.Objects.Interfaces;
using MyProject.Objects.Models;
using MyProject.ViewModels;
using System.Collections.Generic;
using System.Linq;


namespace MyProject.Objects.Entity
{
   
        public class UserEntity : IGetUser 
        {

            private readonly DataBase DB;

            public IEnumerable<User> users { get; set; }
            public UserEntity(DataBase DB)
            {
              
                this.DB = DB;
            }
            public void AddToDB(User user)
            {
                this.DB.User.Add(user);
          
                UserAcc order = new UserAcc()
                {
                    Users = user,
                    Loggin = user.login,
                    Password = user.password,
                };
                DB.UserAcc.Add(order);
            DB.SaveChanges();
            }

            public IEnumerable<User> GetUser(User user)
            {
                return DB.User.Where(u => u.login == user.login).ToList();
            }

          
        }
    

}
