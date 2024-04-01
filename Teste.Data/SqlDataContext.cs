﻿using Teste.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Teste.Data
{
    public class SqlDataContext : IDisposable
    {
        public SqlConnection Connection { get; }

        private static Dictionary<string, string> connectionStringCache = new Dictionary<string, string>();
        private const string KeyConnectionString = "CONNECTION_STRING";
        public SqlDataContext()
        {
            string connectionString = "";
            if (!connectionStringCache.TryGetValue(KeyConnectionString, out connectionString))
            {
                connectionString = APICoreCommon.GetValueSetting(KeyConnectionString);

                if (!connectionStringCache.ContainsKey(KeyConnectionString))

                    connectionStringCache.Add(KeyConnectionString, connectionString);
            }

            Connection = new SqlConnection(connectionString);

            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();

            GC.SuppressFinalize(this);
        }
    }
}
