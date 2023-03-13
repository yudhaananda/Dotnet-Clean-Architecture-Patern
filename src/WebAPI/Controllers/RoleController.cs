using ApplicationCore.Models;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseController
    {
        private readonly IRoleService _service;
        private readonly IMapper _mapper;
        public RoleController(IRoleService service)
        {
            _service = service;
            _mapper = new MapperConfiguration(c => { c.CreateMap<Role, RoleViewModel>().ForMember(e => e.UserRoles, x => x.MapFrom(a => a.UserRoles)); c.CreateMap<UserRole, UserRoleViewModel>(); }).CreateMapper();
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
                result.Add(_mapper.Map<RoleViewModel>(item));
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateRole(RoleViewModel roleViewModel, CancellationToken cancellation)
        {
            var role = _mapper.Map<Role>(roleViewModel);
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
            var role = _mapper.Map<Role>(roleViewModel);
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
