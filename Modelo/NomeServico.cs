using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace APIServicosResidencia.Modelo
{
    public class NomeServico
    {
       
        public int NomeServicoId { get; set; }
        [Required]
        [StringLength(80)]
        public string NomeServicoRes { get; set; }

        [JsonIgnore]
        public int NomeClienteId { get; set; }
        [JsonIgnore]
        public NomeCliente? NomeClientes { get; set; }

    }
}
