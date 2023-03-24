using Microsoft.AspNetCore.Mvc;
using MotoAdd.Application.Services;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MottoAdver.Api.Controllers
{
    [ApiController]
    [Route("api/moto")]
    public class MotoController : ControllerBase
    {
        private readonly IMotoService motoService;

        public MotoController(IMotoService motoService)
        {
            this.motoService = motoService;
        }

        [HttpPost]
       
        public async ValueTask<ActionResult<MotoDto>> CreateMotoAsync(
            [FromForm] CreationMotoDto creationMotoDto)
        {
            var createdMoto = await this.motoService.CreateMotoAsync(creationMotoDto);

            return Created("", createdMoto);
        }

        [HttpPut]
        public async ValueTask<ActionResult<MotoDto>> UpdateMotoAsync(
            ModifyMotoDto modifyMotoDto)
        {
            var updatedMoto = await this.motoService
                .UpdateMotoAsync(modifyMotoDto);

            return Ok(updatedMoto);
        }

        [HttpGet("id : Guid")]
        public async ValueTask<ActionResult<MotoDto>> RetrieveAdminByIdAsync(
            Guid id)
        {
            var selectedById = await this.motoService.GetMotoByIdAsync(id);

            return Ok(selectedById);
        }

        [HttpGet]

        public IActionResult RetrieveAllAdmins()
        {
            var allAdmins = this.motoService.GetAllMotos();

            return Ok(allAdmins);
        }

        [HttpDelete("id : Guid")]
        public async ValueTask<ActionResult<MotoDto>> DeleteAdminAsync(Guid id)
        {
            var deletedAdmin = await this.motoService.DeleteMotoByIdAsync(id);

            return Ok(deletedAdmin);
        }
    }
}
