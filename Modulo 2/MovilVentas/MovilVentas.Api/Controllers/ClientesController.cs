using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovilVentas.Api.Dtos;
using MovilVentas.Api.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovilVentas.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ClientesController : Controller
    {
        public IClienteService ClienteService { get; set; }
        public ClientesController(IClienteService clienteService)
        {
            ClienteService = clienteService;
        }
        //GET api/v1/clientes
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                 
                return Ok(new ClienteDto[] {  });

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

           
        }

        //GET api/v1/clientes/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = new ClienteDto { };
                if (response==null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ClienteDto body)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = ClienteService.Create(body);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
             
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
