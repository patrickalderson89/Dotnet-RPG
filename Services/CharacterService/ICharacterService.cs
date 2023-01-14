namespace Dotnet_RPG.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterByID(int ID);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newChar);
    }
}