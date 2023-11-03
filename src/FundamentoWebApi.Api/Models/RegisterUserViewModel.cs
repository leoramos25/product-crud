using System.ComponentModel.DataAnnotations;

namespace FundamentoWebApi.Api.Models;

public class ResgisterUserViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "", MinimumLength = 8)]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "As senhas não conferem.")]
    public string ConfirmPassword { get; set; }
}