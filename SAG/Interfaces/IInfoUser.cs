using SAG.Models;
using System.Threading.Tasks;

namespace SAG.Interfaces
{
    public interface IInfoUser
    {
        Task<InfoUserModel> GetInfoUser(string userId);
    }
}
