using GestorDocumental.Core.CustomEntities;
using GestorDocumental.Core.Entities;
using GestorDocumental.Core.Exceptions;
using GestorDocumental.Core.Interfaces;
using GestorDocumental.Core.QueryFilters;
using System;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace GestorDocumental.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Usuario model)
        {
            model.Password = BC.HashPassword(model.Password);
            model.FechaCrea = DateTime.Now;
            await _unitOfWork.UsuarioRepository.Add(model);
            await _unitOfWork.SaveChangesAsyn();
        }

        public async Task<bool> DeleteById(Guid Id)
        {
            await _unitOfWork.UsuarioRepository.Delete(Id);
            return true;
        }

        public async Task<PageList<Usuario>> GetAll(UsuarioQueryFilter filters)
        {
            var usuarios = await _unitOfWork.UsuarioRepository.GetAll();

            if (filters.UserName != null)
            {
                usuarios = usuarios.Where(x => x.UserName.ToLower().Contains(filters.UserName.ToLower()));
            }

            if (filters.Rol != null)
            {
                usuarios = usuarios.Where(x => x.Rol == filters.Rol);
            }

            var pageTerceros = PageList<Usuario>.Create(usuarios, filters.PageNumber, filters.PageSize);

            return pageTerceros;
        }

        public async Task<Usuario> GetById(Guid Id)
        {
            return await _unitOfWork.UsuarioRepository.GetById(Id);
        }

        public async Task<bool> Update(Usuario model)
        {
            var usuario = await GetById(model.Id);
            if (usuario == null)
            {
                throw new BusinessExeption("El Usuario no existe.");
            }

            model.Password = BC.HashPassword(model.Password);

            usuario.UserName = model.UserName;
            usuario.Password = model.Password;
            usuario.Rol = model.Rol;
            usuario.TerceroId = model.TerceroId;
            usuario.FechaActualiza = DateTime.Now;

            _unitOfWork.UsuarioRepository.Update(usuario);
            await _unitOfWork.SaveChangesAsyn();
            return true;
        }
    }
}
