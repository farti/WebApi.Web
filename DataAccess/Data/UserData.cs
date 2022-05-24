using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUsers() => _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertUser(UserModel model) => _db.SaveData("dbo.spUser_Insert", new { model.FirstName, model.LastName });

    public Task UpdateUser(UserModel model) => _db.SaveData("dbo.spUser_Update", model);

    public Task DeleteUser(int id) => _db.SaveData("dbo.spUser_Delete", new { Id = id });
}

