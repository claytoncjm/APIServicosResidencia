using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APIServicosResidencia.Modelo
{
    public class NomeCliente
    {
        public NomeCliente()
        {
            Servicos = new Collection<NomeServico>();
        }


        public int NomeClienteId { get; set; }
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }
        [Required]
        [StringLength(80)]
        public string Email { get; set; }
        [Required]
        [StringLength(15)]
        public string  NumeroCelular { get; set; }

        [JsonIgnore]
        public Collection<NomeServico>? Servicos { get; }
    }
}


