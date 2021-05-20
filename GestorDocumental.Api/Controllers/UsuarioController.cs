using AutoMapper;
using GestorDocumental.Api.Responses;
using GestorDocumental.Core.DTOs;
using GestorDocumental.Core.Entities;
using GestorDocumental.Core.Interfaces;
using GestorDocumental.Core.QueryFilters;
using GestorDocumental.Core.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestorDocumental.Api.Controllers
{
    [SwaggerTag("Servicio para la administración de usuarios.")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Creación de tercero.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Retorna el usaurio creado.</response>
        /// <response code="400">Errores de validación.</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpPost]
        public async Task<IActionResult> Add(UsuarioRequest request)
        {
            var usuario = _mapper.Map<Usuario>(request);
            await _service.Add(usuario);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            var respose = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(respose);
        }

        /// <summary>
        /// Actualización de usuario por Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns><response code="200">Retorna true o false.</response>
        /// <response code="400">Errores de validación.</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(Guid Id, UsuarioRequest request)
        {
            var usuario = _mapper.Map<Usuario>(request);
            usuario.Id = Id;
            var result = await _service.Update(usuario);
            var respose = new ApiResponse<bool>(result);
            return Ok(respose);
        }

        /// <summary>
        /// Consultar usuario por Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna el usuario.</response>
        /// <response code="400">Errores de validación.</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var usuario = await _service.GetById(Id);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            var respose = new ApiResponse<UsuarioDto>(usuarioDto);
            return Ok(respose);
        }

        /// <summary>
        /// Consulta de usuarios por sus respectivos filtros.
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        /// <response code="200">Retorna los usuarios con su respectiva paginación.</response>
        /// <response code="400">Errores de validación.</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UsuarioQueryFilter filters)
        {
            var usuarios = await _service.GetAll(filters);
            var usuariosDto = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
            var respose = new ApiResponse<IEnumerable<UsuarioDto>>(usuariosDto);
            var matadata = new
            {
                usuarios.TotalCount,
                usuarios.PageSize,
                usuarios.CurrentPage,
                usuarios.TotlaPages,
                usuarios.HasNextPage,
                usuarios.HasPreviousPage

            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(matadata));
            return Ok(respose);
        }
    }
}
