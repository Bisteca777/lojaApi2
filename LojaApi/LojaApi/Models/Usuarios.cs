using System.Text.Json.Serialization;

namespace LojaApi.Models
{

    public class Usuario
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Endereco { get; set; }
    }
    }
