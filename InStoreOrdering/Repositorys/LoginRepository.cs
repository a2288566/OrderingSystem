using Dapper;
using InStoreOrdering.IRepositorys;
using InStoreOrdering.Models;
using System.Data;
using System.Data.SqlClient;

namespace InStoreOrdering.Repositorys
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnection _dbConnection;

        public LoginRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public bool InsertUserInfo(UserModel user)
        {
            using (var transaction = _dbConnection.BeginTransaction())
            {
                try
                {
                    string sql = "INSERT INTO UserInfo (UserName, Account, Password, Email, Phone, Birthday) VALUES (@UserName, @Account, @Password, @Email, @Phone, @Birthday)";
                    var affectedRows = _dbConnection.Execute(sql, user, transaction);

                    transaction.Commit();
                    return affectedRows > 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("加入使用者資訊錯誤", ex);
                }
            }
        }

        public bool CheckAccount(UserModel user)
        {
            using (var transaction = _dbConnection.BeginTransaction())
            {

            }
            return true;
        }
    }
}
