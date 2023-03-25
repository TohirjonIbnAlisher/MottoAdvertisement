using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoAddver.Application.Services;
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


        [Authorize]
        [HttpPost]
        public async ValueTask<ActionResult<MotoDto>> CreateMotoAsync(
            [FromForm] CreationMotoDto creationMotoDto)
        {
            var createdMoto = await this.motoService.CreateMotoAsync(creationMotoDto);

            return Created("", createdMoto);
        }

        [Authorize]
        [HttpPut]
        public async ValueTask<ActionResult<MotoDto>> UpdateMotoAsync(
            ModifyMotoDto modifyMotoDto)
        {
            var updatedMoto = await this.motoService
                .UpdateMotoAsync(modifyMotoDto);

            return Ok(updatedMoto);
        }

        [Authorize]
        [HttpGet("id : Guid")]
        public async ValueTask<ActionResult<MotoDto>> RetrieveAdminByIdAsync(
            Guid id)
        {
            var selectedById = await this.motoService.GetMotoByIdAsync(id);

            return Ok(selectedById);
        }

        [Authorize]
        [HttpGet]
        public IActionResult RetrieveAllAdmins()
        {
            var allAdmins = this.motoService.GetAllMotos();

            return Ok(allAdmins);
        }

        [Authorize]
        [HttpDelete("id : Guid")]
        public async ValueTask<ActionResult<MotoDto>> DeleteAdminAsync(Guid id)
        {
            var deletedAdmin = await this.motoService.DeleteMotoByIdAsync(id);

            return Ok(deletedAdmin);
        }
    }
}
