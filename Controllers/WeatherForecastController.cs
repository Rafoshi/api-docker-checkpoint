using apicsharp.Models;
using apicsharp.Repo;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace apicsharp.Controllers
{
    [ApiController]
    [Route("produto")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepo _repo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost("criar")]
        public ActionResult Criar(Produto produto)
        {
            try
            {
                _repo.Criar(produto);
                
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet("obter")]
        public ActionResult Get(string id)
        {
            
            try
            {
                var produto = _repo.ObterPorId(id);
                if (produto is null)
                    return NoContent();
                else
                    return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut("atualizar")]
        public ActionResult Atualizar(Produto produto)
        {
            try
            {
                _repo.Atualizar(produto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
