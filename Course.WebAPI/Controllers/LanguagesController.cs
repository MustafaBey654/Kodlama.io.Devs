using Core.Application.Requests;
using Course.Application.Features.Languages.Commands.CreateLanguage;
using Course.Application.Features.Languages.Dtos;
using Course.Application.Features.Languages.Models;
using Course.Application.Features.Languages.Queries.GetByIdLanguage;
using Course.Application.Features.Languages.Queries.GetListLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreatedLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }


        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListBrandQuery = new GetListLanguageQuery { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListBrandQuery);

            return Ok(result);
        }



        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            LanguageGetByIdDto languageGetByIdDto = await Mediator.Send(getByIdLanguageQuery);
            return Ok(languageGetByIdDto);

        }
    }
}
