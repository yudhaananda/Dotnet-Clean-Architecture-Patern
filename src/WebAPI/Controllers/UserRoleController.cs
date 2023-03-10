using ApplicationCore.Models;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : BaseController
    {
        private readonly IUserRoleService _service;
        public UserRoleController(IUserRoleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserRoleViewModel>>> GetUserRole([FromQuery] Dictionary<string, string> filter, CancellationToken cancellation)
        {
            var userRole = await _service.GetAsync(filter, cancellation);
            if (userRole.Count == 0)
            {
                return NotFound();
            }
            var result = new List<UserRoleViewModel>();
            foreach (var item in userRole)
            {
                result.Add(Mapper<UserRole, UserRoleViewModel>().Map<UserRoleViewModel>(item));
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUserRole(UserRoleViewModel userRoleViewModel, CancellationToken cancellation)
        {
            var userRole = Mapper<UserRoleViewModel, UserRole>().Map<UserRole>(userRoleViewModel);
            var isCreated = await _service.CreateAsync(userRole, cancellation);
            if (!isCreated)
            {
                return BadRequest("Failed to Create UserRole");
            }
            return Ok(isCreated);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> EditUserRole(int id, UserRoleViewModel userRoleViewModel, CancellationToken cancellation)
        {
            var userRole = Mapper<UserRoleViewModel, UserRole>().Map<UserRole>(userRoleViewModel);
            var isEdited = await _service.EditAsync(userRole, id, cancellation);
            if (!isEdited)
            {
                return BadRequest("Failed to Edit UserRole");
            }
            return Ok(isEdited);
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUserRole(int id, CancellationToken cancellation)
        {
            var isDeleted = await _service.DeleteAsync(id, cancellation);
            if (!isDeleted)
            {
                return BadRequest("Failed to Delete UserRole");
            }
            return Ok(isDeleted);
        }
    }
}
