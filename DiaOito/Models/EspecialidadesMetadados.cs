using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiaOito.Models
{
    public partial class Especialidades
    {

    }

    [MetadataType(typeof(EspecialidadesMetadados))]
    public class EspecialidadesMetadados
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a Especialidade")]
        public string Especialidade { get; set; }

    }
}