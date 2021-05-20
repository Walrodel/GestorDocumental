using GestorDocumental.Core.CustomEntities;
using GestorDocumental.Core.Entities;
using GestorDocumental.Core.Exceptions;
using GestorDocumental.Core.Interfaces;
using GestorDocumental.Core.QueryFilters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDocumental.Core.Services
{
    public class TerceroService : ITerceroService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TerceroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Tercero model)
        {
            model.FechaCrea = DateTime.Now;
            await _unitOfWork.TerceroRepository.Add(model);
            await _unitOfWork.SaveChangesAsyn();
        }

        public async Task<bool> DeleteById(Guid Id)
        {
            await _unitOfWork.TerceroRepository.Delete(Id);
            return true;
        }

        public async Task<PageList<Tercero>> GetAll(TerceroQueryFilter filters)
        {
            var terceros = await _unitOfWork.TerceroRepository.GetAll();

            if (filters.Identificaion != null)
            {
                terceros = terceros.Where(x => x.Identificaion.ToLower().Contains(filters.Identificaion.ToLower()));
            }

            if (filters.Nombres != null)
            {
                terceros = terceros.Where(x => x.Nombres.ToLower().Contains(filters.Nombres.ToLower()));
            }

            if (filters.Apellidos != null)
            {
                terceros = terceros.Where(x => x.Apellidos != null && x.Apellidos.ToLower().Contains(filters.Apellidos.ToLower()));
            }

            if (filters.Correo != null)
            {
                terceros = terceros.Where(x => x.Correo != null && x.Correo.ToLower().Contains(filters.Correo.ToLower()));
            }

            if (filters.Direccion != null)
            {
                terceros = terceros.Where(x => x.Direccion != null && x.Direccion.ToLower().Contains(filters.Direccion.ToLower()));
            }

            if (filters.Telefono != null)
            {
                terceros = terceros.Where(x => x.Telefono != null && x.Telefono.ToLower().Contains(filters.Telefono.ToLower()));
            }

            var pageTerceros = PageList<Tercero>.Create(terceros, filters.PageNumber, filters.PageSize);

            return pageTerceros;
        }

        public async Task<Tercero> GetById(Guid Id)
        {
            return await _unitOfWork.TerceroRepository.GetById(Id);
        }

        public async Task<bool> Update(Tercero model)
        {
            var tercero = await GetById(model.Id);
            if (tercero == null)
            {
                throw new BusinessExeption("El Tercero no existe.");
            }

            tercero.Identificaion = model.Identificaion;
            tercero.Nombres = model.Nombres;
            tercero.Apellidos = model.Apellidos;
            tercero.Correo = model.Correo;
            tercero.Direccion = model.Direccion;
            tercero.Telefono = model.Telefono;
            tercero.FechaActualiza = DateTime.Now;

            _unitOfWork.TerceroRepository.Update(tercero);
            await _unitOfWork.SaveChangesAsyn();
            return true;
        }
    }
}
