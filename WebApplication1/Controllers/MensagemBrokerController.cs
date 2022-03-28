using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("v1/MensagemBroker")]
    public class MensagemBrokerController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<MensagemBroker>>> Get([FromServices] DataContext context)
        {
            var mensagens = await context.MensagemBrokers.ToListAsync();
            return mensagens;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<MensagemBroker>> Post ([FromServices] DataContext context, [FromBody] MensagemBroker model)
        {
            if(ModelState.IsValid)
            {
                context.MensagemBrokers.Add(model);
                await context.SaveChangesAsync();
                return model;
                
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
