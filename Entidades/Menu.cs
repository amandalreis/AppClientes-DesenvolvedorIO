using Entidades.Cadastro;
using Repositories;

namespace Entidades;
public class Menu
{
    private ClienteRepository _clienteRepository;

    public Menu(ClienteRepository repository)
    {
        _clienteRepository = repository;
    }

    public void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("Cadastro de Clientes");
        Console.WriteLine("--------------------");
        Console.WriteLine("1. Cadastrar Cliente;");
        Console.WriteLine("2. Exibir Clientes;");
        Console.WriteLine("3. Editar Cliente;");
        Console.WriteLine("4. Excluir Cliente;");
        Console.WriteLine("5. Sair.");

        Console.Write(Environment.NewLine);
        EscolherOpcao();
    }

    private void EscolherOpcao()
    {
        Console.Write("Selecione uma das opções listadas acima: ");
        var opcaoSelecionada = Console.ReadLine();
        switch(opcaoSelecionada)
        {
            case "1":
                {
                    _clienteRepository.CadastrarCliente();
                    AguardarParaVoltarAoMenu();
                    break;
                }
            case "2":
                {
                    _clienteRepository.ImprimirClientes();
                    AguardarParaVoltarAoMenu();
                    break;
                }
            case "3":
                {
                    _clienteRepository.EditarCliente();
                    AguardarParaVoltarAoMenu();
                    break;
                }
            case "4":
                {
                    _clienteRepository.ExcluirCliente();
                    AguardarParaVoltarAoMenu();
                    break;
                }
            case "5":
                {
                    Console.WriteLine("Até logo! :)");
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.Clear();
                    Console.WriteLine("A opção selecionada não existe!");
                    AguardarParaVoltarAoMenu();
                    break;
                }
        }
    }

    private void AguardarParaVoltarAoMenu()
    {
        Console.Write("Pressione qualquer tecla para voltar ao menu:");
        Console.ReadKey();
        MostrarMenu();
    }

}