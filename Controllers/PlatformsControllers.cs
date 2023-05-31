using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsControllers: ControllerBase
    {
        private readonly IPlatformRepository _repository;
        private IMapper _mapper;

        public PlatformsControllers(IPlatformRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;                
            }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>>GetPlatforms()
        {
            var result = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(result));
        }


        [HttpGet("{id}", Name= "GetPlatformById")]
        public ActionResult<PlatformReadDto>GetPlatformsById(int id)
        {
            var result = _repository.GetPlatformById(id);
            if (result != null)
                return Ok(_mapper.Map<PlatformReadDto>(result));
            return NotFound();
            
        }


    }
}