using Campanha.Service;
using Campanha.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDE.Campanha.Domain.Entidades;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace apiCampanhaDDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class CadastroController : ControllerBase
    {
        private BaseService<Cadastro> service = new BaseService<Cadastro>();


        [HttpPost]
        public IActionResult Post([FromBody] Cadastro item)
        {
            try
            {
                service.Post<CadastroValidador>(item);

                return Ok(new ObjectResult(item.CodCadastro));
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
        public IActionResult Put([FromBody]Cadastro item)
        {
            try
            {
                service.Put<CadastroValidador>(item);

                return Ok("Cadastro alterado com sucesso!");
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
