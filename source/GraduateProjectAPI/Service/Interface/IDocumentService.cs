using GraduateProjectAPI.DTO;

namespace GraduateProjectAPI.Service.Interface
{
    public interface IDocumentService
    {
        /// <summary>
        /// метод выводит исходящие/входящие документы
        /// resultModel == 1  Входищие; resultModel == 2  Исходящие
        /// </summary>
        public Task<List<DocumentDto>> GetWorkDocuments(int userId, int resultModel, string expression/*, int page, int pageSize*/);
        //public Task<List<DocumentDto>> GetIncomingSpentDocuments(int userId);
        public Task<List<DocumentDto>> GetOutgoingDocumentsWork(int pageNumber, int pageSize, int userId);
        public Task<List<InstacesDocumentDto>> GetRouteInstances(int documentId);

    }
}
