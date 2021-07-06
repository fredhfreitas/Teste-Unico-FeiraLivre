using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Unico.FeiraLivre.Service.Features.FeiraFeatures.Commands;
using Unico.FeiraLivre.Service.Features.FeiraFeatures.Queries;

namespace Unico.FeiraLivre.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/Feira")]
    [ApiVersion("1.0")]
    public class FeiraController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeiraCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllFeiraQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetFeiraByIdQuery { Id = id }));
        }

        [HttpGet("{distrito}")]
        public async Task<IActionResult> GetByDistrito(string distrito)
        {
            return Ok(await Mediator.Send(new GetFeiraByDistritoQuery { Distrito = distrito }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFeiraByIdCommand { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateFeiraCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
