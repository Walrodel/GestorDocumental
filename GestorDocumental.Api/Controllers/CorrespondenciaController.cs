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
    [SwaggerTag("Servicio para la administración de correspondencias.")]
    [Route("api/[controller]")]
    [ApiController]
    public class CorrespondenciaController : ControllerBase
    {
        private readonly ICorrespondenciaService _service;
        private readonly IMapper _mapper;

        public CorrespondenciaController(ICorrespondenciaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Creación de correspondencia.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Retorna la correspondencia creada.</response>
        /// <response code="400">Errores de validación.</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpPost]
        public async Task<IActionResult> Add(CorrespondenciaRequest request)
        {
            var correspondencia = _mapper.Map<Correspondencia>(request);
            await _service.Add(correspondencia);
            var correspondenciaDto = _mapper.Map<CorrespondenciaDto>(correspondencia);
            var respose = new ApiResponse<CorrespondenciaDto>(correspondenciaDto);
            return Ok(respose);
        }

        /// <summary>
        /// Consultar correspondencia por Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna la correspondencia.</response>
        /// <response code="400">Errores de validación.</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var correspondencia = await _service.GetById(Id);
            var correspondenciaDto = _mapper.Map<CorrespondenciaDto>(correspondencia);
            var respose = new ApiResponse<CorrespondenciaDto>(correspondenciaDto);
            return Ok(respose);
        }

        /// <summary>
        /// Consulta las correspondencias por sus respectivos filtros.
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        /// <response code="200">Retorna las correspondencia con su respectiva paginación.</response>
        /// <response code="400">Errores de validación.</response>
        /// <response code="500">Error interno en el servidor.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CorrespondenciaQueryFilter filters)
        {
            var correspondencias = await _service.GetAll(filters);
            var correspondenciasDto = _mapper.Map<IEnumerable<CorrespondenciaDto>>(correspondencias);
            var respose = new ApiResponse<IEnumerable<CorrespondenciaDto>>(correspondenciasDto);
            var matadata = new
            {
                correspondencias.TotalCount,
                correspondencias.PageSize,
                correspondencias.CurrentPage,
                correspondencias.TotlaPages,
                correspondencias.HasNextPage,
                correspondencias.HasPreviousPage

            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(matadata));
            return Ok(respose);
        }
    }
}
