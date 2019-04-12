using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiaOito.Models
{
    
    public partial class Medicos
    {

    }

    [MetadataType(typeof(MedicosMetadados))]
    public class MedicosMetadados
    {
        public int Id { get; set; }
        /*
        [Required(ErrorMessage = "Obrigatorio informar o CRM")]
        [StringLength(30, ErrorMessage = "O CRM deve possuir 30 caracteres")]
        public string CRM { get; set; }
        */

        [Required(ErrorMessage = "Obrigatorio informar o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a Cidade")]
        public Cidades Cidade { get; set; }

        public MedicoPorEspecialidade MedicoPorEspecialidade { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Email")]
        public string Email { get; set; }

        public Boolean AtendePorConvenio { get; set; }

        public Boolean TemClinica { get; set; }

        public String WebsiteBlog { get; set; }

    }
}