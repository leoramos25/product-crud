using System.ComponentModel.DataAnnotations;

namespace FundamentoWebApi.Api.Models;

public class LoginUserViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email em formato inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "", MinimumLength = 8)]
    public string Password { get; set; }
}