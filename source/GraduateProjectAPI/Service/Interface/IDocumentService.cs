using GraduateProjectAPI.DTO;
using GraduateProjectAPI.Entities.Documents;

namespace GraduateProjectAPI.Service.Interface
{
    public interface IDocumentService
    {
        public Task<List<DocumentDto>> GetAllDocumentAsync(int userId, int resultModel, string expression);
    }
}
