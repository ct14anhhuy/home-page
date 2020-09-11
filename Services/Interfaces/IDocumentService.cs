using DTO;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IDocumentService
    {
        IEnumerable<DocumentDTO> GetListDocumentByCategoryId(int categoryId);

        IEnumerable<DocumentDTO> GetListActivedDocumentByCategoryId(int categoryId);

        DocumentDTO GetDocumentById(int id);

        DocumentDTO GetActivedDocumentById(int id);

        DocumentDTO Add(DocumentDTO documentDTO);

        void Edit(DocumentDTO documentDTO);

        DocumentDTO Delete(int id);
    }
}