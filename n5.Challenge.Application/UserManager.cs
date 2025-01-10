
namespace n5.Challenge.Application
{
    public class UserManager : IUserManager
    {
        public async Task<string> GetUsernameAsync(int id)
        {
            await Task.CompletedTask;
            return "Ok";
        }

        public List<string> GetUsersInfo(int id)
        {
            return ["Usuario 1", "Usuario 2", "Usuario 3"];
        }

    }
}
