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
        public async Task<IActionResult> GetDocuments(/*int page, int pageSize, */int resultModel,  int userId = 23546, string expression= "oldnavigatorhidenotinorder")
        {
            var result = await _documentService.GetWorkDocuments(userId, resultModel, expression); ;
            return Ok(result);
        }
        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetOutgoingDocumentsWork(int pageNumber, int pageSize, int userId = 23546)
        {
            var result = await _documentService.GetOutgoingDocumentsWork(pageNumber, pageSize, userId); 
            return Ok(result);
        }

        [HttpGet("{documentId}")]
        public async Task<IActionResult> GetInstances([FromRoute] int documentId)
        {
            var result = await _documentService.GetRouteInstances(documentId);
            return Ok(result);
        }
    }
}
