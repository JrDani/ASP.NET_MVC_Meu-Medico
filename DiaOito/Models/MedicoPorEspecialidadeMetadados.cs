using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiaOito.Models
{
    public partial class MedicoPorEspecialidade
    {

    }

    [MetadataType(typeof(MedicoPorEspecialidadeMetadados))]
    public class MedicoPorEspecialidadeMetadados
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a Especialidade")]
        public Especialidades Especialidade { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Medico")]
        public Medicos Medico { get; set; }

    }
}