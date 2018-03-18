using Dapper;
using SAG.Interfaces;
using SAG.Models;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SAG.Repositories
{
    public class UserRepository : BaseRepository, IUser
    {

        public UserRepository(IConnectionFactory connection) : base(connection)
        {
        }

        public async Task<Result> AddUser(UserModel model)
        {
            return await WithConnection(async c =>
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Email ", model.Email, DbType.String, ParameterDirection.Input, 255);
                parameters.Add("@Password", model.Password, DbType.String, ParameterDirection.Input, 255);
                parameters.Add("@Name", model.Name, DbType.String, ParameterDirection.Input, 50);
                parameters.Add("@MiddleName", model.MiddleName, DbType.String, ParameterDirection.Input, 40);
                parameters.Add("@LastName", model.LastName, DbType.String, ParameterDirection.Input, 40);
                parameters.Add("@NickName", model.NickName, DbType.String, ParameterDirection.Input, 20);
                parameters.Add("@UserRegister", model.Username, DbType.String, ParameterDirection.Input, 255);
                var result = await c.QueryAsync<Result>(
                    sql: "[dbo].[sp_RegisterUser]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            });
        }
    }
}