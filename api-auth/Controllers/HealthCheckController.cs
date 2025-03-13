using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;

namespace api_auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly MongoClient _mongoClient;
        public HealthCheckController(MongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Tenta listar os bancos de dados para verificar a conexão
                await _mongoClient.ListDatabaseNamesAsync();
                return Ok(new { status = "Healthy", message = "MongoDB connection is healthy." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, 
                    new { status = "Unhealthy", 
                          message = $"{ex.Message}" 
                        });
            }
        }
    }
}
