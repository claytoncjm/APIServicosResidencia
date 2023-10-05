using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APIServicosResidencia.Modelo
{
    public class Localizacao
    {
        public Localizacao()
        {
            NomeClientes = new Collection<NomeCliente>();
        }

        public int LocalizacaoId { get; set; }
        [Required]
        [StringLength(80)]
        public string Cidade { get; set; }
        [Required]
        [StringLength(50)]
        public string Bairro { get; set; }

        [JsonIgnore]
        public int NomeClienteId { get; set; }
        [JsonIgnore]
        public ICollection<NomeCliente>? NomeClientes { get; set; }
    }

    
}

