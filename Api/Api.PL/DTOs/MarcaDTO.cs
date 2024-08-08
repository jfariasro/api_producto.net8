using System.Text.Json.Serialization;

namespace Api.PL.DTOs
{
    public class MarcaDTO
    {
        [JsonPropertyName("idmarca")]
        public int Idmarca { get; set; }

        [JsonPropertyName("nombre")]
        public string? Nombre { get; set; }

        [JsonPropertyName("descripcion")]
        public string? Descripcion { get; set; }
    }
}
