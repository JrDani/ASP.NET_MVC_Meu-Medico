using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiaOito.Models
{
    public partial class Estado
    {

    }

    [MetadataType(typeof(Estado))]
    public class EstadoMetadados
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a Sigla")]
        public string Sigla { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Pais")]
        public Pais Pais { get; set; }


    }
}