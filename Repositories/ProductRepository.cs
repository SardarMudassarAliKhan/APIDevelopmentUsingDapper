using APIDevelopmentUsingDapper.Interfaces;
using APIDevelopmentUsingDapper.Model;
using Dapper;
using System.Data;

namespace APIDevelopmentUsingDapper.Repositories
{
    public class ProductRepository: IProductRepository
    {
        public IDapperDbConnection _dapperDbConnection;
        public ProductRepository(IDapperDbConnection dapperDbConnection)
        {
            _dapperDbConnection = dapperDbConnection;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            using(IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryAsync<Product>("SELECT * FROM Products");
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            using(IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<int> CreateProductAsync(Product Product)
        {
            using(IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                const string query = "INSERT INTO Products (Name) VALUES (@Name); SELECT SCOPE_IDENTITY();";
                return await db.ExecuteScalarAsync<int>(query, Product);
            }
        }

        public async Task<bool> UpdateProductAsync(Product Product)
        {
            using(IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                const string query = "UPDATE Products SET Name = @Name WHERE Id = @Id";
                int rowsAffected = await db.ExecuteAsync(query, Product);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            using(IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                const string query = "DELETE FROM Products WHERE Id = @Id";
                int rowsAffected = await db.ExecuteAsync(query, new { Id = id });
                return rowsAffected > 0;
            }
        }
    }
}
