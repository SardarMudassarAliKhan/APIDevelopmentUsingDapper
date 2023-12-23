using System.Data;

namespace APIDevelopmentUsingDapper.Interfaces
{
    public interface IDapperDbConnection
    {
        public IDbConnection CreateConnection();
    }
}
