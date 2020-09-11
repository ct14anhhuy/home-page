using AutoMapper;
using Data;
using DTO;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Utilities;

namespace Services
{
    public class DocumentService : IDocumentService
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Document> _documentRepository;
        private IMapper _mapper;

        public DocumentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _documentRepository = _unitOfWork.DocumentRepository;
            _mapper = mapper;
        }

        public IEnumerable<DocumentDTO> GetListDocumentByCategoryId(int categoryId)
        {
            var docs = _documentRepository.GetMultiByPredicate(x => x.CategoryId == categoryId);
            return _mapper.Map<IEnumerable<DocumentDTO>>(docs);
        }

        public IEnumerable<DocumentDTO> GetListActivedDocumentByCategoryId(int categoryId)
        {
            var docs = _documentRepository.GetMultiByPredicate(x => x.CategoryId == categoryId && x.IsActive);
            return _mapper.Map<IEnumerable<DocumentDTO>>(docs);
        }

        public DocumentDTO GetDocumentById(int id)
        {
            var doc = _documentRepository.GetSingleByPredicate(x => x.Id == id);
            return _mapper.Map<DocumentDTO>(doc);
        }

        public DocumentDTO GetActivedDocumentById(int id)
        {
            var doc = _documentRepository.GetSingleByPredicate(x => x.Id == id && x.IsActive);
            return _mapper.Map<DocumentDTO>(doc);
        }

        public DocumentDTO Add(DocumentDTO documentDTO)
        {
            try
            {
                documentDTO.FileName = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}-{documentDTO.PdfFile.FileName}";
                documentDTO.FileName = documentDTO.FileName.ConvertToUnsignAndRemoveEmpty();
                documentDTO.PdfFile.SaveAs(ConfigHelper.ReadSetting("PdfFullPath") + documentDTO.FileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            documentDTO.Description = documentDTO.Description.Trim();
            var document = _documentRepository.Add(_mapper.Map<Document>(documentDTO));
            _unitOfWork.Commit();
            return _mapper.Map<DocumentDTO>(document);
        }

        public void Edit(DocumentDTO documentDTO)
        {
            _documentRepository.Update(_mapper.Map<Document>(documentDTO));
            _unitOfWork.Commit();
        }

        public DocumentDTO Delete(int id)
        {
            var document = _documentRepository.DeleteById(id);
            _unitOfWork.Commit();
            return _mapper.Map<DocumentDTO>(document);
        }
    }
}