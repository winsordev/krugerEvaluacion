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
    public class PropietarioController : ControllerBase
    {
        private readonly IPropietarioService _propietarioService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public PropietarioController(IPropietarioService postService, IMapper mapper, IUriService uriService)
        {
            _propietarioService = postService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all posts
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetPropietario))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PropietarioDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPropietario([FromQuery] PostQueryFilter filters)
        {
            var posts = _propietarioService.GetPropietario(filters);
            var postsDtos = _mapper.Map<IEnumerable<PropietarioDto>>(posts);

            var metadata = new Metadata
            {
                TotalCount = posts.TotalCount,
                PageSize = posts.PageSize,
                CurrentPage = posts.CurrentPage,
                TotalPages = posts.TotalPages,
                HasNextPage = posts.HasNextPage,
                HasPreviousPage = posts.HasPreviousPage,
                NextPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetPropietario))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetPropietario))).ToString()
            };

            var response = new ApiResponse<IEnumerable<PropietarioDto>>(postsDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PropietarioDto postDto)
        {
            var post = _mapper.Map<Propietario>(postDto);

            await _propietarioService.InsertPropietario(post);

            postDto = _mapper.Map<PropietarioDto>(post);
            var response = new ApiResponse<PropietarioDto>(postDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PropietarioDto postDto)
        {
            var post = _mapper.Map<Propietario>(postDto);

            await _propietarioService.UpdatePropietario(post);

            postDto = _mapper.Map<PropietarioDto>(post);
            var response = new ApiResponse<PropietarioDto>(postDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _propietarioService.GetPropietario(id);
            var postDto = _mapper.Map<PropietarioDto>(post);
            var response = new ApiResponse<PropietarioDto>(postDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _propietarioService.GetPropietario(id);
            //var postDto = _mapper.Map<PropietarioDto>(post);
            if (post != null)
            {
                var response = await _propietarioService.DeletePropietario(id); ;
                return Ok(response);
            }
            else {
                return BadRequest("Propietario no existe");
            }
        }
    }
}
