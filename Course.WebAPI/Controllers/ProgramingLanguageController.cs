using Core.Application.Requests;
using Course.Application.Features.ProgramingLanguagess.Command.CreateProgramingLanguage;
using Course.Application.Features.ProgramingLanguagess.Command.DeleteProgramingLanguage;
using Course.Application.Features.ProgramingLanguagess.Command.UpdatedProgramingLanguage;
using Course.Application.Features.ProgramingLanguagess.Dtos;
using Course.Application.Features.ProgramingLanguagess.Models;
using Course.Application.Features.ProgramingLanguagess.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguageController : BaseController
    {
        [HttpPost("Create")]

        public async Task<IActionResult> Add([FromBody] CreateProgramingLanguageCommand createProgramingLanguageCommand)
        {
            CreatedProgramingLanguageDto result = await Mediator.Send(createProgramingLanguageCommand);
            return Created("", result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgramingLanguageCommand updateProgramingLanguageCommand)
        {
            var result = await Mediator.Send(updateProgramingLanguageCommand);
            return Ok(result);
        }

        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete([FromQuery] DeletePrograminLanguageCommand deletePrograminLanguageCommand)
        {
            var result = await Mediator.Send(deletePrograminLanguageCommand);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgramingLanguageQuery getList = new() { PageRequest = pageRequest };

            ListModelProgramingLanguage result = await Mediator.Send(getList);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery getByIdProgramingLanguageQuery)
        {
            GetByIdLanguageProgramingDto getByIdLanguageProgramingDto = await Mediator.Send(getByIdProgramingLanguageQuery);
            return Ok(getByIdLanguageProgramingDto);
        }
    }
}
