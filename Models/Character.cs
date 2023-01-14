namespace Dotnet_RPG.Models
{
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HP { get; set; } = 100;
        public int Strenght { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RPGClass Class { get; set; } = RPGClass.Knight;

    }
}