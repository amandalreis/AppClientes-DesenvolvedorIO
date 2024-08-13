using Entidades.Cadastro;

namespace Repositories;

public class ClienteRepository 
{
    public string pathArquivoClientes = "clientes.json";
    public List<Cliente> clientes = new List<Cliente>();
    
    //Métodos privados
    private void ArmazenarCliente(Cliente cliente)
    {
        clientes.Add(cliente);
        ArmazenarClientes();
    }

    private void RemoverCliente(Cliente cliente)
    {
        clientes.Remove(cliente);
        ArmazenarClientes();
    }

    private void ArmazenarClientes()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(clientes);
        File.WriteAllText(pathArquivoClientes, json);
    }

    private List<dynamic> ObterERetornarInformacoesCliente()
    {
        Console.Write("Nome do cliente: ");
        var nome = Console.ReadLine();

        DateOnly dataNascimento;
        Console.Write("Data de Nascimento: ");

        while (!DateOnly.TryParse(Console.ReadLine(), out dataNascimento))
        {
            Console.WriteLine("Data fornecida inválida! Tente novamente.");
            Console.Write("Data de Nascimento: ");
        }

        decimal desconto = 0;
        Console.Write("Desconto: ");

        while (!decimal.TryParse(Console.ReadLine(), out desconto))
        {
            Console.WriteLine("Desconto fornecido inválido! Tente novamente.");
            Console.Write("Desconto: ");
        }

        return new List<dynamic>{ nome, dataNascimento, desconto };
    }

    //Métodos públicos
    public void LerClientes()
    {
        if (File.Exists(pathArquivoClientes))
        {
            var dados = File.ReadAllText(pathArquivoClientes);
            clientes = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(dados);
        }
    }

    public void CadastrarCliente()
    {
        Console.Clear();

        Console.WriteLine("---- CADASTRO DE CLIENTE ----");
        Console.Write(Environment.NewLine);
        
        var informacoesCliente = ObterERetornarInformacoesCliente();

        var cliente = new Cliente(id: clientes.Count + 1, nome: informacoesCliente[0], dataNascimento: informacoesCliente[1], desconto: informacoesCliente[2], cadastradoEm: DateTime.Now);

        ArmazenarCliente(cliente);

        Console.Write(Environment.NewLine);
        Console.WriteLine("Cliente cadastrado com sucesso!");
        ImprimirCliente(cliente);
    }

    public void EditarCliente()
    {
        Console.Clear();
        Console.Write("Informe o ID do cliente: ");
        var idCliente = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(c => c.Id == int.Parse(idCliente));

        if (cliente == null)
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Cliente não encontrado!");
            return;
        }

        ImprimirCliente(cliente);

        var informacoesCliente = ObterERetornarInformacoesCliente();

        cliente.Nome = informacoesCliente[0];
        cliente.DataNascimento = informacoesCliente[1];
        cliente.Desconto = informacoesCliente[2];

        ArmazenarClientes();

        Console.Write(Environment.NewLine);
        Console.WriteLine("Cliente editado com sucesso!");
        ImprimirCliente(cliente);
    }

    public void ExcluirCliente()
    {
        Console.Clear();
        Console.Write("Informe o ID do cliente: ");
        var idCliente = Console.ReadLine();

        var cliente = clientes.FirstOrDefault(c => c.Id == int.Parse(idCliente));

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado!");
            return;
        }
        
        ImprimirCliente(cliente);
        Console.Write(Environment.NewLine);
        RemoverCliente(cliente);

        Console.WriteLine("Cliente excluído com sucesso!");
    }

    public void ImprimirCliente(Cliente cliente)
    {
        Console.WriteLine($"ID................: {cliente.Id}");
        Console.WriteLine($"Nome..............: {cliente.Nome}");
        Console.WriteLine($"Desconto..........: {cliente.Desconto.ToString("0.00")}");
        Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento}");
        Console.WriteLine($"Data de Cadastro..: {cliente.CadastradoEm}");
        Console.WriteLine("-----------------------------");
    }

    public void ImprimirClientes()
    {
        Console.Clear();
        
        if (clientes.Count == 0) {
            Console.WriteLine("Não há clientes cadastrados!");
            return;
        }
        foreach(Cliente cliente in clientes)
        {
            ImprimirCliente(cliente);
        }
    }
}