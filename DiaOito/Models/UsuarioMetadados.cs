using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiaOito.Models
{
    public partial class Usuario
    {

    }

    [MetadataType(typeof(UsuarioMetadados))]
    public class UsuarioMetadados
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Username")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Email")]
        public string Email { get; set; }
    }
}