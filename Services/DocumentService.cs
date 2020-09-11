using AutoMapper;
using Data;
using DTO;
using Repositories;
using System;
using System.Collections.Generic;
using Utilities;

namespace Services
{
    public class DocumentService
    {
        private UnitOfWork _unitOfWork;
        private GenericRepository<Document> _documentRepository;

        public DocumentService()
        {
            _unitOfWork = new UnitOfWork();
            _documentRepository = _unitOfWork.DocumentRepository;
        }

        public IEnumerable<DocumentDTO> GetListDocumentByCategoryId(int categoryId)
        {
            var docs = _documentRepository.GetMultiByPredicate(x => x.CategoryId == categoryId);
            return Mapper.Map<IEnumerable<DocumentDTO>>(docs);
        }

        public IEnumerable<DocumentDTO> GetListActivedDocumentByCategoryId(int categoryId)
        {
            var docs = _documentRepository.GetMultiByPredicate(x => x.CategoryId == categoryId && x.IsActive);
            return Mapper.Map<IEnumerable<DocumentDTO>>(docs);
        }

        public DocumentDTO GetDocumentById(int id)
        {
            var doc = _documentRepository.GetSingleByPredicate(x => x.Id == id);
            return Mapper.Map<DocumentDTO>(doc);
        }

        public DocumentDTO GetActivedDocumentById(int id)
        {
            var doc = _documentRepository.GetSingleByPredicate(x => x.Id == id && x.IsActive);
            return Mapper.Map<DocumentDTO>(doc);
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
            var document = _documentRepository.Add(Mapper.Map<Document>(documentDTO));
            _unitOfWork.Commit();
            return Mapper.Map<DocumentDTO>(document);
        }

        public void Edit(DocumentDTO documentDTO)
        {
            _documentRepository.Update(Mapper.Map<Document>(documentDTO));
            _unitOfWork.Commit();
        }

        public DocumentDTO Delete(int id)
        {
            var document = _documentRepository.DeleteById(id);
            _unitOfWork.Commit();
            return Mapper.Map<DocumentDTO>(document);
        }
    }
}