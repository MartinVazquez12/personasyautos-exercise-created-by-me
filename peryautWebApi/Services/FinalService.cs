using AutoMapper;
using peryautWebApi.Dtos;
using peryautWebApi.Models;
using peryautWebApi.Repositories.Interfaces;
using peryautWebApi.Services.Int;
using peryautWebApi.Validators;
using System.Net;

namespace peryautWebApi.Services
{
    public class FinalService : IFinalService
    {
        private readonly IAutoRepo _autoRepo;
        private readonly IMarcaRepo _marcaRepo;
        private readonly IPersonaRepo _personaRepo;
        private readonly IMapper _mapper;
        private readonly PostAutoDtoValidator _validator;

        public FinalService(IAutoRepo autoRepo,
            IMarcaRepo marcaRepo,
            IPersonaRepo personaRepo,
            IMapper mapper,
            PostAutoDtoValidator validator)
        {
            _autoRepo = autoRepo;
            _marcaRepo = marcaRepo;
            _personaRepo = personaRepo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ApiResponseDto<List<AutoDto>>> GetAutosAsync()
        {
            var response = new ApiResponseDto<List<AutoDto>>();

            var listAutos = await _autoRepo.GetAllAutosActives();
            if (listAutos != null && listAutos.Count > 0)
            {
                var autosDto = _mapper.Map<List<AutoDto>>(listAutos);
                response.Data = autosDto;
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontraron autos", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<List<PersonaDto>>> GetPersonasNotAutoAsync(Guid autoId)
        {
            var response = new ApiResponseDto<List<PersonaDto>>();

            var listP = await _personaRepo.GetPersonaNotInAutoAndAlive(autoId);
            if (listP != null && listP.Count > 0)
            {
                var persDto = _mapper.Map<List<PersonaDto>>(listP);
                response.Data = persDto;
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontraron personas", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<List<MarcaDto>>> GetMarcasAsync()
        {
            var response = new ApiResponseDto<List<MarcaDto>>();

            var listMarcas = await _marcaRepo.GetAllMarcas();
            if (listMarcas != null && listMarcas.Count > 0)
            {
                var marcasDto = _mapper.Map<List<MarcaDto>>(listMarcas);
                response.Data = marcasDto;
                response.Success = true;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontraron marcas", HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<PostAutoDto>> PostAutoAsync(PostAutoDto postAutoDto)
        {
            var response = new ApiResponseDto<PostAutoDto>();

            var validacion = await _validator.ValidateAsync(postAutoDto);
            if (!validacion.IsValid)
            {
                response.SetError("No se pudo validar correctamente", HttpStatusCode.BadRequest);
                return response;
            }
            try
            {
                var existeAuto = await _autoRepo.ExisteAuto(postAutoDto.nombrepost, postAutoDto.colorpost);
                if (existeAuto)
                {
                    response.SetError("Ya existe el auto", HttpStatusCode.BadRequest);
                    return response;
                }

                var auto = _mapper.Map<Auto>(postAutoDto);
                auto.Id = Guid.NewGuid();

                await _autoRepo.AddAuto(auto);

                var autoAdd = _mapper.Map<PostAutoDto>(auto);
                response.Success = true;
                response.Data = autoAdd;
                response.StatusCode = HttpStatusCode.OK;
                return response;

            }
            catch (Exception ex)
            {
                response.SetError("Error al añadir el auto", HttpStatusCode.InternalServerError);
                throw;
            }

        }

        public async Task<ApiResponseDto<DCADto>> PostDuenioxAutoAsync(DCADto dcaDto)
        {
            var response = new ApiResponseDto<DCADto>();

            try
            {
                var duenioXauto = _mapper.Map<DueniosConAuto>(dcaDto);
                duenioXauto.Id = Guid.NewGuid();
                duenioXauto.Fecha = DateOnly.MaxValue;

                await _autoRepo.AddDuenioToAuto(duenioXauto);

                var dcaAdd = _mapper.Map<DCADto>(duenioXauto);
                response.Success = true;
                response.Data = dcaAdd;
                response.StatusCode = HttpStatusCode.OK;
                return response;
            }
            catch(Exception e)
            {
                response.SetError("Error al añadir el DCA", HttpStatusCode.InternalServerError);
                throw;
            }
            
        }
    }
}
