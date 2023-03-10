using ApplicationCore.Models;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService service) 
        { 
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleViewModel>>> GetRole([FromQuery] Dictionary<string, string> filter, CancellationToken cancellation)
        {
            var role = await _service.GetAsync(filter, cancellation);
            if (role.Count == 0)
            {
                return NotFound();
            }
            var result = new List<RoleViewModel>();
            foreach (var item in role)
            {
                result.Add(Mapper<Role, RoleViewModel>().Map<RoleViewModel>(item));
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateRole(RoleViewModel roleViewModel, CancellationToken cancellation)
        {
            var role = Mapper<RoleViewModel, Role>().Map<Role>(roleViewModel);
            var isCreated = await _service.CreateAsync(role, cancellation);
            if (!isCreated)
            {
                return BadRequest("Failed to Create Role");
            }
            return Ok(isCreated);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> EditRole(int id, RoleViewModel roleViewModel, CancellationToken cancellation)
        {
            var role = Mapper<RoleViewModel, Role>().Map<Role>(roleViewModel);
            var isEdited = await _service.EditAsync(role, id, cancellation);
            if (!isEdited)
            {
                return BadRequest("Failed to Edit Role");
            }
            return Ok(isEdited);
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteRole(int id, CancellationToken cancellation)
        {
            var isDeleted = await _service.DeleteAsync(id, cancellation);
            if (!isDeleted)
            {
                return BadRequest("Failed to Delete Role");
            }
            return Ok(isDeleted);
        }
    }
}
