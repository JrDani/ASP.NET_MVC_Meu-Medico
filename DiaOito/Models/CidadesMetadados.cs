using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiaOito.Models
{
    public partial class Cidades
    {

    }

    [MetadataType(typeof(CidadesMetadados))]
    public class CidadesMetadados
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Estado")]
        public Estado Estado { get; set; }
    }
}