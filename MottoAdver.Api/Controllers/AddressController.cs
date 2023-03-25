using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoAdd.Application.Services;
using MottoAdver.Application.DataTransferObjects;

namespace MottoAdver.Api.Controllers
{
    [ApiController]
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [Authorize]
        [HttpPut]
        public async ValueTask<ActionResult<AddressDto>> UpdateMotoAsync(
            ModifyAddressDto modifyAddressDto)
        {
            var updatedAddress = await this.addressService
                .ModifyAddressAsync(modifyAddressDto);

            return Ok(updatedAddress);
        }

        [Authorize]
        [HttpGet("id : Guid")]
        public async ValueTask<ActionResult<AddressDto>> RetrieveAdminByIdAsync(
            Guid id)
        {
            var selectedById = await this.addressService.RetrieveAddressByIdAsync(id);

            return Ok(selectedById);
        }

        [Authorize]
        [HttpGet]
        public IActionResult RetrieveAllAdmins()
        {
            var allAddresses = this.addressService.RetrieveAddress();

            return Ok(allAddresses);
        }

        [Authorize]
        [HttpDelete("id : Guid")]
        public async ValueTask<ActionResult<AddressDto>> DeleteAdminAsync(
            Guid id)
        {
            var deletedAdress = await this.addressService.RemoveAddressAsync(id);

            return Ok(deletedAdress);
        }
    }
}
