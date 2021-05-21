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
    public class CorrespondenciaService : ICorrespondenciaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CorrespondenciaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Correspondencia model)
        {
            var remitente = await _unitOfWork.TerceroRepository.GetById(model.RemitenteId);
            if(remitente is null)
            {
                throw new BusinessExeption("El remitente no existe.");
            }
            var destonatario = await _unitOfWork.TerceroRepository.GetById(model.DestinatarioId);
            if (destonatario is null)
            {
                throw new BusinessExeption("El destinatario no existe.");
            }

            model.FechaCrea = DateTime.Now;
            model.Numero = await _unitOfWork.CorrespondenciaRepository.GetMaxNumero() + 1;
            model.Consecutivo = $"{model.Tipo}{model.Numero.ToString().PadLeft(8, '0')}";
            await _unitOfWork.CorrespondenciaRepository.Add(model);

            await _unitOfWork.SaveChangesAsyn();

        }

        public async Task<PageList<Correspondencia>> GetAll(CorrespondenciaQueryFilter filters)
        {
            var correspondencias = await _unitOfWork.CorrespondenciaRepository.GetAllRelation();
            if (filters.Consecutivo != null)
            {
                correspondencias = correspondencias.Where(x => x.Consecutivo == filters.Consecutivo);
            }

            if (filters.Tipo != null)
            {
                correspondencias = correspondencias.Where(x => x.Tipo == filters.Tipo);
            }

            if (filters.RemitenteId != null)
            {
                correspondencias = correspondencias.Where(x => x.RemitenteId == filters.RemitenteId);
            }

            if (filters.DestinatarioId != null)
            {
                correspondencias = correspondencias.Where(x => x.DestinatarioId == filters.DestinatarioId);
            }

            var pageCorrespondencias = PageList<Correspondencia>.Create(correspondencias, filters.PageNumber, filters.PageSize);

            return pageCorrespondencias;
        }

        public async Task<Correspondencia> GetById(Guid Id)
        {
            return await _unitOfWork.CorrespondenciaRepository.GetByIdAndRelation(Id);
        }
    }
}
