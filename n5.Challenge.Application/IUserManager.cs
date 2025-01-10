using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n5.Challenge.Application
{
    public interface IUserManager
    {
        List<string> GetUsersInfo(int id);

        Task<string> GetUsernameAsync(int id);


    }
}
