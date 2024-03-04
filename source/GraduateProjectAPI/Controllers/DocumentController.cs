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
        public async Task<IActionResult> GetDocuments(int resultModel,  int userId = 23546, string expression= "oldnavigatorhidenotinorder")
        {
            var result = await _documentService.GetIncomingWorkDocuments(userId, resultModel, expression); ;
            return Ok(result);
        }


        [HttpGet("{nameProcedur}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetOutgoingDocumentsWork(string nameProcedur, int pageNumber, int pageSize, int userId = 23546)
        {
            var result = await _documentService.GetOutgoingDocumentsWork(nameProcedur, pageNumber, pageSize, userId); 
            return Ok(result);
        }


        [HttpGet("{documentId}")]
        public async Task<IActionResult> GetInstances([FromRoute] int documentId)
        {
            var result = await _documentService.GetRouteInstances(documentId);
            return Ok(result);
        }


        [HttpGet("archive/{year}")]
        public async Task<IActionResult> GetArchive(int year)
        {
            var result = await _documentService.GetListArchive(year);
            return Ok(result);
        }

        [HttpGet("archive/{keyNote}/{year}/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetListDocumentKeyNoteArchive(int keyNote, int year, int pageNumber, int pageSize, int userId = 23546)
        {
            var result = await _documentService.GetListDocumentKeyNoteArchive(keyNote, year, pageNumber, pageSize, userId);
            return Ok(result);
        }
    }
}
