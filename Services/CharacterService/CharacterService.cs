namespace Dotnet_RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newChar)
        {
            var serviceReponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _context.Characters.AddAsync(_mapper.Map<Character>(newChar));
            await _context.SaveChangesAsync();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceReponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            return serviceReponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int ID)
        {
            var serviceReponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = await _context.Characters.FindAsync(ID);

            if (character is not null)
            {
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                var dbCharacters = await _context.Characters.ToListAsync();
                serviceReponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            else
            {
                serviceReponse.Success = false;
                serviceReponse.Message = $"Character with ID '{ID}' not found";
            }

            return serviceReponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceReponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceReponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            return serviceReponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterByID(int ID)
        {
            var serviceReponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Characters.FindAsync(ID);

            if (dbCharacter is not null)
                serviceReponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            else
            {
                serviceReponse.Success = false;
                serviceReponse.Message = $"Character with ID '{ID}' not found";
            }

            return serviceReponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedChar)
        {
            var serviceReponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Characters.FindAsync(updatedChar.ID);

            if (dbCharacter is not null)
            {
                dbCharacter.Name = updatedChar.Name;
                dbCharacter.HP = updatedChar.HP;
                dbCharacter.Strenght = updatedChar.Strenght;
                dbCharacter.Defense = updatedChar.Defense;
                dbCharacter.Intelligence = updatedChar.Intelligence;
                dbCharacter.Class = updatedChar.Class;

                await _context.SaveChangesAsync();
            }
            else
            {
                serviceReponse.Success = false;
                serviceReponse.Message = $"Character with ID '{updatedChar.ID}' not found";
            }

            return serviceReponse;
        }
    }
}