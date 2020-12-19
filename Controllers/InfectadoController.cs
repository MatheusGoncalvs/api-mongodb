using api_mongodb.data.collections;
using api_mongodb.models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace api_mongodb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.UserId, dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);

            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();

            return Ok(infectados);
        }

        [HttpPut("{userId}")]
        public ActionResult AtualizarInfectado([FromBody] InfectadoDto dto, int userId)
        {
            var infectado = new Infectado(dto.UserId, dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.ReplaceOne(Builders<Infectado>.Filter.Where(x => x.UserId == userId), infectado);

            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{userId}")]
        public ActionResult DeletarInfectado(int userId)
        {
            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(x => x.UserId == userId));

            return Ok();
        }
    }
}