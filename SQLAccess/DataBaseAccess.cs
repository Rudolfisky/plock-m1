using VariableClasses;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SQLAccess
{
    public class DataBaseAccess
    {
        public static string GetConnectionString()
        {
            ConnectionString ConnString = new ConnectionString();
            return ConnString.connectionString;
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public static IEnumerable<T> LoadData<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql, parameters);
            }
        }

        public static int DeleteData<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, parameters);
            }
        }

        public static bool ValidateUser(string sql)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionString()))
            {
                return conn.ExecuteScalar<bool>(sql);
            }
        }
    }
}
