using System.Diagnostics.Contracts;

namespace Entidades.Cadastro;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set;}
    public DateOnly DataNascimento { get; set; }
    public DateTime CadastradoEm { get; set; }
    public decimal Desconto { get; set;}

    public Cliente(int id, string nome, DateOnly dataNascimento, DateTime cadastradoEm, decimal desconto)
    {
        Id = id;
        Nome = nome;
        DataNascimento = dataNascimento;
        CadastradoEm = cadastradoEm;
        Desconto = desconto;
    }
}