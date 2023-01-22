namespace Dotnet_RPG.Dtos.Character
{
    public class AddCharacterDto
    {
        public string Name { get; set; } = "Frodo";
        public int HP { get; set; } = 100;
        public int Strenght { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RPGClass Class { get; set; } = RPGClass.Knight;
    }
}