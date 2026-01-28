using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPfinal_ApplicationConsole.Data;

internal class DataConnection
{
    private static readonly string connectionString = "Server=localhost;Database=BlogConsole;User ID=root;Password=root";

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}
