using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoDeFeirasAPI.Data;
using GerenciamentoDeFeirasAPI.Models;

namespace GerenciamentoDeFeirasAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeiraController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly ILogger<FeiraController> _logger;


        public FeiraController(ApiContext context, ILogger<FeiraController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public JsonResult CreateEdit(Feira feira)
        {
            _logger.LogInformation("Acessou o método de Criação/Edição de Feira.");
            try
            {
                if (feira.Id == 0)
                {
                    _context.Feiras.Add(feira);
                }
                else
                {
                    var feiraCadastrada = _context.Feiras.Find(feira.Id);

                    if (feiraCadastrada == null)
                    {
                        _logger.LogInformation("Feira Id: " + feira.Id + ", não econtrada no banco de dados.");
                        return new JsonResult(new {message = "Feira não econtrada no banco de dados."});
                    }
                    feiraCadastrada = feira;
                }

                _context.SaveChanges();
                _logger.LogInformation("Feira gravada/editada com sucesso!");
                return new JsonResult(Ok(feira));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Erro");
                return new JsonResult(new { message = "Erro ao gravar/edigar feira - Erro interno da API."});
            }
        }

        [HttpGet]
        public JsonResult GetList(string? distrito, string? regiao5, string? nome, string? bairro)
        {
            _logger.LogInformation("Acessou o método de busca de Feira.");
            try
            {
                var result = _context.Feiras.ToList();

                Feira feira = new Feira();
                if (!string.IsNullOrEmpty(distrito))
                    result = result.Where(f => f.Distrito == distrito).ToList();
                if (!string.IsNullOrEmpty(regiao5))
                    result = result.Where(f => f.Distrito == regiao5).ToList();
                if (!string.IsNullOrEmpty(nome))
                    result = result.Where(f => f.Distrito == nome).ToList();
                if (!string.IsNullOrEmpty(bairro))
                    result = result.Where(f => f.Distrito == bairro).ToList();

                if (result == null)
                {
                    _logger.LogInformation("Feira não econtrada no banco de dados.");
                    return new JsonResult(new { message = "Feira não econtrada no banco de dados." });
                }

                return new JsonResult(Ok(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Erro");
                return new JsonResult(new { message = "Erro ao buscar lista de feiras - Erro interno da API." });
            }
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _logger.LogInformation("Acessou o método de exclusão de Feira.");
            try
            {
                var result = _context.Feiras.Find(id);

                if (result == null)
                {
                    _logger.LogInformation("Feira Id: " + id + ", não econtrada no banco de dados.");
                    return new JsonResult(new { message = "Feira não econtrada no banco de dados." });
                }

                _context.Feiras.Remove(result);
                _context.SaveChanges();

                return new JsonResult(NoContent());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Erro");
                return new JsonResult(new { message = "Erro ao excluir feira - Erro interno da API." });
            }
        }
    }
}
