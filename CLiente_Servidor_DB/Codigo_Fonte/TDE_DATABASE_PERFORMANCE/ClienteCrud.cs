using System;
using Microsoft.Data.SqlClient;

public class ClienteCrud
{
    private DatabaseConnection _dbConnection;

    public ClienteCrud(DatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    // Listar todos os clientes
    public void ListarClientes()
    {
        _dbConnection.OpenConnection();
        
        if (_dbConnection.Connection == null)
            return;

        using (SqlCommand cmd = new SqlCommand("SELECT Id, Nome, Email FROM Clientes", _dbConnection.Connection))
        {
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Clientes:");
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["Id"]}, Nome: {reader["Nome"]}, Email: {reader["Email"]}");
            }
        }

        _dbConnection.CloseConnection();
    }

    // Adicionar um novo cliente
    public void AdicionarCliente(string nome, string email)
    {
        _dbConnection.OpenConnection();
        
        if (_dbConnection.Connection == null)
            return;

        using (SqlCommand cmd = new SqlCommand("INSERT INTO Clientes (Nome, Email) VALUES (@Nome, @Email)", _dbConnection.Connection))
        {
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Cliente adicionado com sucesso.");
        }

        _dbConnection.CloseConnection();
    }

    // Atualizar um cliente existente
    public void AtualizarCliente(int id, string nome, string email)
    {
        _dbConnection.OpenConnection();
        
        if (_dbConnection.Connection == null)
            return;

        using (SqlCommand cmd = new SqlCommand("UPDATE Clientes SET Nome = @Nome, Email = @Email WHERE Id = @Id", _dbConnection.Connection))
        {
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Cliente atualizado com sucesso.");
        }

        _dbConnection.CloseConnection();
    }

    // Remover um cliente pelo ID
    public void RemoverCliente(int id)
    {
        _dbConnection.OpenConnection();
        
        if (_dbConnection.Connection == null)
            return;

        using (SqlCommand cmd = new SqlCommand("DELETE FROM Clientes WHERE Id = @Id", _dbConnection.Connection))
        {
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Cliente removido com sucesso.");
        }

        _dbConnection.CloseConnection();
    }
}
