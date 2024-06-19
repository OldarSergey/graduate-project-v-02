using GraduateProjectAPI.DTO;

namespace GraduateProjectAPI.Service.Interface
{
    public interface IDocumentService
    {
        /// <summary>
        /// метод выводит исходящие/входящие документы
        /// resultModel == 1  Входищие; resultModel == 2  Исходящие
        /// </summary>
        public Task<List<DocumentDto>> GetIncomingWorkDocuments(int userId, int resultModel, string expression/*, int page, int pageSize*/);
        //public Task<List<DocumentDto>> GetIncomingSpentDocuments(int pageNumber, int pageSize, int userId);
        public Task<List<DocumentDto>> GetOutgoingDocumentsWork(string nameProcedur, int pageNumber, int pageSize, int userId);
        public Task<List<InstacesDocumentDto>> GetRouteInstances(int documentId);
        public Task<List<ArchiveDto>> GetListArchive(int year);
        public Task<List<DocumentDto>> GetListDocumentKeyNoteArchive(int keyNote, int year, int pageNumber, int pageSize, int userId);

    }
}
