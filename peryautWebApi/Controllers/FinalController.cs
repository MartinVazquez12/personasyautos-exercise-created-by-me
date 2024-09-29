using Microsoft.AspNetCore.Mvc;
using peryautWebApi.Dtos;
using peryautWebApi.Services.Int;

namespace peryautWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalController : ControllerBase
    {
        private readonly IFinalService _service;

        public FinalController(IFinalService service)
        {
            _service = service;
        }
        [HttpGet("/GetMarcas")]
        public async Task<ActionResult> GetMarcas()
        {
            return Ok(await _service.GetMarcasAsync());
        }

        [HttpGet("/GetPersonas/{id}")]
        public async Task<ActionResult> GetPersonas(Guid id)
        {
            var result = await _service.GetPersonasNotAutoAsync(id);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Data);
            }
            return Ok(result.Data);
        }

        [HttpGet("/GetAutos")]
        public async Task<ActionResult> GetAutos()
        {
            return Ok(await _service.GetAutosAsync());
        }

        [HttpPost("/PostAuto")]
        public async Task<IActionResult> PostJugador([FromBody] PostAutoDto auto)
        {
            try
            {
                var response = await _service.PostAutoAsync(auto);

                if (response.Success)
                {
                    return Ok(response.Data);
                }
                else
                {
                    return BadRequest(response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/PostDCA")]
        public async Task<IActionResult> PostDCA([FromBody] DCADto dca)
        {
            try
            {
                var response = await _service.PostDuenioxAutoAsync(dca);

                if (response.Success)
                {
                    return Ok(response.Data);
                }
                else
                {
                    return BadRequest(response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
