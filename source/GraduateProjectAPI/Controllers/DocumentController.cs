using GraduateProjectAPI.DTO;
using GraduateProjectAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace GraduateProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documents)
        {
            _documentService = documents;
        }
        [HttpGet]
        public async Task<IActionResult> GetDocuments(int userId = 23546, int resultModel=1, string expression= "oldnavigatorhidenotinorder")
        {
            var result = await _documentService.GetAllDocumentAsync(userId, resultModel, expression);
            return Ok(result);
        }
    }
}
