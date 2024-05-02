using System.Text.Json.Serialization;

namespace WebApplication_API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Telefone
    {
        Celular = 1,
        Residencial,
        Comercial
    }
}
