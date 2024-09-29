using peryautWebApi.Dtos;

namespace peryautWebApi.Services.Int
{
    public interface IFinalService
    {
        Task<ApiResponseDto<List<MarcaDto>>> GetMarcasAsync();
        Task<ApiResponseDto<List<PersonaDto>>> GetPersonasNotAutoAsync(Guid autoId);
        Task<ApiResponseDto<List<AutoDto>>> GetAutosAsync();
        Task<ApiResponseDto<PostAutoDto>> PostAutoAsync(PostAutoDto postAutoDto);
        Task<ApiResponseDto<DCADto>> PostDuenioxAutoAsync(DCADto dcaDto);
    }
}
