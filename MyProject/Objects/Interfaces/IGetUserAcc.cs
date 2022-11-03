using MyProject.Objects.Models;
using System.Collections.Generic;

namespace MyProject.Objects.Interfaces
{
    public interface IGetUserAcc
    {
        public void CreateOrder(UserAcc user);
        public IEnumerable<UserAcc> GetUsera(UserAcc user);

        public IEnumerable<UserAcc> usera { get; set; }
    }
}
