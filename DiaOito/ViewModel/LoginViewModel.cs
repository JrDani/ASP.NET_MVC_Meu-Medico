using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiaOito.ViewModel
{
    public class LoginViewModel
    {
        [HiddenInput]
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "Informe o usuário")]
        [MinLength(6, ErrorMessage = "Tem que ter no mínimo 6 caracteres")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Tem que ter no mínimo 6 caracteres")]
        public string Senha { get; set; }
    }
}