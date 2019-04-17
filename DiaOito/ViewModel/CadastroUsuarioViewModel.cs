using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiaOito.ViewModel
{
    public class CadastroUsuarioViewModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "No máximo 100 caracteres")]
        [MinLength(6, ErrorMessage = "Tem que ter no mínimo 6 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(100, ErrorMessage = "No máximo 200 caracteres")]
        [MinLength(6, ErrorMessage = "Tem que ter no mínimo 10 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o login")]
        [MaxLength(30, ErrorMessage = "No máximo 30 caracteres")]
        [MinLength(6, ErrorMessage = "Tem que ter no mínimo 6 caracteres")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessage = "No máximo 100 caracteres")]
        [MinLength(6, ErrorMessage = "Tem que ter no mínimo 6 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [MinLength(6, ErrorMessage = "Tem que ter no mínimo 6 caracteres")]
        [Compare(nameof(Senha), ErrorMessage = "as duas senhas não batem")]
        public string ConfirmacaoSenha { get; set; }
    }
}