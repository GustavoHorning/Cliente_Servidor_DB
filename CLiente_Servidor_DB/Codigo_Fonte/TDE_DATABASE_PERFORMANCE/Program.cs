namespace TDE_DATABASE_PERFORMANCE;
using Microsoft.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=localhost,1433;Database=TDE_Performance_DB;User Id=sa;Password=Passw@rd;TrustServerCertificate=True;";

        DatabaseConnection db = new DatabaseConnection(connectionString);

        // Testar conexão
        db.OpenConnection();
        
        ClienteCrud clienteCrud = new ClienteCrud(db);
        
        // Listar clientes
        clienteCrud.ListarClientes();

        // Adicionar clientes
        clienteCrud.AdicionarCliente("Maria Silva", "maria.silva@email.com");
        clienteCrud.AdicionarCliente("Gustavo Silveira", "gustavosilveira@gmail.com");
        clienteCrud.AdicionarCliente("Fernando", "fernando@outlook.com");
        clienteCrud.AdicionarCliente("Jefferson", "jeffersonTeste@outlook.com");

        // Atualizar um cliente
        clienteCrud.AtualizarCliente(1, "Maria da Silveira", "mariaSilveira@outlook.com");

        // Remover um cliente
        clienteCrud.RemoverCliente(1);
    }
}

