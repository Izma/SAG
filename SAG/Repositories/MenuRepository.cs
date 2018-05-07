
using Dapper;
using SAG.Interfaces;
using SAG.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SAG.Repositories
{
    public class MenuRepository : BaseRepository, IMenu
    {
        public MenuRepository(IConnectionFactory connection) : base(connection)
        {
        }

        public async Task<IEnumerable<MenuModel>> GetMenu()
        {
            return await WithConnection(async c =>
            {
                var result = await c.QueryAsync<MenuModel>(
                   sql: "[dbo].[spGetMenu]",
                   commandType: CommandType.StoredProcedure);
                return result.AsEnumerable();
            });
        }

        public Task<MenuModel> GetMenu(int menuId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> SaveMenu(MenuModel model)
        {
            return await WithConnection(async c =>
            {
                var p = new DynamicParameters();
                p.Add("@Description", model.Description, DbType.String, ParameterDirection.Input, 100);
                p.Add("@Route", model.Route, DbType.String, ParameterDirection.Input, 150);
                p.Add("@ParentID", model.ParentID, DbType.Int32, ParameterDirection.Input);
                p.Add("@IsActive", model.IsActive, DbType.Binary, ParameterDirection.Input);
                p.Add("@UserRegister", model.UserRegister, DbType.String, ParameterDirection.Input, 50);
                var result = await c.QueryAsync<Result>(
                sql: "[dbo].[spRegisterMenu]",
                commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            });
        }
    }
}