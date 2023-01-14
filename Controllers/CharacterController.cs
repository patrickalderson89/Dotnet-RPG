using Dotnet_RPG.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_RPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> GetAll() => Ok(await _characterService.GetAllCharacters());

        [HttpGet("Get/{ID}")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> GetCharacterByID(int ID) => Ok(await _characterService.GetCharacterByID(ID));

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character newChar) => Ok(await _characterService.AddCharacter(newChar));
    }
}