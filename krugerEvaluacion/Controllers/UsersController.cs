using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using krugerEvaluacion.Responses;
using krugerEvaluacion.Core.CustomEntities;
using krugerEvaluacion.Core.DTOs;
using krugerEvaluacion.Core.Entities;
using krugerEvaluacion.Core.Interfaces;
using krugerEvaluacion.Core.QueryFilters;
using krugerEvaluacion.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace krugerEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public UsersController(IUserService userService, IMapper mapper, IUriService uriService)
        {
            _userService = userService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            await _userService.Add(user);

            userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }
    }
}
