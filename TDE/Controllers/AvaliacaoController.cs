using Campanha.Service;
using Campanha.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDE.Campanha.Domain.Entidades;

namespace apiCampanhaDDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class AvaliacaoController : ControllerBase
    {
        private BaseService<Avaliacao> service = new BaseService<Avaliacao>();


        [HttpPost]
        public IActionResult Post([FromBody] Avaliacao item)
        {
            try
            {
                service.Post<AvaliacaoValidador>(item);

                return Ok(new ObjectResult(item.CodCampanha));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var resultado = service.Select(id);
                if (resultado == null)
                    return NotFound();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut]
        public IActionResult Put([FromBody]Avaliacao item)
        {
            try
            {
                service.Put<AvaliacaoValidador>(item);

                return Ok("Avaliação alterada com sucesso!");
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var resultado = service.Select(id);
                if (resultado == null)
                    return NotFound();
                service.Remove(id);
                return Ok("Deleteado com sucesso o registro " + id.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
