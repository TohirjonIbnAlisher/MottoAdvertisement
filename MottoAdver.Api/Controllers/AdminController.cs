using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoAdd.Application.Services;
using MottoAdver.Application.DataTransferObjects;

namespace MotoAdd.Api.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService adminService;

    public AdminController(IAdminService adminService)
    {
        this.adminService = adminService;
    }

    [Authorize]
    [HttpPost]
    public async ValueTask<ActionResult<AdminDto>> CreateAdminAsync(CreationAdminDto admin)
    {
        var createdAdmin = await this.adminService.CreateAdminAsync(admin);

        return Created("", createdAdmin);
    }

    [Authorize]
    [HttpPut]
    public async ValueTask<ActionResult<AdminDto>> UpdateAdminAsync(ModifyAdminDto admin)
    {
        var updatedAdmin = await this.adminService.ModifyAdminAsync(admin);

        return Ok(updatedAdmin);
    }

    [Authorize]
    [HttpGet("id : Guid")]
    public async ValueTask<ActionResult<AdminDto>> RetrieveAdminByIdAsync(Guid id)
    {
        var selectedById = await this.adminService.RetrieveAdminByIdAsync(id);

        return Ok(selectedById);
    }

    [Authorize]
    [HttpGet]
    public IActionResult RetrieveAllAdmins()
    {
        var allAdmins = this.adminService.RetrieveAdmins();

        return Ok(allAdmins);
    }

    [Authorize]
    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<AdminDto>> DeleteAdminAsync(Guid id)
    {
        var deletedAdmin = await this.adminService.RemoveAdminAsync(id);

        return Ok(deletedAdmin);
    }
}
