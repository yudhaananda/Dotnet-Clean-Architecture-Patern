using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Services;
using AutoMapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> GetUser([FromQuery]Dictionary<string, string> filter, CancellationToken cancellation)
        {
            var user = await _service.GetAsync(filter, cancellation);
            if (user.Count == 0)
            {
                return NotFound();
            }
            var result = new List<UserViewModel>();
            foreach (var item in user)
            {
                result.Add(Mapper<User, UserViewModel>().Map<UserViewModel>(item));
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateUser(UserViewModel userViewModel, CancellationToken cancellation)
        {
            var user = Mapper<UserViewModel, User>().Map<User>(userViewModel);
            var isCreated = await _service.CreateAsync(user, cancellation);
            if (!isCreated)
            {
                return BadRequest("Failed to Create User");
            }
            return Ok(isCreated);
        }
        [HttpPut]
        public async Task<ActionResult<bool>> EditUser(int id, UserViewModel userViewModel, CancellationToken cancellation)
        {
            var user = Mapper<UserViewModel, User>().Map<User>(userViewModel);
            var isEdited = await _service.EditAsync(user, id, cancellation);
            if (!isEdited)
            {
                return BadRequest("Failed to Edit User");
            }
            return Ok(isEdited);
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUser(int id, CancellationToken cancellation)
        {
            var isDeleted = await _service.DeleteAsync(id, cancellation);
            if (!isDeleted)
            {
                return BadRequest("Failed to Delete User");
            }
            return Ok(isDeleted);
        }
    }
}
