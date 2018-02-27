using SAG.Models;
using System.Threading.Tasks;

namespace SAG.Interfaces
{
    public interface IUser
    {
        Task<Result> AddUser(UserModel model);
    }
}
