using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoAdd.Application.Services;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MottoAdver.Api.Controllers
{
    [ApiController]
    [Route("api/addvertisement")]
    public class AddvertisementController : ControllerBase
    {
        private readonly IAddvertisementService addvertisementService;

        public AddvertisementController(
            IAddvertisementService addvertisementService)
        {
            this.addvertisementService = addvertisementService;
        }

        [Authorize]
        [HttpPost]
        public async ValueTask<ActionResult<AddvertisementDto>> CreateMotoAsync(
            CreationAddvertisementDto creationAddvertisementDto)
        {
            var createdAdd = await this.addvertisementService
                .CreateAddvertisementAsync(creationAddvertisementDto);

            return Created("", createdAdd);
        }

        [Authorize]
        [HttpPut]
        public async ValueTask<ActionResult<AddvertisementDto>> UpdateMotoAsync(
            ModifyAddvertisementDto modifyAddvertisementDto)
        {
            var updatedAdd = await this.addvertisementService
                .UpdateAddvertisementAsync(modifyAddvertisementDto);

            return Ok(updatedAdd);
        }

        [Authorize]
        [HttpGet("id : Guid")]
        public async ValueTask<ActionResult<AddvertisementDto>> RetrieveAdminByIdAsync(
            Guid id)
        {
            var selectedById = await this.addvertisementService
                .GetAddvertisementByIdAsync(id);

            return Ok(selectedById);
        }

        [HttpGet]
        public IActionResult RetrieveAllAdmins()
        {
            var allAdmins = this.addvertisementService
                .GetAllAddvertisements();

            return Ok(allAdmins);
        }

        [Authorize]
        [HttpDelete("id : Guid")]
        public async ValueTask<ActionResult<AddvertisementDto>> DeleteAddvertisementAsync(
            Guid id)
        {
            var deletedAdmin = await this.addvertisementService
                .DeleteAddvertisementByIdAsync(id);

            return Ok(deletedAdmin);
        }
    }
}
