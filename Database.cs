using MySql.Data.MySqlClient;

namespace StudentManagementWinForms.Data
{
    public static class Database
    {
        public static MySqlConnection CreateConnection()
        {
            string? connectionString =
                Environment.GetEnvironmentVariable(
                    "STUDENT_DB_CONNECTION");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    "Chưa cấu hình biến môi trường STUDENT_DB_CONNECTION.");
            }

            return new MySqlConnection(connectionString);
        }
    }
}