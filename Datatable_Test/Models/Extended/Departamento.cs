using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Datatable_Test.Models
{
    [MetadataType(typeof(DepartamentoMetaData))]
    public partial class Departamento
    {

    }
    public class DepartamentoMetaData
    {
        [Required (AllowEmptyStrings = false, ErrorMessage = "Por favor ingresa un nombre")]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor ingresa una fecha")]
        public DateTime Fecha_Creacion { get; set; }
    }
}