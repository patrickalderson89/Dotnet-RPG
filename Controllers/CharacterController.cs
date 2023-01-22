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
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAll() => Ok(await _characterService.GetAllCharacters());

        [HttpGet("Get/{ID}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetCharacterByID(int ID)
        {
            var response = await _characterService.GetCharacterByID(ID);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newChar) => Ok(await _characterService.AddCharacter(newChar));

        [HttpPut("Update")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updatedChar)
        {
            var response = await _characterService.UpdateCharacter(updatedChar);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("Delete/{ID}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int ID)
        {
            var response = await _characterService.DeleteCharacter(ID);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

    }
}