using System;
using System.Data;
using System.Data.OleDb;

namespace StudentManagement
{
    public class DataAccess : IDisposable
    {
        private OleDbConnection? _conn;

        public DataAccess()
        {
            _conn = new OleDbConnection(Config.ConnStr);
            _conn.Open();
        }

        public DataTable GetTable(string sql, params OleDbParameter[] p)
        {
            using var cmd = new OleDbCommand(sql, _conn);
            if (p != null && p.Length > 0) cmd.Parameters.AddRange(p);
            using var da = new OleDbDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public int Execute(string sql, params OleDbParameter[] p)
        {
            using var cmd = new OleDbCommand(sql, _conn);
            if (p != null && p.Length > 0) cmd.Parameters.AddRange(p);
            return cmd.ExecuteNonQuery();
        }

        public object? ExecuteScalar(string sql, params OleDbParameter[] p)
        {
            using var cmd = new OleDbCommand(sql, _conn);
            if (p != null && p.Length > 0) cmd.Parameters.AddRange(p);
            return cmd.ExecuteScalar();
        }

        public void Dispose()
        {
            _conn?.Close();
            _conn?.Dispose();
        }
    }
}
