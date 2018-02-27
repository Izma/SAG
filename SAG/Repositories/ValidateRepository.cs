using Dapper;
using SAG.Interfaces;
using System.Threading.Tasks;
using System.Data;
using SAG.Models;
using System.Linq;

namespace SAG.Repositories
{
    public class ValidateRepository : BaseRepository, IValidate
    {
        public ValidateRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<ValidateModel> CheckUser(string email, string password)
        {
            return await WithConnection(async c =>
             {
                 var dynamicParameters = new DynamicParameters();
                 dynamicParameters.Add("@email", email, DbType.String, ParameterDirection.Input, 255);
                 dynamicParameters.Add("@password", password, DbType.String, ParameterDirection.Input, 255);
                 var result = await c.QueryAsync<ValidateModel>(
                    sql: "[dbo].[sp_ValidateUser]",
                    param: dynamicParameters,
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
             });
        }
    }
}