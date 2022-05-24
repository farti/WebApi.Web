namespace DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedur, U parameters, string connectionId = "Default");
        Task SaveData<T>(string storedProcedur, T parameters, string connectionId = "Default");
    }
}