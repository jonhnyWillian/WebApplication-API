using System.Text.Json.Serialization;

namespace WebApplication_API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Situacao
    {
        Inativo,
        Ativo
        
    }
}
