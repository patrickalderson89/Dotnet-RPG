namespace Dotnet_RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character {Name = "Sam"}
        };
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newChar)
        {
            var serviceReponse = new ServiceResponse<List<Character>>();
            characters.Add(newChar);
            serviceReponse.Data = characters;
            return serviceReponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceReponse = new ServiceResponse<List<Character>>();
            serviceReponse.Data = characters;
            return serviceReponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterByID(int ID)
        {
            var serviceReponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(c => c.ID == ID);
            serviceReponse.Data = character;

            return serviceReponse;
        }
    }
}