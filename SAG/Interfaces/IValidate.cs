using SAG.Models;
using System.Threading.Tasks;

namespace SAG.Interfaces
{
    public interface IValidate
    {
        Task<ValidateModel> CheckUser(string email, string password);
    }
}
