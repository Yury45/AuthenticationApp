using System.Collections.Generic;

namespace AuthenticationApp.Models.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByLogin(string login);

    }
}
