using Dapper;
using InStoreOrdering.IRepositorys;
using InStoreOrdering.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace InStoreOrdering.Repositorys
{

    public class MealRepository : IMealRepository
    {
        private readonly IDbConnection _dbConnection;

        public MealRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public IEnumerable<MealModel> GetMeals()
        {
            IEnumerable<MealModel> meals = null;

            using (var conn = _dbConnection)
            {
                try
                {
                    var sql = "SELECT * FROM Meals";
                    meals = conn.Query<MealModel>(sql);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return meals;
        }

        public bool AddMeals(List<MealModel> mealModel)
        {
            try
            {
                string sql = "INSERT INTO Meals (ProductName, Price) VALUES (@ProductName, @Price)";
                int rowsAffected = _dbConnection.Execute(sql, mealModel);

                return rowsAffected > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

