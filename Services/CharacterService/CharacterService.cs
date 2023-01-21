namespace Dotnet_RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character {ID= 1, Name = "Sam"}
        };
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
            var character = _mapper.Map<Character>(newChar);
            character.ID = characters.Max(c => c.ID) + 1;
            characters.Add(character);
            serviceReponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceReponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int ID)
        {
            var serviceReponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                characters.Remove(characters.First(c => c.ID == ID));
                serviceReponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (InvalidOperationException)
            {
                serviceReponse.Success = false;
                serviceReponse.Message = $"Character with ID '{ID}' not found.";
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
            var character = characters.FirstOrDefault(c => c.ID == ID);
            serviceReponse.Data = _mapper.Map<GetCharacterDto>(character);

            return serviceReponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedChar)
        {
            var serviceReponse = new ServiceResponse<GetCharacterDto>();

            try
            {
                var character = characters.FirstOrDefault(c => c.ID == updatedChar.ID);

                character.Name = updatedChar.Name;
                character.HP = updatedChar.HP;
                character.Strenght = updatedChar.Strenght;
                character.Defense = updatedChar.Defense;
                character.Intelligence = updatedChar.Intelligence;
                character.Class = updatedChar.Class;

                serviceReponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (NullReferenceException)
            {
                serviceReponse.Success = false;
                serviceReponse.Message = $"Character with ID '{updatedChar.ID}' not found.";
            }

            return serviceReponse;
        }
    }
}