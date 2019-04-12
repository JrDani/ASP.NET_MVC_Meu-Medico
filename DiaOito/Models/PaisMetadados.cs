using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiaOito.Models
{
    public partial class Pais
    {

    }

    [MetadataType(typeof(Pais))]
    public class PaisMetadados
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Pais")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a Sigla")]
        public string Sigla { get; set; }
    }
}