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
    [SwaggerTag("Servicio para la administración de bodegas.")]
    [Route("api/[controller]")]
    [ApiController]
    public class TerceroController : ControllerBase
    {
        private readonly ITerceroService _service;
        private readonly IMapper _mapper;

        public TerceroController(ITerceroService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Creación de tercero.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Retorna el tercero creado.</response>
        /// <response code="400">Errores de validación.</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpPost]
        public async Task<IActionResult> Add(TerceroRequest request)
        {
            var tercero = _mapper.Map<Tercero>(request);
            await _service.Add(tercero);
            var terceroDto = _mapper.Map<TerceroDto>(tercero);
            var respose = new ApiResponse<TerceroDto>(terceroDto);
            return Ok(respose);
        }

        /// <summary>
        /// Actualización de tercero por Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns><response code="200">Retorna true o false.</response>
        /// <response code="400">Errores de validación.</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(Guid Id, TerceroRequest request)
        {
            var tercero = _mapper.Map<Tercero>(request);
            tercero.Id = Id;
            var result = await _service.Update(tercero);
            var respose = new ApiResponse<bool>(result);
            return Ok(respose);
        }

        /// <summary>
        /// Consultar tercero por Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna el tercero.</response>
        /// <response code="400">Errores de validación.</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var tercero = await _service.GetById(Id);
            var terceroDto = _mapper.Map<TerceroDto>(tercero);
            var respose = new ApiResponse<TerceroDto>(terceroDto);
            return Ok(respose);
        }

        /// <summary>
        /// Consulta de terceros por sus respectivos filtros.
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        /// <response code="200">Retorna los terceros con su respectiva paginación.</response>
        /// <response code="400">Errores de validación.</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TerceroQueryFilter filters)
        {
            var terceros = await _service.GetAll(filters);
            var tercerosDto = _mapper.Map<IEnumerable<TerceroDto>>(terceros);
            var respose = new ApiResponse<IEnumerable<TerceroDto>>(tercerosDto);
            var matadata = new
            {
                terceros.TotalCount,
                terceros.PageSize,
                terceros.CurrentPage,
                terceros.TotlaPages,
                terceros.HasNextPage,
                terceros.HasPreviousPage

            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(matadata));
            return Ok(respose);
        }
    }
}
