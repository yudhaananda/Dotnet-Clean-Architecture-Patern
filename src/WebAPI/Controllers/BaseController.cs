using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMapper Mapper<T, P>()
        {
            var mapperConfig = new MapperConfiguration(c => c.CreateMap<T, P>());
            return mapperConfig.CreateMapper();
        }
    }
   
}
