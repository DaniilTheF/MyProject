using MyProject.Objects.Models;
using System;
using System.Collections.Generic;


namespace MyProject.Objects.Interfaces
{
 
   
        public interface IGetUser
        {
            public void AddToDB(User user);
           
            public IEnumerable<User> GetUser(User user);

            public IEnumerable<User> users { get; set; }
        }
    }

