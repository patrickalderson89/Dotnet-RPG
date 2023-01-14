using System.Text.Json.Serialization;

namespace Dotnet_RPG.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RPGClass
    {
        Knight = 1,
        Wizard = 2,
        Cleric = 3
    }
}