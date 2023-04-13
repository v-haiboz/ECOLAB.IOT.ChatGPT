namespace ECOLAB.IOT.ChatGPT.Repository
{
    using System.Data.SqlClient;

    public interface IRepository
    {
        public string ConnectionString { get; }

        public T Execute<T>(Func<SqlConnection, T> func);

        public T Execute<T>(string connectionString, Func<SqlConnection, T> func);

        public T Execute<T>(string connectionString, Func<SqlConnection, SqlTransaction, T> func);
    }

    public class BaseRepository
    {

        private static readonly string connectionstr = "Server=cn-ins-elinkcicd-sqlserver-001-d.database.chinacloudapi.cn,1433;Initial Catalog=CN-INS-ELINKCICD-SQLDB-001-D;Persist Security Info=False;User ID=ELINKCICDSQLAdmin;Password=XD#$s29os21P;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public string ConnectionString { get { return connectionstr; } }

        public T Execute<T>(Func<SqlConnection, T> func)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return func(connection);
            }
        }

        public T Execute<T>(string connectionString, Func<SqlConnection, T> func)
        {
            using (SqlConnection connection = new SqlConnection(connectionString ?? ConnectionString))
            {
                return func(connection);
            }
        }

        public T Execute<T>(Func<SqlConnection, SqlTransaction, T> func)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    return func(connection, transaction);
                }
            }
        }

        public T Execute<T>(string connectionString, Func<SqlConnection, SqlTransaction, T> func)
        {
            using (SqlConnection connection = new SqlConnection(connectionString ?? ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    return func(connection, transaction);
                }
            }
        }
    }
}
