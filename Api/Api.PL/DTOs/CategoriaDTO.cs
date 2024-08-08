using System.Text.Json.Serialization;

namespace Api.PL.DTOs
{
    public class CategoriaDTO
    {
        [JsonPropertyName("idcategoria")]
        public int Idcategoria { get; set; }

        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }
    }
}
