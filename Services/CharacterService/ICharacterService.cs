namespace Dotnet_RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAllCharacters();
        Task<ServiceResponse<Character>> GetCharacterByID(int ID);
        Task<ServiceResponse<List<Character>>> AddCharacter(Character newChar);
    }
}