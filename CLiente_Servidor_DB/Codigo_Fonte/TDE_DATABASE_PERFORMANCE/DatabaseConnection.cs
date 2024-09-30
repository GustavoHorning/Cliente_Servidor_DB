using System;
using Microsoft.Data.SqlClient;

public class DatabaseConnection
{
    private string _connectionString;
    public SqlConnection Connection { get; private set; }

    public DatabaseConnection(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Abre a conexão com o banco
    public void OpenConnection()
    {
        Connection = new SqlConnection(_connectionString);
        try
        {
            Connection.Open();
            Console.WriteLine("Conexão bem-sucedida.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
            Connection = null;
        }
    }

    // Fecha a conexão com o banco
    public void CloseConnection()
    {
        if (Connection != null && Connection.State == System.Data.ConnectionState.Open)
        {
            Connection.Close();
            Console.WriteLine("Conexão fechada.");
        }
    }
}