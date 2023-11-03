using System.ComponentModel.DataAnnotations;

namespace FundamentoWebApi.Api.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigário.")]
    public int QuantidadeEstoque { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigário.")]
    public string Descricao { get; set; }

    public Product(string nome, decimal preco, int quantidadeEstoque, string descricao)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
        Descricao = descricao;
    }
}
