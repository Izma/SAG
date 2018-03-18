using SAG.Interfaces;
using SAG.Models;
using System;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Linq;

namespace SAG.Repositories
{
    public class PersonRepository : BaseRepository, IPerson
    {
        public PersonRepository(IConnectionFactory connection) : base(connection)
        {
        }

        public async Task<Result> AddPerson(PersonModel model)
        {
            return await WithConnection(async q =>
            {
                var parameters = new DynamicParameters();
                parameters.Add("@name ", model.Name, DbType.String, ParameterDirection.Input, 100);
                parameters.Add("@middleName", model.MiddleName, DbType.String, ParameterDirection.Input, 30);
                parameters.Add("@lastName", model.LastName, DbType.String, ParameterDirection.Input, 30);
                parameters.Add("@birthDate", model.BirthDate, DbType.Date, ParameterDirection.Input);
                parameters.Add("@genere", model.Genere, DbType.String, ParameterDirection.Input, 10);
                parameters.Add("@bloodType", model.BloodType, DbType.String, ParameterDirection.Input, 10);
                parameters.Add("@weight", model.BloodType, DbType.String, ParameterDirection.Input, 10);
                parameters.Add("@height", model.Height, DbType.String, ParameterDirection.Input, 10);
                parameters.Add("@description", model.Height, DbType.String, ParameterDirection.Input);
                parameters.Add("@status", model.Height, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("@UserRegister", model.UserRegister, DbType.String, ParameterDirection.Input, 50);
                var result = await q.QueryAsync<Result>(
                    sql: "[dbo].[sp_RegisterPerson]",
                    param: parameters,
                    commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            });
        }
    }
}