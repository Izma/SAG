using Dapper;
using SAG.Interfaces;
using SAG.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SAG.Repositories
{
    public class InfoUserRepository : BaseRepository, IInfoUser
    {

        public InfoUserRepository(IConnectionFactory connection) : base(connection)
        {
        }

        public async Task<InfoUserModel> GetInfoUser(string userId)
        {
            return await WithConnection(async c =>
            {
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@userId", userId, DbType.String, ParameterDirection.Input, 255);
                var result = await c.QueryAsync<InfoUserModel>(
                   sql: "[dbo].[sp_GetInfoUser]",
                   param: dynamicParameters,
                   commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            });
        }
    }
}